using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using ElevenLabs.AgentBuilder;
using ElevenLabs.AgentWorkflows;
using NUnit.Framework;

namespace ElevenLabs.Tests;

// Inside the namespace, so these win over the generated ElevenLabs.Tool model.
using ElevenLabs.AgentTools;
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>
/// <c>Agents.PushAsync</c> and <c>Agents.PullAsync</c> against <see cref="FakeAgentServer"/>, through the real client
/// stack. Ported from elevenlabs-js <c>tests/custom/agents/agent/push.test.ts</c>.
/// </summary>
[TestFixture]
public class AgentPushTest
{
    private static WebhookTool GetOrder(string description = "Look up an order by its number") => AgentBuilderTest.GetOrder(description);

    private static ClientTool ShowOrder() => AgentBuilderTest.ShowOrder();

    private static Agent SupportAgent(params Tool[] tools)
    {
        if (tools.Length == 0)
        {
            tools = new Tool[] { GetOrder(), ShowOrder() };
        }
        var wf = new Workflow();
        wf.Converse("triage", "Find out what the caller needs")
            .When("Caller gave an order number")
            .Tool("lookup", new[] { tools[0] })
            .OnSuccess()
            .Converse("resolve", "Explain the order");
        return new Agent(
            "Support line",
            new AgentOptions
            {
                Prompt = "You help with orders.",
                Tools = new Tool[] { SystemTool.EndCall() }.Concat(tools.Skip(1)).ToList(),
                Workflow = wf,
            }
        );
    }

    private static Dictionary<string, ToolPushResult> Results(params (string Name, string Id, ToolPushAction Action)[] tools) =>
        tools.ToDictionary(t => t.Name, t => new ToolPushResult(t.Id, t.Action));

    private static JsonObject Config(string text) => JsonNode.Parse(text)!.AsObject();

    [Test]
    public async Task CreatesTheToolsThenTheAgentWithTheirIds()
    {
        var server = new FakeAgentServer();
        var result = await server.Client().Agents.PushAsync(SupportAgent());

        Assert.That(server.Writes(), Is.EqualTo(new[] { "POST /v1/convai/tools", "POST /v1/convai/tools", "POST /v1/convai/agents/create" }));
        Assert.That(result.AgentId, Is.EqualTo("agent_new_3"));
        Assert.That(result.Action, Is.EqualTo(AgentPushAction.Created));
        Assert.That(
            result.Tools,
            Is.EqualTo(Results(("show_order", "tool_new_1", ToolPushAction.Created), ("get_order", "tool_new_2", ToolPushAction.Created)))
        );
        var sent = server.Agents["agent_new_3"];
        Assert.That(sent["conversation_config"]!["agent"]!["prompt"]!["tool_ids"]!.ToJsonString(), Is.EqualTo("""["tool_new_1"]"""));
        Assert.That(sent["conversation_config"]!["agent"]!["prompt"]!["built_in_tools"]!["end_call"]!["name"]!.GetValue<string>(), Is.EqualTo("end_call"));
        Assert.That(sent["workflow"]!["nodes"]!["lookup"]!["tools"]!.ToJsonString(), Is.EqualTo("""[{"tool_id":"tool_new_2"}]"""));
        // The tool requests carry the builder's config exactly.
        var toolBody = server.Calls.First(c => c.Method == "POST" && c.Path == "/v1/convai/tools").Body!;
        Assert.That(AgentBuilderTest.Canon(toolBody["tool_config"]), Is.EqualTo(ShowOrder().ToJson().ToJsonString()));
    }

    [Test]
    public async Task UpdatesOnlyWhatChangedAndLeavesAnotherAgentsSameNamedToolAlone()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        var created = await client.Agents.PushAsync(SupportAgent());
        server.AddTool("tool_other", GetOrder("Someone else's").ToJson(), "agent_other");
        server.Calls.Clear();

        var again = await client.Agents.PushAsync(
            SupportAgent(GetOrder("Find an order"), ShowOrder()),
            new AgentPushOptions { AgentId = created.AgentId }
        );

        Assert.That(server.Writes(), Is.EqualTo(new[] { "PATCH /v1/convai/tools/tool_new_2", $"PATCH /v1/convai/agents/{created.AgentId}" }));
        Assert.That(
            server.Calls[0].Query,
            Is.EquivalentTo(new Dictionary<string, string> { ["used_by_agent_id"] = created.AgentId, ["page_size"] = "100" })
        );
        Assert.That(
            again.Tools,
            Is.EqualTo(Results(("show_order", "tool_new_1", ToolPushAction.Unchanged), ("get_order", "tool_new_2", ToolPushAction.Updated)))
        );
        Assert.That(again.Action, Is.EqualTo(AgentPushAction.Updated));
        Assert.That(server.Tools["tool_other"].Config["description"]!.GetValue<string>(), Is.EqualTo("Someone else's"));
    }

    [Test]
    public async Task ReportsToolsTheAgentStoppedUsingAsDetachedWithoutDeletingThem()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        var created = await client.Agents.PushAsync(SupportAgent());
        var agent = SupportAgent();
        agent.Update(new AgentOptions { Tools = Array.Empty<Tool>() });
        var result = await client.Agents.PushAsync(agent, new AgentPushOptions { AgentId = created.AgentId });
        Assert.That(result.Tools["show_order"], Is.EqualTo(new ToolPushResult("tool_new_1", ToolPushAction.Detached)));
        Assert.That(server.Tools.ContainsKey("tool_new_1"), Is.True);
        Assert.That(server.Writes().Any(w => w.StartsWith("DELETE")), Is.False);
    }

    [Test]
    public async Task MatchesABranchPushAgainstTheBranchsToolsNotTheMainBranchs()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        var created = await client.Agents.PushAsync(SupportAgent());
        var agentId = created.AgentId;
        // The branch uses its own copy of get_order, and no show_order.
        server.AddTool("tool_branch_order", GetOrder("Branch lookup").ToJson());
        var branch = (JsonObject)server.Agents[agentId].DeepClone();
        branch["workflow"]!["nodes"]!["lookup"]!["tools"] = new JsonArray(new JsonObject { ["tool_id"] = "tool_branch_order" });
        branch["conversation_config"]!["agent"]!["prompt"]!["tool_ids"] = new JsonArray();
        server.Branches[$"{agentId}/agtbrch_1"] = branch;
        server.Calls.Clear();

        var result = await client.Agents.PushAsync(
            SupportAgent(GetOrder("Changed lookup")),
            new AgentPushOptions { AgentId = agentId, BranchId = "agtbrch_1", VersionDescription = "Branch edit" }
        );
        Assert.That(result.Tools["get_order"], Is.EqualTo(new ToolPushResult("tool_branch_order", ToolPushAction.Updated)));
        Assert.That(result.Tools.ContainsKey("show_order"), Is.False, "a main-branch tool the branch never used isn't detached");
        Assert.That(server.Writes(), Is.EqualTo(new[] { "PATCH /v1/convai/tools/tool_branch_order", $"PATCH /v1/convai/agents/{agentId}" }));
        Assert.That(server.Calls.Any(c => c.Query.ContainsKey("used_by_agent_id")), Is.False);
        var patch = server.Calls.Last();
        Assert.That(patch.Query["branch_id"], Is.EqualTo("agtbrch_1"));
        Assert.That(patch.Body!["version_description"]!.GetValue<string>(), Is.EqualTo("Branch edit"));
    }

    [Test]
    public void ValidatesBeforeAnyApiCall()
    {
        var server = new FakeAgentServer();
        var agent = new Agent("A", new AgentOptions { Prompt = "p", Tools = new Tool[] { Tool.Webhook("broken", "No URL") } });
        Assert.That(async () => await server.Client().Agents.PushAsync(agent), Throws.TypeOf<AgentValidationException>());
        Assert.That(server.Calls, Is.Empty);
    }

    [Test]
    public async Task ReportsWhatItWroteBeforeAFailure()
    {
        var server = new FakeAgentServer { FailOn = new Regex("^POST /v1/convai/agents/create$") };
        AgentPushException? error = null;
        try
        {
            await server.Client().Agents.PushAsync(SupportAgent());
        }
        catch (AgentPushException ex)
        {
            error = ex;
        }
        Assert.That(error, Is.Not.Null);
        Assert.That(error!.Message, Does.StartWith("Couldn't create agent \"Support line\""));
        Assert.That(error.InnerException, Is.InstanceOf<ElevenLabsClientApiException>());
        Assert.That(error.Result.AgentId, Is.Null);
        Assert.That(error.Result.Action, Is.Null);
        Assert.That(
            error.Result.Tools,
            Is.EqualTo(Results(("show_order", "tool_new_1", ToolPushAction.Created), ("get_order", "tool_new_2", ToolPushAction.Created)))
        );
    }

    [Test]
    public async Task SavesAProjectOpenedFromADirectoryAfterAPartialFailure()
    {
        var dir = CliProjectFixture.TempDir();
        var project = AgentProject.Open(dir);
        var server = new FakeAgentServer { FailOn = new Regex("^POST /v1/convai/agents/create$") };
        Assert.That(
            async () => await server.Client().Agents.PushAsync(SupportAgent(), new AgentPushOptions { Project = project }),
            Throws.TypeOf<AgentPushException>().With.Message.StartWith("Couldn't create agent")
        );
        var files = CliProjectFixture.ReadTree(dir);
        Assert.That(files.Keys.OrderBy(k => k, StringComparer.Ordinal), Is.EqualTo(new[] { "tool_configs/get_order.json", "tool_configs/show_order.json", "tools.json" }));
        var reopened = AgentProject.Open(dir);
        Assert.That(reopened.Tools.Select(t => reopened.GetToolId(t)), Is.EqualTo(new[] { "tool_new_1", "tool_new_2" }));
        Assert.That(project.ChangedFiles, Is.Empty);

        // The next push finds the tools it already created, and creates only the agent.
        server.FailOn = null;
        server.Calls.Clear();
        var result = await server.Client().Agents.PushAsync(SupportAgent(), new AgentPushOptions { Project = reopened });
        Assert.That(server.Writes(), Is.EqualTo(new[] { "POST /v1/convai/agents/create" }));
        Assert.That(result.Tools.Values.Select(t => t.Action), Is.EqualTo(new[] { ToolPushAction.Unchanged, ToolPushAction.Unchanged }));
    }

    [Test]
    public void SurfacesCancellationAsIsAndStillSavesTheProject()
    {
        var dir = CliProjectFixture.TempDir();
        var project = AgentProject.Open(dir);
        using var cancel = new CancellationTokenSource();
        var server = new FakeAgentServer();
        // Cancel while the second tool is being created: the first one is done and recorded.
        server.OnCall = _ =>
        {
            if (server.Calls.Count == 2)
            {
                cancel.Cancel();
            }
        };
        Assert.That(
            async () => await server.Client().Agents.PushAsync(SupportAgent(), new AgentPushOptions { Project = project }, cancellationToken: cancel.Token),
            Throws.InstanceOf<OperationCanceledException>()
        );
        Assert.That(server.Writes(), Is.EqualTo(new[] { "POST /v1/convai/tools", "POST /v1/convai/tools" }));
        Assert.That(CliProjectFixture.ReadTree(dir).Keys.OrderBy(k => k, StringComparer.Ordinal), Is.EqualTo(new[] { "tool_configs/show_order.json", "tools.json" }));
    }

    [Test]
    public void RefusesAgentIdTogetherWithAProject()
    {
        var server = new FakeAgentServer();
        Assert.That(
            async () =>
                await server.Client().Agents.PushAsync(
                    SupportAgent(),
                    new AgentPushOptions { AgentId = "agent_1", Project = AgentProject.FromFiles(new Dictionary<string, string>()) }
                ),
            Throws.TypeOf<ArgumentException>().With.Message.Contains("not both")
        );
    }

    [Test]
    public async Task RecordsIdsAndWritesTheCliLayoutThenUpdatesByRecordedId()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        var project = AgentProject.FromFiles(new Dictionary<string, string>());

        await client.Agents.PushAsync(SupportAgent(), new AgentPushOptions { Project = project });
        var files = project.ToFiles();
        Assert.That(
            files.Keys.OrderBy(k => k, StringComparer.Ordinal),
            Is.EqualTo(new[] { "agent_configs/Support-line.json", "agents.json", "tool_configs/get_order.json", "tool_configs/show_order.json", "tools.json" })
        );
        Assert.That(
            files["agents.json"],
            Is.EqualTo("{\n    \"agents\": [\n        {\n            \"config\": \"agent_configs/Support-line.json\",\n            \"id\": \"agent_new_3\"\n        }\n    ]\n}")
        );
        Assert.That(
            JsonNode.Parse(files["tools.json"])!.ToJsonString(),
            Is.EqualTo(
                """{"tools":[{"type":"client","config":"tool_configs/show_order.json","id":"tool_new_1"},{"type":"webhook","config":"tool_configs/get_order.json","id":"tool_new_2"}]}"""
            )
        );
        Assert.That(
            JsonNode.Parse(files["agent_configs/Support-line.json"])!["conversation_config"]!["agent"]!["prompt"]!["tool_ids"]!.ToJsonString(),
            Is.EqualTo("""["tool_new_1"]""")
        );

        // A fresh script run: new objects, matched to the project's entries by name.
        server.Calls.Clear();
        var reloaded = AgentProject.FromFiles(files);
        var result = await client.Agents.PushAsync(SupportAgent(), new AgentPushOptions { Project = reloaded });
        Assert.That(server.Writes(), Is.EqualTo(new[] { "PATCH /v1/convai/agents/agent_new_3" }));
        Assert.That(result.Tools["get_order"].Action, Is.EqualTo(ToolPushAction.Unchanged));
        // Only the version the update reported is new, recorded like the CLI does.
        Assert.That(reloaded.ChangedFiles, Is.EqualTo(new[] { "agents.json" }));
        Assert.That(JsonNode.Parse(reloaded.ToFiles()["agents.json"])!["agents"]![0]!["version_id"]!.GetValue<string>(), Is.EqualTo("ver_1"));
    }

    [Test]
    public async Task PushesALoadedAgentsSettingsTheSdkDoesNotModel()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        server.AddTool("tool_lookup", Config("""{"type":"client","name":"lookup","description":"old"}"""));
        var project = AgentProject.FromFiles(
            new Dictionary<string, string>
            {
                ["agents.json"] = """{"agents":[{"config":"agent_configs/a.json","id":"agent_1"}]}""",
                ["tools.json"] = """{"tools":[{"type":"client","config":"tool_configs/t.json","id":"tool_lookup"}]}""",
                ["agent_configs/a.json"] =
                    """{"name":"A","conversation_config":{"agent":{"prompt":{"prompt":"p","tool_ids":["tool_lookup"]}},"future_setting":{"on":true}},"platform_settings":{},"tags":[]}""",
                ["tool_configs/t.json"] = """{"type":"client","name":"lookup","description":"d","future_field":1}""",
            }
        );
        server.AddAgent("agent_1", new JsonObject());

        var agent = project.GetAgent("A");
        agent.Update(new AgentOptions { FirstMessage = "Hello" });
        await client.Agents.PushAsync(agent, new AgentPushOptions { Project = project });

        var toolPatch = server.Calls.First(c => c.Method == "PATCH" && c.Path.Contains("/tools/"));
        Assert.That(toolPatch.Body!["tool_config"]!["future_field"]!.GetValue<int>(), Is.EqualTo(1));
        var agentPatch = server.Calls.First(c => c.Method == "PATCH" && c.Path.Contains("/agents/"));
        Assert.That(agentPatch.Body!["conversation_config"]!["future_setting"]!.ToJsonString(), Is.EqualTo("""{"on":true}"""));
        Assert.That(agentPatch.Body!["conversation_config"]!["agent"]!["first_message"]!.GetValue<string>(), Is.EqualTo("Hello"));
        Assert.That(
            project.ChangedFiles.OrderBy(k => k, StringComparer.Ordinal),
            Is.EqualTo(new[] { "agent_configs/a.json", "agents.json", "tool_configs/t.json", "tools.json" })
        );
    }

    [Test]
    public async Task PullLoadsAnAgentWithItsToolsAsToolObjectsAndWritesThemIntoAProject()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        var created = await client.Agents.PushAsync(SupportAgent());

        var project = AgentProject.FromFiles(new Dictionary<string, string>());
        var agent = await client.Agents.PullAsync(created.AgentId, new AgentPullOptions { Project = project });
        Assert.That(agent.Name, Is.EqualTo("Support line"));
        Assert.That(agent.Tools().Select(t => t.Name), Is.EqualTo(new[] { "show_order", "get_order" }));
        Assert.That(project.GetAgentId(agent), Is.EqualTo(created.AgentId));

        var files = project.ToFiles();
        Assert.That(
            files.Keys.OrderBy(k => k, StringComparer.Ordinal),
            Is.EqualTo(new[] { "agent_configs/Support-line.json", "agents.json", "tool_configs/get_order.json", "tool_configs/show_order.json", "tools.json" })
        );
        var config = JsonNode.Parse(files["agent_configs/Support-line.json"])!.AsObject();
        Assert.That(config.Select(f => f.Key), Is.EqualTo(new[] { "conversation_config", "name", "platform_settings", "tags", "workflow" }));

        // Pushing the pulled agent back changes no tools.
        server.Calls.Clear();
        var result = await client.Agents.PushAsync(agent, new AgentPushOptions { Project = project });
        Assert.That(server.Writes(), Is.EqualTo(new[] { $"PATCH /v1/convai/agents/{created.AgentId}" }));
        Assert.That(result.Tools.Values.Select(t => t.Action), Is.EqualTo(new[] { ToolPushAction.Unchanged, ToolPushAction.Unchanged }));
    }

    [Test]
    public async Task PullWithoutAProjectKeepsNonWebhookToolsAttachedById()
    {
        var server = new FakeAgentServer();
        server.AddTool("tool_mcp", Config("""{"type":"mcp","name":"search","description":"d","integration_type":"mcp_server","mcp_tool_name":"search","mcp_tool_description":"d","mcp_server_id":"srv","mcp_server_name":"Search"}"""));
        server.AddTool("tool_ping", Config("""{"type":"client","name":"ping","description":"Ping"}"""));
        server.AddAgent(
            "agent_1",
            Config("""{"name":"A","conversation_config":{"agent":{"prompt":{"prompt":"p","tool_ids":["tool_mcp","tool_ping"]}}},"platform_settings":{},"tags":[]}""")
        );
        var agent = await server.Client().Agents.PullAsync("agent_1");
        Assert.That(agent.Tools().Select(t => t.Name), Is.EqualTo(new[] { "ping" }));
        Assert.That(agent.ToolIds, Is.EqualTo(new[] { "tool_mcp" }));
        Assert.That(server.Writes(), Is.Empty);
    }

    private const string McpTool =
        """{"type":"mcp","name":"docs_search","description":"d","integration_type":"mcp_server","mcp_tool_name":"search","mcp_tool_description":"d","mcp_server_id":"srv","mcp_server_name":"Search"}""";

    [Test]
    public async Task PushLeavesAnMcpToolObjectAttachedByTheIdItWasLoadedWith()
    {
        // Loaded as a Tool object (as a project's tools.json does), not into ToolIds.
        var server = new FakeAgentServer();
        server.AddTool("tool_mcp", Config(McpTool), "agent_1");
        var config = Config(
            """{"name":"A","conversation_config":{"agent":{"prompt":{"prompt":"p","tool_ids":["tool_mcp"]}}},"platform_settings":{},"tags":[]}"""
        );
        server.AddAgent("agent_1", (JsonObject)config.DeepClone());
        var mcp = Tool.FromJson(Config(McpTool));
        var agent = Agent.FromJson(config, new Dictionary<string, Tool> { ["tool_mcp"] = mcp });
        Assert.That(agent.Tools(), Is.Empty);

        var result = await server.Client().Agents.PushAsync(agent, new AgentPushOptions { AgentId = "agent_1" });
        Assert.That(server.Writes(), Is.EqualTo(new[] { "PATCH /v1/convai/agents/agent_1" }));
        Assert.That(result.Tools, Is.Empty, "neither created, updated nor detached");
        var sent = server.Calls.Last().Body!["conversation_config"]!["agent"]!["prompt"]!["tool_ids"]!;
        Assert.That(sent.AsArray().Select(id => id!.GetValue<string>()), Is.EqualTo(new[] { "tool_mcp" }));
        Assert.That(server.Tools["tool_mcp"].Config.ToJsonString(), Is.EqualTo(Config(McpTool).ToJsonString()));
    }

    [Test]
    public void AnMcpToolObjectInAWorkflowNodeKeepsItsLoadedId()
    {
        var mcp = Tool.FromJson(Config(McpTool));
        var config = Config("""{"name":"A","conversation_config":{"agent":{"prompt":{"prompt":"p","tool_ids":["tool_mcp"]}}}}""");
        var agent = Agent.FromJson(config, new Dictionary<string, Tool> { ["tool_mcp"] = mcp });
        var wf = new Workflow();
        wf.Tool("run", new[] { mcp });
        agent.Update(new AgentOptions { Workflow = wf });
        Assert.That(agent.Tools(), Is.Empty);
        var wire = agent.ToJson(new Dictionary<string, string>());
        Assert.That(wire["workflow"]!["nodes"]!["run"]!["tools"]![0]!["tool_id"]!.GetValue<string>(), Is.EqualTo("tool_mcp"));
    }

    [Test]
    public void RejectsAnMcpToolObjectWithoutAnIdBeforeAnyRequest()
    {
        var server = new FakeAgentServer();
        var viaTools = new Agent("A", new AgentOptions { Prompt = "p" }).AddTool(Tool.FromJson(Config(McpTool)));
        var wf = new Workflow();
        wf.Tool("run", new[] { Tool.FromJson(Config(McpTool)) });
        var viaWorkflow = new Agent("A", new AgentOptions { Prompt = "p", Workflow = wf });
        foreach (var agent in new[] { viaTools, viaWorkflow })
        {
            var ex = Assert.Throws<AgentValidationException>(() => agent.Validate())!;
            var issue = ex.Issues.Single();
            Assert.That(issue.Code, Is.EqualTo("invalid_tool"));
            Assert.That(issue.Path, Is.EqualTo("tools.docs_search"));
            Assert.That(
                issue.Message,
                Is.EqualTo(
                    "Tool \"docs_search\" has type \"mcp\", which push doesn't create or update: load it with its id or attach it with ToolIds"
                )
            );
            Assert.That(async () => await server.Client().Agents.PushAsync(agent), Throws.TypeOf<AgentValidationException>());
        }
        Assert.That(server.Calls, Is.Empty);
    }

    [Test]
    public async Task UpdatesAProjectToolWhoseOnlyChangeIsAFieldTheSdkDoesNotModel()
    {
        var server = new FakeAgentServer();
        server.AddTool("tool_1", Config("""{"type":"client","name":"ping","description":"d","future_field":1}"""), "agent_1");
        server.AddAgent("agent_1", new JsonObject());
        var project = AgentProject.FromFiles(
            new Dictionary<string, string>
            {
                ["agents.json"] = """{"agents":[{"config":"agent_configs/a.json","id":"agent_1"}]}""",
                ["tools.json"] = """{"tools":[{"type":"client","config":"tool_configs/t.json","id":"tool_1"}]}""",
                ["agent_configs/a.json"] = """{"name":"A","conversation_config":{"agent":{"prompt":{"prompt":"p","tool_ids":["tool_1"]}}}}""",
                ["tool_configs/t.json"] = """{"type":"client","name":"ping","description":"d","future_field":2}""",
            }
        );
        var result = await server.Client().Agents.PushAsync(project.GetAgent("A"), new AgentPushOptions { Project = project });
        Assert.That(result.Tools["ping"].Action, Is.EqualTo(ToolPushAction.Updated));
        Assert.That(server.Tools["tool_1"].Config["future_field"]!.GetValue<int>(), Is.EqualTo(2));
    }

    [Test]
    public async Task BringsTheProjectUpToDateWhenTheServerAlreadyMatchesANewDefinition()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        var project = AgentProject.FromFiles(new Dictionary<string, string>());
        await client.Agents.PushAsync(SupportAgent(GetOrder("v2"), ShowOrder()), new AgentPushOptions { Project = project });
        var files = new Dictionary<string, string>(project.ToFiles())
        {
            ["tool_configs/get_order.json"] = ProjectFormat.FormatIndex(GetOrder("v1").ToJson()),
        };
        var stale = AgentProject.FromFiles(files);
        var result = await client.Agents.PushAsync(SupportAgent(GetOrder("v2"), ShowOrder()), new AgentPushOptions { Project = stale });
        Assert.That(result.Tools["get_order"].Action, Is.EqualTo(ToolPushAction.Unchanged));
        Assert.That(JsonNode.Parse(stale.ToFiles()["tool_configs/get_order.json"])!["description"]!.GetValue<string>(), Is.EqualTo("v2"));
    }

    [Test]
    public async Task DoesNotReportAToolAsDetachedWhileTheWorkflowStillUsesItsId()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        server.AddTool("tool_raw", ShowOrder().ToJson());
        var wf = new Workflow();
        wf.Tool("run", new[] { "tool_raw" });
        var agent = new Agent("A", new AgentOptions { Prompt = "p", Workflow = wf });
        var created = await client.Agents.PushAsync(agent);
        var again = await client.Agents.PushAsync(agent, new AgentPushOptions { AgentId = created.AgentId });
        Assert.That(again.Tools, Is.Empty);
    }

    [Test]
    public async Task KeepsAProjectToolsUnmodeledFieldsWhenTheSameToolIsRebuiltInCode()
    {
        var server = new FakeAgentServer();
        var client = server.Client();
        var project = AgentProject.FromFiles(new Dictionary<string, string>());
        await client.Agents.PushAsync(SupportAgent(), new AgentPushOptions { Project = project });
        var files = new Dictionary<string, string>(project.ToFiles());
        var withExtra = JsonNode.Parse(files["tool_configs/get_order.json"])!.AsObject();
        withExtra["future_field"] = 1;
        files["tool_configs/get_order.json"] = ProjectFormat.FormatIndex(withExtra);
        server.Tools["tool_new_2"].Config = (JsonObject)withExtra.DeepClone();

        var reloaded = AgentProject.FromFiles(files);
        var result = await client.Agents.PushAsync(SupportAgent(), new AgentPushOptions { Project = reloaded });
        Assert.That(result.Tools["get_order"].Action, Is.EqualTo(ToolPushAction.Unchanged));
        Assert.That(JsonNode.Parse(reloaded.ToFiles()["tool_configs/get_order.json"])!["future_field"]!.GetValue<int>(), Is.EqualTo(1));
    }

    [Test]
    public async Task PassesRequestOptionsToEveryRequest()
    {
        var server = new FakeAgentServer();
        var options = new RequestOptions { AdditionalHeaders = new[] { new KeyValuePair<string, string?>("x-test", "1") } };
        var seen = new List<string?>();
        var client = new ElevenLabsClient(
            "test",
            new ClientOptions { BaseUrl = "https://api.test/", HttpClient = new HttpClient(new HeaderSpy(server, seen)), MaxRetries = 0 }
        );
        var created = await client.Agents.PushAsync(SupportAgent(), options: options);
        await client.Agents.PushAsync(SupportAgent(), new AgentPushOptions { AgentId = created.AgentId }, options);
        await client.Agents.PullAsync(created.AgentId, options: options);
        Assert.That(seen, Has.Count.EqualTo(server.Calls.Count));
        Assert.That(seen, Is.All.EqualTo("1"));
    }

    private sealed class HeaderSpy(HttpMessageHandler inner, List<string?> seen) : DelegatingHandler(inner)
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            seen.Add(request.Headers.TryGetValues("x-test", out var values) ? values.Single() : null);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
