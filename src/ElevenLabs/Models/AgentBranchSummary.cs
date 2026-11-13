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
public record AgentBranchSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("created_at")]
    public required int CreatedAt { get; set; }

    [JsonPropertyName("last_committed_at")]
    public required int LastCommittedAt { get; set; }

    [JsonPropertyName("is_archived")]
    public required bool IsArchived { get; set; }

    [JsonPropertyName("protection_status")]
    public BranchProtectionStatus? ProtectionStatus { get; set; }

    [JsonPropertyName("auto_rebase")]
    public bool? AutoRebase { get; set; }

    /// <value>Set while the branch is kept in sync with another branch (Main today), pulling in its new versions automatically. Null when it is not synced.</value>
    [JsonPropertyName("sync_status")]
    public BranchSyncStatus? SyncStatus { get; set; }

    /// <value>Access information for the branch</value>
    [JsonPropertyName("access_info")]
    public ResourceAccessInfo? AccessInfo { get; set; }

    /// <value>Percentage of traffic live on the branch</value>
    [JsonPropertyName("current_live_percentage")]
    public double? CurrentLivePercentage { get; set; }

    /// <value>ID of the parent branch</value>
    [JsonPropertyName("parent_branch_id")]
    public string? ParentBranchId { get; set; }

    /// <value>Whether a draft exists for the branch</value>
    [JsonPropertyName("draft_exists")]
    public bool? DraftExists { get; set; }

    /// <value>Unix seconds when the caller's draft on this branch was first created, or null when they have no draft. A draft created before last_committed_at was written against a config the branch has since moved past, so it may not reflect the current one.</value>
    [JsonPropertyName("draft_created_at")]
    public int? DraftCreatedAt { get; set; }

    /// <value>Whether the caller's draft on this branch was created before the branch's last commit, meaning it was written against a config the branch has since moved past and may not reflect the current one.</value>
    [JsonPropertyName("draft_is_behind_tip")]
    public bool? DraftIsBehindTip { get; set; }

    /// <value>Number of calls in the last 7 days</value>
    [JsonPropertyName("calls_7d")]
    public int? Calls7D { get; set; }

    /// <value>Number of commits on this branch not yet on main, relative to their common ancestor. Null if it could not be computed (e.g. no common ancestor, or the branch history exceeds the comparison budget).</value>
    [JsonPropertyName("commits_ahead")]
    public int? CommitsAhead { get; set; }

    /// <value>Number of commits on main not yet incorporated into this branch, relative to their common ancestor. Null if it could not be computed (e.g. no common ancestor, or the branch history exceeds the comparison budget).</value>
    [JsonPropertyName("commits_behind")]
    public int? CommitsBehind { get; set; }

    /// <value>ID of the branch this branch's tip version was merged into, if any</value>
    [JsonPropertyName("merged_into_branch_id")]
    public string? MergedIntoBranchId { get; set; }

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
    public virtual bool Equals(AgentBranchSummary? other)
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
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(LastCommittedAt, other.LastCommittedAt)
            && ValueEquality.AreEqual(IsArchived, other.IsArchived)
            && ValueEquality.AreEqual(ProtectionStatus, other.ProtectionStatus)
            && ValueEquality.AreEqual(AutoRebase, other.AutoRebase)
            && ValueEquality.AreEqual(SyncStatus, other.SyncStatus)
            && ValueEquality.AreEqual(AccessInfo, other.AccessInfo)
            && ValueEquality.AreEqual(CurrentLivePercentage, other.CurrentLivePercentage)
            && ValueEquality.AreEqual(ParentBranchId, other.ParentBranchId)
            && ValueEquality.AreEqual(DraftExists, other.DraftExists)
            && ValueEquality.AreEqual(DraftCreatedAt, other.DraftCreatedAt)
            && ValueEquality.AreEqual(DraftIsBehindTip, other.DraftIsBehindTip)
            && ValueEquality.AreEqual(Calls7D, other.Calls7D)
            && ValueEquality.AreEqual(CommitsAhead, other.CommitsAhead)
            && ValueEquality.AreEqual(CommitsBehind, other.CommitsBehind)
            && ValueEquality.AreEqual(MergedIntoBranchId, other.MergedIntoBranchId)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastCommittedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsArchived);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProtectionStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoRebase);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SyncStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccessInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CurrentLivePercentage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ParentBranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DraftExists);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DraftCreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DraftIsBehindTip);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Calls7D);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CommitsAhead);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CommitsBehind);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MergedIntoBranchId);
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
