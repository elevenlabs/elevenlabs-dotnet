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

namespace ElevenLabs.Reception;

/// <summary>
/// Fern-shape interface for BillingClient. Mirrors the public surface of <c>BillingClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IBillingClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IBillingClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListInvoicesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBillingClient SetListInvoicesAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetInvoiceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBillingClient SetGetInvoiceAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListUpcomingPaymentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBillingClient SetListUpcomingPaymentsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>List the invoices charged to the reseller's card, newest first, one per workspace invoice</summary>
    WithRawResponseTask<ResellerInvoicesResponse> ListInvoicesAsync(
        ListInvoicesBillingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get one invoice charged to the reseller's card, broken down into the workspace invoice's lines</summary>
    WithRawResponseTask<ResellerInvoiceDetail> GetInvoiceAsync(
        string invoiceId,
        GetInvoiceBillingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>List the next workspace renewals the reseller's card will be charged for, soonest first</summary>
    WithRawResponseTask<ResellerUpcomingPaymentsResponse> ListUpcomingPaymentsAsync(
        ListUpcomingPaymentsBillingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class BillingClient : IBillingClient { }
