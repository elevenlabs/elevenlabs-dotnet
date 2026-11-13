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
using OneOf;

namespace ElevenLabs.Services;

/// <summary>
/// Service class providing access to API endpoints for KnowledgeBaseService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class KnowledgeBaseService : BaseService
{
    private RequestConfig? _sizeAsyncConfig;
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _getOrCreateRagIndexesAsyncConfig;
    private RequestConfig? _searchAsyncConfig;

    internal KnowledgeBaseService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>SizeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public KnowledgeBaseService SetSizeAsyncConfig(RequestConfig config)
    {
        _sizeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public KnowledgeBaseService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetOrCreateRagIndexesAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public KnowledgeBaseService SetGetOrCreateRagIndexesAsyncConfig(RequestConfig config)
    {
        _getOrCreateRagIndexesAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public KnowledgeBaseService SetSearchAsyncConfig(RequestConfig config)
    {
        _searchAsyncConfig = config;
        return this;
    }

    /// <summary>Returns the number of pages in the agent's knowledge base.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAgentKnowledgebaseSizeResponseModel> SizeAsync(
        string agentId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_sizeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/agent/{agent_id}/knowledge-base/size"
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
        global::ElevenLabs.GetAgentKnowledgebaseSizeResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAgentKnowledgebaseSizeResponseModel>(
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

    /// <summary>Get a list of available knowledge base documents</summary>
    /// <param name="pageSize">How many documents to return at maximum. Can not exceed 100, defaults to 30.</param>
    /// <param name="search">If specified, the endpoint returns only such knowledge base documents whose names start with this string.</param>
    /// <param name="showOnlyOwnedDocuments">If set to true, the endpoint will return only documents owned by you (and not shared from somebody else). Deprecated: use created_by_user_id instead.</param>
    /// <param name="createdByUserId">Filter documents by creator user ID. When set, only documents created by this user are returned. Takes precedence over show_only_owned_documents. Use '@me' to refer to the authenticated user.</param>
    /// <param name="types">If present, the endpoint will return only documents of the given types.</param>
    /// <param name="parentFolderId">If set, the endpoint will return only documents that are direct children of the given folder.</param>
    /// <param name="ancestorFolderId">If set, the endpoint will return only documents that are descendants of the given folder.</param>
    /// <param name="foldersFirst">Whether folders should be returned first in the list of documents.</param>
    /// <param name="sortDirection">The direction to sort the results</param>
    /// <param name="sortBy">The field to sort the results by</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetKnowledgeBaseListResponseModel> ListAsync(
        long? pageSize = 30,
        string? search = null,
        bool? showOnlyOwnedDocuments = false,
        string? createdByUserId = null,
        List<global::ElevenLabs.KnowledgeBaseDocumentType>? types = null,
        string? parentFolderId = null,
        string? ancestorFolderId = null,
        bool? foldersFirst = false,
        global::ElevenLabs.SortDirection1? sortDirection = null,
        global::ElevenLabs.Agents.KnowledgeBaseSortBy? sortBy = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/knowledge-base")
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("show_only_owned_documents", showOnlyOwnedDocuments)
            .SetOptionalQueryParameter("created_by_user_id", createdByUserId)
            .SetOptionalQueryParameter("types", types)
            .SetOptionalQueryParameter("parent_folder_id", parentFolderId)
            .SetOptionalQueryParameter("ancestor_folder_id", ancestorFolderId)
            .SetOptionalQueryParameter("folders_first", foldersFirst)
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
        global::ElevenLabs.GetKnowledgeBaseListResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetKnowledgeBaseListResponseModel>(
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

    /// <summary>Retrieves and/or creates RAG indexes for multiple knowledge base documents in a single request. Maximum 100 items per request.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<
        Dictionary<string, global::ElevenLabs.GetOrCreateRagIndexesKnowledgeBaseResponse>
    > GetOrCreateRagIndexesAsync(
        global::ElevenLabs.Agents.BodyComputeRagIndexesInBatchV1ConvaiKnowledgeBaseRagIndexPost input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_getOrCreateRagIndexesAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/convai/knowledge-base/rag-index")
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
        Dictionary<string, global::ElevenLabs.GetOrCreateRagIndexesKnowledgeBaseResponse> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                Dictionary<string, global::ElevenLabs.GetOrCreateRagIndexesKnowledgeBaseResponse>
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

    /// <summary>Fuzzy text search over knowledge base document content</summary>
    /// <param name="query">The search query text</param>
    /// <param name="pageSize">How many documents to return at maximum. Can not exceed 100, defaults to 30.</param>
    /// <param name="types">If present, the endpoint will return only documents of the given types.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.KnowledgeBaseContentSearchResponseModel> SearchAsync(
        string query,
        long? pageSize = 30,
        List<global::ElevenLabs.KnowledgeBaseDocumentType>? types = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (query is null)
            throw new ArgumentNullException(nameof(query));

        var resolvedConfig = GetResolvedConfig(_searchAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/knowledge-base/search")
            .SetOptionalQueryParameter("query", query)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("types", types)
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
        global::ElevenLabs.KnowledgeBaseContentSearchResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.KnowledgeBaseContentSearchResponseModel>(
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
