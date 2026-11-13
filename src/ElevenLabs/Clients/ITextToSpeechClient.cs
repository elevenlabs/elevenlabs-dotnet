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
/// Fern-shape interface for TextToSpeechClient. Mirrors the public surface of <c>TextToSpeechClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface ITextToSpeechClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToSpeechClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToSpeechClient SetConvertAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ConvertWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToSpeechClient SetConvertWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToSpeechClient SetStreamAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>StreamWithTimestampsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    ITextToSpeechClient SetStreamWithTimestampsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>Converts text into speech using a voice of your choice and returns audio.</summary>
    WithRawResponseTask<global::System.IO.Stream> ConvertAsync(
        string voiceId,
        ConvertTextToSpeechRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Generate speech from text with precise character-level timing information for audio-text synchronization.</summary>
    WithRawResponseTask<AudioWithTimestampsResponse> ConvertWithTimestampsAsync(
        string voiceId,
        ConvertWithTimestampsTextToSpeechRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Converts text into speech using a voice of your choice and returns audio as an audio stream.</summary>
    WithRawResponseTask<global::System.IO.Stream> StreamAsync(
        string voiceId,
        StreamTextToSpeechRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Converts text into speech using a voice of your choice and returns a stream of JSONs containing audio as a base64 encoded string together with information on when which character was spoken.</summary>
    global::ElevenLabs.WithRawResponseStream<StreamingAudioChunkWithTimestampsResponse> StreamWithTimestampsAsync(
        string voiceId,
        StreamTextToSpeechWithTimestampsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class TextToSpeechClient : ITextToSpeechClient { }
