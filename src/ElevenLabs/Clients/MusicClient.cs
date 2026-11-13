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
/// Fern-shape client for MusicClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IMusicClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class MusicClient
{
    private readonly MusicService _service;

    internal MusicClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new MusicService(httpClient);
        CompositionPlan = new CompositionPlanClient(httpClient);
        Finetunes = new FinetunesClient(httpClient);
    }

    public ICompositionPlanClient CompositionPlan { get; }
    public IFinetunesClient Finetunes { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>VideoToMusicAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetVideoToMusicAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetVideoToMusicAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ComposeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetComposeAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetComposeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ComposeDetailedAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetComposeDetailedAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetComposeDetailedAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetStreamAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetStreamAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UploadAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetUploadAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUploadAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SeparateStemsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetSeparateStemsAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSeparateStemsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ComposeDetailedStreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMusicClient SetComposeDetailedStreamAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetComposeDetailedStreamAsyncConfig(config);
        return this;
    }

    /// <summary>Generate background music from one or more video files. Videos are combined in order. Optional description and style tags influence the generated music.</summary>
    public WithRawResponseTask<global::System.IO.Stream> VideoToMusicAsync(
        VideoToMusicMusicRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.VideoToMusicAsync(
                        request.Body,
                        request.OutputFormat,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Compose a song from a prompt or a composition plan.</summary>
    public WithRawResponseTask<global::System.IO.Stream> ComposeAsync(
        ComposeMusicRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.ComposeAsync(
                        request.Body,
                        request.OutputFormat,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Compose a song from a prompt or a composition plan.</summary>
    public WithRawResponseTask<ComposeDetailedMusicResponse> ComposeDetailedAsync(
        ComposeDetailedMusicRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ComposeDetailedMusicResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ComposeDetailedAsync(
                        request.Body,
                        request.OutputFormat,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Stream a composed song from a prompt or a composition plan.</summary>
    public WithRawResponseTask<global::System.IO.Stream> StreamAsync(
        StreamMusicRequest request,
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

    /// <summary>Upload a music file to be later used for inpainting. Price for uploading is the same as the one for song generation. All uploaded content gets inspected for copyright infringement. If copyrighted content is detected, half of the request cost is still charged.</summary>
    public WithRawResponseTask<MusicUploadResponse> UploadAsync(
        UploadMusicRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MusicUploadResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UploadAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Separate an audio file into individual stems. This endpoint might have high latency, depending on the length of the audio file.</summary>
    public WithRawResponseTask<global::System.IO.Stream> SeparateStemsAsync(
        SeparateStemsMusicRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.SeparateStemsAsync(
                        request.Body,
                        request.OutputFormat,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Stream a song and its detailed metadata using Server-Sent Events (SSE).</summary>
    public global::ElevenLabs.WithRawResponseStream<string> ComposeDetailedStreamAsync(
        ComposeDetailedStreamMusicRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        WithRawResponseAdapter.WithOptions(
            options,
            () =>
                _service.ComposeDetailedStreamAsync(
                    request.Body,
                    request.OutputFormat,
                    request.EnableLogging,
                    request.XiApiKey,
                    cancellationToken: cancellationToken
                )
        );
}
