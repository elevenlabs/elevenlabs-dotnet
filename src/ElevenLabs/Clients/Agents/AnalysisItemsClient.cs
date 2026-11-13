using ElevenLabs;
using ElevenLabs.Agents.AnalysisItems;
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
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape client for AnalysisItemsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IAnalysisItemsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class AnalysisItemsClient
{
    private readonly AnalysisItemsService _service;

    internal AnalysisItemsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new AnalysisItemsService(httpClient);
        DependentAgents = new DependentAgentsClient(httpClient);
    }

    public IDependentAgentsClient DependentAgents { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAttachmentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetUpdateAttachmentsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateAttachmentsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListVersionsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetListVersionsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListVersionsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CopyAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAnalysisItemsClient SetCopyAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCopyAsyncConfig(config);
        return this;
    }

    /// <summary>List analysis items available in the workspace.</summary>
    public WithRawResponseTask<AnalysisItemsResponseModel> ListAsync(
        ListAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AnalysisItemsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Search,
                        request.PageSize,
                        request.Kind,
                        request.AnalysisItemIds?.ToList(),
                        request.CreatedByUserId,
                        request.SortDirection,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a new analysis item (evaluation criterion or data collection) in the workspace.</summary>
    public WithRawResponseTask<AnalysisItemResponseModel> CreateAsync(
        CreateAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AnalysisItemResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    request.Body.Match(
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            )
                    )
            )
        );

    /// <summary>Attach or detach one analysis item on multiple agent branches.</summary>
    public WithRawResponseTask<UpdateAnalysisItemAttachmentsResponseModel> UpdateAttachmentsAsync(
        string analysisItemId,
        UpdateAttachmentsAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UpdateAnalysisItemAttachmentsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAttachmentsAsync(
                        request.Body,
                        analysisItemId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get an analysis item available in the workspace.</summary>
    public WithRawResponseTask<AnalysisItemResponseModel> GetAsync(
        string analysisItemId,
        GetAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AnalysisItemResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        analysisItemId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Update an analysis item. Publishes a new version when the content changes.</summary>
    public WithRawResponseTask<AnalysisItemResponseModel> UpdateAsync(
        string analysisItemId,
        UpdateAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AnalysisItemResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    request.Body.Match(
                        value =>
                            _service.UpdateAsync(
                                value,
                                analysisItemId,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.UpdateAsync(
                                value,
                                analysisItemId,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            )
                    )
            )
        );

    /// <summary>Delete an analysis item and all of its versions from the workspace.</summary>
    public WithRawResponseTask<object> DeleteAsync(
        string analysisItemId,
        DeleteAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        analysisItemId,
                        request.Force,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>List the published versions of an analysis item, newest first.</summary>
    public WithRawResponseTask<AnalysisItemVersionsResponseModel> ListVersionsAsync(
        string analysisItemId,
        ListVersionsAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AnalysisItemVersionsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListVersionsAsync(
                        analysisItemId,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a new analysis item from this item's current definition.</summary>
    public WithRawResponseTask<AnalysisItemResponseModel> CopyAsync(
        string analysisItemId,
        CopyAnalysisItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AnalysisItemResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CopyAsync(
                        analysisItemId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
