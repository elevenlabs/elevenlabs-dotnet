using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// The verbs that add a node and connect it to the current point in the workflow. Each returns the new node, so
/// linear flows chain: <c>wf.Converse(...).When("...").Tool(...)</c>.
/// </summary>
public abstract class WorkflowChain
{
    private protected readonly WorkflowGraph Graph;

    private protected WorkflowChain(WorkflowGraph graph) => Graph = graph;

    private protected abstract EdgeOrigin Origin();

    /// <summary>The agent holds a conversation with <paramref name="prompt"/> added to its instructions, until an outgoing condition holds. A subagent node.</summary>
    public WorkflowNode Converse(string id, string prompt, ConverseOptions? options = null)
    {
        options ??= new ConverseOptions();
        var model = new JsonObject
        {
            ["type"] = "override_agent",
            ["label"] = id,
            ["additional_prompt"] = prompt,
        };
        var rest = new Dictionary<string, JsonNode?>();
        PutNode(rest, "position", options.Position);
        PutStr(rest, "label", options.Label);
        PutNode(rest, "knowledge_base", options.KnowledgeBase);
        PutNode(rest, "conversation_config", options.ConversationConfig);
        PutStr(rest, "entry_behavior", options.EntryBehavior);
        var applied = Graph.ApplyOptions(id, model, null, options.ToolIds, null, rest);
        Graph.AddNode(id, applied);
        return Connect(id, null);
    }

    /// <summary>Runs the tools in parallel. Branch on the result with <c>OnResult()</c>, or <c>OnSuccess()</c> and <c>OnFailure()</c>.</summary>
    public WorkflowNode Tool(string id, IEnumerable<string> toolIds, ToolOptions? options = null)
    {
        options ??= new ToolOptions();
        var rest = new Dictionary<string, JsonNode?>();
        PutNode(rest, "position", options.Position);
        var applied = Graph.ApplyOptions(
            id,
            new JsonObject { ["type"] = "tool" },
            null,
            new List<string>(toolIds),
            SchemaOverridesToWire(options.SchemaOverrides),
            rest
        );
        Graph.AddNode(id, applied);
        return Connect(id, null);
    }

    /// <summary>Transfers the conversation to a phone number, SIP URI or another agent.</summary>
    public WorkflowNode Transfer(string id, Destination destination, TransferOptions? options = null)
    {
        options ??= new TransferOptions();
        var rest = new Dictionary<string, JsonNode?>();
        PutNode(rest, "position", options.Position);
        PutStr(rest, "transfer_type", options.TransferType);
        PutNode(rest, "custom_sip_headers", options.CustomSipHeaders);
        PutBool(rest, "sip_refer_play_dialtone", options.SipReferPlayDialtone);
        PutNode(rest, "uui", options.Uui);
        PutNode(rest, "post_dial_digits", options.PostDialDigits);
        PutInt(rest, "delay_ms", options.DelayMs);
        PutStr(rest, "transfer_message", options.TransferMessage);
        PutBool(rest, "enable_transferred_agent_first_message", options.EnableTransferredAgentFirstMessage);
        PutBool(rest, "preserve_client_tts_overrides", options.PreserveClientTtsOverrides);
        PutBool(rest, "preserve_voice_settings", options.PreserveVoiceSettings);
        var applied = Graph.ApplyOptions(id, destination.ToWire(), null, null, null, rest);
        Graph.AddNode(id, applied);
        return Connect(id, null);
    }

    /// <summary>Ends the conversation. Every <c>End()</c> without an id shares one end node, <c>"end"</c>.</summary>
    public WorkflowNode End(EndOptions? options = null)
    {
        options ??= new EndOptions();
        var id = options.Id ?? "end";
        var rest = new Dictionary<string, JsonNode?>();
        PutNode(rest, "position", options.Position);
        var applied = Graph.ApplyOptions(id, new JsonObject { ["type"] = "end" }, null, null, null, rest);
        Graph.AddNode(id, applied);
        return Connect(id, null);
    }

    /// <summary>Moves the conversation to a node that already exists (or will by <c>Build()</c>), for merges and loops.</summary>
    public WorkflowNode GoTo(string target, Condition? back = null) => Connect(target, back);

    /// <summary>Moves the conversation to an existing node, for merges and loops.</summary>
    public WorkflowNode GoTo(WorkflowNode target, Condition? back = null) => Connect(target.Id, back);

    private WorkflowNode Connect(string target, Condition? back)
    {
        var origin = Origin();
        Graph.Edges.Add(
            new GraphEdge(origin.Source, target)
            {
                ForwardCondition = origin.ForwardCondition,
                BackwardCondition = back == null ? origin.BackwardCondition : back.ToWire(),
            }
        );
        return new WorkflowNode(Graph, target, origin.Source);
    }

    private protected static WorkflowBranch Branch(WorkflowGraph graph, string source, Condition condition, Condition? back) =>
        new(graph, new EdgeOrigin(source, condition.ToWire(), back?.ToWire()));

    private protected static JsonObject? SchemaOverridesToWire(
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, JsonNode>>? schemaOverrides
    )
    {
        if (schemaOverrides == null)
        {
            return null;
        }
        var obj = new JsonObject();
        foreach (var tool in schemaOverrides)
        {
            var paths = new JsonObject();
            foreach (var path in tool.Value)
            {
                paths[path.Key] = path.Value.DeepClone();
            }
            obj[tool.Key] = paths;
        }
        return obj;
    }

    private protected static void PutNode(Dictionary<string, JsonNode?> d, string key, JsonNode? value)
    {
        if (value != null)
        {
            d[key] = value;
        }
    }

    private protected static void PutStr(Dictionary<string, JsonNode?> d, string key, string? value)
    {
        if (value != null)
        {
            d[key] = JsonValue.Create(value);
        }
    }

    private protected static void PutBool(Dictionary<string, JsonNode?> d, string key, bool? value)
    {
        if (value != null)
        {
            d[key] = JsonValue.Create(value.Value);
        }
    }

    private protected static void PutInt(Dictionary<string, JsonNode?> d, string key, int? value)
    {
        if (value != null)
        {
            d[key] = JsonValue.Create(value.Value);
        }
    }
}

/// <summary>A pending edge out of a node, opened by <c>When()</c>, <c>OnSuccess()</c> or <c>OnFailure()</c>. Carries the node verbs and <c>GoTo</c>.</summary>
public sealed class WorkflowBranch : WorkflowChain
{
    private readonly EdgeOrigin _from;

    internal WorkflowBranch(WorkflowGraph graph, EdgeOrigin origin)
        : base(graph) => _from = origin;

    private protected override EdgeOrigin Origin() => _from;
}

/// <summary>A handle to one node in a workflow. Handles are cheap: all state lives in the <see cref="Workflow"/>.</summary>
public sealed class WorkflowNode : WorkflowChain
{
    private readonly string? _parentId;

    internal WorkflowNode(WorkflowGraph graph, string id, string? parentId = null)
        : base(graph)
    {
        Id = id;
        _parentId = parentId;
    }

    /// <summary>This node's id.</summary>
    public string Id { get; }

    /// <summary>The API node type, for example <c>"override_agent"</c> or <c>"tool"</c>.</summary>
    public string? Type =>
        Graph.ContainsNode(Id) ? (Graph.GetNode(Id)["type"] as JsonValue)?.GetValue<string>() : null;

    /// <summary>Opens a branch that is followed when <paramref name="condition"/> holds.</summary>
    public WorkflowBranch When(Condition condition, Condition? back = null) => Branch(Graph, Id, condition, back);

    /// <summary>Opens a branch that is followed when the LLM judges <paramref name="condition"/> to be true.</summary>
    public WorkflowBranch When(string condition, Condition? back = null) => When(Condition.Llm(condition), back);

    /// <summary>Opens a branch that is followed when <paramref name="condition"/> evaluates to true.</summary>
    public WorkflowBranch When(Expr condition, Condition? back = null) => When(Condition.Expr(condition), back);

    /// <summary>Opens the branch followed when every tool in this tool node succeeded.</summary>
    public WorkflowBranch OnSuccess(string? label = null) => Branch(Graph, Id, Condition.Success(label), null);

    /// <summary>Opens the branch followed when any tool in this tool node failed.</summary>
    public WorkflowBranch OnFailure(string? label = null) => Branch(Graph, Id, Condition.Failure(label), null);

    /// <summary>
    /// Routes both outcomes of this tool node in one place. Same as calling <c>OnSuccess()</c> and then
    /// <c>OnFailure()</c>, so the success edge always comes first. Either may be omitted. Returns this node.
    /// </summary>
    public WorkflowNode OnResult(Action<WorkflowBranch>? success = null, Action<WorkflowBranch>? failure = null)
    {
        success?.Invoke(OnSuccess());
        failure?.Invoke(OnFailure());
        return this;
    }

    /// <summary>
    /// The node this handle was chained from, so a whole workflow can be written as one chain. For a handle from
    /// <c>Node(id)</c>, the source of the first edge into the node. The start node if there is neither.
    /// </summary>
    public WorkflowNode Up()
    {
        var parent = _parentId;
        if (parent == null)
        {
            foreach (var edge in Graph.Edges)
            {
                if (edge.Target == Id && edge.Source != Id)
                {
                    parent = edge.Source;
                    break;
                }
            }
        }
        return new WorkflowNode(Graph, parent ?? Graph.StartId);
    }

    /// <summary>Changes this node's options. Only fields that apply to the node's kind may be set; <c>Build()</c> reports the rest.</summary>
    public WorkflowNode Update(NodeUpdate update)
    {
        if (!Graph.ContainsNode(Id))
        {
            Graph.Issue("unknown_node", $"Can't update unknown node \"{Id}\"", Id);
            return this;
        }
        var rest = new Dictionary<string, JsonNode?>();
        PutStr(rest, "prompt", update.Prompt);
        PutNode(rest, "position", update.Position);
        PutStr(rest, "label", update.Label);
        PutNode(rest, "knowledge_base", update.KnowledgeBase);
        PutNode(rest, "conversation_config", update.ConversationConfig);
        PutStr(rest, "entry_behavior", update.EntryBehavior);
        PutStr(rest, "transfer_type", update.TransferType);
        PutNode(rest, "custom_sip_headers", update.CustomSipHeaders);
        PutBool(rest, "sip_refer_play_dialtone", update.SipReferPlayDialtone);
        PutNode(rest, "uui", update.Uui);
        PutNode(rest, "post_dial_digits", update.PostDialDigits);
        PutInt(rest, "delay_ms", update.DelayMs);
        PutStr(rest, "transfer_message", update.TransferMessage);
        PutBool(rest, "enable_transferred_agent_first_message", update.EnableTransferredAgentFirstMessage);
        PutBool(rest, "preserve_client_tts_overrides", update.PreserveClientTtsOverrides);
        PutBool(rest, "preserve_voice_settings", update.PreserveVoiceSettings);
        var applied = Graph.ApplyOptions(
            Id,
            Graph.GetNode(Id),
            update.Destination,
            update.ToolIds,
            SchemaOverridesToWire(update.SchemaOverrides),
            rest
        );
        Graph.SetNode(Id, applied);
        return this;
    }

    private protected override EdgeOrigin Origin() => new(Id, Condition.Always().ToWire());
}
