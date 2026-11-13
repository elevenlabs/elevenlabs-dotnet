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
/// Service class providing access to API endpoints for HistoryService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class HistoryService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;
    private RequestConfig? _getAudioAsyncConfig;
    private RequestConfig? _downloadAsyncConfig;

    internal HistoryService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public HistoryService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public HistoryService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public HistoryService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAudioAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public HistoryService SetGetAudioAsyncConfig(RequestConfig config)
    {
        _getAudioAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DownloadAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public HistoryService SetDownloadAsyncConfig(RequestConfig config)
    {
        _downloadAsyncConfig = config;
        return this;
    }

    /// <summary>Returns a list of your generated audio (e.g. text to speech, speech to speech, Studio, dubbing). Music and SFX generations are not included and cannot currently be retrieved via the API.</summary>
    /// <param name="pageSize">How many history items to return at maximum. Can not exceed 1000, defaults to 100.</param>
    /// <param name="startAfterHistoryItemId">After which ID to start fetching, use this parameter to paginate across a large collection of history items. In case this parameter is not provided history items will be fetched starting from the most recently created one ordered descending by their creation date.</param>
    /// <param name="voiceId">ID of the voice to be filtered for. You can use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="modelId">Search term used for filtering history items. If provided, source becomes required.</param>
    /// <param name="dateBeforeUnix">Unix timestamp to filter history items before this date (exclusive).</param>
    /// <param name="dateAfterUnix">Unix timestamp to filter history items after this date (inclusive).</param>
    /// <param name="sortDirection">Sort direction for the results.</param>
    /// <param name="search">search term used for filtering</param>
    /// <param name="source">Source of the generated history item</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetSpeechHistoryResponse> ListAsync(
        long? pageSize = 100,
        string? startAfterHistoryItemId = null,
        string? voiceId = null,
        string? modelId = null,
        long? dateBeforeUnix = null,
        long? dateAfterUnix = null,
        global::ElevenLabs.ListHistoryRequestSortDirection? sortDirection = null,
        string? search = null,
        global::ElevenLabs.ListHistoryRequestSource? source = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/history")
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("start_after_history_item_id", startAfterHistoryItemId)
            .SetOptionalQueryParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("model_id", modelId)
            .SetOptionalQueryParameter("date_before_unix", dateBeforeUnix)
            .SetOptionalQueryParameter("date_after_unix", dateAfterUnix)
            .SetOptionalQueryParameter("sort_direction", sortDirection?.Value)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("source", source?.Value)
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
        global::ElevenLabs.GetSpeechHistoryResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetSpeechHistoryResponse>(
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

    /// <summary>Retrieves a history item.</summary>
    /// <param name="historyItemId">ID of the history item to be used. You can use the [Get generated items](/docs/api-reference/history/list) endpoint to retrieve a list of history items.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.SpeechHistoryItemResponse> GetAsync(
        string historyItemId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (historyItemId is null)
            throw new ArgumentNullException(nameof(historyItemId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/history/{history_item_id}")
            .SetPathParameter("history_item_id", historyItemId)
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
        global::ElevenLabs.SpeechHistoryItemResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.SpeechHistoryItemResponse>(
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

    /// <summary>Delete a history item by its ID</summary>
    /// <param name="historyItemId">ID of the history item to be used. You can use the [Get generated items](/docs/api-reference/history/list) endpoint to retrieve a list of history items.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DeleteHistoryItemResponse> DeleteAsync(
        string historyItemId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (historyItemId is null)
            throw new ArgumentNullException(nameof(historyItemId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Delete, "v1/history/{history_item_id}")
            .SetPathParameter("history_item_id", historyItemId)
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
        global::ElevenLabs.DeleteHistoryItemResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DeleteHistoryItemResponse>(
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

    /// <summary>Returns the audio of an history item.</summary>
    /// <param name="historyItemId">ID of the history item to be used. You can use the [Get generated items](/docs/api-reference/history/list) endpoint to retrieve a list of history items.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> GetAudioAsync(
        string historyItemId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (historyItemId is null)
            throw new ArgumentNullException(nameof(historyItemId));

        var resolvedConfig = GetResolvedConfig(_getAudioAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/history/{history_item_id}/audio")
            .SetPathParameter("history_item_id", historyItemId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteDownloadAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Open the response body as a live stream
        global::System.IO.Stream result = await global::ElevenLabs
            .Core.ResponseBodyStream.OpenAsync(response, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    /// <summary>Download one or more history items. If one history item ID is provided, we will return a single audio file. If more than one history item IDs are provided, we will provide the history items packed into a .zip file.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> DownloadAsync(
        global::ElevenLabs.History.DownloadHistoryRequest input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_downloadAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/history/download")
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteDownloadAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Open the response body as a live stream
        global::System.IO.Stream result = await global::ElevenLabs
            .Core.ResponseBodyStream.OpenAsync(response, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }
}
