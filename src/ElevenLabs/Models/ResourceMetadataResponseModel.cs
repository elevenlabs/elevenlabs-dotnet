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
public record ResourceMetadataResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the resource.</value>
    [JsonPropertyName("resource_id")]
    public required string ResourceId { get; set; }

    /// <value>The name of the resource, if available.</value>
    [JsonPropertyName("resource_name")]
    public string? ResourceName { get; set; }

    /// <value>Resource types that can be shared in the workspace. The name always need to match the collection names</value>
    [JsonPropertyName("resource_type")]
    public required WorkspaceResourceType ResourceType { get; set; }

    /// <value>The ID of the user who created the resource.</value>
    [JsonPropertyName("creator_user_id")]
    public string? CreatorUserId { get; set; }

    /// <value>The access level for anonymous users. If None, the resource is not shared publicly.</value>
    [JsonPropertyName("anonymous_access_level_override")]
    public ResourceMetadataResponseModelAnonymousAccessLevelOverride? AnonymousAccessLevelOverride { get; set; }

    /// <value>A mapping of grant slots to group IDs. Keys are the preset access roles plus workspace custom-role ids ('role_...'). When the resource is shared with a user, the group id is the user's id.</value>
    [JsonPropertyName("role_to_group_ids")]
    public Dictionary<string, IEnumerable<string>> RoleToGroupIds { get; set; } =
        new Dictionary<string, IEnumerable<string>>();

    /// <value>List of options for sharing the resource further in the workspace. These are users who don't have access to the resource yet.</value>
    [JsonPropertyName("share_options")]
    public IEnumerable<ShareOptionResponseModel> ShareOptions { get; set; } =
        new List<ShareOptionResponseModel>();

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
    public virtual bool Equals(ResourceMetadataResponseModel? other)
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
            && ValueEquality.AreEqual(ResourceId, other.ResourceId)
            && ValueEquality.AreEqual(ResourceName, other.ResourceName)
            && ValueEquality.AreEqual(ResourceType, other.ResourceType)
            && ValueEquality.AreEqual(CreatorUserId, other.CreatorUserId)
            && ValueEquality.AreEqual(
                AnonymousAccessLevelOverride,
                other.AnonymousAccessLevelOverride
            )
            && ValueEquality.AreEqual(RoleToGroupIds, other.RoleToGroupIds)
            && ValueEquality.AreEqual(ShareOptions, other.ShareOptions)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResourceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResourceName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResourceType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatorUserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AnonymousAccessLevelOverride);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RoleToGroupIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShareOptions);
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
