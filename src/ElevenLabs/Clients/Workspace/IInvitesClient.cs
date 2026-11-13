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
/// Fern-shape interface for InvitesClient. Mirrors the public surface of <c>InvitesClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IInvitesClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IInvitesClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IInvitesClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateBatchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IInvitesClient SetCreateBatchAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IInvitesClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Sends an email invitation to join your workspace to the provided email. If the user doesn't have an account they will be prompted to create one. If the user accepts this invite they will be added as a user to your workspace and your subscription using one of your seats. This endpoint may only be called by workspace members with the WORKSPACE_MEMBERS_INVITE permission. If the user is already in the workspace a 400 error will be returned.</summary>
    WithRawResponseTask<AddWorkspaceInviteResponseModel> CreateAsync(
        CreateInvitesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Sends email invitations to join your workspace to the provided emails. Requires all email addresses to be part of a verified domain. If the users don't have an account they will be prompted to create one. If the users accept these invites they will be added as users to your workspace and your subscription using one of your seats. This endpoint may only be called by workspace members with the WORKSPACE_MEMBERS_INVITE permission.</summary>
    WithRawResponseTask<AddWorkspaceInviteResponseModel> CreateBatchAsync(
        CreateBatchInvitesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Invalidates an existing email invitation. The invitation will still show up in the inbox it has been delivered to, but activating it to join the workspace won't work. This endpoint may only be called by workspace members with the WORKSPACE_MEMBERS_INVITE permission.</summary>
    WithRawResponseTask<DeleteWorkspaceInviteResponseModel> DeleteAsync(
        DeleteInvitesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class InvitesClient : IInvitesClient { }
