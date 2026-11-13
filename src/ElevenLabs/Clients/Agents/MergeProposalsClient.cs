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
/// Fern-shape client for MergeProposalsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IMergeProposalsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class MergeProposalsClient
{
    private readonly MergeProposalsService _service;

    internal MergeProposalsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new MergeProposalsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMergeProposalsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMergeProposalsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMergeProposalsClient SetCreateAsyncConfig(
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
    public IMergeProposalsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMergeProposalsClient SetUpdateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SubmitReviewAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMergeProposalsClient SetSubmitReviewAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetSubmitReviewAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddCommentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMergeProposalsClient SetAddCommentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetAddCommentAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMergeProposalsClient SetMergeAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetMergeAsyncConfig(config);
        return this;
    }

    /// <summary>List the proposals for an agent, newest first.</summary>
    public WithRawResponseTask<PaginatedResultAgentMergeProposalResponse_> ListAsync(
        string agentId,
        ListMergeProposalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<PaginatedResultAgentMergeProposalResponse_>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        agentId,
                        request.Status,
                        request.SourceBranchId,
                        request.TargetBranchId,
                        request.Search,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Record a request to merge a source branch into a target branch. Anyone with edit access can open one; merging it later is gated on write access to the target branch, so this is how a change reaches a protected branch the author cannot merge into themselves.</summary>
    public WithRawResponseTask<CreateAgentMergeProposalResponseModel> CreateAsync(
        string agentId,
        CreateMergeProposalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreateAgentMergeProposalResponseModel>(
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

    /// <summary>Get a single merge_proposal.</summary>
    public WithRawResponseTask<AgentMergeProposalResponse> GetAsync(
        string agentId,
        string mergeProposalId,
        GetMergeProposalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentMergeProposalResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        agentId,
                        mergeProposalId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Edit an open merge_proposal's title or description, or close it. The author closing it is recorded as withdrawn; anyone else as rejected.</summary>
    public WithRawResponseTask<AgentMergeProposalResponse> UpdateAsync(
        string agentId,
        string mergeProposalId,
        UpdateMergeProposalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentMergeProposalResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        agentId,
                        mergeProposalId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Approve a merge_proposal or request changes on it. A user's latest review replaces their previous one. Non-admins need an approval from another user before the merge is allowed.</summary>
    public WithRawResponseTask<AgentMergeProposalResponse> SubmitReviewAsync(
        string agentId,
        string mergeProposalId,
        SubmitReviewMergeProposalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentMergeProposalResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SubmitReviewAsync(
                        request.Body,
                        agentId,
                        mergeProposalId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Leave a comment on a merge_proposal without recording a review verdict. Unlike reviews, comments accumulate and can still be added once the merge_proposal is merged or closed.</summary>
    public WithRawResponseTask<AgentMergeProposalResponse> AddCommentAsync(
        string agentId,
        string mergeProposalId,
        AddCommentMergeProposalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentMergeProposalResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.AddCommentAsync(
                        request.Body,
                        agentId,
                        mergeProposalId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Execute the merge. The caller must have write access to the target branch (admins only, for a protected branch), so this is where a reviewer approves and merges a request opened by someone who could not.</summary>
    public WithRawResponseTask<AgentMergeProposalResponse> MergeAsync(
        string agentId,
        string mergeProposalId,
        MergeMergeProposalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AgentMergeProposalResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.MergeAsync(
                        request.Body,
                        agentId,
                        mergeProposalId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
