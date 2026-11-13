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

namespace ElevenLabs.Agents.KnowledgeBase;

/// <summary>
/// Fern-shape interface for DocumentsClient. Mirrors the public surface of <c>DocumentsClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IDocumentsClient
{
    public ElevenLabs.Agents.KnowledgeBase.Documents.ISummariesClient Summaries { get; }
    public IChunkClient Chunk { get; }
    public IChunksClient Chunks { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromUrlAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetCreateFromUrlAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromFileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetCreateFromFileAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromTextAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetCreateFromTextAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateFolderAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetCreateFolderAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAgentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetGetAgentsAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetBulkAgentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetGetBulkAgentsAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetContentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetGetContentAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetSourceFileUrlAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetGetSourceFileUrlAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>MoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetMoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>BulkMoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetBulkMoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>BulkDeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentsClient SetBulkDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Create a knowledge base document generated by scraping the given webpage.</summary>
    WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFromUrlAsync(
        CreateFromUrlDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a knowledge base document generated form the uploaded file.</summary>
    WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFromFileAsync(
        CreateFromFileDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a knowledge base document containing the provided text.</summary>
    WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFromTextAsync(
        CreateFromTextDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a folder used for grouping documents together.</summary>
    WithRawResponseTask<AddKnowledgeBaseResponseModel> CreateFolderAsync(
        CreateFolderDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get details about a specific documentation making up the agent's knowledge base</summary>
    WithRawResponseTask<ResponseGetDocumentationFromKnowledgeBaseV1ConvaiKnowledgeBaseDocumentationIdGet> GetAsync(
        string documentationId,
        GetDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Update the name, content and/or auto-sync settings of a document.</summary>
    WithRawResponseTask<ResponseUpdateDocumentV1ConvaiKnowledgeBaseDocumentationIdPatch> UpdateAsync(
        string documentationId,
        UpdateDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete a document or folder from the knowledge base.</summary>
    WithRawResponseTask<object> DeleteAsync(
        string documentationId,
        DeleteDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a list of agents depending on this knowledge base document</summary>
    WithRawResponseTask<GetKnowledgeBaseDependentAgentsResponseModel> GetAgentsAsync(
        string documentationId,
        GetAgentsDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a list of agents depending on any of the given knowledge base documents.</summary>
    WithRawResponseTask<GetKnowledgeBaseDependentAgentsResponseModel> GetBulkAgentsAsync(
        GetBulkAgentsDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get the entire content of a document from the knowledge base</summary>
    WithRawResponseTask<string> GetContentAsync(
        string documentationId,
        GetContentDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a signed URL to download the original source file of a file-type document from the knowledge base</summary>
    WithRawResponseTask<KnowledgeBaseSourceFileUrlResponseModel> GetSourceFileUrlAsync(
        string documentationId,
        GetSourceFileUrlDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Moves the entity from one folder to another.</summary>
    WithRawResponseTask MoveAsync(
        string documentId,
        MoveDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Moves multiple entities from one folder to another.</summary>
    WithRawResponseTask BulkMoveAsync(
        BulkMoveDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete multiple documents or folders from the knowledge base. Each id succeeds or fails independently.</summary>
    WithRawResponseTask<Dictionary<string, BulkDeleteDocumentsResponse>> BulkDeleteAsync(
        BulkDeleteDocumentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class DocumentsClient : IDocumentsClient { }
