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
public record ProjectExternalAudioResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("external_audio_id")]
    public required string ExternalAudioId { get; set; }

    [JsonPropertyName("filename")]
    public required string Filename { get; set; }

    [JsonPropertyName("signed_url")]
    public string? SignedUrl { get; set; }

    [JsonPropertyName("offset_ms")]
    public required int OffsetMs { get; set; }

    [JsonPropertyName("duration_ms")]
    public required int DurationMs { get; set; }

    [JsonPropertyName("start_time_ms")]
    public required int StartTimeMs { get; set; }

    [JsonPropertyName("end_time_ms")]
    public int? EndTimeMs { get; set; }

    [JsonPropertyName("order")]
    public required string Order { get; set; }

    [JsonPropertyName("track_id")]
    public required string TrackId { get; set; }

    [JsonPropertyName("created_at_ms")]
    public required int CreatedAtMs { get; set; }

    [JsonPropertyName("updated_at_ms")]
    public required int UpdatedAtMs { get; set; }

    [JsonPropertyName("volume_gain_db")]
    public double? VolumeGainDb { get; set; }

    [JsonPropertyName("muted")]
    public bool? Muted { get; set; }

    [JsonPropertyName("fade_in_ms")]
    public int? FadeInMs { get; set; }

    [JsonPropertyName("fade_out_ms")]
    public int? FadeOutMs { get; set; }

    [JsonPropertyName("source_external_audio_id")]
    public string? SourceExternalAudioId { get; set; }

    [JsonPropertyName("source_asset_id")]
    public string? SourceAssetId { get; set; }

    [JsonPropertyName("source_platform_asset_id")]
    public string? SourcePlatformAssetId { get; set; }

    [JsonPropertyName("pending_blocks_metadata")]
    public PendingBlocksMetadataModel? PendingBlocksMetadata { get; set; }

    [JsonPropertyName("pending_external_audios_metadata")]
    public PendingExternalAudiosMetadataModel? PendingExternalAudiosMetadata { get; set; }

    [JsonPropertyName("speech_imported")]
    public bool? SpeechImported { get; set; }

    [JsonPropertyName("pending_task")]
    public PendingClipTask? PendingTask { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("current_snapshot_id")]
    public string? CurrentSnapshotId { get; set; }

    [JsonPropertyName("source_context")]
    public ProjectExternalAudioResponseModelSourceContext? SourceContext { get; set; }

    [JsonPropertyName("analysis")]
    public AudioAnalysis? Analysis { get; set; }

    [JsonPropertyName("transcription")]
    public AssetTranscription? Transcription { get; set; }

    [JsonPropertyName("type")]
    public ProjectExternalAudioResponseModelType? Type { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("import_speech_progress")]
    public double? ImportSpeechProgress { get; set; }

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
    public virtual bool Equals(ProjectExternalAudioResponseModel? other)
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
            && ValueEquality.AreEqual(ExternalAudioId, other.ExternalAudioId)
            && ValueEquality.AreEqual(Filename, other.Filename)
            && ValueEquality.AreEqual(SignedUrl, other.SignedUrl)
            && ValueEquality.AreEqual(OffsetMs, other.OffsetMs)
            && ValueEquality.AreEqual(DurationMs, other.DurationMs)
            && ValueEquality.AreEqual(StartTimeMs, other.StartTimeMs)
            && ValueEquality.AreEqual(EndTimeMs, other.EndTimeMs)
            && ValueEquality.AreEqual(Order, other.Order)
            && ValueEquality.AreEqual(TrackId, other.TrackId)
            && ValueEquality.AreEqual(CreatedAtMs, other.CreatedAtMs)
            && ValueEquality.AreEqual(UpdatedAtMs, other.UpdatedAtMs)
            && ValueEquality.AreEqual(VolumeGainDb, other.VolumeGainDb)
            && ValueEquality.AreEqual(Muted, other.Muted)
            && ValueEquality.AreEqual(FadeInMs, other.FadeInMs)
            && ValueEquality.AreEqual(FadeOutMs, other.FadeOutMs)
            && ValueEquality.AreEqual(SourceExternalAudioId, other.SourceExternalAudioId)
            && ValueEquality.AreEqual(SourceAssetId, other.SourceAssetId)
            && ValueEquality.AreEqual(SourcePlatformAssetId, other.SourcePlatformAssetId)
            && ValueEquality.AreEqual(PendingBlocksMetadata, other.PendingBlocksMetadata)
            && ValueEquality.AreEqual(
                PendingExternalAudiosMetadata,
                other.PendingExternalAudiosMetadata
            )
            && ValueEquality.AreEqual(SpeechImported, other.SpeechImported)
            && ValueEquality.AreEqual(PendingTask, other.PendingTask)
            && ValueEquality.AreEqual(Error, other.Error)
            && ValueEquality.AreEqual(CurrentSnapshotId, other.CurrentSnapshotId)
            && ValueEquality.AreEqual(SourceContext, other.SourceContext)
            && ValueEquality.AreEqual(Analysis, other.Analysis)
            && ValueEquality.AreEqual(Transcription, other.Transcription)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(ImportSpeechProgress, other.ImportSpeechProgress)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExternalAudioId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Filename);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SignedUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OffsetMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartTimeMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndTimeMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Order);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TrackId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VolumeGainDb);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Muted);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FadeInMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FadeOutMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceExternalAudioId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceAssetId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourcePlatformAssetId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PendingBlocksMetadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PendingExternalAudiosMetadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeechImported);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PendingTask);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Error);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CurrentSnapshotId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceContext);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Analysis);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Transcription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ImportSpeechProgress);
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
