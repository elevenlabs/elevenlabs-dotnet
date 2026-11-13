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
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape client for WorkspaceClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IWorkspaceClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class WorkspaceClient
{
    private readonly WorkspaceService _service;

    internal WorkspaceClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new WorkspaceService(httpClient);
        AuditLogs = new AuditLogsClient(httpClient);
        AuthConnections = new AuthConnectionsClient(httpClient);
        Groups = new GroupsClient(httpClient);
        Members = new ElevenLabs.Workspace.MembersClient(httpClient);
        Invites = new InvitesClient(httpClient);
        Resources = new ResourcesClient(httpClient);
        Usage = new UsageClient(httpClient);
        Analytics = new ElevenLabs.Workspace.AnalyticsClient(httpClient);
    }

    public IAuditLogsClient AuditLogs { get; }
    public IAuthConnectionsClient AuthConnections { get; }
    public IGroupsClient Groups { get; }
    public ElevenLabs.Workspace.IMembersClient Members { get; }
    public IInvitesClient Invites { get; }
    public IResourcesClient Resources { get; }
    public IUsageClient Usage { get; }
    public ElevenLabs.Workspace.IAnalyticsClient Analytics { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IWorkspaceClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SetThirdPartyDisablingPolicyAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IWorkspaceClient SetSetThirdPartyDisablingPolicyAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetSetThirdPartyDisablingPolicyAsyncConfig(config);
        return this;
    }

    /// <summary>Set the workspace-wide Third-Party Disabling policy. When set, it forces, for every API key in the workspace, whether the holder of a key (potentially a third party who found it) may disable it via the self-disable endpoint or when it leaks publicly — overriding each key's own setting. Pass `true` to allow it for all keys, `false` to forbid it for all keys, or `null` to clear the override so per-key values and the plan default apply again. Workspace admins only.</summary>
    public WithRawResponseTask<object> SetThirdPartyDisablingPolicyAsync(
        SetThirdPartyDisablingPolicyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SetThirdPartyDisablingPolicyAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
