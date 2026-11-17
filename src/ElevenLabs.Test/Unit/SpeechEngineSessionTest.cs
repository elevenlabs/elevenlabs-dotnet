using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ElevenLabs.SpeechEngine;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for <c>global::ElevenLabs.SpeechEngine.SpeechEngineSession</c>, mirroring the shared
/// cross-SDK suite: protocol parsing, ping/pong, string and streamed responses with LLM-chunk text
/// extraction, and lifecycle events.
/// </summary>
[TestFixture]
public class SpeechEngineSessionTest
{
    private List<string> _sent = new();
    private bool _closed;

    private SpeechEngineSession Session()
    {
        _sent = new List<string>();
        _closed = false;
        return new SpeechEngineSession(text => _sent.Add(text), () => _closed = true);
    }

    private List<JsonObject> DecodedSent() =>
        _sent.Select(s => (JsonObject)JsonNode.Parse(s)!).ToList();

    [Test]
    public void InitSetsConversationIdAndEmits()
    {
        var session = Session();
        string? seen = null;
        session.OnInit((id, s) => seen = id);

        session.HandleRawMessage("{\"type\":\"init\",\"conversation_id\":\"conv_1\"}");

        Assert.That(seen, Is.EqualTo("conv_1"));
        Assert.That(session.ConversationId, Is.EqualTo("conv_1"));
    }

    [Test]
    public void PingReceivesPong()
    {
        var session = Session();
        session.HandleRawMessage("{\"type\":\"ping\"}");
        var sent = DecodedSent();
        Assert.That(sent, Has.Count.EqualTo(1));
        Assert.That(sent[0]["type"]!.GetValue<string>(), Is.EqualTo("pong"));
    }

    [Test]
    public void TranscriptDeliversMessagesAndStringResponse()
    {
        var session = Session();
        IReadOnlyList<ConversationMessage>? received = null;
        session.OnTranscript(
            (transcript, token, s) =>
            {
                received = transcript;
                s.SendResponse("hello there");
                return Task.CompletedTask;
            }
        );

        session.HandleRawMessage(
            "{\"type\":\"user_transcript\",\"event_id\":7,\"user_transcript\":[{\"role\":\"user\",\"content\":\"hi\"}]}"
        );

        Assert.That(received, Is.Not.Null);
        Assert.That(received!, Has.Count.EqualTo(1));
        Assert.That(received![0].Role, Is.EqualTo("user"));
        Assert.That(received![0].Content, Is.EqualTo("hi"));

        var sent = DecodedSent();
        Assert.That(sent, Has.Count.EqualTo(2));
        Assert.That(sent[0]["content"]!.GetValue<string>(), Is.EqualTo("hello there"));
        Assert.That(sent[0]["event_id"]!.GetValue<long>(), Is.EqualTo(7L));
        Assert.That(sent[0]["is_final"]!.GetValue<bool>(), Is.False);
        Assert.That(sent[1]["content"]!.GetValue<string>(), Is.EqualTo(""));
        Assert.That(sent[1]["is_final"]!.GetValue<bool>(), Is.True);
    }

    [Test]
    public void StreamedResponseSendsChunksThenFinal()
    {
        var session = Session();
        session.OnTranscript(
            (t, token, s) =>
            {
                s.SendResponse(new object?[] { "foo", "", "bar" }); // empty chunk is skipped
                return Task.CompletedTask;
            }
        );

        session.HandleRawMessage(
            "{\"type\":\"user_transcript\",\"event_id\":3,\"user_transcript\":[]}"
        );

        var contents = DecodedSent().Select(m => m["content"]!.GetValue<string>()).ToList();
        Assert.That(contents, Is.EqualTo(new[] { "foo", "bar", "" }));
    }

    [Test]
    public void StreamedResponseExtractsOpenAiChatChunks()
    {
        var session = Session();
        session.OnTranscript(
            (t, token, s) =>
            {
                s.SendResponse(
                    new object?[]
                    {
                        new { choices = new[] { new { delta = new { content = "Hel" } } } },
                        new { choices = new[] { new { delta = new { content = "lo" } } } },
                    }
                );
                return Task.CompletedTask;
            }
        );

        session.HandleRawMessage(
            "{\"type\":\"user_transcript\",\"event_id\":1,\"user_transcript\":[]}"
        );

        var contents = DecodedSent().Select(m => m["content"]!.GetValue<string>()).ToList();
        Assert.That(contents, Is.EqualTo(new[] { "Hel", "lo", "" }));
    }

    [Test]
    public void SendResponseOutsideHandlerIsSuppressed()
    {
        var session = Session();
        session.SendResponse("nope");
        Assert.That(_sent, Is.Empty);
    }

    [Test]
    public void SendResponseAfterHandlerCompletesIsSuppressed()
    {
        var session = Session();
        session.OnTranscript((t, token, s) => Task.CompletedTask); // completes without sending

        session.HandleRawMessage(
            "{\"type\":\"user_transcript\",\"event_id\":1,\"user_transcript\":[]}"
        );
        _sent.Clear();

        // The send permission must end with the handler, not linger as a field.
        session.SendResponse("late");
        Assert.That(_sent, Is.Empty);
    }

    [Test]
    public async Task ResponseKeepsItsOwnTurnsEventIdAfterANewerTranscript()
    {
        var session = Session();
        var firstStarted = new TaskCompletionSource<bool>(
            TaskCreationOptions.RunContinuationsAsynchronously
        );
        var release = new TaskCompletionSource<bool>(
            TaskCreationOptions.RunContinuationsAsynchronously
        );
        var firstDone = new TaskCompletionSource<bool>(
            TaskCreationOptions.RunContinuationsAsynchronously
        );

        session.OnTranscript(
            async (t, token, s) =>
            {
                if (t.Count > 0 && t[0].Content == "first")
                {
                    firstStarted.SetResult(true);
                    await release.Task;
                    s.SendResponse("reply"); // must carry turn 1's event_id
                    firstDone.SetResult(true);
                }
            }
        );

        session.HandleRawMessage(
            "{\"type\":\"user_transcript\",\"event_id\":1,\"user_transcript\":[{\"role\":\"user\",\"content\":\"first\"}]}"
        );
        await firstStarted.Task;

        // A newer transcript (event_id 2) arrives while turn 1 is still awaiting.
        session.HandleRawMessage(
            "{\"type\":\"user_transcript\",\"event_id\":2,\"user_transcript\":[{\"role\":\"user\",\"content\":\"second\"}]}"
        );

        release.SetResult(true);
        await firstDone.Task;

        var reply = DecodedSent().First(m => m["content"]!.GetValue<string>() == "reply");
        Assert.That(reply["event_id"]!.GetValue<long>(), Is.EqualTo(1L));
    }

    [Test]
    public void TranscriptAfterCloseStartsNoHandler()
    {
        var session = Session();
        var invoked = false;
        session.OnTranscript(
            (t, token, s) =>
            {
                invoked = true;
                return Task.CompletedTask;
            }
        );

        session.Close();
        session.HandleRawMessage(
            "{\"type\":\"user_transcript\",\"event_id\":1,\"user_transcript\":[]}"
        );

        Assert.That(invoked, Is.False, "a transcript must not start a handler on a closed session");
    }

    [Test]
    public void CloseMessageEmitsCloseAndClosesSession()
    {
        var session = Session();
        var closedEvent = false;
        session.OnClose(s => closedEvent = true);

        session.HandleRawMessage("{\"type\":\"close\"}");

        Assert.That(closedEvent, Is.True);
        Assert.That(session.IsOpen, Is.False);
    }

    [Test]
    public void ErrorMessageEmitsError()
    {
        var session = Session();
        System.Exception? err = null;
        session.OnError((e, s) => err = e);

        session.HandleRawMessage("{\"type\":\"error\",\"message\":\"boom\"}");

        Assert.That(err, Is.Not.Null);
        Assert.That(err!.Message, Is.EqualTo("boom"));
    }

    [Test]
    public void MalformedJsonEmitsError()
    {
        var session = Session();
        System.Exception? err = null;
        session.OnError((e, s) => err = e);

        session.HandleRawMessage("{not json");

        Assert.That(err, Is.Not.Null);
    }

    [Test]
    public void CloseInvokesCloseCallback()
    {
        var session = Session();
        Assert.That(session.IsOpen, Is.True);

        session.Close();

        Assert.That(_closed, Is.True);
        Assert.That(session.IsOpen, Is.False);
    }

    [Test]
    public void TransportDisconnectEmitsDisconnectedOnce()
    {
        var session = Session();
        var count = 0;
        session.OnDisconnected(s => count++);

        session.HandleDisconnect();
        session.HandleDisconnect();

        Assert.That(count, Is.EqualTo(1));
        Assert.That(session.IsOpen, Is.False);
    }
}
