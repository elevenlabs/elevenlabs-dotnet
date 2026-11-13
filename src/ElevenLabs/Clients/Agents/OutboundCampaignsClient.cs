using ElevenLabs;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
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
/// Fern-shape client for OutboundCampaignsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IOutboundCampaignsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class OutboundCampaignsClient
{
    private readonly OutboundCampaignsService _service;

    internal OutboundCampaignsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new OutboundCampaignsService(httpClient);
        Config = new ConfigClient(httpClient);
        Leads = new LeadsClient(httpClient);
        Calls = new CallsClient(httpClient);
        Attention = new AttentionClient(httpClient);
    }

    public IConfigClient Config { get; }
    public ILeadsClient Leads { get; }
    public ICallsClient Calls { get; }
    public IAttentionClient Attention { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetListAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>PauseAllAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetPauseAllAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetPauseAllAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StopAllAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetStopAllAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetStopAllAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetCreateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetGetAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetProgressAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetGetProgressAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetProgressAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetFollowUpRequestsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetGetFollowUpRequestsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetFollowUpRequestsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>PauseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetPauseAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetPauseAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ResumeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetResumeAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetResumeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StopAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOutboundCampaignsClient SetStopAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetStopAsyncConfig(config);
        return this;
    }

    /// <summary>List the workspace's outbound campaigns, newest first.</summary>
    public WithRawResponseTask<CampaignPageResponse> ListAsync(
        ListOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CampaignPageResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.PageSize,
                        request.Status?.ToList(),
                        request.AgentId,
                        request.Channel,
                        request.Mode,
                        request.Search,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Pause every running outbound campaign in the workspace. Paused campaigns place no new calls until resumed.</summary>
    public WithRawResponseTask<PauseAllCampaignsResponse> PauseAllAsync(
        PauseAllOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<PauseAllCampaignsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.PauseAllAsync(request.XiApiKey, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Stop every outbound campaign in the workspace that hasn't finished. Returns `202` while calls already placed are still finishing.</summary>
    public WithRawResponseTask<StopAllCampaignsResponse> StopAllAsync(
        StopAllOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<StopAllCampaignsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.StopAllAsync(request.XiApiKey, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Create an outbound campaign that calls or messages each recipient with the agent, within the policy's calling windows, retrying and following up as it allows. Returns `201` for a new campaign. A repeated request, matched by `idempotency_key` or else by its body, returns the existing campaign with `created` false.</summary>
    public WithRawResponseTask<SubmitCampaignResponse> CreateAsync(
        CreateOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<SubmitCampaignResponse>(
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

    /// <summary>Get an outbound campaign and its lead counts.</summary>
    public WithRawResponseTask<CampaignResponse> GetAsync(
        string campaignId,
        GetOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CampaignResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        campaignId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get where an outbound campaign's leads and calls stand, and when its next call is due.</summary>
    public WithRawResponseTask<CampaignProgressResponse> GetProgressAsync(
        string campaignId,
        GetProgressOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CampaignProgressResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetProgressAsync(
                        campaignId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Count the callbacks and redirects contacts asked for during an outbound campaign's calls.</summary>
    public WithRawResponseTask<CampaignFollowUpRequestsResponse> GetFollowUpRequestsAsync(
        string campaignId,
        GetFollowUpRequestsOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CampaignFollowUpRequestsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetFollowUpRequestsAsync(
                        campaignId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Pause an outbound campaign. It places no new calls until resumed; calls already placed carry on.</summary>
    public WithRawResponseTask<CampaignResponse> PauseAsync(
        string campaignId,
        PauseOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CampaignResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.PauseAsync(
                        campaignId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Resume a paused outbound campaign, including calls an attention item held back.</summary>
    public WithRawResponseTask<CampaignResponse> ResumeAsync(
        string campaignId,
        ResumeOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CampaignResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ResumeAsync(
                        campaignId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Stop an outbound campaign for good: queued calls are cancelled and no lead is called again. Returns `202` with the campaign `stopping` while calls already placed are still finishing.</summary>
    public WithRawResponseTask<CampaignResponse> StopAsync(
        string campaignId,
        StopOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CampaignResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.StopAsync(
                        campaignId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
