using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

// Option keys are the canonical names from the cross-SDK spec, in PascalCase. Nested values (position, knowledge
// base, conversation config, SIP headers, schema overrides, ...) are taken in API wire format as JsonNode, so the
// builder stays decoupled from the generated request types while still round-tripping their JSON exactly.

/// <summary>Options shared by every node kind.</summary>
public abstract class NodeOptions
{
    /// <summary>Position in the workflow editor (wire format, e.g. <c>{ "x": 300, "y": 0 }</c>). Nodes without one are laid out automatically.</summary>
    public JsonNode? Position { get; set; }
}

/// <summary>Options for a <c>Converse()</c> (subagent) node.</summary>
public sealed class ConverseOptions : NodeOptions
{
    /// <summary>Name shown in the workflow editor. Defaults to the node id.</summary>
    public string? Label { get; set; }

    /// <summary>Tools available to this subagent, on top of the agent's own, by id.</summary>
    public IReadOnlyList<string>? ToolIds { get; set; }

    /// <summary>
    /// More tools for this subagent, after <see cref="ToolIds"/>: <c>Tool</c> objects, whose ids are filled in when
    /// the workflow is built with <c>toolIds</c> (as <c>Agents.PushAsync()</c> does), or ids.
    /// </summary>
    public IReadOnlyList<ToolRef>? Tools { get; set; }

    /// <summary>Knowledge base documents available to this subagent (wire format), on top of the agent's own.</summary>
    public JsonNode? KnowledgeBase { get; set; }

    /// <summary>Overrides for the agent's conversation config while this subagent is active (wire format).</summary>
    public JsonNode? ConversationConfig { get; set; }

    /// <summary>When the subagent starts speaking.</summary>
    public string? EntryBehavior { get; set; }
}

/// <summary>Options for a <c>Tool()</c> node.</summary>
public sealed class ToolOptions : NodeOptions
{
    /// <summary>
    /// Parameter overrides per tool id (or tool name, for a <c>Tool</c> object), keyed by dotted parameter path
    /// (wire-format values).
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyDictionary<string, JsonNode>>? SchemaOverrides { get; set; }
}

/// <summary>Options for a <c>Transfer()</c> node. Phone/SIP options apply to phone and SIP transfers; the rest to agent transfers.</summary>
public sealed class TransferOptions : NodeOptions
{
    public string? TransferType { get; set; }
    public JsonNode? CustomSipHeaders { get; set; }
    public bool? SipReferPlayDialtone { get; set; }
    public JsonNode? Uui { get; set; }
    public JsonNode? PostDialDigits { get; set; }
    public int? DelayMs { get; set; }
    public string? TransferMessage { get; set; }
    public bool? EnableTransferredAgentFirstMessage { get; set; }
    public bool? PreserveClientTtsOverrides { get; set; }
    public bool? PreserveVoiceSettings { get; set; }
}

/// <summary>Options for an <c>End()</c> node.</summary>
public sealed class EndOptions : NodeOptions
{
    /// <summary>Defaults to <c>"end"</c>, which every <c>End()</c> without an id shares.</summary>
    public string? Id { get; set; }
}

/// <summary>Fields accepted by <see cref="WorkflowNode.Update"/>. Only the fields that apply to the node's kind may be set.</summary>
public sealed class NodeUpdate : NodeOptions
{
    /// <summary>Subagent nodes: the instructions added to the agent's prompt.</summary>
    public string? Prompt { get; set; }

    /// <summary>Subagent nodes: extra tools. Tool nodes: the tools to run. By id.</summary>
    public IReadOnlyList<string>? ToolIds { get; set; }

    /// <summary>
    /// Like <see cref="ToolIds"/>, as <c>Tool</c> objects or ids, after <see cref="ToolIds"/>. Setting either one
    /// replaces the node's tools.
    /// </summary>
    public IReadOnlyList<ToolRef>? Tools { get; set; }

    /// <summary>Transfer nodes: where to transfer to.</summary>
    public Destination? Destination { get; set; }

    public string? Label { get; set; }
    public JsonNode? KnowledgeBase { get; set; }
    public JsonNode? ConversationConfig { get; set; }
    public string? EntryBehavior { get; set; }
    public IReadOnlyDictionary<string, IReadOnlyDictionary<string, JsonNode>>? SchemaOverrides { get; set; }
    public string? TransferType { get; set; }
    public JsonNode? CustomSipHeaders { get; set; }
    public bool? SipReferPlayDialtone { get; set; }
    public JsonNode? Uui { get; set; }
    public JsonNode? PostDialDigits { get; set; }
    public int? DelayMs { get; set; }
    public string? TransferMessage { get; set; }
    public bool? EnableTransferredAgentFirstMessage { get; set; }
    public bool? PreserveClientTtsOverrides { get; set; }
    public bool? PreserveVoiceSettings { get; set; }
}
