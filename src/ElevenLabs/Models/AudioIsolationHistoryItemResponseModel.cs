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
public record AudioIsolationHistoryItemResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("created_at_unix")]
    public required int CreatedAtUnix { get; set; }

    [JsonPropertyName("format")]
    public required string Format { get; set; }

    [JsonPropertyName("duration_seconds")]
    public double? DurationSeconds { get; set; }

    [JsonPropertyName("download_url")]
    public string? DownloadUrl { get; set; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("source_video_url")]
    public string? SourceVideoUrl { get; set; }

    [JsonPropertyName("supports_video")]
    public required bool SupportsVideo { get; set; }

    [JsonPropertyName("processing")]
    public required bool Processing { get; set; }

    [JsonPropertyName("video_processing_failed")]
    public required bool VideoProcessingFailed { get; set; }

    [JsonPropertyName("preview_b64")]
    public string? PreviewB64 { get; set; }

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
    public virtual bool Equals(AudioIsolationHistoryItemResponseModel? other)
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
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(Format, other.Format)
            && ValueEquality.AreEqual(DurationSeconds, other.DurationSeconds)
            && ValueEquality.AreEqual(DownloadUrl, other.DownloadUrl)
            && ValueEquality.AreEqual(IconUrl, other.IconUrl)
            && ValueEquality.AreEqual(SourceVideoUrl, other.SourceVideoUrl)
            && ValueEquality.AreEqual(SupportsVideo, other.SupportsVideo)
            && ValueEquality.AreEqual(Processing, other.Processing)
            && ValueEquality.AreEqual(VideoProcessingFailed, other.VideoProcessingFailed)
            && ValueEquality.AreEqual(PreviewB64, other.PreviewB64)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Format);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DownloadUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IconUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceVideoUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportsVideo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Processing);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VideoProcessingFailed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviewB64);
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
