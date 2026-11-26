using ElevenLabs;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.CustomerSupport;
using ElevenLabs.CustomerSupport.Requesters;
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

namespace ElevenLabs.Agents;

[Serializable]
public record BodyUpdateAgentBranchV1ConvaiAgentsAgentIdBranchesBranchIdPatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>New name for the branch. Must be unique within the agent.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>New description for the branch. Pass an empty string to clear it.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>Whether the branch should be archived</value>
    [JsonPropertyName("is_archived")]
    public bool? IsArchived { get; set; }

    /// <value>The protection level for the branch</value>
    [JsonPropertyName("protection_status")]
    public BranchProtectionStatus? ProtectionStatus { get; set; }

    /// <value>When true, rebase this branch automatically after each new version of the branch it is kept in sync with (`sync_branch_id`, main by default). Cannot be enabled on the main branch, or while this branch is more protected than a non-main branch it is kept in sync with.</value>
    [JsonPropertyName("auto_rebase")]
    public bool? AutoRebase { get; set; }

    /// <value>ID of the branch to keep this branch in sync with: its new versions are pulled in automatically while `auto_rebase` is on. Pass the main branch's ID to sync with main again. Must be the main branch or the active branch this branch was created from (`parent_branch_id`). At most 10 branches can be kept in sync with one another in a row. Cannot be set on the main branch.</value>
    [JsonPropertyName("sync_branch_id")]
    public string? SyncBranchId { get; set; }

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
    public virtual bool Equals(
        BodyUpdateAgentBranchV1ConvaiAgentsAgentIdBranchesBranchIdPatch? other
    )
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
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(IsArchived, other.IsArchived)
            && ValueEquality.AreEqual(ProtectionStatus, other.ProtectionStatus)
            && ValueEquality.AreEqual(AutoRebase, other.AutoRebase)
            && ValueEquality.AreEqual(SyncBranchId, other.SyncBranchId)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsArchived);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProtectionStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoRebase);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SyncBranchId);
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
