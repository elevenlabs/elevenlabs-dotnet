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

namespace ElevenLabs;

/// <summary>
/// Fern-shape interface for ServiceAccountsClient. Mirrors the public surface of <c>ServiceAccountsClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IServiceAccountsClient
{
    public ElevenLabs.ServiceAccounts.IApiKeysClient ApiKeys { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IServiceAccountsClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IServiceAccountsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IServiceAccountsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>List all service accounts in the workspace</summary>
    WithRawResponseTask<WorkspaceServiceAccountListResponseModel> ListAsync(
        ListServiceAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a new service account in the workspace. By default, a workspace can have up to 20 service accounts. Enterprise customers may request an increase to this limit.</summary>
    WithRawResponseTask<WorkspaceCreateServiceAccountResponseModel> CreateAsync(
        CreateServiceAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class ServiceAccountsClient : IServiceAccountsClient { }
