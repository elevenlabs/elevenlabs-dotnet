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
/// Fern-shape client for ProceduresClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IProceduresClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ProceduresClient
{
    private readonly ProceduresService _service;

    internal ProceduresClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new ProceduresService(httpClient);
        Drafts = new ElevenLabs.Agents.Procedures.DraftsClient(httpClient);
    }

    public ElevenLabs.Agents.Procedures.IDraftsClient Drafts { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IProceduresClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IProceduresClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IProceduresClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CompileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IProceduresClient SetCompileAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCompileAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IProceduresClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IProceduresClient SetRemoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRemoveAsyncConfig(config);
        return this;
    }

    /// <summary>List the procedures attached to this agent branch. By default, unpublished drafts take precedence over the latest committed version. Pass agent_version_id to list a published snapshot instead. has_draft is true when a procedure has unpublished draft changes on this branch. Procedure content is not included; use Get Procedure to read a procedure's body.</summary>
    public WithRawResponseTask<ListProceduresResponseModel> ListAsync(
        string agentId,
        string branchId,
        ListProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ListProceduresResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        agentId,
                        branchId,
                        request.AgentVersionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a new procedure for the agent on a branch.</summary>
    public WithRawResponseTask<CreateProcedureResponseModel> CreateAsync(
        string agentId,
        string branchId,
        CreateProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreateProcedureResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        new global::ElevenLabs.Agents.CreateProcedureRequestModel
                        {
                            Name = request.Name,
                            Content = request.Content,
                            Type = request.Type,
                            Trigger = request.Trigger,
                            FolderParentId = request.FolderParentId,
                        },
                        agentId,
                        branchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Legacy. Do not use. Saving an agent draft (`POST /v1/convai/agents/{agent_id}/drafts`) and publishing an agent (`PATCH /v1/convai/agents/{agent_id}`) compile structured procedures into workflow nodes and edges, save the compiled workflow with the draft or version, and return validation errors, so a separate compile call is no longer needed. This endpoint remains available for the time being so existing callers do not break, as a dry-run that compiles the current procedure drafts into a workflow without persisting anything. It will eventually be deprecated.</summary>
    public WithRawResponseTask<CompileProceduresResponseModel> CompileAsync(
        string agentId,
        string branchId,
        CompileProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CompileProceduresResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CompileAsync(
                        agentId,
                        branchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieve a procedure at a specific version or the current branch HEAD.</summary>
    public WithRawResponseTask<ProcedureAtVersionResponseModel> GetAsync(
        string agentId,
        string branchId,
        string procedureId,
        GetProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ProcedureAtVersionResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        agentId,
                        branchId,
                        procedureId,
                        request.VersionId,
                        request.AgentVersionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Remove a procedure from the agent's draft working set. Removing a folder cascades to its entire subtree, rejected if any procedure outside the subtree hands off into it.</summary>
    public WithRawResponseTask<object> RemoveAsync(
        string agentId,
        string branchId,
        string procedureId,
        RemoveProceduresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RemoveAsync(
                        agentId,
                        branchId,
                        procedureId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
