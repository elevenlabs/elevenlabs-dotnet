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

/// <summary>Tracks the link back to the original file in an external source.</summary>
[Serializable]
public record ExternalFileSyncInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public required ExternalSyncProvider Type { get; set; }

    /// <value>Entity ID in the external system</value>
    [JsonPropertyName("source_entity_id")]
    public required string SourceEntityId { get; set; }

    /// <value>Integration connection instance ID</value>
    [JsonPropertyName("integration_connection_id")]
    public required string IntegrationConnectionId { get; set; }

    /// <value>Folder ID in the external system this file was synced from</value>
    [JsonPropertyName("source_parent_entity_id")]
    public required string SourceParentEntityId { get; set; }

    /// <value>Original MIME type in the external system</value>
    [JsonPropertyName("source_mime_type")]
    public required string SourceMimeType { get; set; }

    /// <value>Last modified time from the external system</value>
    [JsonPropertyName("source_modified_time")]
    public required DateTime SourceModifiedTime { get; set; }

    /// <value>KB folder ID of the sync root, used to query all entities under a sync tree</value>
    [JsonPropertyName("root_folder_id")]
    public string? RootFolderId { get; set; }

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
    public virtual bool Equals(ExternalFileSyncInfo? other)
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
            && ValueEquality.AreEqual(SourceEntityId, other.SourceEntityId)
            && ValueEquality.AreEqual(IntegrationConnectionId, other.IntegrationConnectionId)
            && ValueEquality.AreEqual(SourceParentEntityId, other.SourceParentEntityId)
            && ValueEquality.AreEqual(SourceMimeType, other.SourceMimeType)
            && ValueEquality.AreEqual(SourceModifiedTime, other.SourceModifiedTime)
            && ValueEquality.AreEqual(RootFolderId, other.RootFolderId)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceEntityId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntegrationConnectionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceParentEntityId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceMimeType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceModifiedTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RootFolderId);
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
