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
/// Fern-shape client for BranchesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IBranchesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class BranchesClient
{
    private readonly BranchesService _service;

    internal BranchesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new BranchesService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>PreviewMergeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetPreviewMergeAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetPreviewMergeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetMergeAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetMergeAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>PreviewRebaseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetPreviewRebaseAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetPreviewRebaseAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RebaseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBranchesClient SetRebaseAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRebaseAsyncConfig(config);
        return this;
    }

    /// <summary>Returns a list of branches an agent has</summary>
    public WithRawResponseTask<ListResponseAgentBranchSummary_> ListAsync(
        string agentId,
        ListBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ListResponseAgentBranchSummary_>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        agentId,
                        request.IncludeArchived,
                        request.Limit,
                        request.IncludeCommitStatus,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a new branch from a given version of any branch</summary>
    public WithRawResponseTask<CreateAgentBranchResponseModel> CreateAsync(
        string agentId,
        CreateBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreateAgentBranchResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        agentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get information about a single agent branch</summary>
    public WithRawResponseTask<AgentBranchResponse> GetAsync(
        string agentId,
        string branchId,
        GetBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentBranchResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        agentId,
                        branchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Update agent branch properties such as name, description, archiving status, protection level, and auto-rebase onto main</summary>
    public WithRawResponseTask<AgentBranchResponse> UpdateAsync(
        string agentId,
        string branchId,
        UpdateBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentBranchResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        agentId,
                        branchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns the result of merging the source branch into the target branch without performing the merge. Useful for showing an accurate diff before confirming.</summary>
    public WithRawResponseTask<MergePreviewResponseModel> PreviewMergeAsync(
        string agentId,
        string sourceBranchId,
        PreviewMergeBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MergePreviewResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.PreviewMergeAsync(
                        agentId,
                        sourceBranchId,
                        request.TargetBranchId,
                        request.Force,
                        request.IncludeProcedureGeneratedWorkflowElements,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Merge a branch into a target branch</summary>
    public WithRawResponseTask<object> MergeAsync(
        string agentId,
        string sourceBranchId,
        MergeBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.MergeAsync(
                        request.Body,
                        agentId,
                        sourceBranchId,
                        request.TargetBranchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns the result of pulling changes from a source branch (defaults to main) into the given branch without performing it, preserving the given branch's own changes. Useful for showing an accurate diff before confirming.</summary>
    public WithRawResponseTask<MergePreviewResponseModel> PreviewRebaseAsync(
        string agentId,
        string branchId,
        PreviewRebaseBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MergePreviewResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.PreviewRebaseAsync(
                        agentId,
                        branchId,
                        request.SourceBranchId,
                        request.IncludeProcedureGeneratedWorkflowElements,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Pull changes from a source branch (defaults to main) into this branch as a new version, preserving this branch's own changes on conflicts.</summary>
    public WithRawResponseTask<object> RebaseAsync(
        string agentId,
        string branchId,
        RebaseBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RebaseAsync(
                        request.Body,
                        agentId,
                        branchId,
                        request.SourceBranchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
