using ElevenLabs;
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

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape client for LlmUsageClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ILlmUsageClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class LlmUsageClient
{
    private readonly LlmUsageService _service;

    internal LlmUsageClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new LlmUsageService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILlmUsageClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CalculateForAgentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILlmUsageClient SetCalculateForAgentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCalculateForAgentAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CalculateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILlmUsageClient SetCalculateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCalculateAsyncConfig(config);
        return this;
    }

    /// <summary>Calculates expected number of LLM tokens needed for the specified agent.</summary>
    public WithRawResponseTask<LlmUsageCalculatorResponseModel> CalculateForAgentAsync(
        string agentId,
        CalculateForAgentLlmUsageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<LlmUsageCalculatorResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CalculateForAgentAsync(
                        request.Body,
                        agentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns a list of LLM models and the expected cost for using them based on the provided values.</summary>
    public WithRawResponseTask<LlmUsageCalculatorResponseModel> CalculateAsync(
        LlmUsageCalculatorPublicRequestModel request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<LlmUsageCalculatorResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.CalculateAsync(request, cancellationToken: cancellationToken)
            )
        );
}
