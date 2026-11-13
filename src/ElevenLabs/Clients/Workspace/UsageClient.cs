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
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Workspace;

/// <summary>
/// Fern-shape client for UsageClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IUsageClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class UsageClient
{
    private readonly UsageService _service;

    internal UsageClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new UsageService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IUsageClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetUsageByProductOverTimeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IUsageClient SetGetUsageByProductOverTimeAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetUsageByProductOverTimeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetUsageAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IUsageClient SetGetUsageAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetUsageAsyncConfig(config);
        return this;
    }

    /// <summary>Returns credit usage broken down by product type over time, for workspaces billed in credits. The response is a tabular structure with columns, column_types, column_units, and rows. Some id columns also get a display-name column, such as user_label or voice_name, appended after the existing columns. For workspaces billed by cost, ranges that reach the date the workspace moved to cost billing return an error; use /v1/workspace/analytics/usage instead.</summary>
    public WithRawResponseTask<WorkspaceAnalyticsQueryResponseModel> GetUsageByProductOverTimeAsync(
        GetUsageByProductOverTimeUsageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<WorkspaceAnalyticsQueryResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetUsageByProductOverTimeAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns the cost of the workspace's usage over time, for workspaces billed by cost. Usage is bucketed by UTC day. The response is a tabular structure with columns, column_types, column_units, and rows, with one row per group and bucket. `total_cost` is the cost in the workspace's currency and `total_charge_count` the billed quantity. Usage can be grouped or filtered by at most two of `user_id`, `hashed_xi_api_key`, `region`, `reporting_workspace_id`, `billing_group_id`, `product_type`, `surface` and `actor`, and grouping by two of them requires an `eq` or `in` filter on one. `model`, `request_source`, `fiat_charge_type` and `fiat_currency` can always be added. Some id columns also get a display-name column, such as user_label, appended after the existing columns. Workspaces billed in credits should use /v1/workspace/analytics/query/usage-by-product-over-time.</summary>
    public WithRawResponseTask<WorkspaceAnalyticsQueryResponseModel> GetUsageAsync(
        GetUsageUsageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<WorkspaceAnalyticsQueryResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetUsageAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
