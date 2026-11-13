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
/// Service class providing access to API endpoints for MergeProposalsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class MergeProposalsService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _createAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _submitReviewAsyncConfig;
    private RequestConfig? _addCommentAsyncConfig;
    private RequestConfig? _mergeAsyncConfig;

    internal MergeProposalsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MergeProposalsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MergeProposalsService SetCreateAsyncConfig(RequestConfig config)
    {
        _createAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MergeProposalsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MergeProposalsService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SubmitReviewAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MergeProposalsService SetSubmitReviewAsyncConfig(RequestConfig config)
    {
        _submitReviewAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddCommentAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MergeProposalsService SetAddCommentAsyncConfig(RequestConfig config)
    {
        _addCommentAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MergeProposalsService SetMergeAsyncConfig(RequestConfig config)
    {
        _mergeAsyncConfig = config;
        return this;
    }

    /// <summary>List the proposals for an agent, newest first.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="status">Only return proposals with this status.</param>
    /// <param name="sourceBranchId">Only return proposals with this source branch.</param>
    /// <param name="targetBranchId">Only return proposals with this target branch.</param>
    /// <param name="search">Case-insensitive substring match over title and description.</param>
    /// <param name="pageSize">How many results at most should be returned</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.PaginatedResultAgentMergeProposalResponse_> ListAsync(
        string agentId,
        global::ElevenLabs.Agents.MergeProposalStatus? status = null,
        string? sourceBranchId = null,
        string? targetBranchId = null,
        string? search = null,
        long? pageSize = 100,
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
            "v1/convai/agents/{agent_id}/merge-proposals"
        )
            .SetPathParameter("agent_id", agentId)
            .SetOptionalQueryParameter("status", status?.Value)
            .SetOptionalQueryParameter("source_branch_id", sourceBranchId)
            .SetOptionalQueryParameter("target_branch_id", targetBranchId)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("page_size", pageSize)
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
        global::ElevenLabs.PaginatedResultAgentMergeProposalResponse_ result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.PaginatedResultAgentMergeProposalResponse_>(
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

    /// <summary>Record a request to merge a source branch into a target branch. Anyone with edit access can open one; merging it later is gated on write access to the target branch, so this is how a change reaches a protected branch the author cannot merge into themselves.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.CreateAgentMergeProposalResponseModel> CreateAsync(
        global::ElevenLabs.Agents.BodyCreateAMergeProposalV1ConvaiAgentsAgentIdMergeProposalsPost input,
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

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/agents/{agent_id}/merge-proposals"
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
        global::ElevenLabs.CreateAgentMergeProposalResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.CreateAgentMergeProposalResponseModel>(
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

    /// <summary>Get a single merge_proposal.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="mergeProposalId">Unique identifier for the merge_proposal.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentMergeProposalResponse> GetAsync(
        string agentId,
        string mergeProposalId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (mergeProposalId is null)
            throw new ArgumentNullException(nameof(mergeProposalId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("merge_proposal_id", mergeProposalId)
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
        global::ElevenLabs.AgentMergeProposalResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentMergeProposalResponse>(
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

    /// <summary>Edit an open merge_proposal's title or description, or close it. The author closing it is recorded as withdrawn; anyone else as rejected.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="mergeProposalId">Unique identifier for the merge_proposal.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentMergeProposalResponse> UpdateAsync(
        global::ElevenLabs.Agents.BodyUpdateAMergeProposalV1ConvaiAgentsAgentIdMergeProposalsMergeProposalIdPatch input,
        string agentId,
        string mergeProposalId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (mergeProposalId is null)
            throw new ArgumentNullException(nameof(mergeProposalId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("merge_proposal_id", mergeProposalId)
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
        global::ElevenLabs.AgentMergeProposalResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentMergeProposalResponse>(
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

    /// <summary>Approve a merge_proposal or request changes on it. A user's latest review replaces their previous one. Non-admins need an approval from another user before the merge is allowed.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="mergeProposalId">Unique identifier for the merge_proposal.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentMergeProposalResponse> SubmitReviewAsync(
        global::ElevenLabs.Agents.BodyReviewAMergeProposalV1ConvaiAgentsAgentIdMergeProposalsMergeProposalIdReviewsPost input,
        string agentId,
        string mergeProposalId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (mergeProposalId is null)
            throw new ArgumentNullException(nameof(mergeProposalId));

        var resolvedConfig = GetResolvedConfig(_submitReviewAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}/reviews"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("merge_proposal_id", mergeProposalId)
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
        global::ElevenLabs.AgentMergeProposalResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentMergeProposalResponse>(
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

    /// <summary>Leave a comment on a merge_proposal without recording a review verdict. Unlike reviews, comments accumulate and can still be added once the merge_proposal is merged or closed.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="mergeProposalId">Unique identifier for the merge_proposal.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentMergeProposalResponse> AddCommentAsync(
        global::ElevenLabs.Agents.BodyCommentOnAMergeProposalV1ConvaiAgentsAgentIdMergeProposalsMergeProposalIdCommentsPost input,
        string agentId,
        string mergeProposalId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (mergeProposalId is null)
            throw new ArgumentNullException(nameof(mergeProposalId));

        var resolvedConfig = GetResolvedConfig(_addCommentAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}/comments"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("merge_proposal_id", mergeProposalId)
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
        global::ElevenLabs.AgentMergeProposalResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentMergeProposalResponse>(
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

    /// <summary>Execute the merge. The caller must have write access to the target branch (admins only, for a protected branch), so this is where a reviewer approves and merges a request opened by someone who could not.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="mergeProposalId">Unique identifier for the merge_proposal.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentMergeProposalResponse> MergeAsync(
        global::ElevenLabs.Agents.BodyMergeAMergeProposalV1ConvaiAgentsAgentIdMergeProposalsMergeProposalIdMergePost input,
        string agentId,
        string mergeProposalId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (mergeProposalId is null)
            throw new ArgumentNullException(nameof(mergeProposalId));

        var resolvedConfig = GetResolvedConfig(_mergeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/agents/{agent_id}/merge-proposals/{merge_proposal_id}/merge"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("merge_proposal_id", mergeProposalId)
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
        global::ElevenLabs.AgentMergeProposalResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentMergeProposalResponse>(
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
