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
using ElevenLabs.CustomerSupport;
using ElevenLabs.CustomerSupport.Requesters;
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
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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

namespace ElevenLabs.Reception;

/// <summary>
/// Fern-shape client for SubscriptionsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ISubscriptionsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class SubscriptionsClient
{
    private readonly SubscriptionsService _service;

    internal SubscriptionsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new SubscriptionsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISubscriptionsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AssignAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISubscriptionsClient SetAssignAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetAssignAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ChangeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISubscriptionsClient SetChangeAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetChangeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UnassignAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISubscriptionsClient SetUnassignAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUnassignAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RestoreAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISubscriptionsClient SetRestoreAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetRestoreAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CancelPendingDowngradeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISubscriptionsClient SetCancelPendingDowngradeAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCancelPendingDowngradeAsyncConfig(config);
        return this;
    }

    /// <summary>Subscribe a reseller-attributed workspace to one of the reseller's tiers</summary>
    public WithRawResponseTask<Dictionary<string, string>> AssignAsync(
        string workspaceId,
        AssignSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, string>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.AssignAsync(
                        request.Body,
                        workspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Move a reseller-attributed workspace between the reseller's tiers. Upgrades apply immediately; downgrades and lateral moves take effect at the end of the billing period.</summary>
    public WithRawResponseTask<Dictionary<string, string>> ChangeAsync(
        string workspaceId,
        ChangeSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, string>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ChangeAsync(
                        request.Body,
                        workspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>End a reseller-attributed workspace's subscription at the end of the current billing period</summary>
    public WithRawResponseTask<Dictionary<string, string>> UnassignAsync(
        string workspaceId,
        UnassignSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, string>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UnassignAsync(
                        workspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Undo a pending unassignment so the subscription renews normally</summary>
    public WithRawResponseTask<Dictionary<string, string>> RestoreAsync(
        string workspaceId,
        RestoreSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, string>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RestoreAsync(
                        workspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Drop a scheduled downgrade, leaving the workspace on its current tier</summary>
    public WithRawResponseTask<Dictionary<string, string>> CancelPendingDowngradeAsync(
        string workspaceId,
        CancelPendingDowngradeSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, string>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CancelPendingDowngradeAsync(
                        workspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
