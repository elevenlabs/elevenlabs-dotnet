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
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape interface for EnvironmentVariablesClient. Mirrors the public surface of <c>EnvironmentVariablesClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IEnvironmentVariablesClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IEnvironmentVariablesClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IEnvironmentVariablesClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IEnvironmentVariablesClient SetCreateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IEnvironmentVariablesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IEnvironmentVariablesClient SetUpdateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IEnvironmentVariablesClient SetDeleteAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>List all environment variables for the workspace with optional filtering</summary>
    WithRawResponseTask<EnvironmentVariablesListResponse> ListAsync(
        ListEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a new environment variable for the workspace</summary>
    WithRawResponseTask<EnvironmentVariableResponse> CreateAsync(
        CreateEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a specific environment variable by ID</summary>
    WithRawResponseTask<EnvironmentVariableResponse> GetAsync(
        string envVarId,
        GetEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Replace an environment variable's values. Use null to remove its value for an environment (except production); delete an environment with DELETE /v1/convai/environments/{environment}.</summary>
    WithRawResponseTask<EnvironmentVariableResponse> UpdateAsync(
        string envVarId,
        UpdateEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete an environment variable and its values in all environments. WARNING: Agents are not checked. A variable that an agent still uses (custom LLM, webhooks or cloud storage export, on any branch or version) is deleted anyway, and that agent's conversations then fail. The delete is only rejected while tools, MCP servers or the workspace conversation initiation webhook use the variable.</summary>
    WithRawResponseTask DeleteAsync(
        string envVarId,
        DeleteEnvironmentVariablesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class EnvironmentVariablesClient : IEnvironmentVariablesClient { }
