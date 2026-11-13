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
public record UnitTestSummaryResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the test</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Name of the test</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The access information of the test</value>
    [JsonPropertyName("access_info")]
    public ResourceAccessInfo? AccessInfo { get; set; }

    /// <value>Creation time of the test in unix seconds</value>
    [JsonPropertyName("created_at_unix_secs")]
    public required int CreatedAtUnixSecs { get; set; }

    /// <value>Last update time of the test in unix seconds</value>
    [JsonPropertyName("last_updated_at_unix_secs")]
    public required int LastUpdatedAtUnixSecs { get; set; }

    [JsonPropertyName("type")]
    public required TestType Type { get; set; }

    [JsonPropertyName("entity_type")]
    public AgentTestEntityType? EntityType { get; set; }

    /// <value>The ID of the parent folder</value>
    [JsonPropertyName("folder_parent_id")]
    public string? FolderParentId { get; set; }

    /// <value>The folder path segments from root to this entity</value>
    [JsonPropertyName("folder_path")]
    public IEnumerable<AgentTestFolderPathSegmentResponseModel>? FolderPath { get; set; }

    /// <value>Number of direct children (tests and subfolders) for folders only</value>
    [JsonPropertyName("children_count")]
    public int? ChildrenCount { get; set; }

    /// <value>Channel the test simulates the conversation as. Null for folders or default behavior.</value>
    [JsonPropertyName("conversation_initiation_source")]
    public ConversationInitiationSource1? ConversationInitiationSource { get; set; }

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
    public virtual bool Equals(UnitTestSummaryResponseModel? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(AccessInfo, other.AccessInfo)
            && ValueEquality.AreEqual(CreatedAtUnixSecs, other.CreatedAtUnixSecs)
            && ValueEquality.AreEqual(LastUpdatedAtUnixSecs, other.LastUpdatedAtUnixSecs)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(EntityType, other.EntityType)
            && ValueEquality.AreEqual(FolderParentId, other.FolderParentId)
            && ValueEquality.AreEqual(FolderPath, other.FolderPath)
            && ValueEquality.AreEqual(ChildrenCount, other.ChildrenCount)
            && ValueEquality.AreEqual(
                ConversationInitiationSource,
                other.ConversationInitiationSource
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccessInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastUpdatedAtUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntityType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FolderParentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FolderPath);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChildrenCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationInitiationSource);
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
