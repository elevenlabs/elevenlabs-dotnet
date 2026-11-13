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
using ElevenLabs.TextToVoice;
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
/// Fern-shape client for TextToVoiceClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITextToVoiceClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TextToVoiceClient
{
    private readonly TextToVoiceService _service;

    internal TextToVoiceClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TextToVoiceService(httpClient);
        Preview = new PreviewClient(httpClient);
    }

    public IPreviewClient Preview { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToVoiceClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToVoiceClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DesignAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToVoiceClient SetDesignAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDesignAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemixAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToVoiceClient SetRemixAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRemixAsyncConfig(config);
        return this;
    }

    /// <summary>Create a voice from previously generated voice preview. This endpoint should be called after you fetched a generated_voice_id using POST /v1/text-to-voice/design or POST /v1/text-to-voice/:voice_id/remix.</summary>
    public WithRawResponseTask<Voice> CreateAsync(
        CreateTextToVoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Voice>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Design a voice via a prompt. This method returns a list of voice previews. Each preview has a generated_voice_id and a sample of the voice as base64 encoded mp3 audio. To create a voice use the generated_voice_id of the preferred preview with the /v1/text-to-voice endpoint.</summary>
    public WithRawResponseTask<VoiceDesignPreviewResponse> DesignAsync(
        DesignTextToVoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<VoiceDesignPreviewResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DesignAsync(
                        request.Body,
                        request.OutputFormat,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Remix an existing voice via a prompt. This method returns a list of voice previews. Each preview has a generated_voice_id and a sample of the voice as base64 encoded mp3 audio. To create a voice use the generated_voice_id of the preferred preview with the /v1/text-to-voice endpoint.</summary>
    public WithRawResponseTask<VoiceDesignPreviewResponse> RemixAsync(
        string voiceId,
        RemixTextToVoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<VoiceDesignPreviewResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RemixAsync(
                        request.Body,
                        voiceId,
                        request.OutputFormat,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
