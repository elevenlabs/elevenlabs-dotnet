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
/// Fern-shape client for SpeechToTextClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ISpeechToTextClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class SpeechToTextClient
{
    private readonly SpeechToTextService _service;

    internal SpeechToTextClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new SpeechToTextService(httpClient);
        Transcripts = new ElevenLabs.SpeechToText.TranscriptsClient(httpClient);
    }

    public ElevenLabs.SpeechToText.ITranscriptsClient Transcripts { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISpeechToTextClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISpeechToTextClient SetConvertAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConvertAsyncConfig(config);
        return this;
    }

    /// <summary>Transcribe an audio or video file. If webhook is set to true, the request will be processed asynchronously and results sent to configured webhooks. When use_multi_channel is true and the provided audio has multiple channels, a 'transcripts' object with separate transcripts for each channel is returned; set multichannel_output_style='combined' to instead receive a single transcript with all channels merged and sorted by time. Otherwise, returns a single transcript. The optional webhook_metadata parameter allows you to attach custom data that will be included in webhook responses for request correlation and tracking.</summary>
    public WithRawResponseTask<ResponseSpeechToTextV1SpeechToTextPost> ConvertAsync(
        ConvertSpeechToTextRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseSpeechToTextV1SpeechToTextPost>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ConvertAsync(
                        request.Body,
                        request.Token,
                        request.EnableLogging,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
