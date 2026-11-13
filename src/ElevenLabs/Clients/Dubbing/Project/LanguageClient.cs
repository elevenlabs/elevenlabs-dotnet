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

namespace ElevenLabs.Dubbing.Project;

/// <summary>
/// Fern-shape client for LanguageClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ILanguageClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class LanguageClient
{
    private readonly LanguageService _service;

    internal LanguageClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new LanguageService(httpClient);
        Transcript = new ElevenLabs.Dubbing.Project.Language.TranscriptClient(httpClient);
    }

    public ElevenLabs.Dubbing.Project.Language.ITranscriptClient Transcript { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILanguageClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILanguageClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILanguageClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILanguageClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ILanguageClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>List a project's language targets, cursor-paginated, each with signed output URLs once it has produced an output.</summary>
    public WithRawResponseTask<DubbingLanguageListResponse> ListAsync(
        string projectId,
        ListLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingLanguageListResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        projectId,
                        request.Cursor,
                        request.PageSize,
                        request.Status,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>
    /// Add a language to dub a project into, and queue the dub.
    ///
    /// This is the call that produces dubbed audio, and it is billed per generation. The target is created `queued` and starts as soon as the project is `ready`, so it can be added at any point after the project is created. It inherits the project's dubbing model and cannot pick another.
    ///
    /// A project created with `webhook_ids` sends a `dubbing_language_completed` event carrying the output download URLs, so we recommend subscribing rather than polling this target to completion.
    /// </summary>
    public WithRawResponseTask<DubbingLanguageResponse> CreateAsync(
        string projectId,
        CreateLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingLanguageResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        projectId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Full language-target detail. Once the target reports `completed`, `outputs` carries the signed download URLs. To learn when that happens, we recommend the project's `webhook_ids` subscription rather than polling this endpoint; fetch here when a delivered URL has expired, or to reconcile after an edit.</summary>
    public WithRawResponseTask<DubbingLanguageResponse> GetAsync(
        string projectId,
        string languageId,
        GetLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingLanguageResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        projectId,
                        languageId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete a language target and its outputs, leaving the project and its other languages intact. This cannot be undone, and a dub already running is still billed.</summary>
    public WithRawResponseTask DeleteAsync(
        string projectId,
        string languageId,
        DeleteLanguageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.DeleteAsync(
                        projectId,
                        languageId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
