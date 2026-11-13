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

[Serializable]
public record ConversationDeletionSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("deletion_time_unix_secs")]
    public int? DeletionTimeUnixSecs { get; set; }

    [JsonPropertyName("deleted_logs_at_time_unix_secs")]
    public int? DeletedLogsAtTimeUnixSecs { get; set; }

    [JsonPropertyName("deleted_audio_at_time_unix_secs")]
    public int? DeletedAudioAtTimeUnixSecs { get; set; }

    [JsonPropertyName("deleted_transcript_at_time_unix_secs")]
    public int? DeletedTranscriptAtTimeUnixSecs { get; set; }

    [JsonPropertyName("delete_transcript_and_pii")]
    public bool? DeleteTranscriptAndPii { get; set; }

    [JsonPropertyName("delete_audio")]
    public bool? DeleteAudio { get; set; }

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
    public virtual bool Equals(ConversationDeletionSettings? other)
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
            && ValueEquality.AreEqual(DeletionTimeUnixSecs, other.DeletionTimeUnixSecs)
            && ValueEquality.AreEqual(DeletedLogsAtTimeUnixSecs, other.DeletedLogsAtTimeUnixSecs)
            && ValueEquality.AreEqual(DeletedAudioAtTimeUnixSecs, other.DeletedAudioAtTimeUnixSecs)
            && ValueEquality.AreEqual(
                DeletedTranscriptAtTimeUnixSecs,
                other.DeletedTranscriptAtTimeUnixSecs
            )
            && ValueEquality.AreEqual(DeleteTranscriptAndPii, other.DeleteTranscriptAndPii)
            && ValueEquality.AreEqual(DeleteAudio, other.DeleteAudio)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeletionTimeUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeletedLogsAtTimeUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeletedAudioAtTimeUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeletedTranscriptAtTimeUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeleteTranscriptAndPii);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeleteAudio);
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
