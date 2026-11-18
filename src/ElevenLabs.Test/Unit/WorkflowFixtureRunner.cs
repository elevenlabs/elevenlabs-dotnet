using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;

namespace ElevenLabs.Tests;

/// <summary>
/// Interprets the language-neutral fixtures in <c>docs/agents-as-code/fixtures</c> through the .NET builder.
/// See <c>workflow-spec.md</c>, "Fixtures". Mirrors the reference runner (elevenlabs-js fixtureRunner.ts).
/// </summary>
internal static class WorkflowFixtureRunner
{
    public sealed class FixtureResult
    {
        public string? Json { get; set; }
        public List<string>? Errors { get; set; }
    }

    public static FixtureResult Run(JsonObject fixture)
    {
        Workflow wf;
        if (fixture["from"] is JsonNode from)
        {
            wf = Workflow.FromJson(from);
        }
        else
        {
            var psl = (fixture["workflow"] as JsonObject)?["preventSubagentLoops"] is JsonNode p
                ? p.GetValue<bool>()
                : (bool?)null;
            wf = new Workflow(psl);
        }

        RunOps(wf, fixture["ops"] as JsonArray ?? new JsonArray(), wf);

        try
        {
            return new FixtureResult { Json = wf.ToJsonString() };
        }
        catch (WorkflowValidationException ex)
        {
            return new FixtureResult { Errors = ex.Issues.Select(issue => issue.Code).ToList() };
        }
    }

    private static WorkflowNode? RunOps(Workflow wf, JsonArray ops, WorkflowChain first)
    {
        WorkflowChain previous = first;
        WorkflowNode? result = null;

        foreach (var opNode in ops)
        {
            var op = (JsonObject)opNode!;
            var kind = op["op"]!.GetValue<string>();

            switch (kind)
            {
                case "update":
                    wf.Node(Str(op["node"])!).Update(ParseUpdate(op["options"] as JsonObject));
                    continue;
                case "remove":
                    wf.Remove(Str(op["node"])!);
                    continue;
                case "onResult":
                {
                    var node = op["at"] == null ? (WorkflowNode)previous : wf.Node(Str(op["at"])!);
                    var successOps = op["success"] as JsonArray;
                    var failureOps = op["failure"] as JsonArray;
                    node.OnResult(
                        success: successOps == null ? null : branch => RunOps(wf, successOps, branch),
                        failure: failureOps == null ? null : branch => RunOps(wf, failureOps, branch)
                    );
                    continue;
                }
                case "insertBetween":
                {
                    var innerOps = op["ops"] as JsonArray ?? new JsonArray();
                    wf.InsertBetween(
                        Str(op["source"])!,
                        Str(op["target"])!,
                        fromBranch => RunOps(wf, innerOps, fromBranch)
                    );
                    continue;
                }
            }

            WorkflowChain at =
                op["at"] == null ? previous
                : Str(op["at"]) == "$start" ? wf
                : wf.Node(Str(op["at"])!);

            if (op["when"] != null)
            {
                var back = op["back"] == null ? null : ToCondition(op["back"]!);
                at = When(at, ToCondition(op["when"]!), back);
            }
            else if (op["onSuccess"] is JsonNode s && s.GetValue<bool>())
            {
                at = ((WorkflowNode)at).OnSuccess();
            }
            else if (op["onFailure"] is JsonNode f && f.GetValue<bool>())
            {
                at = ((WorkflowNode)at).OnFailure();
            }

            switch (kind)
            {
                case "converse":
                    result = at.Converse(Str(op["id"])!, Str(op["prompt"])!, ParseConverse(op["options"] as JsonObject));
                    break;
                case "tool":
                    result = at.Tool(Str(op["id"])!, ToStringList(op["toolIds"])!, ParseTool(op["options"] as JsonObject));
                    break;
                case "transfer":
                    result = at.Transfer(
                        Str(op["id"])!,
                        ParseDestination((JsonObject)op["destination"]!),
                        ParseTransfer(op["options"] as JsonObject)
                    );
                    break;
                case "end":
                    result = at.End(ParseEnd(op["options"] as JsonObject));
                    break;
                case "goTo":
                    result = at.GoTo(Str(op["target"])!, op["back"] == null ? null : ToCondition(op["back"]!));
                    break;
            }
            previous = result!;
        }
        return result;
    }

    private static WorkflowBranch When(WorkflowChain at, Condition condition, Condition? back) =>
        at switch
        {
            Workflow wf => wf.When(condition, back),
            WorkflowNode node => node.When(condition, back),
            _ => throw new InvalidOperationException("when() is only valid on the workflow or a node"),
        };

    private static Condition ToCondition(JsonNode raw)
    {
        if (raw is JsonValue value && value.TryGetValue<string>(out var text))
        {
            return Condition.Llm(text);
        }
        var obj = (JsonObject)raw;
        if (obj.ContainsKey("llm"))
        {
            return Condition.Llm(obj["llm"]!.GetValue<string>(), Str(obj["label"]));
        }
        return Condition.Expr(Expr.FromModel(obj["expr"]!), Str(obj["label"]));
    }

    private static Destination ParseDestination(JsonObject raw)
    {
        if (raw.ContainsKey("phone"))
        {
            return Destination.Phone(raw["phone"]!.GetValue<string>());
        }
        if (raw.ContainsKey("phoneVariable"))
        {
            return Destination.PhoneVariable(raw["phoneVariable"]!.GetValue<string>());
        }
        if (raw.ContainsKey("sip"))
        {
            return Destination.Sip(raw["sip"]!.GetValue<string>());
        }
        if (raw.ContainsKey("sipVariable"))
        {
            return Destination.SipVariable(raw["sipVariable"]!.GetValue<string>());
        }
        return Destination.Agent(raw["agent"]!.GetValue<string>(), Str(raw["nodeId"]));
    }

    private static ConverseOptions ParseConverse(JsonObject? o)
    {
        var opt = new ConverseOptions();
        if (o == null)
        {
            return opt;
        }
        opt.Position = Clone(o["position"]);
        opt.Label = Str(o["label"]);
        opt.ToolIds = ToStringList(o["toolIds"]);
        opt.KnowledgeBase = Clone(o["knowledgeBase"]);
        opt.ConversationConfig = Clone(o["conversationConfig"]);
        opt.EntryBehavior = Str(o["entryBehavior"]);
        return opt;
    }

    private static ToolOptions ParseTool(JsonObject? o)
    {
        var opt = new ToolOptions();
        if (o == null)
        {
            return opt;
        }
        opt.Position = Clone(o["position"]);
        opt.SchemaOverrides = ParseSchemaOverrides(o["schemaOverrides"] as JsonObject);
        return opt;
    }

    private static TransferOptions ParseTransfer(JsonObject? o)
    {
        var opt = new TransferOptions();
        if (o == null)
        {
            return opt;
        }
        opt.Position = Clone(o["position"]);
        opt.TransferType = Str(o["transferType"]);
        opt.CustomSipHeaders = Clone(o["customSipHeaders"]);
        opt.SipReferPlayDialtone = Bool(o["sipReferPlayDialtone"]);
        opt.Uui = Clone(o["uui"]);
        opt.PostDialDigits = Clone(o["postDialDigits"]);
        opt.DelayMs = Int(o["delayMs"]);
        opt.TransferMessage = Str(o["transferMessage"]);
        opt.EnableTransferredAgentFirstMessage = Bool(o["enableTransferredAgentFirstMessage"]);
        opt.PreserveClientTtsOverrides = Bool(o["preserveClientTtsOverrides"]);
        opt.PreserveVoiceSettings = Bool(o["preserveVoiceSettings"]);
        return opt;
    }

    private static EndOptions ParseEnd(JsonObject? o)
    {
        var opt = new EndOptions();
        if (o == null)
        {
            return opt;
        }
        opt.Position = Clone(o["position"]);
        opt.Id = Str(o["id"]);
        return opt;
    }

    private static NodeUpdate ParseUpdate(JsonObject? o)
    {
        var opt = new NodeUpdate();
        if (o == null)
        {
            return opt;
        }
        opt.Prompt = Str(o["prompt"]);
        opt.ToolIds = ToStringList(o["toolIds"]);
        opt.Destination = o["destination"] is JsonObject d ? ParseDestination(d) : null;
        opt.Position = Clone(o["position"]);
        opt.Label = Str(o["label"]);
        opt.KnowledgeBase = Clone(o["knowledgeBase"]);
        opt.ConversationConfig = Clone(o["conversationConfig"]);
        opt.EntryBehavior = Str(o["entryBehavior"]);
        opt.SchemaOverrides = ParseSchemaOverrides(o["schemaOverrides"] as JsonObject);
        opt.TransferType = Str(o["transferType"]);
        opt.CustomSipHeaders = Clone(o["customSipHeaders"]);
        opt.SipReferPlayDialtone = Bool(o["sipReferPlayDialtone"]);
        opt.Uui = Clone(o["uui"]);
        opt.PostDialDigits = Clone(o["postDialDigits"]);
        opt.DelayMs = Int(o["delayMs"]);
        opt.TransferMessage = Str(o["transferMessage"]);
        opt.EnableTransferredAgentFirstMessage = Bool(o["enableTransferredAgentFirstMessage"]);
        opt.PreserveClientTtsOverrides = Bool(o["preserveClientTtsOverrides"]);
        opt.PreserveVoiceSettings = Bool(o["preserveVoiceSettings"]);
        return opt;
    }

    private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, JsonNode>>? ParseSchemaOverrides(
        JsonObject? so
    )
    {
        if (so == null)
        {
            return null;
        }
        var outer = new Dictionary<string, IReadOnlyDictionary<string, JsonNode>>();
        foreach (var tool in so)
        {
            var inner = new Dictionary<string, JsonNode>();
            foreach (var path in (JsonObject)tool.Value!)
            {
                inner[path.Key] = path.Value!.DeepClone();
            }
            outer[tool.Key] = inner;
        }
        return outer;
    }

    private static IReadOnlyList<string>? ToStringList(JsonNode? node) =>
        node is JsonArray arr ? arr.Select(n => n!.GetValue<string>()).ToList() : null;

    private static string? Str(JsonNode? node) => (node as JsonValue)?.GetValue<string>();

    private static bool? Bool(JsonNode? node) => node == null ? (bool?)null : node.GetValue<bool>();

    private static int? Int(JsonNode? node) => node == null ? (int?)null : node.GetValue<int>();

    private static JsonNode? Clone(JsonNode? node) => node?.DeepClone();
}
