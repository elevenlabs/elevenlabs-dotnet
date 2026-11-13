using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.Services;
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
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape client for TextToSpeechClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITextToSpeechClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TextToSpeechClient
{
    private readonly TextToSpeechService _service;

    internal TextToSpeechClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TextToSpeechService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToSpeechClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToSpeechClient SetConvertAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConvertAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToSpeechClient SetConvertWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetConvertWithTimestampsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToSpeechClient SetStreamAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetStreamAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToSpeechClient SetStreamWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetStreamWithTimestampsAsyncConfig(config);
        return this;
    }

    /// <summary>Converts text into speech using a voice of your choice and returns audio.</summary>
    public WithRawResponseTask<global::System.IO.Stream> ConvertAsync(
        string voiceId,
        ConvertTextToSpeechRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.ConvertAsync(
                        request.Body,
                        voiceId,
                        request.EnableLogging,
                        request.OptimizeStreamingLatency,
                        request.OutputFormat,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Generate speech from text with precise character-level timing information for audio-text synchronization.</summary>
    public WithRawResponseTask<AudioWithTimestampsResponse> ConvertWithTimestampsAsync(
        string voiceId,
        ConvertWithTimestampsTextToSpeechRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AudioWithTimestampsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ConvertWithTimestampsAsync(
                        request.Body,
                        voiceId,
                        request.EnableLogging,
                        request.OptimizeStreamingLatency,
                        request.OutputFormat,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Converts text into speech using a voice of your choice and returns audio as an audio stream.</summary>
    public WithRawResponseTask<global::System.IO.Stream> StreamAsync(
        string voiceId,
        StreamTextToSpeechRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.StreamAsync(
                        request.Body,
                        voiceId,
                        request.EnableLogging,
                        request.OptimizeStreamingLatency,
                        request.OutputFormat,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Converts text into speech using a voice of your choice and returns a stream of JSONs containing audio as a base64 encoded string together with information on when which character was spoken.</summary>
    public global::ElevenLabs.WithRawResponseStream<StreamingAudioChunkWithTimestampsResponse> StreamWithTimestampsAsync(
        string voiceId,
        StreamTextToSpeechWithTimestampsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        WithRawResponseAdapter.WithOptions(
            options,
            () =>
                _service.StreamWithTimestampsAsync(
                    request.Body,
                    voiceId,
                    request.EnableLogging,
                    request.OptimizeStreamingLatency,
                    request.OutputFormat,
                    request.XiApiKey,
                    cancellationToken: cancellationToken
                )
        );
}
