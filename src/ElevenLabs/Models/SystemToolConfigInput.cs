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

/// <summary>A system tool is a tool that is used to call a system method in the server</summary>
[Serializable]
public record SystemToolConfigInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The type of tool</value>
    [JsonPropertyName("type")]
    public SystemToolConfigInputType? Type { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>Description of when the tool should be used and what it does. Leave empty to use the default description that's optimized for the specific tool type.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>The maximum time in seconds to wait for the tool call to complete.</value>
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

    [JsonPropertyName("params")]
    public required SystemToolConfigInputParams Params { get; set; }

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
    public virtual bool Equals(SystemToolConfigInput? other)
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
            && ValueEquality.AreEqual(Params, other.Params)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Params);
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
