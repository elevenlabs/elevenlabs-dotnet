using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
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
/// Fern-shape client for DocumentClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IDocumentClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class DocumentClient
{
    private readonly DocumentService _service;

    internal DocumentClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new DocumentService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateFileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentClient SetUpdateFileAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateFileAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RefreshAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentClient SetRefreshAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRefreshAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ComputeRagIndexAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDocumentClient SetComputeRagIndexAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetComputeRagIndexAsyncConfig(config);
        return this;
    }

    /// <summary>Update the source file of a file document. The document name, content, and metadata are updated to reflect the new file. Any manual content edits will be overwritten.</summary>
    public WithRawResponseTask<ResponseUpdateFileDocumentV1ConvaiKnowledgeBaseDocumentationIdUpdateFilePatch> UpdateFileAsync(
        string documentationId,
        UpdateFileDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseUpdateFileDocumentV1ConvaiKnowledgeBaseDocumentationIdUpdateFilePatch>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateFileAsync(
                        request.Body,
                        documentationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Manually refresh a URL document by re-fetching its content from the source URL.</summary>
    public WithRawResponseTask<ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost> RefreshAsync(
        string documentationId,
        RefreshDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RefreshAsync(
                        documentationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>In case the document is not RAG indexed, it triggers rag indexing task, otherwise it just returns the current status.</summary>
    public WithRawResponseTask<RagDocumentIndexResponseModel> ComputeRagIndexAsync(
        string documentationId,
        ComputeRagIndexDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RagDocumentIndexResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ComputeRagIndexAsync(
                        request.Body,
                        documentationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
