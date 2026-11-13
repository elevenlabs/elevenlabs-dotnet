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
        _service.SetGetAsyncConfig(config);
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
        _service.SetUpdateSegmentAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteSegmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptClient SetDeleteSegmentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetDeleteSegmentAsyncConfig(config);
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
        _service.SetUpdateSegmentsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateSegmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITranscriptClient SetCreateSegmentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateSegmentAsyncConfig(config);
        return this;
    }

    /// <summary>The project's source transcript, as editable segments. Available once the project is `ready`.</summary>
    public WithRawResponseTask<DubbingSourceTranscriptResponse> GetAsync(
        string projectId,
        GetTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingSourceTranscriptResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        projectId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Enterprise only. Edit a source segment's text, speaker, or timing. Omitted fields are left unchanged. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    public WithRawResponseTask<DubbingSourceSegmentUpdateResponse> UpdateSegmentAsync(
        string projectId,
        string segmentId,
        UpdateSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingSourceSegmentUpdateResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateSegmentAsync(
                        request.Body,
                        projectId,
                        segmentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Enterprise only. Remove a source segment from the transcript so it is no longer dubbed. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    public WithRawResponseTask<DubbingTranscriptRevisionResponse> DeleteSegmentAsync(
        string projectId,
        string segmentId,
        DeleteSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingTranscriptRevisionResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteSegmentAsync(
                        projectId,
                        segmentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Enterprise only. Edit several source segments' text, speaker, or timing in one atomic request: every edit applies or none does. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    public WithRawResponseTask<DubbingBulkSourceSegmentUpdateResponse> UpdateSegmentsAsync(
        string projectId,
        UpdateSegmentsTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingBulkSourceSegmentUpdateResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateSegmentsAsync(
                        request.Body,
                        projectId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Enterprise only. Add a new source segment to the transcript. Its span must lie within the source media, last between 0.1 and 25 seconds, and not overlap another segment by the same speaker. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    public WithRawResponseTask<DubbingSourceSegmentUpdateResponse> CreateSegmentAsync(
        string projectId,
        CreateSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DubbingSourceSegmentUpdateResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateSegmentAsync(
                        request.Body,
                        projectId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
