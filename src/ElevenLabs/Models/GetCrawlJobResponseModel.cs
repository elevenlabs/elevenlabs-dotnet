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
public record GetCrawlJobResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public CrawlType? Type { get; set; }

    [JsonPropertyName("seed_url")]
    public required string SeedUrl { get; set; }

    [JsonPropertyName("pattern")]
    public string? Pattern { get; set; }

    /// <value>URLs matching any of these patterns are skipped, even if they match `pattern`.</value>
    [JsonPropertyName("exclude_patterns")]
    public IEnumerable<string>? ExcludePatterns { get; set; }

    [JsonPropertyName("max_pages")]
    public required int MaxPages { get; set; }

    /// <value>Whether to automatically discover and enqueue additional pages found while crawling.</value>
    [JsonPropertyName("auto_discover")]
    public bool? AutoDiscover { get; set; }

    [JsonPropertyName("status")]
    public CrawlStatus? Status { get; set; }

    [JsonPropertyName("pages_identified")]
    public int? PagesIdentified { get; set; }

    [JsonPropertyName("pages_scraped")]
    public int? PagesScraped { get; set; }

    [JsonPropertyName("pages_skipped")]
    public int? PagesSkipped { get; set; }

    [JsonPropertyName("pages_failed")]
    public int? PagesFailed { get; set; }

    [JsonPropertyName("root_folder_id")]
    public required string RootFolderId { get; set; }

    [JsonPropertyName("updated_at")]
    public required int UpdatedAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("created_at")]
    public required int CreatedAt { get; set; }

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
    public virtual bool Equals(GetCrawlJobResponseModel? other)
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
            && ValueEquality.AreEqual(SeedUrl, other.SeedUrl)
            && ValueEquality.AreEqual(Pattern, other.Pattern)
            && ValueEquality.AreEqual(ExcludePatterns, other.ExcludePatterns)
            && ValueEquality.AreEqual(MaxPages, other.MaxPages)
            && ValueEquality.AreEqual(AutoDiscover, other.AutoDiscover)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(PagesIdentified, other.PagesIdentified)
            && ValueEquality.AreEqual(PagesScraped, other.PagesScraped)
            && ValueEquality.AreEqual(PagesSkipped, other.PagesSkipped)
            && ValueEquality.AreEqual(PagesFailed, other.PagesFailed)
            && ValueEquality.AreEqual(RootFolderId, other.RootFolderId)
            && ValueEquality.AreEqual(UpdatedAt, other.UpdatedAt)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SeedUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Pattern);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExcludePatterns);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxPages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoDiscover);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PagesIdentified);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PagesScraped);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PagesSkipped);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PagesFailed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RootFolderId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
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
