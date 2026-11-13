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
public record DubbingProjectResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Unique identifier of the dubbing project.</value>
    [JsonPropertyName("project_id")]
    public required string ProjectId { get; set; }

    /// <value>Lifecycle status of the project: `queued` before the source is picked up, `preparing` while it is transcribed, `ready` once transcription is done and language targets can start, or `failed`. A project is never reported as `processing` — that value belongs to language targets.</value>
    [JsonPropertyName("status")]
    public required DubbingProjectResponseStatus Status { get; set; }

    /// <value>The free-form string you supplied as `reference` when creating the project, or null if you supplied none.</value>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <value>BCP-47 language tag of the source media (null if auto-detected).</value>
    [JsonPropertyName("source_language")]
    public string? SourceLanguage { get; set; }

    /// <value>Dubbing model every language target of this project is dubbed with. Fixed at create time and not selectable per language.</value>
    [JsonPropertyName("model_id")]
    public string? ModelId { get; set; }

    /// <value>Source media metadata, populated once the source has been fetched and decoded (shortly after create, before the project is `ready`); null until then.</value>
    [JsonPropertyName("media")]
    public DubbingSourceMediaInfo? Media { get; set; }

    /// <value>Identifiers of the language targets under this project. Populated when a single project is fetched, and on create when `target_language` creates one. Always empty in list responses — list the project's language targets instead.</value>
    [JsonPropertyName("language_ids")]
    public IEnumerable<string>? LanguageIds { get; set; }

    /// <value>IDs of the workspace webhooks notified as this project and its languages reach `ready`, `completed`, or `failed`.</value>
    [JsonPropertyName("webhook_ids")]
    public IEnumerable<string>? WebhookIds { get; set; }

    /// <value>Monotonic counter incremented whenever the source transcript is edited (segment add/edit/delete).</value>
    [JsonPropertyName("revision")]
    public required int Revision { get; set; }

    /// <value>Why the project failed; null unless `status` is `failed`. Also null for the few projects that failed before failure reporting was introduced.</value>
    [JsonPropertyName("error")]
    public DubbingErrorResponse? Error { get; set; }

    /// <value>Non-fatal conditions raised while preparing the source, empty when there are none. Reflects the latest preparation. Conditions raised while dubbing a particular language are reported on that language instead.</value>
    [JsonPropertyName("warnings")]
    public IEnumerable<VoicesNotPermittedWarning>? Warnings { get; set; }

    /// <value>When the project was created.</value>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <value>When the project was last updated.</value>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
    public virtual bool Equals(DubbingProjectResponse? other)
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
            && ValueEquality.AreEqual(ProjectId, other.ProjectId)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(Reference, other.Reference)
            && ValueEquality.AreEqual(SourceLanguage, other.SourceLanguage)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(Media, other.Media)
            && ValueEquality.AreEqual(LanguageIds, other.LanguageIds)
            && ValueEquality.AreEqual(WebhookIds, other.WebhookIds)
            && ValueEquality.AreEqual(Revision, other.Revision)
            && ValueEquality.AreEqual(Error, other.Error)
            && ValueEquality.AreEqual(Warnings, other.Warnings)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(UpdatedAt, other.UpdatedAt)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProjectId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Reference);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Media);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WebhookIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Revision);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Error);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Warnings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAt);
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
