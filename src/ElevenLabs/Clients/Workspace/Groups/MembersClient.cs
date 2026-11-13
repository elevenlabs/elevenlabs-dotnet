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
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Workspace.Groups;

/// <summary>
/// Fern-shape client for MembersClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IMembersClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class MembersClient
{
    private readonly MembersService _service;

    internal MembersClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new MembersService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMembersClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMembersClient SetRemoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRemoveAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMembersClient SetAddAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetAddAsyncConfig(config);
        return this;
    }

    /// <summary>Removes a member from the specified group. Requires `group_members_manage` permission.</summary>
    public WithRawResponseTask<DeleteWorkspaceGroupMemberResponseModel> RemoveAsync(
        string groupId,
        RemoveMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DeleteWorkspaceGroupMemberResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RemoveAsync(
                        request.Body,
                        groupId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Adds a member of your workspace to the specified group. Requires `group_members_manage` permission.</summary>
    public WithRawResponseTask<AddWorkspaceGroupMemberResponseModel> AddAsync(
        string groupId,
        AddMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddWorkspaceGroupMemberResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.AddAsync(
                        request.Body,
                        groupId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
