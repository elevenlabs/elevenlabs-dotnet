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
/// Fern-shape interface for DocumentClient. Mirrors the public surface of <c>DocumentClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IDocumentClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateFileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentClient SetUpdateFileAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>RefreshAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentClient SetRefreshAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ComputeRagIndexAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDocumentClient SetComputeRagIndexAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Update the source file of a file document. The document name, content, and metadata are updated to reflect the new file. Any manual content edits will be overwritten.</summary>
    WithRawResponseTask<ResponseUpdateFileDocumentV1ConvaiKnowledgeBaseDocumentationIdUpdateFilePatch> UpdateFileAsync(
        string documentationId,
        UpdateFileDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Manually refresh a URL document by re-fetching its content from the source URL.</summary>
    WithRawResponseTask<ResponseRefreshUrlDocumentContentV1ConvaiKnowledgeBaseDocumentationIdRefreshPost> RefreshAsync(
        string documentationId,
        RefreshDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>In case the document is not RAG indexed, it triggers rag indexing task, otherwise it just returns the current status.</summary>
    WithRawResponseTask<RagDocumentIndexResponseModel> ComputeRagIndexAsync(
        string documentationId,
        ComputeRagIndexDocumentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class DocumentClient : IDocumentClient { }
