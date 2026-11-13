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
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape interface for TriageTicketsClient. Mirrors the public surface of <c>TriageTicketsClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface ITriageTicketsClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateManualAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetCreateManualAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListForWorkspaceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetListForWorkspaceAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAssignableUsersAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetListAssignableUsersAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>AddCommentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetAddCommentAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetMergeAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>AddTurnCommentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITriageTicketsClient SetAddTurnCommentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>List an agent's conversation triage tickets, ordered by most recently created first unless sorted by priority. These are tickets about the agent's own performance on a conversation (for triage with Architect), not tickets an agent opens for end users.</summary>
    WithRawResponseTask<GetAgentConversationTicketsPageResponseModel> ListAsync(
        string agentId,
        ListTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Manually raise a follow-up ticket against an agent, not tied to any conversation (for example a task like 'add the KB about X'). Without a title, one is derived from the comment. Requires viewer access to the agent.</summary>
    WithRawResponseTask<AgentConversationTicketResponseModel> CreateManualAsync(
        string agentId,
        CreateManualTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>List conversation triage tickets across every agent in the workspace, ordered by most recently created first. Use this to build a workspace-wide view (for example, tickets assigned to the caller). Supports the same filters, sorting and search as the per-agent endpoint. Tickets for agents the caller cannot access are omitted.</summary>
    WithRawResponseTask<GetAgentConversationTicketsPageResponseModel> ListForWorkspaceAsync(
        ListForWorkspaceTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Raise a ticket about an agent's performance on a conversation, for triage with Architect. Provide an overall comment and/or turn-level comments describing what went wrong.</summary>
    WithRawResponseTask<AgentConversationTicketResponseModel> CreateAsync(
        CreateTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>All non-service-account workspace members, each flagged with whether they currently have at least viewer access to the agent. Members without access are included (not filtered out) so the UI can offer them as an assignee and prompt to grant access first.</summary>
    WithRawResponseTask<IEnumerable<AssignableUserResponseModel>> ListAssignableUsersAsync(
        string agentId,
        ListAssignableUsersTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get an agent conversation ticket by ID.</summary>
    WithRawResponseTask<AgentConversationTicketResponseModel> GetAsync(
        string agentqaTicketId,
        GetTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Update a ticket's title, comment, status, priority, and/or assignee. Requires viewer access to the ticket's agent.</summary>
    WithRawResponseTask<AgentConversationTicketResponseModel> UpdateAsync(
        string agentqaTicketId,
        UpdateTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete an agent conversation ticket. Restricted to the ticket creator or a workspace admin.</summary>
    WithRawResponseTask DeleteAsync(
        string agentqaTicketId,
        DeleteTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Append a comment discussing how to resolve the ticket. Requires viewer access to the ticket's agent.</summary>
    WithRawResponseTask<AgentConversationTicketResponseModel> AddCommentAsync(
        string agentqaTicketId,
        AddCommentTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Merge other open tickets of the same agent into this pending, in-progress, or resolved one. Their conversations move onto this ticket, its priority is raised to the highest among them, and they are kept with status 'merged'. Requires viewer access to the ticket's agent.</summary>
    WithRawResponseTask<AgentConversationTicketResponseModel> MergeAsync(
        string agentqaTicketId,
        MergeTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Append a turn-level comment to a ticket. Requires viewer access to the ticket's agent.</summary>
    WithRawResponseTask<AgentConversationTicketResponseModel> AddTurnCommentAsync(
        string agentqaTicketId,
        AddTurnCommentTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class TriageTicketsClient : ITriageTicketsClient { }
