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
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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

[Serializable]
public record AgentToolRequestClientEventData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("tool_name")]
    public required string ToolName { get; set; }

    [JsonPropertyName("tool_call_id")]
    public required string ToolCallId { get; set; }

    [JsonPropertyName("tool_type")]
    public required string ToolType { get; set; }

    [JsonPropertyName("event_id")]
    public required int EventId { get; set; }

    [JsonPropertyName("expects_response")]
    public required bool ExpectsResponse { get; set; }

    [JsonPropertyName("disable_interruptions")]
    public required bool DisableInterruptions { get; set; }

    [JsonPropertyName("response_timeout_secs")]
    public required int ResponseTimeoutSecs { get; set; }

    [JsonPropertyName("execution_mode")]
    public required string ExecutionMode { get; set; }

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
    public virtual bool Equals(AgentToolRequestClientEventData? other)
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
            && ValueEquality.AreEqual(ToolCallId, other.ToolCallId)
            && ValueEquality.AreEqual(ToolType, other.ToolType)
            && ValueEquality.AreEqual(EventId, other.EventId)
            && ValueEquality.AreEqual(ExpectsResponse, other.ExpectsResponse)
            && ValueEquality.AreEqual(DisableInterruptions, other.DisableInterruptions)
            && ValueEquality.AreEqual(ResponseTimeoutSecs, other.ResponseTimeoutSecs)
            && ValueEquality.AreEqual(ExecutionMode, other.ExecutionMode)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EventId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExpectsResponse);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableInterruptions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseTimeoutSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExecutionMode);
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
