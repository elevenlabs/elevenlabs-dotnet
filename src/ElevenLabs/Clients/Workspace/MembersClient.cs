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
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMembersClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMembersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateUsageLimitAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMembersClient SetUpdateUsageLimitAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateUsageLimitAsyncConfig(config);
        return this;
    }

    /// <summary>Gets a list of all members of the workspace, including locked members. Service accounts are excluded. Requires the workspace_members_read permission.</summary>
    public WithRawResponseTask<IEnumerable<WorkspaceMemberResponseModel>> ListAsync(
        ListMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<IEnumerable<WorkspaceMemberResponseModel>>(
            WithRawResponseAdapter.WrapEnumerable(
                options,
                () => _service.ListAsync(request.XiApiKey, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Updates attributes of a workspace member. Apart from the email identifier, all parameters will remain unchanged unless specified. This endpoint may only be called by workspace administrators.</summary>
    public WithRawResponseTask<UpdateWorkspaceMemberResponseModel> UpdateAsync(
        UpdateMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UpdateWorkspaceMemberResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Sets or clears the monthly credit usage limit of a workspace member or service account. This endpoint may only be called by workspace administrators.</summary>
    public WithRawResponseTask<UpdateMemberUsageLimitResponseModel> UpdateUsageLimitAsync(
        string userId,
        UpdateUsageLimitMembersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UpdateMemberUsageLimitResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateUsageLimitAsync(
                        request.Body,
                        userId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
