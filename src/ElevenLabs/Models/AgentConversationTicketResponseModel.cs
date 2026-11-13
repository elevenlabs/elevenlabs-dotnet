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
public record AgentConversationTicketResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agentqa_ticket_id")]
    public required string AgentqaTicketId { get; set; }

    [JsonPropertyName("workspace_id")]
    public required string WorkspaceId { get; set; }

    [JsonPropertyName("owner_user_id")]
    public required string OwnerUserId { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("needs_clustering")]
    public required bool NeedsClustering { get; set; }

    /// <value>One-line headline for the ticket. None only on tickets created before titles existed.</value>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("issue_type")]
    public AgentConversationTicketIssueType? IssueType { get; set; }

    [JsonPropertyName("labels")]
    public IEnumerable<string> Labels { get; set; } = new List<string>();

    [JsonPropertyName("conversation_ids")]
    public IEnumerable<string> ConversationIds { get; set; } = new List<string>();

    [JsonPropertyName("first_seen_unix_secs")]
    public int? FirstSeenUnixSecs { get; set; }

    [JsonPropertyName("last_seen_unix_secs")]
    public int? LastSeenUnixSecs { get; set; }

    [JsonPropertyName("qa_comment")]
    public string? QaComment { get; set; }

    [JsonPropertyName("ticket_comments")]
    public IEnumerable<TicketCommentResponseModel> TicketComments { get; set; } =
        new List<TicketCommentResponseModel>();

    [JsonPropertyName("turn_comments")]
    public IEnumerable<TurnCommentResponseModel> TurnComments { get; set; } =
        new List<TurnCommentResponseModel>();

    [JsonPropertyName("status")]
    public required AgentConversationTicketStatus Status { get; set; }

    [JsonPropertyName("priority")]
    public AgentConversationTicketPriority? Priority { get; set; }

    [JsonPropertyName("priority_changes")]
    public IEnumerable<TicketPriorityChangeResponseModel> PriorityChanges { get; set; } =
        new List<TicketPriorityChangeResponseModel>();

    [JsonPropertyName("status_changes")]
    public IEnumerable<TicketStatusChangeResponseModel> StatusChanges { get; set; } =
        new List<TicketStatusChangeResponseModel>();

    /// <value>The ticket this one was merged into, set while its status is 'merged'.</value>
    [JsonPropertyName("merged_into_ticket_id")]
    public string? MergedIntoTicketId { get; set; }

    [JsonPropertyName("source")]
    public required AgentConversationTicketSource Source { get; set; }

    [JsonPropertyName("assignee_user_id")]
    public string? AssigneeUserId { get; set; }

    [JsonPropertyName("created_at_unix_secs")]
    public required int CreatedAtUnixSecs { get; set; }

    [JsonPropertyName("updated_at_unix_secs")]
    public required int UpdatedAtUnixSecs { get; set; }

    /// <value>Where the list's `search` query matched. Set only on searched lists.</value>
    [JsonPropertyName("search_match")]
    public TicketSearchMatchResponseModel? SearchMatch { get; set; }

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
    public virtual bool Equals(AgentConversationTicketResponseModel? other)
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
            && ValueEquality.AreEqual(AgentqaTicketId, other.AgentqaTicketId)
            && ValueEquality.AreEqual(WorkspaceId, other.WorkspaceId)
            && ValueEquality.AreEqual(OwnerUserId, other.OwnerUserId)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(NeedsClustering, other.NeedsClustering)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(IssueType, other.IssueType)
            && ValueEquality.AreEqual(Labels, other.Labels)
            && ValueEquality.AreEqual(ConversationIds, other.ConversationIds)
            && ValueEquality.AreEqual(FirstSeenUnixSecs, other.FirstSeenUnixSecs)
            && ValueEquality.AreEqual(LastSeenUnixSecs, other.LastSeenUnixSecs)
            && ValueEquality.AreEqual(QaComment, other.QaComment)
            && ValueEquality.AreEqual(TicketComments, other.TicketComments)
            && ValueEquality.AreEqual(TurnComments, other.TurnComments)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(Priority, other.Priority)
            && ValueEquality.AreEqual(PriorityChanges, other.PriorityChanges)
            && ValueEquality.AreEqual(StatusChanges, other.StatusChanges)
            && ValueEquality.AreEqual(MergedIntoTicketId, other.MergedIntoTicketId)
            && ValueEquality.AreEqual(Source, other.Source)
            && ValueEquality.AreEqual(AssigneeUserId, other.AssigneeUserId)
            && ValueEquality.AreEqual(CreatedAtUnixSecs, other.CreatedAtUnixSecs)
            && ValueEquality.AreEqual(UpdatedAtUnixSecs, other.UpdatedAtUnixSecs)
            && ValueEquality.AreEqual(SearchMatch, other.SearchMatch)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentqaTicketId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WorkspaceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OwnerUserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NeedsClustering);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IssueType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Labels);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FirstSeenUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastSeenUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QaComment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TicketComments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TurnComments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Priority);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PriorityChanges);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StatusChanges);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MergedIntoTicketId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Source);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AssigneeUserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SearchMatch);
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
