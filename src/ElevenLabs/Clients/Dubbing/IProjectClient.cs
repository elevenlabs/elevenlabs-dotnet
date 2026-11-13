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
using ElevenLabs.Dubbing.Project;
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

namespace ElevenLabs.Dubbing;

/// <summary>
/// Fern-shape interface for ProjectClient. Mirrors the public surface of <c>ProjectClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IProjectClient
{
    public ILanguageClient Language { get; }
    public ElevenLabs.Dubbing.Project.ITranscriptClient Transcript { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IProjectClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProjectClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProjectClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProjectClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IProjectClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>List the dubbing projects in your workspace that you can access, newest first, cursor-paginated. Listed projects carry no `language_ids`; fetch a project, or list its language targets, to see them.</summary>
    WithRawResponseTask<DubbingProjectListResponse> ListAsync(
        ListProjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a dubbing project from an uploaded file (`file`) or a source URL (`source_url`).
    ///
    /// Returns as soon as the project record exists, before the source has been fetched: the project starts `queued` and reaches `ready` once its source has been transcribed. Add a language target to it for each language you want, or pass `target_language` to queue the first one here.
    ///
    /// Creating a project incurs a minimum charge of one language: you are charged for at least one language's dubbing when the project is created, before any output exists. This charge prepays the first language target — the first target you add, or the one queued via `target_language`, consumes it — and each additional language is charged separately.
    ///
    /// Preparation can take minutes on a long source, so we recommend passing `webhook_ids` to be notified when the project turns `ready` or `failed`, rather than polling for it.
    /// </summary>
    WithRawResponseTask<DubbingProjectResponse> CreateAsync(
        CreateProjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Full project detail, including the IDs of every language target under it. To follow a project to `ready`, we recommend a `webhook_ids` subscription rather than polling this endpoint.</summary>
    WithRawResponseTask<DubbingProjectResponse> GetAsync(
        string projectId,
        GetProjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete a project, every language target under it, and their stored media and outputs. This cannot be undone, and a dub already running is still billed.</summary>
    WithRawResponseTask DeleteAsync(
        string projectId,
        DeleteProjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class ProjectClient : IProjectClient { }
