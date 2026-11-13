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
using OneOf;

namespace ElevenLabs;

[Serializable]
public record McpToolConfigOverrideOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The name of the MCP tool</value>
    [JsonPropertyName("tool_name")]
    public required string ToolName { get; set; }

    /// <value>DEPRECATED: use `pre_tool_speech` instead. If set, overrides the server's force_pre_tool_speech setting for this tool.</value>
    [JsonPropertyName("force_pre_tool_speech")]
    public bool? ForcePreToolSpeech { get; set; }

    /// <value>If set, overrides the server's pre_tool_speech setting for this tool.</value>
    [JsonPropertyName("pre_tool_speech")]
    public PreToolSpeechMode? PreToolSpeech { get; set; }

    /// <value>DEPRECATED: use `interruption_mode` instead. If set, overrides the server's disable_interruptions setting for this tool.</value>
    [JsonPropertyName("disable_interruptions")]
    public bool? DisableInterruptions { get; set; }

    /// <value>If set, overrides the server's interruption_mode setting for this tool.</value>
    [JsonPropertyName("interruption_mode")]
    public ToolInterruptionMode? InterruptionMode { get; set; }

    /// <value>Overrides the server's tool_call_sound setting for this tool. A sound name plays that sound; 'off' overrides to no sound (silence); null means do not override (inherit the server default).</value>
    [JsonPropertyName("tool_call_sound")]
    public OneOf<ToolCallSoundType, ToolCallSound21>? ToolCallSound { get; set; }

    /// <value>If set, overrides the server's tool_call_sound_behavior setting for this tool</value>
    [JsonPropertyName("tool_call_sound_behavior")]
    public ToolCallSoundBehavior? ToolCallSoundBehavior { get; set; }

    /// <value>If set, overrides the server's execution_mode setting for this tool</value>
    [JsonPropertyName("execution_mode")]
    public ToolExecutionMode? ExecutionMode { get; set; }

    /// <value>If set, overrides the server's response timeout for this MCP tool (seconds).</value>
    [JsonPropertyName("response_timeout_secs")]
    public int? ResponseTimeoutSecs { get; set; }

    /// <value>Dynamic variable assignments for this MCP tool</value>
    [JsonPropertyName("assignments")]
    public IEnumerable<DynamicVariableAssignment>? Assignments { get; set; }

    /// <value>Mapping of json path to input override configuration</value>
    [JsonPropertyName("input_overrides")]
    public Dictionary<
        string,
        McpToolConfigOverrideOutputInputOverrides
    >? InputOverrides { get; set; }

    /// <value>Mock responses with optional parameter conditions. Evaluated top-to-bottom; first match wins.</value>
    [JsonPropertyName("response_mocks")]
    public IEnumerable<ToolResponseMockConfigOutput>? ResponseMocks { get; set; }

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
    public virtual bool Equals(McpToolConfigOverrideOutput? other)
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
            && ValueEquality.AreEqual(ToolName, other.ToolName)
            && ValueEquality.AreEqual(ForcePreToolSpeech, other.ForcePreToolSpeech)
            && ValueEquality.AreEqual(PreToolSpeech, other.PreToolSpeech)
            && ValueEquality.AreEqual(DisableInterruptions, other.DisableInterruptions)
            && ValueEquality.AreEqual(InterruptionMode, other.InterruptionMode)
            && ValueEquality.AreEqual(ToolCallSound, other.ToolCallSound)
            && ValueEquality.AreEqual(ToolCallSoundBehavior, other.ToolCallSoundBehavior)
            && ValueEquality.AreEqual(ExecutionMode, other.ExecutionMode)
            && ValueEquality.AreEqual(ResponseTimeoutSecs, other.ResponseTimeoutSecs)
            && ValueEquality.AreEqual(Assignments, other.Assignments)
            && ValueEquality.AreEqual(InputOverrides, other.InputOverrides)
            && ValueEquality.AreEqual(ResponseMocks, other.ResponseMocks)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ForcePreToolSpeech);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreToolSpeech);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableInterruptions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InterruptionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallSound);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallSoundBehavior);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExecutionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseTimeoutSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Assignments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InputOverrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseMocks);
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
