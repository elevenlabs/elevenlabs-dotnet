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
/// Service class providing access to API endpoints for AgentsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class AgentsService : BaseService
{
    private RequestConfig? _createAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _duplicateAsyncConfig;
    private RequestConfig? _runTestsAsyncConfig;
    private RequestConfig? _ragIndexOverviewAsyncConfig;
    private RequestConfig? _getDocumentRagIndexesAsyncConfig;
    private RequestConfig? _deleteDocumentRagIndexAsyncConfig;

    internal AgentsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetCreateAsyncConfig(RequestConfig config)
    {
        _createAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DuplicateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetDuplicateAsyncConfig(RequestConfig config)
    {
        _duplicateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RunTestsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetRunTestsAsyncConfig(RequestConfig config)
    {
        _runTestsAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RagIndexOverviewAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetRagIndexOverviewAsyncConfig(RequestConfig config)
    {
        _ragIndexOverviewAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetDocumentRagIndexesAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetGetDocumentRagIndexesAsyncConfig(RequestConfig config)
    {
        _getDocumentRagIndexesAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteDocumentRagIndexAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AgentsService SetDeleteDocumentRagIndexAsyncConfig(RequestConfig config)
    {
        _deleteDocumentRagIndexAsyncConfig = config;
        return this;
    }

    /// <summary>Create an agent from a config object</summary>
    /// <param name="enableVersioning">Deprecated: all agents are versioned. This parameter is ignored.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.CreateAgentResponseModel> CreateAsync(
        global::ElevenLabs.BodyCreateAgentV1ConvaiAgentsCreatePost input,
        bool? enableVersioning = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/convai/agents/create")
            .SetOptionalQueryParameter("enable_versioning", enableVersioning)
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
        global::ElevenLabs.CreateAgentResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.CreateAgentResponseModel>(
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

    /// <summary>Retrieve config for an agent</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="versionId">The ID of the agent version to use</param>
    /// <param name="branchId">The ID of the branch to use</param>
    /// <param name="includeProcedureGeneratedWorkflowElements">Whether to include the workflow nodes and edges generated from structured procedures. When false, the workflow contains only authored elements.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAgentResponseModel> GetAsync(
        string agentId,
        string? versionId = null,
        string? branchId = null,
        bool? includeProcedureGeneratedWorkflowElements = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/agents/{agent_id}")
            .SetPathParameter("agent_id", agentId)
            .SetOptionalQueryParameter("version_id", versionId)
            .SetOptionalQueryParameter("branch_id", branchId)
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
        global::ElevenLabs.GetAgentResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAgentResponseModel>(
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

    /// <summary>Patches an Agent settings</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="enableVersioningIfNotEnabled">Deprecated: all agents are versioned. This parameter is ignored.</param>
    /// <param name="branchId">The ID of the branch to use</param>
    /// <param name="includeProcedureGeneratedWorkflowElements">Whether to include the workflow nodes and edges generated from structured procedures. When false, the workflow contains only authored elements.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAgentResponseModel> UpdateAsync(
        global::ElevenLabs.UpdateAgentRequest input,
        string agentId,
        bool? enableVersioningIfNotEnabled = true,
        string? branchId = null,
        bool? includeProcedureGeneratedWorkflowElements = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(new HttpMethod("PATCH"), "v1/convai/agents/{agent_id}")
            .SetPathParameter("agent_id", agentId)
            .SetOptionalQueryParameter(
                "enable_versioning_if_not_enabled",
                enableVersioningIfNotEnabled
            )
            .SetOptionalQueryParameter("branch_id", branchId)
            .SetOptionalQueryParameter(
                "include_procedure_generated_workflow_elements",
                includeProcedureGeneratedWorkflowElements
            )
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
        global::ElevenLabs.GetAgentResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAgentResponseModel>(
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

    /// <summary>Delete an agent</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="force">If set to true, the agent is deleted even if other agents use it as a subagent, and it is removed from those agents and their branches.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task DeleteAsync(
        string agentId,
        bool? force = false,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Delete, "v1/convai/agents/{agent_id}")
            .SetPathParameter("agent_id", agentId)
            .SetOptionalQueryParameter("force", force)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>Returns a list of your agents and their metadata.</summary>
    /// <param name="pageSize">How many Agents to return at maximum. Can not exceed 100, defaults to 30.</param>
    /// <param name="search">Search by agents name.</param>
    /// <param name="archived">Filter agents by archived status</param>
    /// <param name="showOnlyOwnedAgents">If set to true, the endpoint will omit any agents that were shared with you by someone else and include only the ones you own. Deprecated: use created_by_user_id instead.</param>
    /// <param name="createdByUserId">Filter agents by creator user ID. When set, only agents created by this user are returned. Takes precedence over show_only_owned_agents. Use '@me' to refer to the authenticated user.</param>
    /// <param name="tags">Filter agents by tag. Repeat the parameter to match any of several tags.</param>
    /// <param name="sortDirection">The direction to sort the results</param>
    /// <param name="sortBy">The field to sort the results by</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAgentsPageResponseModel> ListAsync(
        long? pageSize = 30,
        string? search = null,
        bool? archived = null,
        bool? showOnlyOwnedAgents = false,
        string? createdByUserId = null,
        List<string>? tags = null,
        global::ElevenLabs.SortDirection1? sortDirection = null,
        global::ElevenLabs.AgentSortBy? sortBy = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/agents")
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("archived", archived)
            .SetOptionalQueryParameter("show_only_owned_agents", showOnlyOwnedAgents)
            .SetOptionalQueryParameter("created_by_user_id", createdByUserId)
            .SetOptionalQueryParameter("tags", tags)
            .SetOptionalQueryParameter("sort_direction", sortDirection?.Value)
            .SetOptionalQueryParameter("sort_by", sortBy?.Value)
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
        global::ElevenLabs.GetAgentsPageResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAgentsPageResponseModel>(
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

    /// <summary>Create a new agent by duplicating an existing one. The new agent gets a copy of every unarchived branch of the source agent, each with the same name and description and starting from the latest version on that branch. The live traffic split is copied onto the new branches, with any share held by a branch that was not copied moved to main. Version history, drafts, archived branches, past traffic splits and experiments are not copied.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.CreateAgentResponseModel> DuplicateAsync(
        global::ElevenLabs.BodyDuplicateAgentV1ConvaiAgentsAgentIdDuplicatePost input,
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

        var resolvedConfig = GetResolvedConfig(_duplicateAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/convai/agents/{agent_id}/duplicate")
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
        global::ElevenLabs.CreateAgentResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.CreateAgentResponseModel>(
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

    /// <summary>Run selected tests on the agent with provided configuration. If the agent configuration is provided, it will be used to override default agent configuration.</summary>
    /// <param name="agentId">The id of an agent. This is returned on agent creation.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetTestSuiteInvocationResponseModel> RunTestsAsync(
        global::ElevenLabs.RunAgentTestsRequestModel input,
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

        var resolvedConfig = GetResolvedConfig(_runTestsAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/convai/agents/{agent_id}/run-tests")
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
        global::ElevenLabs.GetTestSuiteInvocationResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetTestSuiteInvocationResponseModel>(
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

    /// <summary>Provides total size and other information of RAG indexes used by knowledgebase documents</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.RagIndexOverviewResponseModel> RagIndexOverviewAsync(
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_ragIndexOverviewAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/knowledge-base/rag-index")
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
        global::ElevenLabs.RagIndexOverviewResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.RagIndexOverviewResponseModel>(
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

    /// <summary>Provides information about all RAG indexes of the specified knowledgebase document.</summary>
    /// <param name="documentationId">The id of a document from the knowledge base. This is returned on document addition.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.RagDocumentIndexesResponseModel> GetDocumentRagIndexesAsync(
        string documentationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (documentationId is null)
            throw new ArgumentNullException(nameof(documentationId));

        var resolvedConfig = GetResolvedConfig(_getDocumentRagIndexesAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/knowledge-base/{documentation_id}/rag-index"
        )
            .SetPathParameter("documentation_id", documentationId)
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
        global::ElevenLabs.RagDocumentIndexesResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.RagDocumentIndexesResponseModel>(
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

    /// <summary>Delete RAG index for the knowledgebase document.</summary>
    /// <param name="documentationId">The id of a document from the knowledge base. This is returned on document addition.</param>
    /// <param name="ragIndexId">The id of RAG index of document from the knowledge base.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.RagDocumentIndexResponseModel> DeleteDocumentRagIndexAsync(
        string documentationId,
        string ragIndexId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (documentationId is null)
            throw new ArgumentNullException(nameof(documentationId));
        if (ragIndexId is null)
            throw new ArgumentNullException(nameof(ragIndexId));

        var resolvedConfig = GetResolvedConfig(_deleteDocumentRagIndexAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/convai/knowledge-base/{documentation_id}/rag-index/{rag_index_id}"
        )
            .SetPathParameter("documentation_id", documentationId)
            .SetPathParameter("rag_index_id", ragIndexId)
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
        global::ElevenLabs.RagDocumentIndexResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.RagDocumentIndexResponseModel>(
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
