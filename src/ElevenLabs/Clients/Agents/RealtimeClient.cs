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
using ElevenLabs.Workspace.Groups;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape client for RealtimeClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IRealtimeClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class RealtimeClient
{
    private readonly RealtimeService _service;

    internal RealtimeClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new RealtimeService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListConversationGroupsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetListConversationGroupsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListConversationGroupsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetCreateConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateConversationGroupAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetGetConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetConversationGroupAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetUpdateConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateConversationGroupAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetDeleteConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetDeleteConversationGroupAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SetConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetSetConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetSetConversationGroupAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ClearConversationGroupAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetClearConversationGroupAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetClearConversationGroupAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateClientSecretAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRealtimeClient SetCreateClientSecretAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateClientSecretAsyncConfig(config);
        return this;
    }

    /// <summary>List the realtime conversation groups the current user can view.</summary>
    public WithRawResponseTask<RealtimeConversationGroupsResponseModel> ListConversationGroupsAsync(
        ListConversationGroupsRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RealtimeConversationGroupsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListConversationGroupsAsync(
                        request.PageSize,
                        request.Search,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a realtime conversation group owned by the current user.</summary>
    public WithRawResponseTask<RealtimeConversationGroupResponseModel> CreateConversationGroupAsync(
        CreateConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RealtimeConversationGroupResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateConversationGroupAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a realtime conversation group by id.</summary>
    public WithRawResponseTask<RealtimeConversationGroupResponseModel> GetConversationGroupAsync(
        string conversationGroupId,
        GetConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RealtimeConversationGroupResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetConversationGroupAsync(
                        conversationGroupId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Rename or re-describe a realtime conversation group.</summary>
    public WithRawResponseTask<RealtimeConversationGroupResponseModel> UpdateConversationGroupAsync(
        string conversationGroupId,
        UpdateConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RealtimeConversationGroupResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateConversationGroupAsync(
                        request.Body,
                        conversationGroupId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete a realtime conversation group. Every conversation in it becomes ungrouped, so access granted through the group is revoked.</summary>
    public WithRawResponseTask<object> DeleteConversationGroupAsync(
        string conversationGroupId,
        DeleteConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteConversationGroupAsync(
                        conversationGroupId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Place a realtime conversation in a conversation group, moving it out of its current group if it has one.</summary>
    public WithRawResponseTask<object> SetConversationGroupAsync(
        string conversationId,
        SetConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SetConversationGroupAsync(
                        request.Body,
                        conversationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Remove a realtime conversation from its conversation group.</summary>
    public WithRawResponseTask<object> ClearConversationGroupAsync(
        string conversationId,
        ClearConversationGroupRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ClearConversationGroupAsync(
                        conversationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create an ephemeral client secret for authenticating browser-based Realtime API sessions.</summary>
    public WithRawResponseTask<ClientSecretResponse> CreateClientSecretAsync(
        CreateClientSecretRealtimeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ClientSecretResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateClientSecretAsync(
                        new global::ElevenLabs.Agents.CreateClientSecretRequest
                        {
                            Session = request.Session,
                            ExpiresAfter = request.ExpiresAfter,
                        },
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
