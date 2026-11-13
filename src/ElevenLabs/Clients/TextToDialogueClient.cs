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
/// Fern-shape client for TextToDialogueClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITextToDialogueClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TextToDialogueClient
{
    private readonly TextToDialogueService _service;

    internal TextToDialogueClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TextToDialogueService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToDialogueClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToDialogueClient SetConvertAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetConvertAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToDialogueClient SetStreamAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetStreamAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToDialogueClient SetConvertWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetConvertWithTimestampsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToDialogueClient SetStreamWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetStreamWithTimestampsAsyncConfig(config);
        return this;
    }

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns audio.</summary>
    public WithRawResponseTask<global::System.IO.Stream> ConvertAsync(
        ConvertTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.ConvertAsync(
                        request.Body,
                        request.OutputFormat,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns an audio stream.</summary>
    public WithRawResponseTask<global::System.IO.Stream> StreamAsync(
        StreamTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.StreamAsync(
                        request.Body,
                        request.OutputFormat,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Generate dialogue from text with precise character-level timing information for audio-text synchronization.</summary>
    public WithRawResponseTask<AudioWithTimestampsAndVoiceSegmentsResponseModel> ConvertWithTimestampsAsync(
        ConvertWithTimestampsTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AudioWithTimestampsAndVoiceSegmentsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ConvertWithTimestampsAsync(
                        request.Body,
                        request.OutputFormat,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns a stream of JSON blobs containing audio as a base64 encoded string and timestamps</summary>
    public global::ElevenLabs.WithRawResponseStream<StreamingAudioChunkWithTimestampsAndVoiceSegmentsResponseModel> StreamWithTimestampsAsync(
        StreamWithTimestampsTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        WithRawResponseAdapter.WithOptions(
            options,
            () =>
                _service.StreamWithTimestampsAsync(
                    request.Body,
                    request.OutputFormat,
                    request.EnableLogging,
                    request.XiApiKey,
                    cancellationToken: cancellationToken
                )
        );
}
