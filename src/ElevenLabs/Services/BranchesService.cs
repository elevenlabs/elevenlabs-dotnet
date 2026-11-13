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
/// Service class providing access to API endpoints for BranchesService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class BranchesService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _createAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _previewMergeAsyncConfig;
    private RequestConfig? _mergeAsyncConfig;
    private RequestConfig? _previewRebaseAsyncConfig;
    private RequestConfig? _rebaseAsyncConfig;

    internal BranchesService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetCreateAsyncConfig(RequestConfig config)
    {
        _createAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>PreviewMergeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetPreviewMergeAsyncConfig(RequestConfig config)
    {
        _previewMergeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetMergeAsyncConfig(RequestConfig config)
    {
        _mergeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>PreviewRebaseAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetPreviewRebaseAsyncConfig(RequestConfig config)
    {
        _previewRebaseAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RebaseAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public BranchesService SetRebaseAsyncConfig(RequestConfig config)
    {
        _rebaseAsyncConfig = config;
        return this;
    }

    /// <summary>Returns a list of branches an agent has</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="includeArchived">Whether archived branches should be included</param>
    /// <param name="limit">How many results at most should be returned</param>
    /// <param name="includeCommitStatus">Whether to compute how far each branch has diverged from main (commits_ahead/commits_behind). This walks the version DAG of every branch, so it is slow on agents with long histories and is off by default, leaving those fields null.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ListResponseAgentBranchSummary_> ListAsync(
        string agentId,
        bool? includeArchived = false,
        long? limit = 100,
        bool? includeCommitStatus = false,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/agents/{agent_id}/branches")
            .SetPathParameter("agent_id", agentId)
            .SetOptionalQueryParameter("include_archived", includeArchived)
            .SetOptionalQueryParameter("limit", limit)
            .SetOptionalQueryParameter("include_commit_status", includeCommitStatus)
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
        global::ElevenLabs.ListResponseAgentBranchSummary_ result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ListResponseAgentBranchSummary_>(
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

    /// <summary>Create a new branch from a given version of any branch</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.CreateAgentBranchResponseModel> CreateAsync(
        global::ElevenLabs.Agents.BodyCreateANewBranchV1ConvaiAgentsAgentIdBranchesPost input,
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

        var request = new RequestBuilder(HttpMethod.Post, "v1/convai/agents/{agent_id}/branches")
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
        global::ElevenLabs.CreateAgentBranchResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.CreateAgentBranchResponseModel>(
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

    /// <summary>Get information about a single agent branch</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="branchId">Unique identifier for the branch.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentBranchResponse> GetAsync(
        string agentId,
        string branchId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (branchId is null)
            throw new ArgumentNullException(nameof(branchId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/agents/{agent_id}/branches/{branch_id}"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("branch_id", branchId)
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
        global::ElevenLabs.AgentBranchResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentBranchResponse>(
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

    /// <summary>Update agent branch properties such as name, description, archiving status, protection level, and auto-rebase onto main</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="branchId">Unique identifier for the branch.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentBranchResponse> UpdateAsync(
        global::ElevenLabs.Agents.BodyUpdateAgentBranchV1ConvaiAgentsAgentIdBranchesBranchIdPatch input,
        string agentId,
        string branchId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (branchId is null)
            throw new ArgumentNullException(nameof(branchId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/convai/agents/{agent_id}/branches/{branch_id}"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("branch_id", branchId)
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
        global::ElevenLabs.AgentBranchResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentBranchResponse>(
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

    /// <summary>Returns the result of merging the source branch into the target branch without performing the merge. Useful for showing an accurate diff before confirming.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="sourceBranchId">Unique identifier for the source branch to merge from.</param>
    /// <param name="targetBranchId">The ID of the target branch to merge into.</param>
    /// <param name="force">When true, source branch changes always win conflicts regardless of timestamps</param>
    /// <param name="includeProcedureGeneratedWorkflowElements">Whether to include the workflow nodes and edges generated from structured procedures. When false, the workflow contains only authored elements.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MergePreviewResponseModel> PreviewMergeAsync(
        string agentId,
        string sourceBranchId,
        string targetBranchId,
        bool? force = false,
        bool? includeProcedureGeneratedWorkflowElements = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (sourceBranchId is null)
            throw new ArgumentNullException(nameof(sourceBranchId));
        if (targetBranchId is null)
            throw new ArgumentNullException(nameof(targetBranchId));

        var resolvedConfig = GetResolvedConfig(_previewMergeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/agents/{agent_id}/branches/{source_branch_id}/merge-preview"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("source_branch_id", sourceBranchId)
            .SetOptionalQueryParameter("target_branch_id", targetBranchId)
            .SetOptionalQueryParameter("force", force)
            .SetOptionalQueryParameter(
                "include_procedure_generated_workflow_elements",
                includeProcedureGeneratedWorkflowElements
            )
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
        global::ElevenLabs.MergePreviewResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MergePreviewResponseModel>(
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

    /// <summary>Merge a branch into a target branch</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="sourceBranchId">Unique identifier for the source branch to merge from.</param>
    /// <param name="targetBranchId">The ID of the target branch to merge into.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<object> MergeAsync(
        global::ElevenLabs.Agents.BodyMergeABranchIntoATargetBranchV1ConvaiAgentsAgentIdBranchesSourceBranchIdMergePost input,
        string agentId,
        string sourceBranchId,
        string targetBranchId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (sourceBranchId is null)
            throw new ArgumentNullException(nameof(sourceBranchId));
        if (targetBranchId is null)
            throw new ArgumentNullException(nameof(targetBranchId));

        var resolvedConfig = GetResolvedConfig(_mergeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/agents/{agent_id}/branches/{source_branch_id}/merge"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("source_branch_id", sourceBranchId)
            .SetOptionalQueryParameter("target_branch_id", targetBranchId)
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
        object result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<object>(
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

    /// <summary>Returns the result of pulling changes from a source branch (defaults to main) into the given branch without performing it, preserving the given branch's own changes. Useful for showing an accurate diff before confirming.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="branchId">Unique identifier for the source branch to merge from.</param>
    /// <param name="sourceBranchId">The ID of the branch to pull changes from. Defaults to the agent's main branch.</param>
    /// <param name="includeProcedureGeneratedWorkflowElements">Whether to include the workflow nodes and edges generated from structured procedures. When false, the workflow contains only authored elements.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MergePreviewResponseModel> PreviewRebaseAsync(
        string agentId,
        string branchId,
        string? sourceBranchId = null,
        bool? includeProcedureGeneratedWorkflowElements = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (branchId is null)
            throw new ArgumentNullException(nameof(branchId));

        var resolvedConfig = GetResolvedConfig(_previewRebaseAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/agents/{agent_id}/branches/{branch_id}/rebase-preview"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("branch_id", branchId)
            .SetOptionalQueryParameter("source_branch_id", sourceBranchId)
            .SetOptionalQueryParameter(
                "include_procedure_generated_workflow_elements",
                includeProcedureGeneratedWorkflowElements
            )
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
        global::ElevenLabs.MergePreviewResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MergePreviewResponseModel>(
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

    /// <summary>Pull changes from a source branch (defaults to main) into this branch as a new version, preserving this branch's own changes on conflicts.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="branchId">Unique identifier for the source branch to merge from.</param>
    /// <param name="sourceBranchId">The ID of the branch to pull changes from. Defaults to the agent's main branch.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<object> RebaseAsync(
        global::ElevenLabs.Agents.BodyRebaseABranchOntoMainV1ConvaiAgentsAgentIdBranchesBranchIdRebasePost input,
        string agentId,
        string branchId,
        string? sourceBranchId = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (branchId is null)
            throw new ArgumentNullException(nameof(branchId));

        var resolvedConfig = GetResolvedConfig(_rebaseAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/agents/{agent_id}/branches/{branch_id}/rebase"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("branch_id", branchId)
            .SetOptionalQueryParameter("source_branch_id", sourceBranchId)
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
        object result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<object>(
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
