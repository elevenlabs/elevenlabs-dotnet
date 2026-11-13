using ElevenLabs;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
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
/// Fern-shape client for KnowledgeBaseClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IKnowledgeBaseClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class KnowledgeBaseClient
{
    private readonly KnowledgeBaseService _service;

    internal KnowledgeBaseClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new KnowledgeBaseService(httpClient);
        Documents = new DocumentsClient(httpClient);
        CrawlJobs = new CrawlJobsClient(httpClient);
        Document = new DocumentClient(httpClient);
    }

    public IDocumentsClient Documents { get; }
    public ICrawlJobsClient CrawlJobs { get; }
    public IDocumentClient Document { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IKnowledgeBaseClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SizeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IKnowledgeBaseClient SetSizeAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSizeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IKnowledgeBaseClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetOrCreateRagIndexesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IKnowledgeBaseClient SetGetOrCreateRagIndexesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetOrCreateRagIndexesAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IKnowledgeBaseClient SetSearchAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSearchAsyncConfig(config);
        return this;
    }

    /// <summary>Returns the number of pages in the agent's knowledge base.</summary>
    public WithRawResponseTask<GetAgentKnowledgebaseSizeResponseModel> SizeAsync(
        string agentId,
        SizeKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentKnowledgebaseSizeResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SizeAsync(
                        agentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a list of available knowledge base documents</summary>
    public WithRawResponseTask<GetKnowledgeBaseListResponseModel> ListAsync(
        ListKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetKnowledgeBaseListResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.PageSize,
                        request.Search,
                        request.ShowOnlyOwnedDocuments,
                        request.CreatedByUserId,
                        request.Types?.ToList(),
                        request.ParentFolderId,
                        request.AncestorFolderId,
                        request.FoldersFirst,
                        request.SortDirection,
                        request.SortBy,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieves and/or creates RAG indexes for multiple knowledge base documents in a single request. Maximum 100 items per request.</summary>
    public WithRawResponseTask<
        Dictionary<string, GetOrCreateRagIndexesKnowledgeBaseResponse>
    > GetOrCreateRagIndexesAsync(
        GetOrCreateRagIndexesKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, GetOrCreateRagIndexesKnowledgeBaseResponse>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetOrCreateRagIndexesAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Fuzzy text search over knowledge base document content</summary>
    public WithRawResponseTask<KnowledgeBaseContentSearchResponseModel> SearchAsync(
        SearchKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<KnowledgeBaseContentSearchResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SearchAsync(
                        request.Query,
                        request.PageSize,
                        request.Types?.ToList(),
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
