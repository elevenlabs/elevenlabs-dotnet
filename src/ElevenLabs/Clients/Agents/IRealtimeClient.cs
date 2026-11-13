using ElevenLabs;
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

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape interface for RealtimeClient. Mirrors the public surface of <c>RealtimeClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IRealtimeClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListConversationGroupsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetListConversationGroupsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>CreateConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetCreateConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>GetConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetGetConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>UpdateConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetUpdateConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>DeleteConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetDeleteConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>SetConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetSetConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>ClearConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetClearConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>CreateClientSecretAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IRealtimeClient SetCreateClientSecretAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>List the realtime conversation groups the current user can view.</summary>
    WithRawResponseTask<RealtimeConversationGroupsResponseModel> ListConversationGroupsAsync(
        ListConversationGroupsRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a realtime conversation group owned by the current user.</summary>
    WithRawResponseTask<RealtimeConversationGroupResponseModel> CreateConversationGroupAsync(
        CreateConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a realtime conversation group by id.</summary>
    WithRawResponseTask<RealtimeConversationGroupResponseModel> GetConversationGroupAsync(
        string conversationGroupId,
        GetConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Rename or re-describe a realtime conversation group.</summary>
    WithRawResponseTask<RealtimeConversationGroupResponseModel> UpdateConversationGroupAsync(
        string conversationGroupId,
        UpdateConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete a realtime conversation group. Every conversation in it becomes ungrouped, so access granted through the group is revoked.</summary>
    WithRawResponseTask<object> DeleteConversationGroupAsync(
        string conversationGroupId,
        DeleteConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Place a realtime conversation in a conversation group, moving it out of its current group if it has one.</summary>
    WithRawResponseTask<object> SetConversationGroupAsync(
        string conversationId,
        SetConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Remove a realtime conversation from its conversation group.</summary>
    WithRawResponseTask<object> ClearConversationGroupAsync(
        string conversationId,
        ClearConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create an ephemeral client secret for authenticating browser-based Realtime API sessions.</summary>
    WithRawResponseTask<ClientSecretResponse> CreateClientSecretAsync(
        CreateClientSecretRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class RealtimeClient : IRealtimeClient { }
