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

namespace ElevenLabs.Productions;

/// <summary>
/// Fern-shape client for OrdersClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IOrdersClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class OrdersClient
{
    private readonly OrdersService _service;

    internal OrdersClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new OrdersService(httpClient);
        Media = new MediaClient(httpClient);
        Items = new ItemsClient(httpClient);
        Deliverables = new DeliverablesClient(httpClient);
        Languages = new LanguagesClient(httpClient);
    }

    public IMediaClient Media { get; }
    public IItemsClient Items { get; }
    public IDeliverablesClient Deliverables { get; }
    public ILanguagesClient Languages { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOrdersClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOrdersClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOrdersClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOrdersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOrdersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SubmitAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IOrdersClient SetSubmitAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSubmitAsyncConfig(config);
        return this;
    }

    /// <summary>Lists Productions orders in the workspace. Supports filtering by status and date range, with pagination.</summary>
    public WithRawResponseTask<ListOrdersResponse> ListAsync(
        ListOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ListOrdersResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.PageSize,
                        request.Offset,
                        request.Status?.ToList(),
                        request.StartDate,
                        request.EndDate,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Creates a new Productions order in the workspace. The order starts in the open state and can be configured with items before submission.</summary>
    public WithRawResponseTask<CreateOrderResponse> CreateAsync(
        CreateOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreateOrderResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        new global::ElevenLabs.Productions.CreateOrderRequest
                        {
                            Sandbox = request.Sandbox,
                        },
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>
    /// Retrieves full details for a Productions order.
    ///
    /// Quote and pricing information may not be available immediately; if you wish to see the quote before submission, you may need to poll the order details until it is ready.
    /// </summary>
    public WithRawResponseTask<OrderResponse> GetAsync(
        string orderId,
        GetOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<OrderResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        orderId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Updates an open order.</summary>
    public WithRawResponseTask<UpdateOrderResponse> UpdateAsync(
        string orderId,
        UpdateOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UpdateOrderResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        orderId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>
    /// Submits an open order for processing. The order must have at least one item. Once submitted, items can no longer be modified.
    ///
    /// Upon submission, the workspace will be charged for the order. The quote is based on information extracted from the uploaded media, such as its duration. The quote may not be available immediately; if you wish to see the quote before submission, you may need to poll the order details until the quote is ready.
    /// </summary>
    public WithRawResponseTask<SubmitOrderResponse> SubmitAsync(
        string orderId,
        SubmitOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<SubmitOrderResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SubmitAsync(
                        orderId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
