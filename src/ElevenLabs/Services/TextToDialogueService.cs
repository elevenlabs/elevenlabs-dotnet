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
/// Service class providing access to API endpoints for TextToDialogueService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class TextToDialogueService : BaseService
{
    private RequestConfig? _convertAsyncConfig;
    private RequestConfig? _streamAsyncConfig;
    private RequestConfig? _streamWithTimestampsAsyncConfig;
    private RequestConfig? _convertWithTimestampsAsyncConfig;

    internal TextToDialogueService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToDialogueService SetConvertAsyncConfig(RequestConfig config)
    {
        _convertAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToDialogueService SetStreamAsyncConfig(RequestConfig config)
    {
        _streamAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamWithTimestampsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToDialogueService SetStreamWithTimestampsAsyncConfig(RequestConfig config)
    {
        _streamWithTimestampsAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertWithTimestampsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TextToDialogueService SetConvertWithTimestampsAsyncConfig(RequestConfig config)
    {
        _convertWithTimestampsAsyncConfig = config;
        return this;
    }

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns audio.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM and WAV formats with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> ConvertAsync(
        global::ElevenLabs.BodyTextToDialogueMultiVoiceV1TextToDialoguePost input,
        global::ElevenLabs.ConvertTextToDialogueRequestOutputFormat? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_convertAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/text-to-dialogue")
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

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns an audio stream.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> StreamAsync(
        global::ElevenLabs.BodyTextToDialogueMultiVoiceStreamingV1TextToDialogueStreamPost input,
        global::ElevenLabs.AllowedOutputFormats? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_streamAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/text-to-dialogue/stream")
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

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns a stream of JSON blobs containing audio as a base64 encoded string and timestamps</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public global::ElevenLabs.WithRawResponseStream<global::ElevenLabs.StreamingAudioChunkWithTimestampsAndVoiceSegmentsResponseModel> StreamWithTimestampsAsync(
        global::ElevenLabs.BodyTextToDialogueStreamWithTimestamps input,
        global::ElevenLabs.AllowedOutputFormats? outputFormat = null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_streamWithTimestampsAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/text-to-dialogue/stream/with-timestamps"
        )
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        return new global::ElevenLabs.WithRawResponseStream<global::ElevenLabs.StreamingAudioChunkWithTimestampsAndVoiceSegmentsResponseModel>(
            ExecuteStreamWithRawResponseAsync<global::ElevenLabs.StreamingAudioChunkWithTimestampsAndVoiceSegmentsResponseModel>(
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

    /// <summary>Generate dialogue from text with precise character-level timing information for audio-text synchronization.</summary>
    /// <param name="outputFormat">Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM and WAV formats with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</param>
    /// <param name="enableLogging">When enable_logging is set to false zero retention mode will be used for the request. This will mean history features are unavailable for this request, including request stitching. Zero retention mode may only be used by enterprise customers.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AudioWithTimestampsAndVoiceSegmentsResponseModel> ConvertWithTimestampsAsync(
        global::ElevenLabs.BodyTextToDialogueFullWithTimestamps input,
        global::ElevenLabs.ConvertWithTimestampsTextToDialogueRequestOutputFormat? outputFormat =
            null,
        bool? enableLogging = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_convertWithTimestampsAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/text-to-dialogue/with-timestamps")
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
        global::ElevenLabs.AudioWithTimestampsAndVoiceSegmentsResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AudioWithTimestampsAndVoiceSegmentsResponseModel>(
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
