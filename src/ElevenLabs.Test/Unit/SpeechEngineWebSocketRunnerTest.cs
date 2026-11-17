using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElevenLabs.SpeechEngine;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for <c>SpeechEngineWebSocketRunner</c>: UTF-8 messages are decoded once per complete
/// message (so a character split across receives is not corrupted), and every exit completes the
/// close handshake and disposes the socket.
/// </summary>
[TestFixture]
public class SpeechEngineWebSocketRunnerTest
{
    [Test]
    public async Task MultibyteCharacterSplitAcrossReceivesIsNotCorrupted()
    {
        // "café" — 'é' is two UTF-8 bytes (0xC3 0xA9). Split the frame between them.
        var json =
            "{\"type\":\"user_transcript\",\"event_id\":1,\"user_transcript\":[{\"role\":\"user\",\"content\":\"café\"}]}";
        var bytes = Encoding.UTF8.GetBytes(json);
        var splitAt = Array.IndexOf(bytes, (byte)0xC3) + 1; // between the two bytes of 'é'
        var part1 = bytes[..splitAt];
        var part2 = bytes[splitAt..];

        var socket = new FakeWebSocket(
            new[]
            {
                (part1, false, WebSocketMessageType.Text),
                (part2, true, WebSocketMessageType.Text),
            }
        );

        string? content = null;
        await SpeechEngineWebSocketRunner.RunAsync(
            socket,
            session =>
                session.OnTranscript(
                    (transcript, token, s) =>
                    {
                        content = transcript[0].Content;
                        return Task.CompletedTask;
                    }
                ),
            debug: false,
            CancellationToken.None
        );

        Assert.That(content, Is.EqualTo("café"));
    }

    [Test]
    public async Task CompletesCloseHandshakeAndDisposesOnExit()
    {
        // No frames: the fake reports a peer-initiated close, which should end the run.
        var socket = new FakeWebSocket(Array.Empty<(byte[], bool, WebSocketMessageType)>());

        await SpeechEngineWebSocketRunner.RunAsync(
            socket,
            _ => { },
            debug: false,
            CancellationToken.None
        );

        Assert.That(socket.CloseOutputCalled, Is.True, "the close-output handshake must complete");
        Assert.That(socket.Disposed, Is.True, "the socket must be disposed on exit");
    }

    /// <summary>A minimal <see cref="WebSocket"/> that replays queued inbound frames then a close,
    /// and records the outbound close handshake and disposal.</summary>
    private sealed class FakeWebSocket : WebSocket
    {
        private readonly Queue<(byte[] bytes, bool end, WebSocketMessageType type)> _frames;
        private WebSocketState _state = WebSocketState.Open;

        public bool CloseOutputCalled { get; private set; }
        public bool Disposed { get; private set; }

        public FakeWebSocket(IEnumerable<(byte[], bool, WebSocketMessageType)> frames)
        {
            _frames = new Queue<(byte[], bool, WebSocketMessageType)>(frames);
        }

        public override WebSocketState State => _state;
        public override WebSocketCloseStatus? CloseStatus => null;
        public override string? CloseStatusDescription => null;
        public override string? SubProtocol => null;

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken
        )
        {
            if (_frames.Count == 0)
            {
                _state = WebSocketState.CloseReceived;
                return Task.FromResult(
                    new WebSocketReceiveResult(0, WebSocketMessageType.Close, true)
                );
            }
            var (bytes, end, type) = _frames.Dequeue();
            Array.Copy(bytes, 0, buffer.Array!, buffer.Offset, bytes.Length);
            return Task.FromResult(new WebSocketReceiveResult(bytes.Length, type, end));
        }

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken
        ) => Task.CompletedTask;

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken
        )
        {
            CloseOutputCalled = true;
            _state = WebSocketState.Closed;
            return Task.CompletedTask;
        }

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken
        )
        {
            _state = WebSocketState.Closed;
            return Task.CompletedTask;
        }

        public override void Abort() => _state = WebSocketState.Aborted;

        public override void Dispose() => Disposed = true;
    }
}
