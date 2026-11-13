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
using ElevenLabs.Dubbing.Project;
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

namespace ElevenLabs.Dubbing.Project.Language;

/// <summary>
/// Fern-shape client for TranscriptClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITranscriptClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TranscriptClient
{
    private readonly TranscriptService _service;

    internal TranscriptClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TranscriptService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsync1Config(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptClient SetUpdateSegmentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateSegmentAsync1Config(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptClient SetUpdateSegmentsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateSegmentsAsync1Config(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RegenerateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptClient SetRegenerateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetRegenerateAsyncConfig(config);
        return this;
    }

    /// <summary>A language target's transcript: source segments with their translations. Available once the target has produced an output. Returns a conflict while the target is still on its first dub, since it has no translations to return yet.</summary>
    public WithRawResponseTask<DubbingTargetTranscriptResponse> GetAsync(
        string projectId,
        string languageId,
        GetTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingTargetTranscriptResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync1(
                        projectId,
                        languageId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Enterprise only. Edit a segment's translation for a language target. Omitted fields are left unchanged; an explicit null clears the field. Bumps the target's `revision` and marks it `stale` if it had already completed. The source transcript and the project's other languages are untouched, and no audio changes until you regenerate the target.</summary>
    public WithRawResponseTask<DubbingTargetSegmentUpdateResponse> UpdateSegmentAsync(
        string projectId,
        string languageId,
        string segmentId,
        UpdateSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingTargetSegmentUpdateResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateSegmentAsync1(
                        request.Body,
                        projectId,
                        languageId,
                        segmentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Enterprise only. Edit several segments' translations for a language target in one atomic request: every edit applies or none does. Bumps the target's `revision` and marks it `stale` if it had already completed. The source transcript and the project's other languages are untouched, and no audio changes until you regenerate the target.</summary>
    public WithRawResponseTask<DubbingBulkTargetSegmentUpdateResponse> UpdateSegmentsAsync(
        string projectId,
        string languageId,
        UpdateSegmentsTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingBulkTargetSegmentUpdateResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateSegmentsAsync1(
                        request.Body,
                        projectId,
                        languageId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Enterprise only. Re-dub a target from its edited transcript, re-synthesizing only the edited regions (charged like a generation, less the free-regeneration allowance). Accepted asynchronously: the target returns to `processing` and sends a `dubbing_language_completed` event to the project's `webhook_ids` when the re-dub lands, carrying the new output URLs. Returns a conflict when the target has no edits to apply — nothing is dispatched and nothing is charged.</summary>
    public WithRawResponseTask<DubbingRegenerateResponse> RegenerateAsync(
        string projectId,
        string languageId,
        RegenerateTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingRegenerateResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RegenerateAsync(
                        projectId,
                        languageId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
