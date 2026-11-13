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
using OneOf;

namespace ElevenLabs;

[Serializable]
public record WorkspaceGroupResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("members")]
    public IEnumerable<string> Members { get; set; } = new List<string>();

    [JsonPropertyName("permissions")]
    public IEnumerable<WorkspaceGroupPermission>? Permissions { get; set; }

    [JsonPropertyName("group_usage_limit")]
    public OneOf<int, GroupUsageLimit2>? GroupUsageLimit { get; set; }

    [JsonPropertyName("group_pvc_limit")]
    public OneOf<int, GroupPvcLimit2>? GroupPvcLimit { get; set; }

    [JsonPropertyName("group_concurrency_limit")]
    public OneOf<int, GroupConcurrencyLimit2>? GroupConcurrencyLimit { get; set; }

    [JsonPropertyName("group_dubbing_concurrency_limit")]
    public OneOf<int, GroupDubbingConcurrencyLimit2>? GroupDubbingConcurrencyLimit { get; set; }

    [JsonPropertyName("group_music_concurrency_limit")]
    public OneOf<int, GroupMusicConcurrencyLimit2>? GroupMusicConcurrencyLimit { get; set; }

    [JsonPropertyName("character_count")]
    public int? CharacterCount { get; set; }

    [JsonPropertyName("is_scim_synced")]
    public bool? IsScimSynced { get; set; }

    [JsonPropertyName("scim_group")]
    public ScimGroupResponseModel? ScimGroup { get; set; }

    [JsonPropertyName("scim_frozen")]
    public bool? ScimFrozen { get; set; }

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
    public virtual bool Equals(WorkspaceGroupResponseModel? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(Members, other.Members)
            && ValueEquality.AreEqual(Permissions, other.Permissions)
            && ValueEquality.AreEqual(GroupUsageLimit, other.GroupUsageLimit)
            && ValueEquality.AreEqual(GroupPvcLimit, other.GroupPvcLimit)
            && ValueEquality.AreEqual(GroupConcurrencyLimit, other.GroupConcurrencyLimit)
            && ValueEquality.AreEqual(
                GroupDubbingConcurrencyLimit,
                other.GroupDubbingConcurrencyLimit
            )
            && ValueEquality.AreEqual(GroupMusicConcurrencyLimit, other.GroupMusicConcurrencyLimit)
            && ValueEquality.AreEqual(CharacterCount, other.CharacterCount)
            && ValueEquality.AreEqual(IsScimSynced, other.IsScimSynced)
            && ValueEquality.AreEqual(ScimGroup, other.ScimGroup)
            && ValueEquality.AreEqual(ScimFrozen, other.ScimFrozen)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Members);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Permissions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GroupUsageLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GroupPvcLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GroupConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GroupDubbingConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GroupMusicConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsScimSynced);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScimGroup);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScimFrozen);
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
