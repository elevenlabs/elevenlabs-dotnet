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
public record VoiceSample : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the sample.</value>
    [JsonPropertyName("sample_id")]
    public string? SampleId { get; set; }

    /// <value>The name of the sample file.</value>
    [JsonPropertyName("file_name")]
    public string? FileName { get; set; }

    /// <value>The MIME type of the sample file.</value>
    [JsonPropertyName("mime_type")]
    public string? MimeType { get; set; }

    /// <value>The size of the sample file in bytes.</value>
    [JsonPropertyName("size_bytes")]
    public int? SizeBytes { get; set; }

    /// <value>The hash of the sample file.</value>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    [JsonPropertyName("duration_secs")]
    public double? DurationSecs { get; set; }

    [JsonPropertyName("remove_background_noise")]
    public bool? RemoveBackgroundNoise { get; set; }

    [JsonPropertyName("has_isolated_audio")]
    public bool? HasIsolatedAudio { get; set; }

    [JsonPropertyName("has_isolated_audio_preview")]
    public bool? HasIsolatedAudioPreview { get; set; }

    [JsonPropertyName("speaker_separation")]
    public SpeakerSeparationResponseModel? SpeakerSeparation { get; set; }

    [JsonPropertyName("trim_start")]
    public int? TrimStart { get; set; }

    [JsonPropertyName("trim_end")]
    public int? TrimEnd { get; set; }

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
    public virtual bool Equals(VoiceSample? other)
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
            && ValueEquality.AreEqual(SampleId, other.SampleId)
            && ValueEquality.AreEqual(FileName, other.FileName)
            && ValueEquality.AreEqual(MimeType, other.MimeType)
            && ValueEquality.AreEqual(SizeBytes, other.SizeBytes)
            && ValueEquality.AreEqual(Hash, other.Hash)
            && ValueEquality.AreEqual(DurationSecs, other.DurationSecs)
            && ValueEquality.AreEqual(RemoveBackgroundNoise, other.RemoveBackgroundNoise)
            && ValueEquality.AreEqual(HasIsolatedAudio, other.HasIsolatedAudio)
            && ValueEquality.AreEqual(HasIsolatedAudioPreview, other.HasIsolatedAudioPreview)
            && ValueEquality.AreEqual(SpeakerSeparation, other.SpeakerSeparation)
            && ValueEquality.AreEqual(TrimStart, other.TrimStart)
            && ValueEquality.AreEqual(TrimEnd, other.TrimEnd)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SampleId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MimeType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SizeBytes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Hash);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RemoveBackgroundNoise);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasIsolatedAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasIsolatedAudioPreview);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeakerSeparation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TrimStart);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TrimEnd);
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
