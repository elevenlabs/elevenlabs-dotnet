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
public record AgentMergeProposalResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("source_branch_id")]
    public required string SourceBranchId { get; set; }

    [JsonPropertyName("target_branch_id")]
    public required string TargetBranchId { get; set; }

    [JsonPropertyName("source_tip_version_id_at_creation")]
    public required string SourceTipVersionIdAtCreation { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("requested_reviewer_user_ids")]
    public IEnumerable<string>? RequestedReviewerUserIds { get; set; }

    [JsonPropertyName("reviews")]
    public IEnumerable<MergeProposalReview>? Reviews { get; set; }

    [JsonPropertyName("comments")]
    public IEnumerable<MergeProposalComment>? Comments { get; set; }

    [JsonPropertyName("outcome")]
    public Outcome? Outcome { get; set; }

    [JsonPropertyName("created_at")]
    public required int CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required int UpdatedAt { get; set; }

    /// <value>User ID of the merge_proposal's author.</value>
    [JsonPropertyName("author_user_id")]
    public string? AuthorUserId { get; set; }

    /// <value>Access information for the merge_proposal, including creator.</value>
    [JsonPropertyName("access_info")]
    public ResourceAccessInfo? AccessInfo { get; set; }

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
    public virtual bool Equals(AgentMergeProposalResponse? other)
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
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(SourceBranchId, other.SourceBranchId)
            && ValueEquality.AreEqual(TargetBranchId, other.TargetBranchId)
            && ValueEquality.AreEqual(
                SourceTipVersionIdAtCreation,
                other.SourceTipVersionIdAtCreation
            )
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(RequestedReviewerUserIds, other.RequestedReviewerUserIds)
            && ValueEquality.AreEqual(Reviews, other.Reviews)
            && ValueEquality.AreEqual(Comments, other.Comments)
            && ValueEquality.AreEqual(Outcome, other.Outcome)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(UpdatedAt, other.UpdatedAt)
            && ValueEquality.AreEqual(AuthorUserId, other.AuthorUserId)
            && ValueEquality.AreEqual(AccessInfo, other.AccessInfo)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceBranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetBranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceTipVersionIdAtCreation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestedReviewerUserIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Reviews);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Comments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Outcome);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthorUserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccessInfo);
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
