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
/// Fern-shape client for BillingClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IBillingClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class BillingClient
{
    private readonly BillingService _service;

    internal BillingClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new BillingService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBillingClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListInvoicesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBillingClient SetListInvoicesAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListInvoicesAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetInvoiceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBillingClient SetGetInvoiceAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetInvoiceAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListUpcomingPaymentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBillingClient SetListUpcomingPaymentsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListUpcomingPaymentsAsyncConfig(config);
        return this;
    }

    /// <summary>List the invoices charged to the reseller's card, newest first, one per workspace invoice</summary>
    public WithRawResponseTask<ResellerInvoicesResponse> ListInvoicesAsync(
        ListInvoicesBillingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResellerInvoicesResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListInvoicesAsync(
                        request.Cursor,
                        request.PageSize,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get one invoice charged to the reseller's card, broken down into the workspace invoice's lines</summary>
    public WithRawResponseTask<ResellerInvoiceDetail> GetInvoiceAsync(
        string invoiceId,
        GetInvoiceBillingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResellerInvoiceDetail>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetInvoiceAsync(
                        invoiceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>List the next workspace renewals the reseller's card will be charged for, soonest first</summary>
    public WithRawResponseTask<ResellerUpcomingPaymentsResponse> ListUpcomingPaymentsAsync(
        ListUpcomingPaymentsBillingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResellerUpcomingPaymentsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListUpcomingPaymentsAsync(
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
