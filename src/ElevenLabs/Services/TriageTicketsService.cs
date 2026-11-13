using System.Net.Http.Json;
using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Config;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Http;
using ElevenLabs.Http.Exceptions;
using ElevenLabs.Http.Extensions;
using ElevenLabs.Http.Handlers;
using ElevenLabs.Http.Serialization;
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

namespace ElevenLabs.Services;

/// <summary>
/// Service class providing access to API endpoints for TriageTicketsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class TriageTicketsService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _createManualAsyncConfig;
    private RequestConfig? _listForWorkspaceAsyncConfig;
    private RequestConfig? _createAsyncConfig;
    private RequestConfig? _listAssignableUsersAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;
    private RequestConfig? _addCommentAsyncConfig;
    private RequestConfig? _mergeAsyncConfig;
    private RequestConfig? _addTurnCommentAsyncConfig;

    internal TriageTicketsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateManualAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetCreateManualAsyncConfig(RequestConfig config)
    {
        _createManualAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListForWorkspaceAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetListForWorkspaceAsyncConfig(RequestConfig config)
    {
        _listForWorkspaceAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetCreateAsyncConfig(RequestConfig config)
    {
        _createAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAssignableUsersAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetListAssignableUsersAsyncConfig(RequestConfig config)
    {
        _listAssignableUsersAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddCommentAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetAddCommentAsyncConfig(RequestConfig config)
    {
        _addCommentAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetMergeAsyncConfig(RequestConfig config)
    {
        _mergeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddTurnCommentAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TriageTicketsService SetAddTurnCommentAsyncConfig(RequestConfig config)
    {
        _addTurnCommentAsyncConfig = config;
        return this;
    }

    /// <summary>List an agent's conversation triage tickets, ordered by most recently created first unless sorted by priority. These are tickets about the agent's own performance on a conversation (for triage with Architect), not tickets an agent opens for end users.</summary>
    /// <param name="pageSize">How many agent conversation tickets to return. Can not exceed 100.</param>
    /// <param name="conversationId">Filter tickets by conversation id.</param>
    /// <param name="status">Filter tickets by status.</param>
    /// <param name="sources">Filter tickets by how they were raised (qa, agent, manual). Repeat the parameter to filter by multiple sources.</param>
    /// <param name="priorities">Filter tickets by priority. Repeat the parameter to filter by multiple priorities.</param>
    /// <param name="sortBy">Order by most recently created, by priority (most urgent first, then most recently created), or by most recently reported (the newest report merged into the issue, else its creation).</param>
    /// <param name="ownerUserId">Filter tickets by creator. Use 'agent' for agent-raised tickets.</param>
    /// <param name="assigneeUserId">Filter tickets by assignee. Use 'unassigned' for tickets with no assignee.</param>
    /// <param name="issueType">Filter clusters by issue type.</param>
    /// <param name="label">Filter tickets by an exact label.</param>
    /// <param name="mergedIntoTicketId">Filter tickets merged into this ticket.</param>
    /// <param name="search">Case-insensitive free-text search across the ticket's title, description, comments, and turn comments.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAgentConversationTicketsPageResponseModel> ListAsync(
        string agentId,
        long? pageSize = 100,
        string? conversationId = null,
        global::ElevenLabs.AgentConversationTicketStatus? status = null,
        List<global::ElevenLabs.AgentConversationTicketSource>? sources = null,
        List<global::ElevenLabs.AgentConversationTicketPriority>? priorities = null,
        global::ElevenLabs.AgentConversationTicketSortBy? sortBy = null,
        string? ownerUserId = null,
        string? assigneeUserId = null,
        global::ElevenLabs.AgentConversationTicketIssueType? issueType = null,
        string? label = null,
        string? mergedIntoTicketId = null,
        string? search = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/agents/{agent_id}/triage-tickets"
        )
            .SetPathParameter("agent_id", agentId)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("conversation_id", conversationId)
            .SetOptionalQueryParameter("status", status?.Value)
            .SetOptionalQueryParameter("sources", sources)
            .SetOptionalQueryParameter("priorities", priorities)
            .SetOptionalQueryParameter("sort_by", sortBy?.Value)
            .SetOptionalQueryParameter("owner_user_id", ownerUserId)
            .SetOptionalQueryParameter("assignee_user_id", assigneeUserId)
            .SetOptionalQueryParameter("issue_type", issueType?.Value)
            .SetOptionalQueryParameter("label", label)
            .SetOptionalQueryParameter("merged_into_ticket_id", mergedIntoTicketId)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("cursor", cursor)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.GetAgentConversationTicketsPageResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAgentConversationTicketsPageResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Manually raise a follow-up ticket against an agent, not tied to any conversation (for example a task like 'add the KB about X'). Without a title, one is derived from the comment. Requires viewer access to the agent.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentConversationTicketResponseModel> CreateManualAsync(
        global::ElevenLabs.Agents.CreateManualTicketRequestModel input,
        string agentId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_createManualAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/agents/{agent_id}/triage-tickets"
        )
            .SetPathParameter("agent_id", agentId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.AgentConversationTicketResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentConversationTicketResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>List conversation triage tickets across every agent in the workspace, ordered by most recently created first. Use this to build a workspace-wide view (for example, tickets assigned to the caller). Supports the same filters, sorting and search as the per-agent endpoint. Tickets for agents the caller cannot access are omitted.</summary>
    /// <param name="pageSize">How many agent conversation tickets to return. Can not exceed 100.</param>
    /// <param name="agentId">Only tickets for this agent.</param>
    /// <param name="status">Filter tickets by status.</param>
    /// <param name="sources">Filter tickets by how they were raised (qa, agent, manual). Repeat the parameter to filter by multiple sources.</param>
    /// <param name="priorities">Filter tickets by priority. Repeat the parameter to filter by multiple priorities.</param>
    /// <param name="sortBy">Order by most recently created, by priority (most urgent first, then most recently created), or by most recently reported (the newest report merged into the issue, else its creation).</param>
    /// <param name="ownerUserId">Filter tickets by creator. Use 'agent' for agent-raised tickets.</param>
    /// <param name="assigneeUserId">Filter tickets by assignee. Use 'unassigned' for tickets with no assignee.</param>
    /// <param name="issueType">Filter clusters by issue type.</param>
    /// <param name="label">Filter tickets by an exact label.</param>
    /// <param name="mergedIntoTicketId">Filter tickets merged into this ticket.</param>
    /// <param name="search">Case-insensitive free-text search across the ticket's title, description, comments, and turn comments.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAgentConversationTicketsPageResponseModel> ListForWorkspaceAsync(
        long? pageSize = 100,
        string? agentId = null,
        global::ElevenLabs.AgentConversationTicketStatus? status = null,
        List<global::ElevenLabs.AgentConversationTicketSource>? sources = null,
        List<global::ElevenLabs.AgentConversationTicketPriority>? priorities = null,
        global::ElevenLabs.AgentConversationTicketSortBy? sortBy = null,
        string? ownerUserId = null,
        string? assigneeUserId = null,
        global::ElevenLabs.AgentConversationTicketIssueType? issueType = null,
        string? label = null,
        string? mergedIntoTicketId = null,
        string? search = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listForWorkspaceAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/triage-tickets")
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("status", status?.Value)
            .SetOptionalQueryParameter("sources", sources)
            .SetOptionalQueryParameter("priorities", priorities)
            .SetOptionalQueryParameter("sort_by", sortBy?.Value)
            .SetOptionalQueryParameter("owner_user_id", ownerUserId)
            .SetOptionalQueryParameter("assignee_user_id", assigneeUserId)
            .SetOptionalQueryParameter("issue_type", issueType?.Value)
            .SetOptionalQueryParameter("label", label)
            .SetOptionalQueryParameter("merged_into_ticket_id", mergedIntoTicketId)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("cursor", cursor)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.GetAgentConversationTicketsPageResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAgentConversationTicketsPageResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Raise a ticket about an agent's performance on a conversation, for triage with Architect. Provide an overall comment and/or turn-level comments describing what went wrong.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentConversationTicketResponseModel> CreateAsync(
        global::ElevenLabs.Agents.CreateAgentConversationTicketRequestModel input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/convai/triage-tickets")
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.AgentConversationTicketResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentConversationTicketResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>All non-service-account workspace members, each flagged with whether they currently have at least viewer access to the agent. Members without access are included (not filtered out) so the UI can offer them as an assignee and prompt to grant access first.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<
        List<global::ElevenLabs.AssignableUserResponseModel>
    > ListAssignableUsersAsync(
        string agentId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_listAssignableUsersAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/agents/{agent_id}/triage-tickets/assignable-users"
        )
            .SetPathParameter("agent_id", agentId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        List<global::ElevenLabs.AssignableUserResponseModel> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                List<global::ElevenLabs.AssignableUserResponseModel>
            >(responseBody, _jsonSerializerOptions)!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get an agent conversation ticket by ID.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentConversationTicketResponseModel> GetAsync(
        string agentqaTicketId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentqaTicketId is null)
            throw new ArgumentNullException(nameof(agentqaTicketId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/triage-tickets/{agentqa_ticket_id}"
        )
            .SetPathParameter("agentqa_ticket_id", agentqaTicketId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.AgentConversationTicketResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentConversationTicketResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Update a ticket's title, comment, status, priority, and/or assignee. Requires viewer access to the ticket's agent.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentConversationTicketResponseModel> UpdateAsync(
        global::ElevenLabs.Agents.PatchAgentConversationTicketRequestModel input,
        string agentqaTicketId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentqaTicketId is null)
            throw new ArgumentNullException(nameof(agentqaTicketId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/convai/triage-tickets/{agentqa_ticket_id}"
        )
            .SetPathParameter("agentqa_ticket_id", agentqaTicketId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.AgentConversationTicketResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentConversationTicketResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Delete an agent conversation ticket. Restricted to the ticket creator or a workspace admin.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task DeleteAsync(
        string agentqaTicketId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentqaTicketId is null)
            throw new ArgumentNullException(nameof(agentqaTicketId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/convai/triage-tickets/{agentqa_ticket_id}"
        )
            .SetPathParameter("agentqa_ticket_id", agentqaTicketId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>Append a comment discussing how to resolve the ticket. Requires viewer access to the ticket's agent.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentConversationTicketResponseModel> AddCommentAsync(
        global::ElevenLabs.Agents.AddTicketCommentRequestModel input,
        string agentqaTicketId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentqaTicketId is null)
            throw new ArgumentNullException(nameof(agentqaTicketId));

        var resolvedConfig = GetResolvedConfig(_addCommentAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/triage-tickets/{agentqa_ticket_id}/comments"
        )
            .SetPathParameter("agentqa_ticket_id", agentqaTicketId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.AgentConversationTicketResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentConversationTicketResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Merge other open tickets of the same agent into this pending, in-progress, or resolved one. Their conversations move onto this ticket, its priority is raised to the highest among them, and they are kept with status 'merged'. Requires viewer access to the ticket's agent.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentConversationTicketResponseModel> MergeAsync(
        global::ElevenLabs.Agents.MergeAgentConversationTicketsRequestModel input,
        string agentqaTicketId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentqaTicketId is null)
            throw new ArgumentNullException(nameof(agentqaTicketId));

        var resolvedConfig = GetResolvedConfig(_mergeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/triage-tickets/{agentqa_ticket_id}/merge"
        )
            .SetPathParameter("agentqa_ticket_id", agentqaTicketId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.AgentConversationTicketResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentConversationTicketResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Append a turn-level comment to a ticket. Requires viewer access to the ticket's agent.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentConversationTicketResponseModel> AddTurnCommentAsync(
        global::ElevenLabs.Agents.AddTurnCommentRequestModel input,
        string agentqaTicketId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentqaTicketId is null)
            throw new ArgumentNullException(nameof(agentqaTicketId));

        var resolvedConfig = GetResolvedConfig(_addTurnCommentAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/triage-tickets/{agentqa_ticket_id}/turn-comments"
        )
            .SetPathParameter("agentqa_ticket_id", agentqaTicketId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.AgentConversationTicketResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentConversationTicketResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }
}
