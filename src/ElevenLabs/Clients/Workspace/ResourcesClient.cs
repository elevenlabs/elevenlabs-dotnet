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
using ElevenLabs.Services;
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
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Workspace;

/// <summary>
/// Fern-shape client for ResourcesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IResourcesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ResourcesClient
{
    private readonly ResourcesService _service;

    internal ResourcesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new ResourcesService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IResourcesClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IResourcesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ShareAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IResourcesClient SetShareAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetShareAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UnshareAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IResourcesClient SetUnshareAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUnshareAsyncConfig(config);
        return this;
    }

    /// <summary>Gets the metadata of a resource by ID.</summary>
    public WithRawResponseTask<ResourceMetadataResponseModel> GetAsync(
        string resourceId,
        GetResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResourceMetadataResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        resourceId,
                        request.ResourceType,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Grants a role (one of 'admin', 'editor', 'commenter', or 'viewer') on a workspace resource to a user, group, or workspace (service account) API key. This overrides any existing role the target has on the resource. To target a user or service account, pass only the user email; the user must be in your workspace. To target a group, pass only the group id. To target a workspace (service account) API key, pass the api key id; the resource will be shared with the service account associated with that key. You must have admin access to the resource to share it.</summary>
    public WithRawResponseTask<object> ShareAsync(
        string resourceId,
        ShareResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ShareAsync(
                        request.Body,
                        resourceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Removes any existing role on a workspace resource from a user, group, or workspace (service account) API key. To target a user or service account, pass only the user email; the user must be in your workspace. To target a group, pass only the group id. To target a workspace (service account) API key, pass the api key id; the resource will be unshared from the service account associated with that key. You must have admin access to the resource to unshare it. You cannot remove permissions from the user who created the resource.</summary>
    public WithRawResponseTask<object> UnshareAsync(
        string resourceId,
        UnshareResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UnshareAsync(
                        request.Body,
                        resourceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
