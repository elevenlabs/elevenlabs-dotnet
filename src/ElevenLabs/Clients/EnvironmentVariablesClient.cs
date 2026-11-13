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
using ElevenLabs.Workspace.Groups;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape client for EnvironmentVariablesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IEnvironmentVariablesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class EnvironmentVariablesClient
{
    private readonly EnvironmentVariablesService _service;

    internal EnvironmentVariablesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new EnvironmentVariablesService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IEnvironmentVariablesClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IEnvironmentVariablesClient SetListAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IEnvironmentVariablesClient SetCreateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IEnvironmentVariablesClient SetGetAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IEnvironmentVariablesClient SetUpdateAsyncConfig(
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
    public IEnvironmentVariablesClient SetDeleteAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>List all environment variables for the workspace with optional filtering</summary>
    public WithRawResponseTask<EnvironmentVariablesListResponse> ListAsync(
        ListEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<EnvironmentVariablesListResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Cursor,
                        request.PageSize,
                        request.Label,
                        request.Environment,
                        request.Type,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a new environment variable for the workspace</summary>
    public WithRawResponseTask<EnvironmentVariableResponse> CreateAsync(
        CreateEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<EnvironmentVariableResponse>(
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
                        (discriminant, _) =>
                            throw new global::System.ArgumentException(
                                $"Unknown discriminant '{discriminant}'"
                            )
                    )
            )
        );

    /// <summary>Get a specific environment variable by ID</summary>
    public WithRawResponseTask<EnvironmentVariableResponse> GetAsync(
        string envVarId,
        GetEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<EnvironmentVariableResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        envVarId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Replace an environment variable's values. Use null to remove its value for an environment (except production); delete an environment with DELETE /v1/convai/environments/{environment}.</summary>
    public WithRawResponseTask<EnvironmentVariableResponse> UpdateAsync(
        string envVarId,
        UpdateEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<EnvironmentVariableResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        envVarId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete an environment variable and its values in all environments. WARNING: Agents are not checked. A variable that an agent still uses (custom LLM, webhooks or cloud storage export, on any branch or version) is deleted anyway, and that agent's conversations then fail. The delete is only rejected while tools, MCP servers or the workspace conversation initiation webhook use the variable.</summary>
    public WithRawResponseTask DeleteAsync(
        string envVarId,
        DeleteEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.DeleteAsync(
                        envVarId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
