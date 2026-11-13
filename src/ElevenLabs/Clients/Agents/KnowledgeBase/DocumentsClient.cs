using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase.Documents;
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

namespace ElevenLabs.Agents.KnowledgeBase;

/// <summary>
/// Fern-shape client for DocumentsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IDocumentsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class DocumentsClient
{
    private readonly DocumentsService _service;

    internal DocumentsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new DocumentsService(httpClient);
        Summaries = new ElevenLabs.Agents.KnowledgeBase.Documents.SummariesClient(httpClient);
        Chunk = new ChunkClient(httpClient);
        Chunks = new ChunksClient(httpClient);
    }

    public ElevenLabs.Agents.KnowledgeBase.Documents.ISummariesClient Summaries { get; }
    public IChunkClient Chunk { get; }
    public IChunksClient Chunks { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromUrlAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetCreateFromUrlAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateFromUrlAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromFileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetCreateFromFileAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateFromFileAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromTextAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetCreateFromTextAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateFromTextAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateFolderAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetCreateFolderAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateFolderAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAgentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetGetAgentsAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAgentsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetBulkAgentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetGetBulkAgentsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetBulkAgentsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetContentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetGetContentAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetContentAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSourceFileUrlAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetGetSourceFileUrlAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetSourceFileUrlAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>MoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetMoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetMoveAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>BulkMoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetBulkMoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetBulkMoveAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>BulkDeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentsClient SetBulkDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetBulkDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>Create a knowledge base document generated by scraping the given webpage.</summary>
    public WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFromUrlAsync(
        CreateFromUrlDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddKnowledgeBaseResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateFromUrlAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a knowledge base document generated form the uploaded file.</summary>
    public WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFromFileAsync(
        CreateFromFileDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddKnowledgeBaseResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateFromFileAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a knowledge base document containing the provided text.</summary>
    public WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFromTextAsync(
        CreateFromTextDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddKnowledgeBaseResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateFromTextAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a folder used for grouping documents together.</summary>
    public WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFolderAsync(
        CreateFolderDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddKnowledgeBaseResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateFolderAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get details about a specific documentation making up the agent's knowledge base</summary>
    public WithRawResponseTask<ResponseGetDocumentationFromKnowledgeBaseV1ConvaiKnowledgeBaseDocumentationIdGet> GetAsync(
        string documentationId,
        GetDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseGetDocumentationFromKnowledgeBaseV1ConvaiKnowledgeBaseDocumentationIdGet>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        documentationId,
                        request.AgentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Update the name, content and/or auto-sync settings of a document.</summary>
    public WithRawResponseTask<ResponseUpdateDocumentV1ConvaiKnowledgeBaseDocumentationIdPatch> UpdateAsync(
        string documentationId,
        UpdateDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseUpdateDocumentV1ConvaiKnowledgeBaseDocumentationIdPatch>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        documentationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete a document or folder from the knowledge base.</summary>
    public WithRawResponseTask<object> DeleteAsync(
        string documentationId,
        DeleteDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        documentationId,
                        request.Force,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a list of agents depending on this knowledge base document</summary>
    public WithRawResponseTask<GetKnowledgeBaseDependentAgentsResponseModel> GetAgentsAsync(
        string documentationId,
        GetAgentsDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetKnowledgeBaseDependentAgentsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAgentsAsync(
                        documentationId,
                        request.DependentType,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a list of agents depending on any of the given knowledge base documents.</summary>
    public WithRawResponseTask<GetKnowledgeBaseDependentAgentsResponseModel> GetBulkAgentsAsync(
        GetBulkAgentsDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetKnowledgeBaseDependentAgentsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetBulkAgentsAsync(
                        request.Body,
                        request.DependentType,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get the entire content of a document from the knowledge base</summary>
    public WithRawResponseTask<string> GetContentAsync(
        string documentationId,
        GetContentDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<string>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetContentAsync(
                        documentationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a signed URL to download the original source file of a file-type document from the knowledge base</summary>
    public WithRawResponseTask<KnowledgeBaseSourceFileUrlResponseModel> GetSourceFileUrlAsync(
        string documentationId,
        GetSourceFileUrlDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<KnowledgeBaseSourceFileUrlResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetSourceFileUrlAsync(
                        documentationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Moves the entity from one folder to another.</summary>
    public WithRawResponseTask MoveAsync(
        string documentId,
        MoveDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.MoveAsync(
                        request.Body,
                        documentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Moves multiple entities from one folder to another.</summary>
    public WithRawResponseTask BulkMoveAsync(
        BulkMoveDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.BulkMoveAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete multiple documents or folders from the knowledge base. Each id succeeds or fails independently.</summary>
    public WithRawResponseTask<Dictionary<string, BulkDeleteDocumentsResponse>> BulkDeleteAsync(
        BulkDeleteDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, BulkDeleteDocumentsResponse>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.BulkDeleteAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
