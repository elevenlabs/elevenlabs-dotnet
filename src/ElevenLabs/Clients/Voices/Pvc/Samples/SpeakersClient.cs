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

namespace ElevenLabs.Voices.Pvc.Samples;

/// <summary>
/// Fern-shape client for SpeakersClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ISpeakersClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class SpeakersClient
{
    private readonly SpeakersService _service;

    internal SpeakersClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new SpeakersService(httpClient);
        Audio = new ElevenLabs.Voices.Pvc.Samples.Speakers.AudioClient(httpClient);
    }

    public ElevenLabs.Voices.Pvc.Samples.Speakers.IAudioClient Audio { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISpeakersClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISpeakersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SeparateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISpeakersClient SetSeparateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSeparateAsyncConfig(config);
        return this;
    }

    /// <summary>Retrieve the status of the speaker separation process and the list of detected speakers if complete.</summary>
    public WithRawResponseTask<SpeakerSeparationResponseModel> GetAsync(
        string voiceId,
        string sampleId,
        GetSpeakersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<SpeakerSeparationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        voiceId,
                        sampleId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Start speaker separation process for a sample</summary>
    public WithRawResponseTask<StartSpeakerSeparationResponseModel> SeparateAsync(
        string voiceId,
        string sampleId,
        SeparateSpeakersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<StartSpeakerSeparationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SeparateAsync(
                        voiceId,
                        sampleId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
