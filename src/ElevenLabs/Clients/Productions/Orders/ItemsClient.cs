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

namespace ElevenLabs.Productions.Orders;

/// <summary>
/// Fern-shape client for ItemsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IItemsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ItemsClient
{
    private readonly ItemsService _service;

    internal ItemsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new ItemsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IItemsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpsertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IItemsClient SetUpsertAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpsertAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IItemsClient SetRemoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRemoveAsyncConfig(config);
        return this;
    }

    /// <summary>Adds or updates an order item on an open order. Returns the item ID and the quoted price.</summary>
    public WithRawResponseTask<UpsertOrderItemResponse> UpsertAsync(
        string orderId,
        UpsertItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UpsertOrderItemResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpsertAsync(
                        request.Body,
                        orderId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Removes an order item from an open order.</summary>
    public WithRawResponseTask<RemoveOrderItemResponse> RemoveAsync(
        string orderId,
        string itemId,
        RemoveItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RemoveOrderItemResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RemoveAsync(
                        orderId,
                        itemId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
