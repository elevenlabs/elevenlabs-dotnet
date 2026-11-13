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

namespace ElevenLabs.Dubbing;

/// <summary>
/// Fern-shape client for TranscriptsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITranscriptsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TranscriptsClient
{
    private readonly TranscriptsService _service;

    internal TranscriptsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TranscriptsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>Fetch the transcript for one of the languages in a dub.</summary>
    public WithRawResponseTask<DubbingTranscriptsResponseModel> GetAsync(
        string dubbingId,
        string languageCode,
        GetTranscriptsRequestFormatType formatType,
        GetTranscriptsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingTranscriptsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        dubbingId,
                        languageCode,
                        formatType,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
