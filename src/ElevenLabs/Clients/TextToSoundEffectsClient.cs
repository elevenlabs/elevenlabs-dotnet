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
/// Fern-shape client for TextToSoundEffectsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITextToSoundEffectsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TextToSoundEffectsClient
{
    private readonly TextToSoundEffectsService _service;

    internal TextToSoundEffectsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TextToSoundEffectsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToSoundEffectsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITextToSoundEffectsClient SetConvertAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetConvertAsyncConfig(config);
        return this;
    }

    /// <summary>Turn text into sound effects for your videos, voice-overs or video games using the most advanced sound effects models in the world.</summary>
    public WithRawResponseTask<global::System.IO.Stream> ConvertAsync(
        ConvertTextToSoundEffectsRequest request,
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
}
