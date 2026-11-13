using ElevenLabs;
using ElevenLabs.Agents;
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

namespace ElevenLabs.Agents.Conversations;

/// <summary>
/// Fern-shape client for AnalysisClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IAnalysisClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class AnalysisClient
{
    private readonly AnalysisService _service;

    internal AnalysisClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new AnalysisService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RunAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisClient SetRunAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRunAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RunEvaluationAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisClient SetRunEvaluationAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetRunEvaluationAsyncConfig(config);
        return this;
    }

    /// <summary>Run the analysis for a conversation using the agent's current evaluation criteria and data collection settings.</summary>
    public WithRawResponseTask<GetConversationResponseModel> RunAsync(
        string conversationId,
        RunAnalysisRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetConversationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RunAsync(
                        conversationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Rerun a specific evaluation for a conversation.</summary>
    public WithRawResponseTask<GetConversationResponseModel> RunEvaluationAsync(
        string conversationId,
        RunEvaluationAnalysisRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetConversationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RunEvaluationAsync(
                        request.Body,
                        conversationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
