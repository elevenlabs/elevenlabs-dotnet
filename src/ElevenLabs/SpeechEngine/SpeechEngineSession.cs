using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// One Speech Engine conversation over a single WebSocket connection.
/// </summary>
/// <remarks>
/// <para>
/// The session is transport-agnostic: it is handed a <c>send</c> delegate that writes a text frame
/// and a <c>close</c> delegate that closes the connection, so the same protocol logic drives the
/// bundled <see cref="SpeechEngineServer"/> and any custom integration. Feed inbound frames to
/// <see cref="HandleRawMessage"/>; register handlers with the <c>On*</c> methods.
/// </para>
/// <para>
/// When a new user transcript arrives, the previous transcript's <see cref="CancellationToken"/> is
/// cancelled automatically, so a long-running LLM call is interrupted — matching the Python/TS SDKs.
/// </para>
/// <para>Hand-written (see <c>.fernignore</c>), mirroring <c>SpeechEngineSession</c> in the other SDKs.</para>
/// </remarks>
public sealed class SpeechEngineSession
{
    private readonly Action<string> _send;
    private readonly Action _closeConnection;
    private readonly Action<string> _log;

    private readonly List<Action<string, SpeechEngineSession>> _initHandlers = new();
    private readonly List<
        Func<IReadOnlyList<ConversationMessage>, CancellationToken, SpeechEngineSession, Task>
    > _transcriptHandlers = new();
    private readonly List<Action<SpeechEngineSession>> _closeHandlers = new();
    private readonly List<Action<SpeechEngineSession>> _disconnectedHandlers = new();
    private readonly List<Action<Exception, SpeechEngineSession>> _errorHandlers = new();

    private string? _conversationId;
    private long? _currentEventId;
    private CancellationTokenSource? _currentCts;
    private bool _inTranscriptHandler;
    private bool _closed;

    /// <param name="send">Writes a text frame to the connection.</param>
    /// <param name="close">Closes the connection. No-op if omitted.</param>
    /// <param name="debug">Enable debug logging to standard error.</param>
    public SpeechEngineSession(Action<string> send, Action? close = null, bool debug = false)
    {
        _send = send ?? throw new ArgumentNullException(nameof(send));
        _closeConnection = close ?? (static () => { });
        _log = debug
            ? static m => Console.Error.WriteLine("[SpeechEngine] " + m)
            : static _ => { };
    }

    /// <summary>The conversation ID assigned by the API, available after the <c>init</c> event.</summary>
    public string? ConversationId => _conversationId;

    /// <summary>Whether the session is still open.</summary>
    public bool IsOpen => !_closed;

    /// <summary>Register a handler fired once the session is initialized. Returns <c>this</c> for chaining.</summary>
    public SpeechEngineSession OnInit(Action<string, SpeechEngineSession> handler)
    {
        _initHandlers.Add(handler);
        return this;
    }

    /// <summary>Register a handler fired for each user transcript. Returns <c>this</c> for chaining.</summary>
    public SpeechEngineSession OnTranscript(
        Func<IReadOnlyList<ConversationMessage>, CancellationToken, SpeechEngineSession, Task> handler
    )
    {
        _transcriptHandlers.Add(handler);
        return this;
    }

    /// <summary>Register a handler fired on a clean close. Returns <c>this</c> for chaining.</summary>
    public SpeechEngineSession OnClose(Action<SpeechEngineSession> handler)
    {
        _closeHandlers.Add(handler);
        return this;
    }

    /// <summary>Register a handler fired on a transport-level disconnect. Returns <c>this</c> for chaining.</summary>
    public SpeechEngineSession OnDisconnected(Action<SpeechEngineSession> handler)
    {
        _disconnectedHandlers.Add(handler);
        return this;
    }

    /// <summary>Register a handler fired on protocol or transport errors. Returns <c>this</c> for chaining.</summary>
    public SpeechEngineSession OnError(Action<Exception, SpeechEngineSession> handler)
    {
        _errorHandlers.Add(handler);
        return this;
    }

    /// <summary>
    /// Parse and dispatch one inbound text frame. Malformed frames surface on the error event rather
    /// than throwing, so one bad message never ends the loop.
    /// </summary>
    public void HandleRawMessage(string raw)
    {
        JsonNode? node;
        try
        {
            node = JsonNode.Parse(raw);
        }
        catch (Exception e)
        {
            EmitError(e);
            return;
        }
        if (node is not JsonObject msg)
        {
            EmitError(new InvalidOperationException("Expected a JSON object message"));
            return;
        }
        HandleMessage(msg);
    }

    /// <summary>
    /// Send an LLM response back for TTS synthesis. Emits one non-final <c>agent_response</c> with the
    /// text followed by a final empty one. Only valid inside an <see cref="OnTranscript"/> handler;
    /// called elsewhere it warns and does nothing.
    /// </summary>
    public void SendResponse(string response)
    {
        if (!CanSend())
        {
            return;
        }
        var eventId = _currentEventId;
        SendAgentResponse(response, false, eventId);
        SendAgentResponse(string.Empty, true, eventId);
    }

    /// <summary>
    /// Stream an LLM response back for TTS synthesis. Each chunk is a plain string or an
    /// OpenAI/Anthropic/Gemini stream event (text is auto-extracted); empty chunks are skipped. A
    /// final empty <c>agent_response</c> is sent when the stream completes.
    /// </summary>
    public void SendResponse(IEnumerable<object?> response)
    {
        if (!CanSend())
        {
            return;
        }
        var eventId = _currentEventId;
        foreach (var chunk in response)
        {
            if (_closed)
            {
                return;
            }
            var text = ExtractText(chunk);
            if (!string.IsNullOrEmpty(text))
            {
                SendAgentResponse(text!, false, eventId);
            }
        }
        if (!_closed)
        {
            SendAgentResponse(string.Empty, true, eventId);
        }
    }

    /// <summary>
    /// Asynchronously stream an LLM response back for TTS synthesis, stopping early when
    /// <paramref name="cancellationToken"/> fires (e.g. the transcript's interruption token).
    /// </summary>
    public async Task SendResponseAsync(
        IAsyncEnumerable<object?> response,
        CancellationToken cancellationToken = default
    )
    {
        if (!CanSend())
        {
            return;
        }
        var eventId = _currentEventId;
        await foreach (var chunk in response.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            if (_closed || cancellationToken.IsCancellationRequested)
            {
                return;
            }
            var text = ExtractText(chunk);
            if (!string.IsNullOrEmpty(text))
            {
                SendAgentResponse(text!, false, eventId);
            }
        }
        if (!_closed && !cancellationToken.IsCancellationRequested)
        {
            SendAgentResponse(string.Empty, true, eventId);
        }
    }

    /// <summary>
    /// Notify the session that the underlying connection dropped at the transport level. Fires
    /// <c>disconnected</c> once. Called by <see cref="SpeechEngineServer"/>; not needed when driving
    /// the session yourself through <see cref="HandleRawMessage"/>.
    /// </summary>
    public void HandleDisconnect()
    {
        if (_closed)
        {
            return;
        }
        _closed = true;
        _inTranscriptHandler = false;
        AbortCurrent();
        foreach (var h in _disconnectedHandlers.ToArray())
        {
            Guarded("disconnected", () => h(this));
        }
    }

    /// <summary>Close the session and its underlying connection.</summary>
    public void Close()
    {
        if (_closed)
        {
            return;
        }
        _closed = true;
        _inTranscriptHandler = false;
        AbortCurrent();
        _closeConnection();
    }

    private bool CanSend()
    {
        if (_closed)
        {
            throw new InvalidOperationException("Cannot send response: session is closed");
        }
        if (!_inTranscriptHandler)
        {
            _log(
                "sendResponse() called outside an OnTranscript handler; responses can only be sent in "
                    + "reply to a user transcript. To have the agent speak first, set a first message in "
                    + "your Speech Engine conversation config."
            );
            return false;
        }
        return true;
    }

    private void HandleMessage(JsonObject msg)
    {
        switch (GetString(msg, "type"))
        {
            case "init":
                _conversationId = GetString(msg, "conversation_id");
                _log("session initialized, conversation_id=" + _conversationId);
                foreach (var h in _initHandlers.ToArray())
                {
                    Guarded("init", () => h(_conversationId ?? string.Empty, this));
                }
                break;

            case "user_transcript":
                HandleUserTranscript(msg);
                break;

            case "ping":
                SendJson(new JsonObject { ["type"] = "pong" });
                break;

            case "close":
                _closed = true;
                _inTranscriptHandler = false;
                AbortCurrent();
                foreach (var h in _closeHandlers.ToArray())
                {
                    Guarded("close", () => h(this));
                }
                break;

            case "error":
                EmitError(new InvalidOperationException(GetString(msg, "message") ?? string.Empty));
                break;

            // Unknown types are ignored for forward compatibility.
        }
    }

    private void HandleUserTranscript(JsonObject msg)
    {
        var eventId = GetInt64(msg, "event_id");

        // A repeat of the transcript we are already handling is ignored.
        if (eventId != null && eventId == _currentEventId && _currentCts != null)
        {
            _log("skipping duplicate transcript, event_id=" + eventId);
            return;
        }

        AbortCurrent();
        _currentCts = new CancellationTokenSource();
        _currentEventId = eventId;

        var transcript = new List<ConversationMessage>();
        if (msg.TryGetPropertyValue("user_transcript", out var raw) && raw is JsonArray arr)
        {
            foreach (var item in arr)
            {
                if (item is JsonObject m)
                {
                    var role = GetString(m, "role");
                    var content = GetString(m, "content");
                    if (role != null && content != null)
                    {
                        transcript.Add(new ConversationMessage(role, content));
                    }
                }
            }
        }

        _inTranscriptHandler = true;
        var token = _currentCts.Token;
        foreach (var handler in _transcriptHandlers.ToArray())
        {
            RunTranscriptHandler(handler, transcript, token);
        }
    }

    private void RunTranscriptHandler(
        Func<IReadOnlyList<ConversationMessage>, CancellationToken, SpeechEngineSession, Task> handler,
        IReadOnlyList<ConversationMessage> transcript,
        CancellationToken token
    )
    {
        Task task;
        try
        {
            task = handler(transcript, token, this);
        }
        catch (Exception e)
        {
            if (!IsCancellation(e))
            {
                EmitError(e);
            }
            return;
        }

        task.ContinueWith(
            t =>
            {
                var ex = t.Exception?.GetBaseException();
                if (ex != null && !IsCancellation(ex))
                {
                    EmitError(ex);
                }
            },
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default
        );
    }

    private void SendAgentResponse(string content, bool isFinal, long? eventId)
    {
        SendJson(
            new JsonObject
            {
                ["type"] = "agent_response",
                ["content"] = content,
                ["event_id"] = eventId.HasValue ? JsonValue.Create(eventId.Value) : null,
                ["is_final"] = isFinal,
            }
        );
    }

    private void SendJson(JsonObject msg)
    {
        if (_closed)
        {
            return;
        }
        try
        {
            _send(msg.ToJsonString());
        }
        catch (Exception)
        {
            // Send failed — the connection is gone; the server loop detects it.
        }
    }

    private void AbortCurrent()
    {
        if (_currentCts != null)
        {
            try
            {
                _currentCts.Cancel();
            }
            catch (ObjectDisposedException) { }
            _currentCts.Dispose();
            _currentCts = null;
        }
    }

    private void EmitError(Exception error)
    {
        if (_errorHandlers.Count == 0)
        {
            return;
        }
        foreach (var h in _errorHandlers.ToArray())
        {
            try
            {
                h(error, this);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("[SpeechEngine] unhandled error in error handler: " + e.Message);
            }
        }
    }

    private void Guarded(string eventName, Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            if (eventName != "error")
            {
                EmitError(e);
            }
        }
    }

    private static bool IsCancellation(Exception e) =>
        e is OperationCanceledException
        || (e is AggregateException agg && agg.InnerException is OperationCanceledException);

    private static string? GetString(JsonObject obj, string key) =>
        obj.TryGetPropertyValue(key, out var node) && node is JsonValue v && v.TryGetValue<string>(out var s)
            ? s
            : null;

    private static long? GetInt64(JsonObject obj, string key) =>
        obj.TryGetPropertyValue(key, out var node) && node is JsonValue v && v.TryGetValue<long>(out var l)
            ? l
            : (long?)null;

    /// <summary>
    /// Extract text from one LLM stream chunk. Handles plain strings and the common streaming shapes:
    /// OpenAI Responses (<c>response.output_text.delta</c>), OpenAI Chat Completions
    /// (<c>choices[0].delta.content</c>), Anthropic (<c>content_block_delta</c> / <c>text_delta</c>),
    /// and Google Gemini (text parts of <c>candidates[0].content.parts</c>).
    /// </summary>
    internal static string? ExtractText(object? chunk)
    {
        if (chunk is string s)
        {
            return s;
        }
        if (chunk == null)
        {
            return null;
        }

        JsonObject? obj;
        try
        {
            JsonNode? node = chunk switch
            {
                JsonObject o => o,
                JsonNode n => n,
                JsonElement e => JsonSerializer.SerializeToNode(e),
                _ => JsonSerializer.SerializeToNode(chunk),
            };
            obj = node as JsonObject;
        }
        catch (Exception)
        {
            return null;
        }
        if (obj == null)
        {
            return null;
        }

        // OpenAI Responses API
        if (GetString(obj, "type") == "response.output_text.delta" && GetString(obj, "delta") is { } delta)
        {
            return delta;
        }

        // OpenAI Chat Completions API
        if (
            obj.TryGetPropertyValue("choices", out var choices)
            && choices is JsonArray { Count: > 0 } choiceArr
            && choiceArr[0] is JsonObject choice0
            && choice0.TryGetPropertyValue("delta", out var deltaNode)
            && deltaNode is JsonObject deltaObj
            && GetString(deltaObj, "content") is { } content
        )
        {
            return content;
        }

        // Anthropic Messages API
        if (
            GetString(obj, "type") == "content_block_delta"
            && obj.TryGetPropertyValue("delta", out var aDelta)
            && aDelta is JsonObject aDeltaObj
            && GetString(aDeltaObj, "type") == "text_delta"
            && GetString(aDeltaObj, "text") is { } aText
        )
        {
            return aText;
        }

        // Google Gemini API
        if (
            obj.TryGetPropertyValue("candidates", out var candidates)
            && candidates is JsonArray { Count: > 0 } candArr
            && candArr[0] is JsonObject cand0
            && cand0.TryGetPropertyValue("content", out var gContent)
            && gContent is JsonObject gContentObj
            && gContentObj.TryGetPropertyValue("parts", out var parts)
            && parts is JsonArray partsArr
        )
        {
            var sb = new System.Text.StringBuilder();
            foreach (var part in partsArr)
            {
                if (
                    part is JsonObject partObj
                    && !(
                        partObj.TryGetPropertyValue("thought", out var thought)
                        && thought is JsonValue tv
                        && tv.TryGetValue<bool>(out var tb)
                        && tb
                    )
                    && GetString(partObj, "text") is { } partText
                )
                {
                    sb.Append(partText);
                }
            }
            if (sb.Length > 0)
            {
                return sb.ToString();
            }
        }

        return null;
    }
}
