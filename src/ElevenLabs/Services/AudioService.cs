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
/// Service class providing access to API endpoints for AudioService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class AudioService : BaseService
{
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _getAsync1Config;
    private RequestConfig? _getAsync2Config;
    private RequestConfig? _getAsync3Config;
    private RequestConfig? _getAsync4Config;

    internal AudioService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync1</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioService SetGetAsync1Config(RequestConfig config)
    {
        _getAsync1Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync2</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioService SetGetAsync2Config(RequestConfig config)
    {
        _getAsync2Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync3</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioService SetGetAsync3Config(RequestConfig config)
    {
        _getAsync3Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync4</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public AudioService SetGetAsync4Config(RequestConfig config)
    {
        _getAsync4Config = config;
        return this;
    }

    /// <summary>Returns the audio corresponding to a sample attached to a voice.</summary>
    /// <param name="voiceId">ID of the voice to be used. You can use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="sampleId">ID of the sample to be used. You can use the [Get voices](/docs/api-reference/voices/get) endpoint list all the available samples for a voice.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> GetAsync(
        string voiceId,
        string sampleId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));
        if (sampleId is null)
            throw new ArgumentNullException(nameof(sampleId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/voices/{voice_id}/samples/{sample_id}/audio"
        )
            .SetPathParameter("voice_id", voiceId)
            .SetPathParameter("sample_id", sampleId)
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

    /// <summary>Returns dub as a streamed MP3 or MP4 file. If this dub has been edited using Dubbing Studio you need to use the resource render endpoint as this endpoint only returns the original automatic dub result.</summary>
    /// <param name="dubbingId">ID of the dubbing project.</param>
    /// <param name="languageCode">ID of the language.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> GetAsync1(
        string dubbingId,
        string languageCode,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (dubbingId is null)
            throw new ArgumentNullException(nameof(dubbingId));
        if (languageCode is null)
            throw new ArgumentNullException(nameof(languageCode));

        var resolvedConfig = GetResolvedConfig(_getAsync1Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/dubbing/{dubbing_id}/audio/{language_code}"
        )
            .SetPathParameter("dubbing_id", dubbingId)
            .SetPathParameter("language_code", languageCode)
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

    /// <summary>Get the audio recording of a particular conversation</summary>
    /// <param name="conversationId">The id of the conversation you're taking the action on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> GetAsync2(
        string conversationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (conversationId is null)
            throw new ArgumentNullException(nameof(conversationId));

        var resolvedConfig = GetResolvedConfig(_getAsync2Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/conversations/{conversation_id}/audio"
        )
            .SetPathParameter("conversation_id", conversationId)
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

    /// <summary>Retrieve the first 30 seconds of voice sample audio with or without noise removal.</summary>
    /// <param name="voiceId">Voice ID to be used, you can use https://api.elevenlabs.io/v1/voices to list all the available voices.</param>
    /// <param name="sampleId">Sample ID to be used</param>
    /// <param name="removeBackgroundNoise">If set will remove background noise for voice samples using our audio isolation model. If the samples do not include background noise, it can make the quality worse.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.VoiceSamplePreviewResponseModel> GetAsync3(
        string voiceId,
        string sampleId,
        bool? removeBackgroundNoise = false,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));
        if (sampleId is null)
            throw new ArgumentNullException(nameof(sampleId));

        var resolvedConfig = GetResolvedConfig(_getAsync3Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/voices/pvc/{voice_id}/samples/{sample_id}/audio"
        )
            .SetPathParameter("voice_id", voiceId)
            .SetPathParameter("sample_id", sampleId)
            .SetOptionalQueryParameter("remove_background_noise", removeBackgroundNoise)
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
        global::ElevenLabs.VoiceSamplePreviewResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.VoiceSamplePreviewResponseModel>(
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

    /// <summary>Retrieve the separated audio for a specific speaker.</summary>
    /// <param name="voiceId">Voice ID to be used, you can use https://api.elevenlabs.io/v1/voices to list all the available voices.</param>
    /// <param name="sampleId">Sample ID to be used</param>
    /// <param name="speakerId">Speaker ID to be used, you can use GET https://api.elevenlabs.io/v1/voices/{voice_id}/samples/{sample_id}/speakers to list all the available speakers for a sample.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.SpeakerAudioResponseModel> GetAsync4(
        string voiceId,
        string sampleId,
        string speakerId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));
        if (sampleId is null)
            throw new ArgumentNullException(nameof(sampleId));
        if (speakerId is null)
            throw new ArgumentNullException(nameof(speakerId));

        var resolvedConfig = GetResolvedConfig(_getAsync4Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/voices/pvc/{voice_id}/samples/{sample_id}/speakers/{speaker_id}/audio"
        )
            .SetPathParameter("voice_id", voiceId)
            .SetPathParameter("sample_id", sampleId)
            .SetPathParameter("speaker_id", speakerId)
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
        global::ElevenLabs.SpeakerAudioResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.SpeakerAudioResponseModel>(
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
