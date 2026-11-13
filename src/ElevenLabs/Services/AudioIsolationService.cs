using System.Net.Http.Headers;
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
/// Service class providing access to API endpoints for AudioIsolationService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class AudioIsolationService : BaseService
{
    private RequestConfig? _convertAsyncConfig;
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;
    private RequestConfig? _streamAsyncConfig;

    internal AudioIsolationService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioIsolationService SetConvertAsyncConfig(RequestConfig config)
    {
        _convertAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioIsolationService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioIsolationService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioIsolationService SetStreamAsyncConfig(RequestConfig config)
    {
        _streamAsyncConfig = config;
        return this;
    }

    /// <summary>Removes background noise from audio.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> ConvertAsync(
        global::ElevenLabs.AudioIsolationRequest input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_convertAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/audio-isolation")
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteDownloadAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Open the response body as a live stream
        global::System.IO.Stream result = await global::ElevenLabs
            .Core.ResponseBodyStream.OpenAsync(response, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    /// <summary>Returns a list of all your audio isolation generations.</summary>
    /// <param name="pageSize">How many history items to return at maximum. Defaults to 100.</param>
    /// <param name="page">Page number for search pagination (1-based). Only used when search is provided.</param>
    /// <param name="search">Optional search term used for filtering audio isolation history (title/text).</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAudioIsolationHistoryResponseModel> ListAsync(
        long? pageSize = 100,
        long? page = 1,
        string? search = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/audio-isolation/history")
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("page", page)
            .SetOptionalQueryParameter("search", search)
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
        global::ElevenLabs.GetAudioIsolationHistoryResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAudioIsolationHistoryResponseModel>(
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

    /// <summary>Deletes a specific audio isolation history item and the associated media files.</summary>
    /// <param name="historyItemId">Identifier of the audio isolation history item.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task DeleteAsync(
        string historyItemId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (historyItemId is null)
            throw new ArgumentNullException(nameof(historyItemId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/audio-isolation/history/{history_item_id}"
        )
            .SetPathParameter("history_item_id", historyItemId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>Removes background noise from audio.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> StreamAsync(
        global::ElevenLabs.AudioIsolationStreamRequest input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_streamAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/audio-isolation/stream")
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
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
