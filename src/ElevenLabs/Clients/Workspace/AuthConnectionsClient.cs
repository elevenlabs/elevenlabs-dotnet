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
/// Fern-shape client for AuthConnectionsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IAuthConnectionsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class AuthConnectionsClient
{
    private readonly AuthConnectionsService _service;

    internal AuthConnectionsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new AuthConnectionsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAuthConnectionsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAuthConnectionsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAuthConnectionsClient SetCreateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAuthConnectionsClient SetUpdateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAuthConnectionsClient SetDeleteAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>Get all auth connections for the workspace</summary>
    public WithRawResponseTask<ListAuthConnectionsResponse> ListAsync(
        ListAuthConnectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ListAuthConnectionsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.ListAsync(request.XiApiKey, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Create a new OAuth2 auth connection for the workspace</summary>
    public WithRawResponseTask<ResponseCreateWorkspaceAuthConnectionV1WorkspaceAuthConnectionsPost> CreateAsync(
        CreateAuthConnectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseCreateWorkspaceAuthConnectionV1WorkspaceAuthConnectionsPost>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    request.Body.Match(
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            )
                    )
            )
        );

    /// <summary>Update an auth connection</summary>
    public WithRawResponseTask<ResponseUpdateWorkspaceAuthConnectionV1WorkspaceAuthConnectionsAuthConnectionIdPatch> UpdateAsync(
        string authConnectionId,
        UpdateAuthConnectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseUpdateWorkspaceAuthConnectionV1WorkspaceAuthConnectionsAuthConnectionIdPatch>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    request.Body.Match(
                        value =>
                            _service.UpdateAsync(
                                value,
                                authConnectionId,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.UpdateAsync(
                                value,
                                authConnectionId,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.UpdateAsync(
                                value,
                                authConnectionId,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.UpdateAsync(
                                value,
                                authConnectionId,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            )
                    )
            )
        );

    /// <summary>Delete an auth connection</summary>
    public WithRawResponseTask<object> DeleteAsync(
        string authConnectionId,
        DeleteAuthConnectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        authConnectionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
