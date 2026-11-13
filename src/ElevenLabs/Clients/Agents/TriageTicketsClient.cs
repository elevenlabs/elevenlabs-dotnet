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
using ElevenLabs.Services;
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
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape client for TriageTicketsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITriageTicketsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TriageTicketsClient
{
    private readonly TriageTicketsService _service;

    internal TriageTicketsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TriageTicketsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateManualAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetCreateManualAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateManualAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListForWorkspaceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetListForWorkspaceAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListForWorkspaceAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAssignableUsersAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetListAssignableUsersAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListAssignableUsersAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddCommentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetAddCommentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetAddCommentAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetMergeAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetMergeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddTurnCommentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITriageTicketsClient SetAddTurnCommentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetAddTurnCommentAsyncConfig(config);
        return this;
    }

    /// <summary>List an agent's conversation triage tickets, ordered by most recently created first unless sorted by priority. These are tickets about the agent's own performance on a conversation (for triage with Architect), not tickets an agent opens for end users.</summary>
    public WithRawResponseTask<GetAgentConversationTicketsPageResponseModel> ListAsync(
        string agentId,
        ListTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentConversationTicketsPageResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        agentId,
                        request.PageSize,
                        request.ConversationId,
                        request.Status,
                        request.Sources?.ToList(),
                        request.Priorities?.ToList(),
                        request.SortBy,
                        request.OwnerUserId,
                        request.AssigneeUserId,
                        request.IssueType,
                        request.Label,
                        request.MergedIntoTicketId,
                        request.Search,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Manually raise a follow-up ticket against an agent, not tied to any conversation (for example a task like 'add the KB about X'). Without a title, one is derived from the comment. Requires viewer access to the agent.</summary>
    public WithRawResponseTask<AgentConversationTicketResponseModel> CreateManualAsync(
        string agentId,
        CreateManualTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentConversationTicketResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateManualAsync(
                        request.Body,
                        agentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>List conversation triage tickets across every agent in the workspace, ordered by most recently created first. Use this to build a workspace-wide view (for example, tickets assigned to the caller). Supports the same filters, sorting and search as the per-agent endpoint. Tickets for agents the caller cannot access are omitted.</summary>
    public WithRawResponseTask<GetAgentConversationTicketsPageResponseModel> ListForWorkspaceAsync(
        ListForWorkspaceTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentConversationTicketsPageResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListForWorkspaceAsync(
                        request.PageSize,
                        request.AgentId,
                        request.Status,
                        request.Sources?.ToList(),
                        request.Priorities?.ToList(),
                        request.SortBy,
                        request.OwnerUserId,
                        request.AssigneeUserId,
                        request.IssueType,
                        request.Label,
                        request.MergedIntoTicketId,
                        request.Search,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Raise a ticket about an agent's performance on a conversation, for triage with Architect. Provide an overall comment and/or turn-level comments describing what went wrong.</summary>
    public WithRawResponseTask<AgentConversationTicketResponseModel> CreateAsync(
        CreateTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentConversationTicketResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>All non-service-account workspace members, each flagged with whether they currently have at least viewer access to the agent. Members without access are included (not filtered out) so the UI can offer them as an assignee and prompt to grant access first.</summary>
    public WithRawResponseTask<IEnumerable<AssignableUserResponseModel>> ListAssignableUsersAsync(
        string agentId,
        ListAssignableUsersTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<IEnumerable<AssignableUserResponseModel>>(
            WithRawResponseAdapter.WrapEnumerable(
                options,
                () =>
                    _service.ListAssignableUsersAsync(
                        agentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get an agent conversation ticket by ID.</summary>
    public WithRawResponseTask<AgentConversationTicketResponseModel> GetAsync(
        string agentqaTicketId,
        GetTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentConversationTicketResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        agentqaTicketId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Update a ticket's title, comment, status, priority, and/or assignee. Requires viewer access to the ticket's agent.</summary>
    public WithRawResponseTask<AgentConversationTicketResponseModel> UpdateAsync(
        string agentqaTicketId,
        UpdateTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentConversationTicketResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        agentqaTicketId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete an agent conversation ticket. Restricted to the ticket creator or a workspace admin.</summary>
    public WithRawResponseTask DeleteAsync(
        string agentqaTicketId,
        DeleteTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.DeleteAsync(
                        agentqaTicketId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Append a comment discussing how to resolve the ticket. Requires viewer access to the ticket's agent.</summary>
    public WithRawResponseTask<AgentConversationTicketResponseModel> AddCommentAsync(
        string agentqaTicketId,
        AddCommentTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentConversationTicketResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.AddCommentAsync(
                        request.Body,
                        agentqaTicketId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Merge other open tickets of the same agent into this pending, in-progress, or resolved one. Their conversations move onto this ticket, its priority is raised to the highest among them, and they are kept with status 'merged'. Requires viewer access to the ticket's agent.</summary>
    public WithRawResponseTask<AgentConversationTicketResponseModel> MergeAsync(
        string agentqaTicketId,
        MergeTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentConversationTicketResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.MergeAsync(
                        request.Body,
                        agentqaTicketId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Append a turn-level comment to a ticket. Requires viewer access to the ticket's agent.</summary>
    public WithRawResponseTask<AgentConversationTicketResponseModel> AddTurnCommentAsync(
        string agentqaTicketId,
        AddTurnCommentTriageTicketsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentConversationTicketResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.AddTurnCommentAsync(
                        request.Body,
                        agentqaTicketId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
