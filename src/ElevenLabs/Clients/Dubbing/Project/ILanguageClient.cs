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

namespace ElevenLabs.Dubbing.Project;

/// <summary>
/// Fern-shape interface for LanguageClient. Mirrors the public surface of <c>LanguageClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface ILanguageClient
{
    public ElevenLabs.Dubbing.Project.Language.ITranscriptClient Transcript { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    ILanguageClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ILanguageClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ILanguageClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ILanguageClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ILanguageClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>List a project's language targets, cursor-paginated, each with signed output URLs once it has produced an output.</summary>
    WithRawResponseTask<DubbingLanguageListResponse> ListAsync(
        string projectId,
        ListLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add a language to dub a project into, and queue the dub.
    ///
    /// This is the call that produces dubbed audio, and it is billed per generation. The target is created `queued` and starts as soon as the project is `ready`, so it can be added at any point after the project is created. It inherits the project's dubbing model and cannot pick another.
    ///
    /// A project created with `webhook_ids` sends a `dubbing_language_completed` event carrying the output download URLs, so we recommend subscribing rather than polling this target to completion.
    /// </summary>
    WithRawResponseTask<DubbingLanguageResponse> CreateAsync(
        string projectId,
        CreateLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Full language-target detail. Once the target reports `completed`, `outputs` carries the signed download URLs. To learn when that happens, we recommend the project's `webhook_ids` subscription rather than polling this endpoint; fetch here when a delivered URL has expired, or to reconcile after an edit.</summary>
    WithRawResponseTask<DubbingLanguageResponse> GetAsync(
        string projectId,
        string languageId,
        GetLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete a language target and its outputs, leaving the project and its other languages intact. This cannot be undone, and a dub already running is still billed.</summary>
    WithRawResponseTask DeleteAsync(
        string projectId,
        string languageId,
        DeleteLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class LanguageClient : ILanguageClient { }
