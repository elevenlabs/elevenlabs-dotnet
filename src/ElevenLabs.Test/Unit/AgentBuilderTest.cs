using System.Text.Json.Nodes;
using ElevenLabs.AgentBuilder;
using ElevenLabs.AgentWorkflows;
using NUnit.Framework;

namespace ElevenLabs.Tests;

// Inside the namespace, so these win over the generated ElevenLabs.Tool model.
using ElevenLabs.AgentTools;
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>
/// The agent builder and the workflow builder's <c>Tool</c> references. Ported from elevenlabs-js
/// <c>tests/custom/agents/agent/agent.test.ts</c>.
/// </summary>
[TestFixture]
public class AgentBuilderTest
{
    internal static WebhookTool GetOrder(string description = "Look up an order by its number") =>
        Tool.Webhook("get_order", description)
            .Get("https://api.example.com/orders/{order_id}")
            .PathParam("order_id", Schema.String().Describe("The order number"));

    internal static ClientTool ShowOrder() =>
        Tool.Client("show_order", "Show the order card").Param("order_id", Schema.String().FromVariable("order_id"));

    internal static string Canon(JsonNode? node) => Wire.Canonicalize(node)?.ToJsonString() ?? "null";

    internal static Dictionary<string, string> Ids(params string[] pairs)
    {
        var ids = new Dictionary<string, string>();
        for (var i = 0; i < pairs.Length; i += 2)
        {
            ids[pairs[i]] = pairs[i + 1];
        }
        return ids;
    }

    private static List<(string Code, string? Path)> IssuesOf(Action action)
    {
        try
        {
            action();
        }
        catch (AgentValidationException ex)
        {
            return ex.Issues.Select(issue => (issue.Code, issue.Path)).ToList();
        }
        throw new AssertionException("expected an AgentValidationException");
    }

    private static JsonObject Nodes(JsonObject config) => (JsonObject)config["workflow"]!["nodes"]!;

    [Test]
    public void MapsTypedOptionsToolsAndSystemToolsIntoTheApiConfig()
    {
        var agent = new Agent(
            "Support line",
            new AgentOptions
            {
                Prompt = "You are a support agent.",
                FirstMessage = "Hi!",
                Language = "en",
                Llm = Llm.Gemini20Flash,
                Temperature = 0.5,
                VoiceId = "voice_1",
                TtsModel = TtsConversationalModel.FromCustom("eleven_flash_v2_5"),
                Tags = new[] { "support" },
                Tools = new Tool[] { SystemTool.EndCall(), GetOrder() },
                ToolIds = new[] { "tool_existing" },
            }
        );
        var config = agent.ToJson(Ids("get_order", "tool_1"));
        var expected = JsonNode.Parse(
            """
            {
              "conversation_config": {
                "agent": {
                  "first_message": "Hi!",
                  "language": "en",
                  "prompt": {
                    "built_in_tools": {
                      "end_call": { "name": "end_call", "params": { "system_tool_type": "end_call" }, "type": "system" }
                    },
                    "llm": "gemini-2.0-flash",
                    "prompt": "You are a support agent.",
                    "temperature": 0.5,
                    "tool_ids": ["tool_existing", "tool_1"]
                  }
                },
                "tts": { "model_id": "eleven_flash_v2_5", "voice_id": "voice_1" }
              },
              "name": "Support line",
              "platform_settings": {},
              "tags": ["support"]
            }
            """
        );
        Assert.That(Canon(config), Is.EqualTo(Canon(expected)));
        Assert.That(config.ToJsonString(), Is.EqualTo(Canon(config)), "keys are sorted at every level");

        var body = agent.Build(Ids("get_order", "tool_1"));
        Assert.That(body.Name, Is.EqualTo("Support line"));
        Assert.That(body.ConversationConfig.Agent!.Prompt!.ToolIds, Is.EqualTo(new[] { "tool_existing", "tool_1" }));
        Assert.That(body.ConversationConfig.Agent.Prompt.BuiltInTools!.EndCall!.Name, Is.EqualTo("end_call"));
    }

    [Test]
    public void MergesTheRawConfigUnderTheTypedOptions()
    {
        var agent = new Agent(
            "A",
            new AgentOptions
            {
                Prompt = "p",
                ConversationConfig = new ConversationalConfig
                {
                    Turn = new TurnConfig { TurnTimeout = 7 },
                    Agent = new AgentConfig { DisableFirstMessageInterruptions = true },
                },
                PlatformSettings = new AgentPlatformSettingsRequestModel
                {
                    Privacy = new PrivacyConfigInput { RecordVoice = false },
                },
            }
        );
        agent.Update(
            new AgentOptions { ConversationConfig = new ConversationalConfig { Turn = new TurnConfig { SilenceEndCallTimeout = 20 } } }
        );
        var config = agent.ToJson();
        Assert.That(
            Canon(config["conversation_config"]),
            Is.EqualTo(
                Canon(
                    JsonNode.Parse(
                        """{"agent":{"disable_first_message_interruptions":true,"prompt":{"prompt":"p"}},"turn":{"silence_end_call_timeout":20,"turn_timeout":7}}"""
                    )
                )
            )
        );
        Assert.That(Canon(config["platform_settings"]), Is.EqualTo("""{"privacy":{"record_voice":false}}"""));
    }

    [Test]
    public void FillsInTheIdsOfToolObjectsUsedByWorkflowNodes()
    {
        var lookup = GetOrder();
        var show = ShowOrder();
        var wf = new Workflow();
        wf.Converse("triage", "Find out what the caller needs")
            .When("Caller gave an order number")
            .Tool(
                "lookup",
                new[] { lookup },
                new ToolOptions
                {
                    SchemaOverrides = new Dictionary<string, IReadOnlyDictionary<string, JsonNode>>
                    {
                        ["get_order"] = new Dictionary<string, JsonNode>
                        {
                            ["path_params.order_id"] = new JsonObject { ["source"] = "constant", ["constant_value"] = "1" },
                        },
                    },
                }
            )
            .OnSuccess()
            .Converse("resolve", "Explain the order", new ConverseOptions { Tools = new ToolRef[] { show, "tool_raw" } });
        var agent = new Agent("A", new AgentOptions { Prompt = "p", Workflow = wf });

        Assert.That(agent.Tools(), Is.EqualTo(new Tool[] { lookup, show }));
        var nodes = Nodes(agent.ToJson(Ids("get_order", "tool_g", "show_order", "tool_s")));
        Assert.That(
            Canon(nodes["lookup"]!["tools"]),
            Is.EqualTo("""[{"schema_overrides":{"path_params.order_id":{"constant_value":"1","source":"constant"}},"tool_id":"tool_g"}]""")
        );
        Assert.That(Canon(nodes["resolve"]!["additional_tool_ids"]), Is.EqualTo("""["tool_s","tool_raw"]"""));
        Assert.That(
            IssuesOf(() => agent.ToJson(Ids("get_order", "tool_g"))),
            Is.EqualTo(new[] { ("unresolved_tool", (string?)"tools.show_order") })
        );
    }

    [Test]
    public void ValidatesWithoutIds()
    {
        Assert.DoesNotThrow(() => new Agent("A", new AgentOptions { Prompt = "p", Tools = new Tool[] { GetOrder() } }).Validate());
    }

    [Test]
    public void ReportsEveryProblemAtOnce()
    {
        var wf = new Workflow();
        wf.Tool("hang_up", new Tool[] { SystemTool.EndCall() });
        var agent = new Agent(
            "",
            new AgentOptions
            {
                Prompt = "p",
                Tools = new Tool[] { GetOrder(), GetOrder(), Tool.Webhook("broken", "No URL") },
                Workflow = wf,
                ConversationConfig = new ConversationalConfig
                {
                    Agent = new AgentConfig { Prompt = new PromptAgentApiModelInput { Prompt = "raw prompt" } },
                },
            }
        );
        Assert.That(
            IssuesOf(() => agent.Validate()),
            Is.EqualTo(
                new[]
                {
                    ("missing_name", (string?)null),
                    ("option_conflict", "conversation_config.agent.prompt.prompt"),
                    ("duplicate_tool_name", "tools.get_order"),
                    ("invalid_tool", "tools.broken"),
                    ("system_tool_in_workflow", "workflow.tools.end_call"),
                }
            )
        );
    }

    [Test]
    public void WarnsWithoutFailingWhenThereIsNoPrompt()
    {
        var warnings = new List<string>();
        new Agent("A").Validate(issue => warnings.Add(issue.Code));
        Assert.That(warnings, Is.EqualTo(new[] { "missing_prompt" }));
    }

    [Test]
    public void FromJsonRoundTripsACliAgentConfigKeepingUnmodeledFieldsAndToolOrder()
    {
        // Fixture check: agent_configs/support.json round-trips through FromJson().ToJson() to its sorted form.
        var raw = CliProjectFixture.Json("agent_configs/support.json");
        var lookup = Tool.FromJson(CliProjectFixture.Json("tool_configs/lookup_order.json"));
        var agent = Agent.FromJson(raw, new Dictionary<string, Tool> { ["tool_lookup"] = lookup });

        Assert.That(agent.Name, Is.EqualTo("Support"));
        Assert.That(agent.Tools(), Is.EqualTo(new[] { lookup }));
        Assert.That(agent.ToolIds, Is.EqualTo(new[] { "tool_from_dashboard" }));
        Assert.That(agent.ToJson(Ids("lookup_order", "tool_lookup")).ToJsonString(), Is.EqualTo(Canon(raw)));
    }

    [Test]
    public void TurnsALoadedWorkflowIntoAWorkflowOnFirstUseWithToolIdsBoundToToolObjects()
    {
        var raw = CliProjectFixture.Json("agent_configs/support.beta.json");
        var refund = Tool.FromJson(CliProjectFixture.Json("tool_configs/issue_refund.json"));
        var agent = Agent.FromJson(raw, new Dictionary<string, Tool> { ["tool_refund"] = refund });

        Assert.That(agent.Tools(), Is.EqualTo(new[] { refund }), "read from the raw workflow, before it's materialized");
        var unedited = agent.ToJson(Ids("issue_refund", "tool_refund"));
        Assert.That(Canon(unedited["workflow"]), Is.EqualTo(Canon(raw["workflow"])));

        agent.Workflow!.Node("refunds").Update(new NodeUpdate { Prompt = "Handle refunds" });
        var nodes = Nodes(agent.ToJson(Ids("issue_refund", "tool_new")));
        Assert.That(Canon(nodes["refunds"]!["additional_tool_ids"]), Is.EqualTo("""["tool_new"]"""));
        Assert.That(nodes["refunds"]!["additional_prompt"]!.GetValue<string>(), Is.EqualTo("Handle refunds"));
    }

    [Test]
    public void ReplacesALoadedAgentsSystemToolsAlongWithItsOtherTools()
    {
        var agent = Agent.FromJson(CliProjectFixture.Json("agent_configs/support.json"));
        Assert.That(agent.Tools(), Is.Empty, "system tools aren't managed by push");
        agent.Update(new AgentOptions { Tools = Array.Empty<Tool>() });
        var prompt = agent.ToJson()["conversation_config"]!["agent"]!["prompt"]!;
        Assert.That(prompt["built_in_tools"], Is.Null);
        Assert.That(Canon(prompt["tool_ids"]), Is.EqualTo("""["tool_lookup","tool_from_dashboard"]"""), "ids it doesn't manage stay");
    }

    [Test]
    public void TreatsAnExplicitlyEmptyToolListAsSet()
    {
        var agent = new Agent(
            "A",
            new AgentOptions
            {
                Prompt = "p",
                ToolIds = Array.Empty<string>(),
                ConversationConfig = new ConversationalConfig
                {
                    Agent = new AgentConfig { Prompt = new PromptAgentApiModelInput { ToolIds = new[] { "tool_existing" } } },
                },
            }
        );
        Assert.That(
            IssuesOf(() => agent.Validate()),
            Is.EqualTo(new[] { ("option_conflict", (string?)"conversation_config.agent.prompt.tool_ids") })
        );
    }

    [Test]
    public void ValidatesALoadedWorkflowWithoutMaterializingIt()
    {
        var raw = CliProjectFixture.Json("agent_configs/support.beta.json");
        raw["workflow"]!["edges"]!["broken"] = new JsonObject { ["source"] = "start_node", ["target"] = "nowhere" };
        var agent = Agent.FromJson(raw);
        Assert.That(IssuesOf(() => agent.Validate()), Is.EqualTo(new[] { ("invalid_workflow", (string?)"workflow") }));
    }

    [Test]
    public void WritesNewToolIdsIntoALoadedWorkflowItHasNotMaterialized()
    {
        var raw = CliProjectFixture.Json("agent_configs/support.beta.json");
        var refund = Tool.FromJson(CliProjectFixture.Json("tool_configs/issue_refund.json"));
        var agent = Agent.FromJson(raw, new Dictionary<string, Tool> { ["tool_refund"] = refund });
        var nodes = Nodes(agent.ToJson(Ids("issue_refund", "tool_clone")));
        Assert.That(Canon(nodes["refunds"]!["additional_tool_ids"]), Is.EqualTo("""["tool_clone"]"""));
    }

    [Test]
    public void AttachesAToolAddedWithAddTool()
    {
        var agent = new Agent("A", new AgentOptions { Prompt = "p" }).AddTool(GetOrder());
        var prompt = agent.ToJson(Ids("get_order", "tool_1"))["conversation_config"]!["agent"]!["prompt"]!;
        Assert.That(Canon(prompt["tool_ids"]), Is.EqualTo("""["tool_1"]"""));
    }

    [Test]
    public void UpdateRenamesAndReplacesTypedOptions()
    {
        var agent = new Agent("A", new AgentOptions { Prompt = "old", FirstMessage = "Hi" });
        agent.Update(new AgentOptions { Prompt = "new" }, name: "B");
        var config = agent.ToJson();
        Assert.That(agent.Name, Is.EqualTo("B"));
        Assert.That(config["name"]!.GetValue<string>(), Is.EqualTo("B"));
        Assert.That(config["conversation_config"]!["agent"]!["prompt"]!["prompt"]!.GetValue<string>(), Is.EqualTo("new"));
        Assert.That(config["conversation_config"]!["agent"]!["first_message"]!.GetValue<string>(), Is.EqualTo("Hi"));
    }

    [Test]
    public void ReportsInvalidRawConfig()
    {
        var agent = new Agent(
            "A",
            new AgentOptions
            {
                Prompt = "p",
                ConversationConfig = new ConversationalConfig { Agent = new AgentConfig { Prompt = new PromptAgentApiModelInput { Temperature = double.NaN } } },
            }
        );
        Assert.That(IssuesOf(() => agent.Validate()), Is.EqualTo(new[] { ("invalid_config", (string?)"ConversationConfig") }));
    }
}

/// <summary><c>Tool</c> objects in workflow nodes: placeholders, ids at build time, and name clashes.</summary>
[TestFixture]
public class WorkflowToolRefTest
{
    [Test]
    public void LetsARemovedNodesToolNameBeReusedByANewToolObject()
    {
        var wf = new Workflow();
        wf.Tool("a", new[] { AgentBuilderTest.GetOrder() });
        wf.Remove("a");
        wf.Tool("b", new[] { AgentBuilderTest.GetOrder() });
        Assert.DoesNotThrow(() => wf.Build(AgentBuilderTest.Ids("get_order", "tool_1")));
    }

    [Test]
    public void ReportsTwoDifferentToolsWithOneNameInTheSameNode()
    {
        var wf = new Workflow();
        wf.Tool("lookup", new[] { AgentBuilderTest.GetOrder(), AgentBuilderTest.GetOrder() });
        var ex = Assert.Throws<WorkflowValidationException>(() => wf.Build(AgentBuilderTest.Ids("get_order", "tool_1")));
        Assert.That(ex!.Issues.Select(issue => issue.Code), Is.EqualTo(new[] { "duplicate_tool_name" }));

        var lookup = AgentBuilderTest.GetOrder();
        var same = new Workflow();
        same.Tool("lookup", new[] { lookup, lookup });
        Assert.DoesNotThrow(() => same.Build(AgentBuilderTest.Ids("get_order", "tool_1")));
    }

    [Test]
    public void WritesToolObjectsAsIdsInToJsonAndToJsonString()
    {
        var wf = new Workflow();
        wf.Tool("lookup", new[] { AgentBuilderTest.GetOrder() });
        var toolIds = AgentBuilderTest.Ids("get_order", "tool_1");
        Assert.That(JsonNode.Parse(wf.ToJsonString(toolIds))!.ToJsonString(), Is.EqualTo(wf.ToJson(toolIds).ToJsonString()));
        Assert.That(wf.ToJson(toolIds)["nodes"]!["lookup"]!["tools"]!.ToJsonString(), Is.EqualTo("""[{"tool_id":"tool_1"}]"""));
    }

    [Test]
    public void ReportsAToolObjectWithoutAnId()
    {
        var wf = new Workflow();
        wf.Tool("lookup", new ToolRef[] { AgentBuilderTest.GetOrder(), "tool_raw" });
        var ex = Assert.Throws<WorkflowValidationException>(() => wf.ToJson());
        Assert.That(ex!.Issues.Select(issue => (issue.Code, issue.NodeId)), Is.EqualTo(new[] { ("unresolved_tool", (string?)"lookup") }));
    }

    [Test]
    public void ListsTheToolObjectsTheNodesUse()
    {
        var lookup = AgentBuilderTest.GetOrder();
        var show = AgentBuilderTest.ShowOrder();
        var wf = new Workflow();
        wf.Tool("lookup", new ToolRef[] { lookup, "tool_raw" }).OnSuccess().Converse("a", "A", new ConverseOptions { Tools = new ToolRef[] { show } });
        Assert.That(wf.Tools(), Is.EqualTo(new Tool[] { lookup, show }));
        wf.Node("a").Update(new NodeUpdate { ToolIds = new[] { "tool_other" } });
        Assert.That(wf.Tools(), Is.EqualTo(new Tool[] { lookup }), "a tool no node uses any more isn't listed");
    }

    [Test]
    public void FromJsonSwapsKnownToolIdsForToolObjectsAndKeepsUnknownIds()
    {
        var getOrder = Tool.Client("get_order", "Look up an order");
        var wf = new Workflow();
        wf.Converse("a", "A", new ConverseOptions { ToolIds = new[] { "tool_1", "tool_other" } });
        var json = wf.ToJson();

        var loaded = Workflow.FromJson(json, new Dictionary<string, Tool> { ["tool_1"] = getOrder });
        Assert.That(loaded.Tools(), Is.EqualTo(new[] { getOrder }));
        var built = loaded.ToJson(AgentBuilderTest.Ids("get_order", "tool_9")).ToJsonString();
        Assert.That(built, Does.Contain("tool_9"));
        Assert.That(built, Does.Contain("tool_other"));
        Assert.That(built, Does.Not.Contain("tool_1\""));
    }

    [Test]
    public void ReportsSchemaOverridesForAToolTheNodeDoesNotRunByName()
    {
        var wf = new Workflow();
        wf.Tool(
            "lookup",
            new[] { AgentBuilderTest.GetOrder() },
            new ToolOptions
            {
                SchemaOverrides = new Dictionary<string, IReadOnlyDictionary<string, JsonNode>>
                {
                    ["show_order"] = new Dictionary<string, JsonNode> { ["x"] = new JsonObject { ["source"] = "llm" } },
                },
            }
        );
        var ex = Assert.Throws<WorkflowValidationException>(() => wf.Build(AgentBuilderTest.Ids("get_order", "tool_1")));
        Assert.That(ex!.Issues.Single().Message, Does.Contain("tool \"show_order\""));
    }
}
