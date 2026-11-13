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

namespace ElevenLabs;

/// <summary>
/// Fern-shape interface for TextToDialogueClient. Mirrors the public surface of <c>TextToDialogueClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface ITextToDialogueClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToDialogueClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToDialogueClient SetConvertAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToDialogueClient SetStreamAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ConvertWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToDialogueClient SetConvertWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>StreamWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToDialogueClient SetStreamWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns audio.</summary>
    WithRawResponseTask<global::System.IO.Stream> ConvertAsync(
        ConvertTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns an audio stream.</summary>
    WithRawResponseTask<global::System.IO.Stream> StreamAsync(
        StreamTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Generate dialogue from text with precise character-level timing information for audio-text synchronization.</summary>
    WithRawResponseTask<AudioWithTimestampsAndVoiceSegmentsResponseModel> ConvertWithTimestampsAsync(
        ConvertWithTimestampsTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Converts a list of text and voice ID pairs into speech (dialogue) and returns a stream of JSON blobs containing audio as a base64 encoded string and timestamps</summary>
    global::ElevenLabs.WithRawResponseStream<StreamingAudioChunkWithTimestampsAndVoiceSegmentsResponseModel> StreamWithTimestampsAsync(
        StreamWithTimestampsTextToDialogueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class TextToDialogueClient : ITextToDialogueClient { }
