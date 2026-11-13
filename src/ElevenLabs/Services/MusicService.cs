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
/// Service class providing access to API endpoints for MusicService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class MusicService : BaseService
{
    private RequestConfig? _videoToMusicAsyncConfig;
    private RequestConfig? _composeAsyncConfig;
    private RequestConfig? _composeDetailedAsyncConfig;
    private RequestConfig? _composeDetailedStreamAsyncConfig;
    private RequestConfig? _streamAsyncConfig;
    private RequestConfig? _uploadAsyncConfig;
    private RequestConfig? _separateStemsAsyncConfig;

    internal MusicService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>VideoToMusicAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MusicService SetVideoToMusicAsyncConfig(RequestConfig config)
    {
        _videoToMusicAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ComposeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MusicService SetComposeAsyncConfig(RequestConfig config)
    {
        _composeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ComposeDetailedAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MusicService SetComposeDetailedAsyncConfig(RequestConfig config)
    {
        _composeDetailedAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ComposeDetailedStreamAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MusicService SetComposeDetailedStreamAsyncConfig(RequestConfig config)
    {
        _composeDetailedStreamAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MusicService SetStreamAsyncConfig(RequestConfig config)
    {
        _streamAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UploadAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MusicService SetUploadAsyncConfig(RequestConfig config)
    {
        _uploadAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SeparateStemsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MusicService SetSeparateStemsAsyncConfig(RequestConfig config)
    {
        _separateStemsAsyncConfig = config;
        return this;
    }

    /// <summary>Generate background music from one or more video files. Videos are combined in order. Optional description and style tags influence the generated music.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> VideoToMusicAsync(
        global::ElevenLabs.BodyVideoToMusicV1MusicVideoToMusicPost input,
        global::ElevenLabs.AllowedOutputFormats? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_videoToMusicAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music/video-to-music")
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
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

    /// <summary>Compose a song from a prompt or a composition plan.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. Use "auto" (the default) to let the API pick the best format for the selected model: mp3_44100_128 for v1 models and mp3_48000_192 for v2 models.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> ComposeAsync(
        global::ElevenLabs.BodyComposeMusicV1MusicPost input,
        global::ElevenLabs.ComposeMusicRequestOutputFormat? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_composeAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music")
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
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

    /// <summary>Compose a song from a prompt or a composition plan.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. Use "auto" (the default) to let the API pick the best format for the selected model: mp3_44100_128 for v1 models and mp3_48000_192 for v2 models.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ComposeDetailedMusicResponse> ComposeDetailedAsync(
        global::ElevenLabs.BodyComposeMusicWithADetailedResponseV1MusicDetailedPost input,
        global::ElevenLabs.ComposeDetailedMusicRequestOutputFormat? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_composeDetailedAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music/detailed")
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
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
        global::ElevenLabs.ComposeDetailedMusicResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ComposeDetailedMusicResponse>(
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

    /// <summary>Stream a song and its detailed metadata using Server-Sent Events (SSE).</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. Use "auto" (the default) to let the API pick the best format for the selected model: mp3_44100_128 for v1 models and mp3_48000_192 for v2 models.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public global::ElevenLabs.WithRawResponseStream<string> ComposeDetailedStreamAsync(
        global::ElevenLabs.BodyStreamComposedMusicWithADetailedResponseV1MusicDetailedStreamPost input,
        global::ElevenLabs.ComposeDetailedStreamMusicRequestOutputFormat? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_composeDetailedStreamAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music/detailed/stream")
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetHeader("Accept", "text/event-stream")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        return new global::ElevenLabs.WithRawResponseStream<string>(
            ExecuteStreamWithRawResponseAsync<string>(
                request,
                true,
                true,
                resolvedConfig,
                null,
                null,
                false,
                cancellationToken
            ),
            cancellationToken
        );
    }

    /// <summary>Stream a composed song from a prompt or a composition plan.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. Use "auto" (the default) to let the API pick the best format for the selected model: mp3_44100_128 for v1 models and mp3_48000_192 for v2 models.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> StreamAsync(
        global::ElevenLabs.BodyStreamComposedMusicV1MusicStreamPost input,
        global::ElevenLabs.StreamMusicRequestOutputFormat? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_streamAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music/stream")
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
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

    /// <summary>Upload a music file to be later used for inpainting. Price for uploading is the same as the one for song generation. All uploaded content gets inspected for copyright infringement. If copyrighted content is detected, half of the request cost is still charged.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MusicUploadResponse> UploadAsync(
        global::ElevenLabs.BodyUploadMusicV1MusicUploadPost input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_uploadAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music/upload")
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
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
        global::ElevenLabs.MusicUploadResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MusicUploadResponse>(
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

    /// <summary>Separate an audio file into individual stems. This endpoint might have high latency, depending on the length of the audio file.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> SeparateStemsAsync(
        global::ElevenLabs.BodyStemSeparationV1MusicStemSeparationPost input,
        global::ElevenLabs.AllowedOutputFormats? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_separateStemsAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music/stem-separation")
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
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
