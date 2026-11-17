using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// Event handlers wired onto each <see cref="SpeechEngineSession"/> produced by a
/// <see cref="SpeechEngineServer"/> or by <see cref="SpeechEngineResource"/>'s serve/attach helpers.
/// </summary>
/// <remarks>
/// Hand-written (see <c>.fernignore</c>), mirroring the <c>SpeechEngineCallbacks</c> option object in
/// the Python/TypeScript SDKs.
/// </remarks>
public sealed class SpeechEngineCallbacks
{
    /// <summary>Enable debug logging to standard error.</summary>
    public bool Debug { get; set; }

    /// <summary>
    /// Disable verification of the <c>X-ElevenLabs-Speech-Engine-Authorization</c> JWT on incoming
    /// connections. When <c>true</c>, any client that can reach the server is accepted.
    /// <para>
    /// <b>Insecure.</b> Only enable this when the server is protected another way — typically an IP
    /// allowlist restricting traffic to ElevenLabs' egress ranges. Without that, anyone on the
    /// internet can open a session and consume your compute and downstream LLM quota.
    /// </para>
    /// </summary>
    public bool DisableAuth { get; set; }

    /// <summary>Fired once when the session is initialized with a conversation ID.</summary>
    public Action<string, SpeechEngineSession>? OnInit { get; set; }

    /// <summary>
    /// Fired each time the Speech Engine API sends a user transcript. The
    /// <see cref="CancellationToken"/> is cancelled when a newer transcript arrives, so a
    /// long-running LLM call can be interrupted.
    /// </summary>
    public Func<
        IReadOnlyList<ConversationMessage>,
        CancellationToken,
        SpeechEngineSession,
        Task
    >? OnTranscript { get; set; }

    /// <summary>Fired when ElevenLabs sends a clean close message ending the conversation.</summary>
    public Action<SpeechEngineSession>? OnClose { get; set; }

    /// <summary>Fired when the underlying WebSocket drops unexpectedly.</summary>
    public Action<SpeechEngineSession>? OnDisconnect { get; set; }

    /// <summary>Fired on protocol-level or WebSocket-level errors.</summary>
    public Action<Exception, SpeechEngineSession>? OnError { get; set; }
}
