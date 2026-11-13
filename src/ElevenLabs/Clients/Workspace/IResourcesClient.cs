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
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Workspace;

/// <summary>
/// Fern-shape interface for ResourcesClient. Mirrors the public surface of <c>ResourcesClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IResourcesClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IResourcesClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IResourcesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ShareAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IResourcesClient SetShareAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UnshareAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IResourcesClient SetUnshareAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Gets the metadata of a resource by ID.</summary>
    WithRawResponseTask<ResourceMetadataResponseModel> GetAsync(
        string resourceId,
        GetResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Grants a role (one of 'admin', 'editor', 'commenter', or 'viewer') on a workspace resource to a user, group, or workspace (service account) API key. This overrides any existing role the target has on the resource. To target a user or service account, pass only the user email; the user must be in your workspace. To target a group, pass only the group id. To target a workspace (service account) API key, pass the api key id; the resource will be shared with the service account associated with that key. You must have admin access to the resource to share it.</summary>
    WithRawResponseTask<object> ShareAsync(
        string resourceId,
        ShareResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Removes any existing role on a workspace resource from a user, group, or workspace (service account) API key. To target a user or service account, pass only the user email; the user must be in your workspace. To target a group, pass only the group id. To target a workspace (service account) API key, pass the api key id; the resource will be unshared from the service account associated with that key. You must have admin access to the resource to unshare it. You cannot remove permissions from the user who created the resource.</summary>
    WithRawResponseTask<object> UnshareAsync(
        string resourceId,
        UnshareResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class ResourcesClient : IResourcesClient { }
