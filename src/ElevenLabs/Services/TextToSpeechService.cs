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
/// Service class providing access to API endpoints for TextToSpeechService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class TextToSpeechService : BaseService
{
    private RequestConfig? _convertAsyncConfig;
    private RequestConfig? _convertWithTimestampsAsyncConfig;
    private RequestConfig? _streamAsyncConfig;
    private RequestConfig? _streamWithTimestampsAsyncConfig;
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _createAsyncConfig;
    private RequestConfig? _getAsyncConfig;

    internal TextToSpeechService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToSpeechService SetConvertAsyncConfig(RequestConfig config)
    {
        _convertAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertWithTimestampsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToSpeechService SetConvertWithTimestampsAsyncConfig(RequestConfig config)
    {
        _convertWithTimestampsAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToSpeechService SetStreamAsyncConfig(RequestConfig config)
    {
        _streamAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamWithTimestampsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToSpeechService SetStreamWithTimestampsAsyncConfig(RequestConfig config)
    {
        _streamWithTimestampsAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToSpeechService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToSpeechService SetCreateAsyncConfig(RequestConfig config)
    {
        _createAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToSpeechService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>Converts text into speech using a voice of your choice and returns audio.</summary>
    /// <param name="voiceId">ID of the voice to be used. Use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="optimizeStreamingLatency">
    /// You can turn on latency optimizations at some cost of quality. The best possible final latency varies by model. Possible values:
    /// 0 - default mode (no latency optimizations)
    /// 1 - normal latency optimizations (about 50% of possible latency improvement of option 3)
    /// 2 - strong latency optimizations (about 75% of possible latency improvement of option 3)
    /// 3 - max latency optimizations
    /// 4 - max latency optimizations, but also with text normalizer turned off for even more latency savings (best latency, but can mispronounce eg numbers and dates).
    ///
    /// Defaults to None.
    /// </param>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM and WAV formats with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> ConvertAsync(
        global::ElevenLabs.BodyTextToSpeechFull input,
        string voiceId,
        bool? enableLogging = true,
        long? optimizeStreamingLatency = null,
        global::ElevenLabs.ConvertTextToSpeechRequestOutputFormat? outputFormat = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_convertAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/text-to-speech/{voice_id}")
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalQueryParameter("optimize_streaming_latency", optimizeStreamingLatency)
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
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

    /// <summary>Generate speech from text with precise character-level timing information for audio-text synchronization.</summary>
    /// <param name="voiceId">Voice ID to be used, you can use https://api.elevenlabs.io/v1/voices to list all the available voices.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="optimizeStreamingLatency">
    /// You can turn on latency optimizations at some cost of quality. The best possible final latency varies by model. Possible values:
    /// 0 - default mode (no latency optimizations)
    /// 1 - normal latency optimizations (about 50% of possible latency improvement of option 3)
    /// 2 - strong latency optimizations (about 75% of possible latency improvement of option 3)
    /// 3 - max latency optimizations
    /// 4 - max latency optimizations, but also with text normalizer turned off for even more latency savings (best latency, but can mispronounce eg numbers and dates).
    ///
    /// Defaults to None.
    /// </param>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM and WAV formats with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AudioWithTimestampsResponse> ConvertWithTimestampsAsync(
        global::ElevenLabs.BodyTextToSpeechFullWithTimestamps input,
        string voiceId,
        bool? enableLogging = true,
        long? optimizeStreamingLatency = null,
        global::ElevenLabs.ConvertWithTimestampsTextToSpeechRequestOutputFormat? outputFormat =
            null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_convertWithTimestampsAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/text-to-speech/{voice_id}/with-timestamps"
        )
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalQueryParameter("optimize_streaming_latency", optimizeStreamingLatency)
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
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
        global::ElevenLabs.AudioWithTimestampsResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AudioWithTimestampsResponse>(
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

    /// <summary>Converts text into speech using a voice of your choice and returns audio as an audio stream.</summary>
    /// <param name="voiceId">ID of the voice to be used. Use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="optimizeStreamingLatency">
    /// You can turn on latency optimizations at some cost of quality. The best possible final latency varies by model. Possible values:
    /// 0 - default mode (no latency optimizations)
    /// 1 - normal latency optimizations (about 50% of possible latency improvement of option 3)
    /// 2 - strong latency optimizations (about 75% of possible latency improvement of option 3)
    /// 3 - max latency optimizations
    /// 4 - max latency optimizations, but also with text normalizer turned off for even more latency savings (best latency, but can mispronounce eg numbers and dates).
    ///
    /// Defaults to None.
    /// </param>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> StreamAsync(
        global::ElevenLabs.BodyTextToSpeechStream input,
        string voiceId,
        bool? enableLogging = true,
        long? optimizeStreamingLatency = null,
        global::ElevenLabs.StreamTextToSpeechRequestOutputFormat? outputFormat = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_streamAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/text-to-speech/{voice_id}/stream")
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalQueryParameter("optimize_streaming_latency", optimizeStreamingLatency)
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
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

    /// <summary>Converts text into speech using a voice of your choice and returns a stream of JSONs containing audio as a base64 encoded string together with information on when which character was spoken.</summary>
    /// <param name="voiceId">ID of the voice to be used. Use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="optimizeStreamingLatency">
    /// You can turn on latency optimizations at some cost of quality. The best possible final latency varies by model. Possible values:
    /// 0 - default mode (no latency optimizations)
    /// 1 - normal latency optimizations (about 50% of possible latency improvement of option 3)
    /// 2 - strong latency optimizations (about 75% of possible latency improvement of option 3)
    /// 3 - max latency optimizations
    /// 4 - max latency optimizations, but also with text normalizer turned off for even more latency savings (best latency, but can mispronounce eg numbers and dates).
    ///
    /// Defaults to None.
    /// </param>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public global::ElevenLabs.WithRawResponseStream<global::ElevenLabs.StreamingAudioChunkWithTimestampsResponse> StreamWithTimestampsAsync(
        global::ElevenLabs.BodyTextToSpeechStreamWithTimestamps input,
        string voiceId,
        bool? enableLogging = true,
        long? optimizeStreamingLatency = null,
        global::ElevenLabs.StreamWithTimestampsTextToSpeechRequestOutputFormat? outputFormat = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_streamWithTimestampsAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/text-to-speech/{voice_id}/stream/with-timestamps"
        )
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalQueryParameter("optimize_streaming_latency", optimizeStreamingLatency)
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        return new global::ElevenLabs.WithRawResponseStream<global::ElevenLabs.StreamingAudioChunkWithTimestampsResponse>(
            ExecuteStreamWithRawResponseAsync<global::ElevenLabs.StreamingAudioChunkWithTimestampsResponse>(
                request,
                false,
                false,
                resolvedConfig,
                null,
                null,
                false,
                cancellationToken
            ),
            cancellationToken
        );
    }

    /// <summary>List the speech generations created through this API, newest first.</summary>
    /// <param name="cursor">Pagination cursor: the `next_cursor` value of the previous page's response. Omit it for the first page.</param>
    /// <param name="pageSize">How many generations to return per page.</param>
    /// <param name="status">Only return generations with this lifecycle status.</param>
    /// <param name="modelId">Only return generations of this model.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MediaGenerationListResponse> ListAsync(
        string? cursor = null,
        long? pageSize = 30,
        global::ElevenLabs.Flows.ListTextToSpeechRequestStatus? status = null,
        string? modelId = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/flows/text-to-speech")
            .SetOptionalQueryParameter("cursor", cursor)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("status", status?.Value)
            .SetOptionalQueryParameter("model_id", modelId)
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
        global::ElevenLabs.MediaGenerationListResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MediaGenerationListResponse>(
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

    /// <summary>Start a speech generation with the selected model. Charged per character via text-to-speech billing. Use this over `/v1/text-to-speech` for the asynchronous generation lifecycle or for models not offered there; for direct, synchronous speech synthesis, prefer `/v1/text-to-speech`.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MediaGenerationCreateResponse> CreateAsync(
        global::ElevenLabs.ElevenFlashV25Request input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/flows/text-to-speech")
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
        global::ElevenLabs.MediaGenerationCreateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MediaGenerationCreateResponse>(
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

    /// <summary>Start a speech generation with the selected model. Charged per character via text-to-speech billing. Use this over `/v1/text-to-speech` for the asynchronous generation lifecycle or for models not offered there; for direct, synchronous speech synthesis, prefer `/v1/text-to-speech`.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MediaGenerationCreateResponse> CreateAsync(
        global::ElevenLabs.ElevenMultilingualV2Request input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/flows/text-to-speech")
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
        global::ElevenLabs.MediaGenerationCreateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MediaGenerationCreateResponse>(
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

    /// <summary>Start a speech generation with the selected model. Charged per character via text-to-speech billing. Use this over `/v1/text-to-speech` for the asynchronous generation lifecycle or for models not offered there; for direct, synchronous speech synthesis, prefer `/v1/text-to-speech`.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MediaGenerationCreateResponse> CreateAsync(
        global::ElevenLabs.ElevenV3Request input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/flows/text-to-speech")
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
        global::ElevenLabs.MediaGenerationCreateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MediaGenerationCreateResponse>(
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

    /// <summary>Retrieve the status of a speech generation, and retrieve its output URL once completed.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MediaGenerationResponse> GetAsync(
        string generationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (generationId is null)
            throw new ArgumentNullException(nameof(generationId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/flows/text-to-speech/{generation_id}")
            .SetPathParameter("generation_id", generationId)
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
        global::ElevenLabs.MediaGenerationResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MediaGenerationResponse>(
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
