using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.SpeechEngine;
using ElevenLabs.Studio;
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>An MCP tool configuration that can be used to call MCP servers</summary>
[Serializable]
public record McpToolConfigInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public McpToolConfigInputType? Type { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>Description of when the tool should be used and what it does.</value>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <value>The maximum time in seconds to wait for the MCP tool call to complete. Must be between 5 and 300 seconds (inclusive).</value>
    [JsonPropertyName("response_timeout_secs")]
    public int? ResponseTimeoutSecs { get; set; }

    /// <value>DEPRECATED: use `interruption_mode` instead. If true, the user will not be able to interrupt the agent while this tool is running.</value>
    [JsonPropertyName("disable_interruptions")]
    public bool? DisableInterruptions { get; set; }

    [JsonPropertyName("interruption_mode")]
    public ToolInterruptionMode? InterruptionMode { get; set; }

    /// <value>DEPRECATED: use `pre_tool_speech` instead. If true, the agent will speak before the tool call.</value>
    [JsonPropertyName("force_pre_tool_speech")]
    public bool? ForcePreToolSpeech { get; set; }

    [JsonPropertyName("pre_tool_speech")]
    public PreToolSpeechMode? PreToolSpeech { get; set; }

    /// <value>Configuration for extracting values from tool responses and assigning them to dynamic variables</value>
    [JsonPropertyName("assignments")]
    public IEnumerable<DynamicVariableAssignment>? Assignments { get; set; }

    /// <value>Predefined tool call sound type to play during tool execution. If not specified, no tool call sound will be played.</value>
    [JsonPropertyName("tool_call_sound")]
    public ToolCallSoundType? ToolCallSound { get; set; }

    /// <value>Determines how the tool call sound should be played.</value>
    [JsonPropertyName("tool_call_sound_behavior")]
    public ToolCallSoundBehavior? ToolCallSoundBehavior { get; set; }

    /// <value>Controls how tool errors are processed before being shared with the agent.</value>
    [JsonPropertyName("tool_error_handling_mode")]
    public ToolErrorHandlingMode? ToolErrorHandlingMode { get; set; }

    [JsonPropertyName("integration_type")]
    public required IntegrationType IntegrationType { get; set; }

    /// <value>Schema for any parameters the LLM needs to provide to the MCP tool.</value>
    [JsonPropertyName("parameters")]
    public ObjectJsonSchemaPropertyInput? Parameters { get; set; }

    /// <value>Defines the MCP server-level approval policy for tool execution.</value>
    [JsonPropertyName("approval_policy")]
    public McpApprovalPolicy? ApprovalPolicy { get; set; }

    /// <value>The name of the MCP tool to call</value>
    [JsonPropertyName("mcp_tool_name")]
    public required string McpToolName { get; set; }

    /// <value>The description of the MCP tool to call</value>
    [JsonPropertyName("mcp_tool_description")]
    public required string McpToolDescription { get; set; }

    /// <value>The id of the MCP server to call</value>
    [JsonPropertyName("mcp_server_id")]
    public required string McpServerId { get; set; }

    /// <value>The name of the MCP server to call</value>
    [JsonPropertyName("mcp_server_name")]
    public required string McpServerName { get; set; }

    /// <value>Original inputSchema dict for consistent hashing</value>
    [JsonPropertyName("mcp_input_schema")]
    public Dictionary<string, object?>? McpInputSchema { get; set; }

    [JsonPropertyName("execution_mode")]
    public ToolExecutionMode? ExecutionMode { get; set; }

    /// <value>Input parameter overrides for this tool</value>
    [JsonPropertyName("input_overrides")]
    public Dictionary<string, McpToolConfigInputInputOverrides>? InputOverrides { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    /// <remarks>
    /// Written out rather than synthesized. A record's generated Equals compares every instance
    /// field, and `_extensionData` is a fresh Dictionary per instance compared by REFERENCE, so two
    /// identical models were never equal — silently defeating ==, Distinct(), HashSet membership,
    /// dictionary keys and test assertions for every model in the SDK. Excluding it loses nothing:
    /// it is a transient deserialization sink whose contents are copied into
    /// AdditionalProperties, which IS compared here.
    /// </remarks>
    public virtual bool Equals(McpToolConfigInput? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // The synthesized record Equals compares EqualityContract, so a base instance never equals a
        // derived one. Hand-writing Equals drops that unless it is restated.
        if (EqualityContract != other.EqualityContract)
        {
            return false;
        }
        // Declared properties first: the additional-properties comparison walks a dictionary and
        // allocates a string per entry, and is the least likely of the three to differ, so letting
        // the cheap scalar comparisons short-circuit ahead of it matters for Distinct/HashSet over
        // large collections. Anchored on `true` so a model with no declared properties still emits
        // a valid expression.
        return true
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(ResponseTimeoutSecs, other.ResponseTimeoutSecs)
            && ValueEquality.AreEqual(DisableInterruptions, other.DisableInterruptions)
            && ValueEquality.AreEqual(InterruptionMode, other.InterruptionMode)
            && ValueEquality.AreEqual(ForcePreToolSpeech, other.ForcePreToolSpeech)
            && ValueEquality.AreEqual(PreToolSpeech, other.PreToolSpeech)
            && ValueEquality.AreEqual(Assignments, other.Assignments)
            && ValueEquality.AreEqual(ToolCallSound, other.ToolCallSound)
            && ValueEquality.AreEqual(ToolCallSoundBehavior, other.ToolCallSoundBehavior)
            && ValueEquality.AreEqual(ToolErrorHandlingMode, other.ToolErrorHandlingMode)
            && ValueEquality.AreEqual(IntegrationType, other.IntegrationType)
            && ValueEquality.AreEqual(Parameters, other.Parameters)
            && ValueEquality.AreEqual(ApprovalPolicy, other.ApprovalPolicy)
            && ValueEquality.AreEqual(McpToolName, other.McpToolName)
            && ValueEquality.AreEqual(McpToolDescription, other.McpToolDescription)
            && ValueEquality.AreEqual(McpServerId, other.McpServerId)
            && ValueEquality.AreEqual(McpServerName, other.McpServerName)
            && ValueEquality.AreEqual(McpInputSchema, other.McpInputSchema)
            && ValueEquality.AreEqual(ExecutionMode, other.ExecutionMode)
            && ValueEquality.AreEqual(InputOverrides, other.InputOverrides)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseTimeoutSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableInterruptions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InterruptionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ForcePreToolSpeech);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreToolSpeech);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Assignments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallSound);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallSoundBehavior);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolErrorHandlingMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntegrationType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Parameters);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApprovalPolicy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(McpToolName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(McpToolDescription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(McpServerId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(McpServerName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(McpInputSchema);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExecutionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InputOverrides);
            hash = (hash * 31) + AdditionalProperties.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
