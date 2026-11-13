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
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape interface for OutboundCampaignsClient. Mirrors the public surface of <c>OutboundCampaignsClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IOutboundCampaignsClient
{
    public IConfigClient Config { get; }
    public ILeadsClient Leads { get; }
    public ICallsClient Calls { get; }
    public IAttentionClient Attention { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>PauseAllAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetPauseAllAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>StopAllAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetStopAllAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetProgressAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetGetProgressAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>GetFollowUpRequestsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetGetFollowUpRequestsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>PauseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetPauseAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ResumeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetResumeAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>StopAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOutboundCampaignsClient SetStopAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>List the workspace's outbound campaigns, newest first.</summary>
    WithRawResponseTask<CampaignPageResponse> ListAsync(
        ListOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Pause every running outbound campaign in the workspace. Paused campaigns place no new calls until resumed.</summary>
    WithRawResponseTask<PauseAllCampaignsResponse> PauseAllAsync(
        PauseAllOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Stop every outbound campaign in the workspace that hasn't finished. Returns `202` while calls already placed are still finishing.</summary>
    WithRawResponseTask<StopAllCampaignsResponse> StopAllAsync(
        StopAllOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create an outbound campaign that calls or messages each recipient with the agent, within the policy's calling windows, retrying and following up as it allows. Returns `201` for a new campaign. A repeated request, matched by `idempotency_key` or else by its body, returns the existing campaign with `created` false.</summary>
    WithRawResponseTask<SubmitCampaignResponse> CreateAsync(
        CreateOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get an outbound campaign and its lead counts.</summary>
    WithRawResponseTask<CampaignResponse> GetAsync(
        string campaignId,
        GetOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get where an outbound campaign's leads and calls stand, and when its next call is due.</summary>
    WithRawResponseTask<CampaignProgressResponse> GetProgressAsync(
        string campaignId,
        GetProgressOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Count the callbacks and redirects contacts asked for during an outbound campaign's calls.</summary>
    WithRawResponseTask<CampaignFollowUpRequestsResponse> GetFollowUpRequestsAsync(
        string campaignId,
        GetFollowUpRequestsOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Pause an outbound campaign. It places no new calls until resumed; calls already placed carry on.</summary>
    WithRawResponseTask<CampaignResponse> PauseAsync(
        string campaignId,
        PauseOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Resume a paused outbound campaign, including calls an attention item held back.</summary>
    WithRawResponseTask<CampaignResponse> ResumeAsync(
        string campaignId,
        ResumeOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Stop an outbound campaign for good: queued calls are cancelled and no lead is called again. Returns `202` with the campaign `stopping` while calls already placed are still finishing.</summary>
    WithRawResponseTask<CampaignResponse> StopAsync(
        string campaignId,
        StopOutboundCampaignsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class OutboundCampaignsClient : IOutboundCampaignsClient { }
