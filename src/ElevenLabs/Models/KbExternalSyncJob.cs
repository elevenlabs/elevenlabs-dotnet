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
public record KbExternalSyncJob : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public required ExternalSyncProvider Type { get; set; }

    [JsonPropertyName("folder_id")]
    public required string FolderId { get; set; }

    [JsonPropertyName("integration_connection_id")]
    public required string IntegrationConnectionId { get; set; }

    [JsonPropertyName("triggered_by")]
    public required ExternalSyncJobTrigger TriggeredBy { get; set; }

    [JsonPropertyName("status")]
    public CrawlStatus? Status { get; set; }

    [JsonPropertyName("sync_type")]
    public ExternalSyncJobType? SyncType { get; set; }

    [JsonPropertyName("items_identified")]
    public int? ItemsIdentified { get; set; }

    [JsonPropertyName("items_processed")]
    public int? ItemsProcessed { get; set; }

    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("started_at")]
    public int? StartedAt { get; set; }

    [JsonPropertyName("completed_at")]
    public int? CompletedAt { get; set; }

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
    public virtual bool Equals(KbExternalSyncJob? other)
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
            && ValueEquality.AreEqual(FolderId, other.FolderId)
            && ValueEquality.AreEqual(IntegrationConnectionId, other.IntegrationConnectionId)
            && ValueEquality.AreEqual(TriggeredBy, other.TriggeredBy)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(SyncType, other.SyncType)
            && ValueEquality.AreEqual(ItemsIdentified, other.ItemsIdentified)
            && ValueEquality.AreEqual(ItemsProcessed, other.ItemsProcessed)
            && ValueEquality.AreEqual(ErrorMessage, other.ErrorMessage)
            && ValueEquality.AreEqual(StartedAt, other.StartedAt)
            && ValueEquality.AreEqual(CompletedAt, other.CompletedAt)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FolderId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntegrationConnectionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TriggeredBy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SyncType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ItemsIdentified);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ItemsProcessed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ErrorMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CompletedAt);
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
