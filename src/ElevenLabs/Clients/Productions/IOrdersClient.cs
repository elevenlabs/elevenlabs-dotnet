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
using ElevenLabs.Productions.Orders;
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

namespace ElevenLabs.Productions;

/// <summary>
/// Fern-shape interface for OrdersClient. Mirrors the public surface of <c>OrdersClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IOrdersClient
{
    public IMediaClient Media { get; }
    public IItemsClient Items { get; }
    public IDeliverablesClient Deliverables { get; }
    public ILanguagesClient Languages { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IOrdersClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOrdersClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOrdersClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOrdersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOrdersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>SubmitAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IOrdersClient SetSubmitAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Lists Productions orders in the workspace. Supports filtering by status and date range, with pagination.</summary>
    WithRawResponseTask<ListOrdersResponse> ListAsync(
        ListOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Creates a new Productions order in the workspace. The order starts in the open state and can be configured with items before submission.</summary>
    WithRawResponseTask<CreateOrderResponse> CreateAsync(
        CreateOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves full details for a Productions order.
    ///
    /// Quote and pricing information may not be available immediately; if you wish to see the quote before submission, you may need to poll the order details until it is ready.
    /// </summary>
    WithRawResponseTask<OrderResponse> GetAsync(
        string orderId,
        GetOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Updates an open order.</summary>
    WithRawResponseTask<UpdateOrderResponse> UpdateAsync(
        string orderId,
        UpdateOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits an open order for processing. The order must have at least one item. Once submitted, items can no longer be modified.
    ///
    /// Upon submission, the workspace will be charged for the order. The quote is based on information extracted from the uploaded media, such as its duration. The quote may not be available immediately; if you wish to see the quote before submission, you may need to poll the order details until the quote is ready.
    /// </summary>
    WithRawResponseTask<SubmitOrderResponse> SubmitAsync(
        string orderId,
        SubmitOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class OrdersClient : IOrdersClient { }
