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
/// Fern-shape interface for TranscriptClient. Mirrors the public surface of <c>TranscriptClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface ITranscriptClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetUpdateSegmentAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteSegmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetDeleteSegmentAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetUpdateSegmentsAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateSegmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetCreateSegmentAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>The project's source transcript, as editable segments. Available once the project is `ready`.</summary>
    WithRawResponseTask<DubbingSourceTranscriptResponse> GetAsync(
        string projectId,
        GetTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Enterprise only. Edit a source segment's text, speaker, or timing. Omitted fields are left unchanged. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    WithRawResponseTask<DubbingSourceSegmentUpdateResponse> UpdateSegmentAsync(
        string projectId,
        string segmentId,
        UpdateSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Enterprise only. Remove a source segment from the transcript so it is no longer dubbed. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    WithRawResponseTask<DubbingTranscriptRevisionResponse> DeleteSegmentAsync(
        string projectId,
        string segmentId,
        DeleteSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Enterprise only. Edit several source segments' text, speaker, or timing in one atomic request: every edit applies or none does. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    WithRawResponseTask<DubbingBulkSourceSegmentUpdateResponse> UpdateSegmentsAsync(
        string projectId,
        UpdateSegmentsTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Enterprise only. Add a new source segment to the transcript. Its span must lie within the source media, last between 0.1 and 25 seconds, and not overlap another segment by the same speaker. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    WithRawResponseTask<DubbingSourceSegmentUpdateResponse> CreateSegmentAsync(
        string projectId,
        CreateSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class TranscriptClient : ITranscriptClient { }
