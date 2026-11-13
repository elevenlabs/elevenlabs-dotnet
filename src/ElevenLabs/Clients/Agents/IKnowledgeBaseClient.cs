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

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape interface for KnowledgeBaseClient. Mirrors the public surface of <c>KnowledgeBaseClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IKnowledgeBaseClient
{
    public IDocumentsClient Documents { get; }
    public ICrawlJobsClient CrawlJobs { get; }
    public IDocumentClient Document { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IKnowledgeBaseClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>SizeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IKnowledgeBaseClient SetSizeAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IKnowledgeBaseClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetOrCreateRagIndexesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IKnowledgeBaseClient SetGetOrCreateRagIndexesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IKnowledgeBaseClient SetSearchAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Returns the number of pages in the agent's knowledge base.</summary>
    WithRawResponseTask<GetAgentKnowledgebaseSizeResponseModel> SizeAsync(
        string agentId,
        SizeKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a list of available knowledge base documents</summary>
    WithRawResponseTask<GetKnowledgeBaseListResponseModel> ListAsync(
        ListKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Retrieves and/or creates RAG indexes for multiple knowledge base documents in a single request. Maximum 100 items per request.</summary>
    WithRawResponseTask<
        Dictionary<string, GetOrCreateRagIndexesKnowledgeBaseResponse>
    > GetOrCreateRagIndexesAsync(
        GetOrCreateRagIndexesKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Fuzzy text search over knowledge base document content</summary>
    WithRawResponseTask<KnowledgeBaseContentSearchResponseModel> SearchAsync(
        SearchKnowledgeBaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class KnowledgeBaseClient : IKnowledgeBaseClient { }
