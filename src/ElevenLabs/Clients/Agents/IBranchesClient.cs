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
using ElevenLabs.CustomerSupport;
using ElevenLabs.CustomerSupport.Requesters;
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
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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
/// Fern-shape interface for BranchesClient. Mirrors the public surface of <c>BranchesClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IBranchesClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>PreviewMergeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetPreviewMergeAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>MergeAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetMergeAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>PreviewRebaseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetPreviewRebaseAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>RebaseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IBranchesClient SetRebaseAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Returns a list of branches an agent has</summary>
    WithRawResponseTask<ListResponseAgentBranchSummary_> ListAsync(
        string agentId,
        ListBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a new branch from a given version of any branch</summary>
    WithRawResponseTask<CreateAgentBranchResponseModel> CreateAsync(
        string agentId,
        CreateBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get information about a single agent branch</summary>
    WithRawResponseTask<AgentBranchResponse> GetAsync(
        string agentId,
        string branchId,
        GetBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Update agent branch properties such as name, description, archiving status, protection level, auto-rebase, and the branch it is kept in sync with</summary>
    WithRawResponseTask<AgentBranchResponse> UpdateAsync(
        string agentId,
        string branchId,
        UpdateBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Returns the result of merging the source branch into the target branch without performing the merge. When `conflicts` is not empty, the merge itself is rejected unless `conflict_resolutions` settles every conflict or `force` is set; until then the returned configuration shows one side of each conflict only as a placeholder.</summary>
    WithRawResponseTask<MergePreviewResponseModel> PreviewMergeAsync(
        string agentId,
        string sourceBranchId,
        PreviewMergeBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Merge a branch into a target branch. If both branches changed the same field, the merge returns 409 unless `conflict_resolutions` settles every conflict the merge preview reports, or `force` is set.</summary>
    WithRawResponseTask<object> MergeAsync(
        string agentId,
        string sourceBranchId,
        MergeBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Returns the result of pulling changes from a source branch (defaults to main) into the given branch without performing it. When `conflicts` is not empty, the rebase itself is rejected unless `conflict_resolutions` settles every conflict; until then the returned configuration keeps the given branch's side of each conflict.</summary>
    WithRawResponseTask<MergePreviewResponseModel> PreviewRebaseAsync(
        string agentId,
        string branchId,
        PreviewRebaseBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Pull changes from a source branch (defaults to main) into this branch as a new version. If both branches changed the same field, the rebase returns 409 unless `conflict_resolutions` settles every conflict the rebase preview reports. Callers with only propose access can pull into their own branch from its parent branch (their default source).</summary>
    WithRawResponseTask<object> RebaseAsync(
        string agentId,
        string branchId,
        RebaseBranchesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class BranchesClient : IBranchesClient { }
