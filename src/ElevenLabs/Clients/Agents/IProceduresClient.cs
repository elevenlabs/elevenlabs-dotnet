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
/// Fern-shape interface for ProceduresClient. Mirrors the public surface of <c>ProceduresClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IProceduresClient
{
    public ElevenLabs.Agents.Procedures.IDraftsClient Drafts { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IProceduresClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProceduresClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProceduresClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CompileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProceduresClient SetCompileAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProceduresClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>RemoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProceduresClient SetRemoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>List the procedures attached to this agent branch. By default, unpublished drafts take precedence over the latest committed version. Pass agent_version_id to list a published snapshot instead. has_draft is true when a procedure has unpublished draft changes on this branch. Procedure content is not included; use Get Procedure to read a procedure's body.</summary>
    WithRawResponseTask<ListProceduresResponseModel> ListAsync(
        string agentId,
        string branchId,
        ListProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a new procedure for the agent on a branch.</summary>
    WithRawResponseTask<CreateProcedureResponseModel> CreateAsync(
        string agentId,
        string branchId,
        CreateProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Legacy. Do not use. Saving an agent draft (`POST /v1/convai/agents/{agent_id}/drafts`) and publishing an agent (`PATCH /v1/convai/agents/{agent_id}`) compile structured procedures into workflow nodes and edges, save the compiled workflow with the draft or version, and return validation errors, so a separate compile call is no longer needed. This endpoint remains available for the time being so existing callers do not break, as a dry-run that compiles the current procedure drafts into a workflow without persisting anything. It will eventually be deprecated.</summary>
    WithRawResponseTask<CompileProceduresResponseModel> CompileAsync(
        string agentId,
        string branchId,
        CompileProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Retrieve a procedure at a specific version or the current branch HEAD.</summary>
    WithRawResponseTask<ProcedureAtVersionResponseModel> GetAsync(
        string agentId,
        string branchId,
        string procedureId,
        GetProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Remove a procedure from the agent's draft working set. Removing a folder cascades to its entire subtree, rejected if any procedure outside the subtree hands off into it.</summary>
    WithRawResponseTask<object> RemoveAsync(
        string agentId,
        string branchId,
        string procedureId,
        RemoveProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class ProceduresClient : IProceduresClient { }
