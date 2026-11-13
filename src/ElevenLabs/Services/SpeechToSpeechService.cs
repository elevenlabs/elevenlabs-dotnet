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
/// Service class providing access to API endpoints for SpeechToSpeechService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class SpeechToSpeechService : BaseService
{
    private RequestConfig? _convertAsyncConfig;
    private RequestConfig? _streamAsyncConfig;

    internal SpeechToSpeechService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SpeechToSpeechService SetConvertAsyncConfig(RequestConfig config)
    {
        _convertAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SpeechToSpeechService SetStreamAsyncConfig(RequestConfig config)
    {
        _streamAsyncConfig = config;
        return this;
    }

    /// <summary>Transform audio from one voice to another. Maintain full control over emotion, timing and delivery.</summary>
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
        global::ElevenLabs.SpeechToSpeechRequest input,
        string voiceId,
        bool? enableLogging = true,
        long? optimizeStreamingLatency = null,
        global::ElevenLabs.ConvertSpeechToSpeechRequestOutputFormat? outputFormat = null,
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

        var request = new RequestBuilder(HttpMethod.Post, "v1/voice-changer/{voice_id}")
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalQueryParameter("optimize_streaming_latency", optimizeStreamingLatency)
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
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

    /// <summary>Stream audio from one voice to another. Maintain full control over emotion, timing and delivery.</summary>
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
        global::ElevenLabs.SpeechToSpeechStreamRequest input,
        string voiceId,
        bool? enableLogging = true,
        long? optimizeStreamingLatency = null,
        global::ElevenLabs.StreamSpeechToSpeechRequestOutputFormat? outputFormat = null,
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

        var request = new RequestBuilder(HttpMethod.Post, "v1/voice-changer/{voice_id}/stream")
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalQueryParameter("optimize_streaming_latency", optimizeStreamingLatency)
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
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
