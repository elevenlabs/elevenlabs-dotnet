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

/// <summary>A file or web page the receptionists learn from.</summary>
[Serializable]
public record ReceptionKnowledgeSource : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Type of knowledge source.</value>
    [JsonPropertyName("source_type")]
    public KnowledgeSourceType? SourceType { get; set; }

    /// <value>The page or site URL for 'url' sources.</value>
    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; set; }

    /// <value>When the URL was last read, as a Unix timestamp in seconds.</value>
    [JsonPropertyName("last_scraped_at_unix")]
    public int? LastScrapedAtUnix { get; set; }

    /// <value>The uploaded file's name for 'file' sources; empty for URLs.</value>
    [JsonPropertyName("original_filename")]
    public string? OriginalFilename { get; set; }

    /// <value>The uploaded file's MIME type; empty for URLs.</value>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    /// <value>The uploaded file's size in bytes; 0 for URLs.</value>
    [JsonPropertyName("file_size_bytes")]
    public int? FileSizeBytes { get; set; }

    /// <value>
    /// Processing status for knowledge sources.
    ///
    /// - `processing`: the file or site is being read.
    /// - `ready`: done; the results are available.
    /// - `error`: it failed and can be retried.
    ///
    /// See `progress` for detail.
    /// </value>
    [JsonPropertyName("status")]
    public KnowledgeSourceStatus? Status { get; set; }

    /// <value>Why processing failed, when status is 'error'.</value>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    /// <value>Machine-readable cause of the failure, when status is 'error'.</value>
    [JsonPropertyName("failure_reason")]
    public IngestFailure? FailureReason { get; set; }

    /// <value>Whether the whole site was crawled rather than the single page at source_url.</value>
    [JsonPropertyName("crawl_entire_site")]
    public bool? CrawlEntireSite { get; set; }

    /// <value>How many pages were read for 'url' sources.</value>
    [JsonPropertyName("scraped_pages_count")]
    public int? ScrapedPagesCount { get; set; }

    /// <value>A short plain-text preview of the content.</value>
    [JsonPropertyName("content_preview")]
    public string? ContentPreview { get; set; }

    /// <value>When processing started, as a Unix timestamp in seconds.</value>
    [JsonPropertyName("processing_started_at_unix")]
    public int? ProcessingStartedAtUnix { get; set; }

    /// <value>The knowledge source's ID.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Unix timestamp (seconds since epoch)</value>
    [JsonPropertyName("created_at_unix")]
    public int? CreatedAtUnix { get; set; }

    /// <value>Unix timestamp (seconds since epoch)</value>
    [JsonPropertyName("updated_at_unix")]
    public int? UpdatedAtUnix { get; set; }

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
    public virtual bool Equals(ReceptionKnowledgeSource? other)
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
            && ValueEquality.AreEqual(SourceType, other.SourceType)
            && ValueEquality.AreEqual(SourceUrl, other.SourceUrl)
            && ValueEquality.AreEqual(LastScrapedAtUnix, other.LastScrapedAtUnix)
            && ValueEquality.AreEqual(OriginalFilename, other.OriginalFilename)
            && ValueEquality.AreEqual(ContentType, other.ContentType)
            && ValueEquality.AreEqual(FileSizeBytes, other.FileSizeBytes)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(ErrorMessage, other.ErrorMessage)
            && ValueEquality.AreEqual(FailureReason, other.FailureReason)
            && ValueEquality.AreEqual(CrawlEntireSite, other.CrawlEntireSite)
            && ValueEquality.AreEqual(ScrapedPagesCount, other.ScrapedPagesCount)
            && ValueEquality.AreEqual(ContentPreview, other.ContentPreview)
            && ValueEquality.AreEqual(ProcessingStartedAtUnix, other.ProcessingStartedAtUnix)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(UpdatedAtUnix, other.UpdatedAtUnix)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastScrapedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalFilename);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileSizeBytes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ErrorMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FailureReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CrawlEntireSite);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScrapedPagesCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentPreview);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProcessingStartedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnix);
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
