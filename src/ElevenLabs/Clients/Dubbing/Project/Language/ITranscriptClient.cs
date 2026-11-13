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

namespace ElevenLabs.Dubbing.Project.Language;

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
    /// Sets method-level configuration for <c>UpdateSegmentsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetUpdateSegmentsAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>RegenerateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITranscriptClient SetRegenerateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>A language target's transcript: source segments with their translations. Available once the target has produced an output. Returns a conflict while the target is still on its first dub, since it has no translations to return yet.</summary>
    WithRawResponseTask<DubbingTargetTranscriptResponse> GetAsync(
        string projectId,
        string languageId,
        GetTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Enterprise only. Edit a segment's translation for a language target. Omitted fields are left unchanged; an explicit null clears the field. Bumps the target's `revision` and marks it `stale` if it had already completed. The source transcript and the project's other languages are untouched, and no audio changes until you regenerate the target.</summary>
    WithRawResponseTask<DubbingTargetSegmentUpdateResponse> UpdateSegmentAsync(
        string projectId,
        string languageId,
        string segmentId,
        UpdateSegmentTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Enterprise only. Edit several segments' translations for a language target in one atomic request: every edit applies or none does. Bumps the target's `revision` and marks it `stale` if it had already completed. The source transcript and the project's other languages are untouched, and no audio changes until you regenerate the target.</summary>
    WithRawResponseTask<DubbingBulkTargetSegmentUpdateResponse> UpdateSegmentsAsync(
        string projectId,
        string languageId,
        UpdateSegmentsTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Enterprise only. Re-dub a target from its edited transcript, re-synthesizing only the edited regions (charged like a generation, less the free-regeneration allowance). Accepted asynchronously: the target returns to `processing` and sends a `dubbing_language_completed` event to the project's `webhook_ids` when the re-dub lands, carrying the new output URLs. Returns a conflict when the target has no edits to apply — nothing is dispatched and nothing is charged.</summary>
    WithRawResponseTask<DubbingRegenerateResponse> RegenerateAsync(
        string projectId,
        string languageId,
        RegenerateTranscriptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class TranscriptClient : ITranscriptClient { }
