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
public record ProjectImageResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("image_id")]
    public required string ImageId { get; set; }

    [JsonPropertyName("filename")]
    public required string Filename { get; set; }

    [JsonPropertyName("signed_url")]
    public string? SignedUrl { get; set; }

    [JsonPropertyName("thumbnail_signed_url")]
    public string? ThumbnailSignedUrl { get; set; }

    [JsonPropertyName("type")]
    public ProjectImageResponseModelType? Type { get; set; }

    [JsonPropertyName("source")]
    public ProjectImageResponseModelSource? Source { get; set; }

    [JsonPropertyName("file_size_bytes")]
    public required int FileSizeBytes { get; set; }

    [JsonPropertyName("width")]
    public required int Width { get; set; }

    [JsonPropertyName("height")]
    public required int Height { get; set; }

    [JsonPropertyName("track_id")]
    public string? TrackId { get; set; }

    [JsonPropertyName("offset_ms")]
    public required int OffsetMs { get; set; }

    [JsonPropertyName("duration_ms")]
    public required int DurationMs { get; set; }

    [JsonPropertyName("order")]
    public required string Order { get; set; }

    /// <value>Defines asset positioning and transformation on canvas.</value>
    [JsonPropertyName("canvas_placement")]
    public required CanvasPlacement CanvasPlacement { get; set; }

    [JsonPropertyName("animation")]
    public ClipAnimation? Animation { get; set; }

    [JsonPropertyName("opacity")]
    public double? Opacity { get; set; }

    [JsonPropertyName("created_at_ms")]
    public required int CreatedAtMs { get; set; }

    [JsonPropertyName("updated_at_ms")]
    public required int UpdatedAtMs { get; set; }

    [JsonPropertyName("current_snapshot_id")]
    public string? CurrentSnapshotId { get; set; }

    [JsonPropertyName("source_asset_id")]
    public string? SourceAssetId { get; set; }

    [JsonPropertyName("source_platform_asset_id")]
    public string? SourcePlatformAssetId { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("pending_task")]
    public PendingClipTask? PendingTask { get; set; }

    [JsonPropertyName("analysis")]
    public ImageAnalysis? Analysis { get; set; }

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
    public virtual bool Equals(ProjectImageResponseModel? other)
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
            && ValueEquality.AreEqual(ImageId, other.ImageId)
            && ValueEquality.AreEqual(Filename, other.Filename)
            && ValueEquality.AreEqual(SignedUrl, other.SignedUrl)
            && ValueEquality.AreEqual(ThumbnailSignedUrl, other.ThumbnailSignedUrl)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(Source, other.Source)
            && ValueEquality.AreEqual(FileSizeBytes, other.FileSizeBytes)
            && ValueEquality.AreEqual(Width, other.Width)
            && ValueEquality.AreEqual(Height, other.Height)
            && ValueEquality.AreEqual(TrackId, other.TrackId)
            && ValueEquality.AreEqual(OffsetMs, other.OffsetMs)
            && ValueEquality.AreEqual(DurationMs, other.DurationMs)
            && ValueEquality.AreEqual(Order, other.Order)
            && ValueEquality.AreEqual(CanvasPlacement, other.CanvasPlacement)
            && ValueEquality.AreEqual(Animation, other.Animation)
            && ValueEquality.AreEqual(Opacity, other.Opacity)
            && ValueEquality.AreEqual(CreatedAtMs, other.CreatedAtMs)
            && ValueEquality.AreEqual(UpdatedAtMs, other.UpdatedAtMs)
            && ValueEquality.AreEqual(CurrentSnapshotId, other.CurrentSnapshotId)
            && ValueEquality.AreEqual(SourceAssetId, other.SourceAssetId)
            && ValueEquality.AreEqual(SourcePlatformAssetId, other.SourcePlatformAssetId)
            && ValueEquality.AreEqual(Error, other.Error)
            && ValueEquality.AreEqual(PendingTask, other.PendingTask)
            && ValueEquality.AreEqual(Analysis, other.Analysis)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ImageId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Filename);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SignedUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ThumbnailSignedUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Source);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileSizeBytes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Width);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Height);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TrackId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OffsetMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Order);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanvasPlacement);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Animation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Opacity);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CurrentSnapshotId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceAssetId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourcePlatformAssetId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Error);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PendingTask);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Analysis);
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
