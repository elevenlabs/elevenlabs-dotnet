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
/// Fern-shape client for GroupsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IGroupsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class GroupsClient
{
    private readonly GroupsService _service;

    internal GroupsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new GroupsService(httpClient);
        Members = new ElevenLabs.Workspace.Groups.MembersClient(httpClient);
    }

    public ElevenLabs.Workspace.Groups.IMembersClient Members { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IGroupsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IGroupsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IGroupsClient SetSearchAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSearchAsyncConfig(config);
        return this;
    }

    /// <summary>Get all groups in the workspace</summary>
    public WithRawResponseTask<Dictionary<string, WorkspaceGroupResponseModel>> ListAsync(
        ListGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, WorkspaceGroupResponseModel>>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.ListAsync(request.XiApiKey, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Searches for user groups in the workspace. Multiple or no groups may be returned.</summary>
    public WithRawResponseTask<IEnumerable<WorkspaceGroupByNameResponseModel>> SearchAsync(
        SearchGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<IEnumerable<WorkspaceGroupByNameResponseModel>>(
            WithRawResponseAdapter.WrapEnumerable(
                options,
                () =>
                    _service.SearchAsync(
                        request.Name,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
