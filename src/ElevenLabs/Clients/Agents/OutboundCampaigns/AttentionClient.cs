using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
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

namespace ElevenLabs.Agents.OutboundCampaigns;

/// <summary>
/// Fern-shape client for AttentionClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IAttentionClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class AttentionClient
{
    private readonly AttentionService _service;

    internal AttentionClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new AttentionService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAttentionClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAttentionClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RetryAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAttentionClient SetRetryAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRetryAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ResolveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAttentionClient SetResolveAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetResolveAsyncConfig(config);
        return this;
    }

    /// <summary>List problems in the workspace's outbound campaigns that need you to act, such as an agent or phone number that can no longer be used, newest first. A campaign with an open item holds back the calls it affects.</summary>
    public WithRawResponseTask<AttentionPageResponse> ListAsync(
        ListAttentionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AttentionPageResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.CampaignId,
                        request.IncludeResolved,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Place the calls a retryable attention item holds back, once its cause is fixed. Resumes the campaign.</summary>
    public WithRawResponseTask<AttentionView> RetryAsync(
        string attentionId,
        RetryAttentionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AttentionView>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RetryAsync(
                        attentionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Close an attention item that can't be retried, recording how it was handled.</summary>
    public WithRawResponseTask<AttentionView> ResolveAsync(
        string attentionId,
        ResolveAttentionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AttentionView>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ResolveAsync(
                        request.Body,
                        attentionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
