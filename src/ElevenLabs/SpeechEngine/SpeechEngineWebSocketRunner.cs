#if NET8_0_OR_GREATER
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// Drives a single accepted <see cref="WebSocket"/> as a <see cref="SpeechEngineSession"/>: wires the
/// caller's handlers, pumps inbound text frames into the session, and serialises outbound sends.
/// Shared by the standalone <see cref="SpeechEngineServer"/> and the ASP.NET Core attach helper.
/// </summary>
/// <remarks>
/// Server-side WebSocket hosting targets net8.0+; the transport-agnostic
/// <see cref="SpeechEngineSession"/>, <see cref="SpeechEngineJwtVerifier"/> and
/// <see cref="SpeechEngineResource.CreateSession"/> remain available on every target framework.
/// </remarks>
internal static class SpeechEngineWebSocketRunner
{
    public static async Task RunAsync(
        WebSocket socket,
        Action<SpeechEngineSession> configure,
        bool debug,
        CancellationToken cancellationToken
    )
    {
        // WebSocket.SendAsync must not run concurrently, and the session may send from several
        // async handlers at once, so every frame goes out under this gate.
        var sendGate = new SemaphoreSlim(1, 1);

        void Send(string text)
        {
            sendGate.Wait(cancellationToken);
            try
            {
                socket
                    .SendAsync(
                        new ArraySegment<byte>(Encoding.UTF8.GetBytes(text)),
                        WebSocketMessageType.Text,
                        endOfMessage: true,
                        cancellationToken
                    )
                    .GetAwaiter()
                    .GetResult();
            }
            finally
            {
                sendGate.Release();
            }
        }

        void Close()
        {
            try
            {
                socket
                    .CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception)
            {
                // Already gone — nothing to close.
            }
        }

        var session = new SpeechEngineSession(Send, Close, debug);
        configure(session);

        var buffer = new byte[8192];
        // Accumulate raw bytes and decode once per complete message: a multi-byte UTF-8 character can
        // straddle two receives (including at the 8 KiB buffer boundary), and decoding each receive
        // on its own would turn the split bytes into replacement characters.
        using var messageBytes = new MemoryStream();
        try
        {
            while (
                socket.State == WebSocketState.Open
                && !cancellationToken.IsCancellationRequested
                && session.IsOpen
            )
            {
                WebSocketReceiveResult result;
                try
                {
                    result = await socket
                        .ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception)
                {
                    break;
                }

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    break;
                }

                messageBytes.Write(buffer, 0, result.Count);
                if (!result.EndOfMessage)
                {
                    continue;
                }

                var raw = Encoding.UTF8.GetString(messageBytes.ToArray());
                messageBytes.SetLength(0);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    session.HandleRawMessage(raw);
                }
            }
        }
        finally
        {
            session.HandleDisconnect();
            // Complete the close-output handshake and release the socket on every exit — a
            // peer-initiated close, a disconnect, or cancellation — so the peer is not left waiting
            // and the connection's resources are deterministically freed.
            await CompleteCloseHandshakeAsync(socket, sendGate).ConfigureAwait(false);
            socket.Dispose();
            sendGate.Dispose();
        }
    }

    private static async Task CompleteCloseHandshakeAsync(WebSocket socket, SemaphoreSlim sendGate)
    {
        if (socket.State != WebSocketState.Open && socket.State != WebSocketState.CloseReceived)
        {
            return;
        }
        // Bound the whole handshake, including acquiring the gate: an outbound send blocked by
        // backpressure to a dead peer holds the gate, so without a deadline on the WaitAsync the
        // cleanup would never reach CloseOutputAsync or the caller's socket.Dispose().
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        try
        {
            await sendGate.WaitAsync(timeout.Token).ConfigureAwait(false);
        }
        catch (Exception)
        {
            // Timed out waiting for the gate (or it was disposed): let the caller dispose the socket,
            // which aborts the blocked send.
            return;
        }
        try
        {
            await socket
                .CloseOutputAsync(WebSocketCloseStatus.NormalClosure, string.Empty, timeout.Token)
                .ConfigureAwait(false);
        }
        catch (Exception)
        {
            // Peer already gone — nothing to hand-shake.
        }
        finally
        {
            sendGate.Release();
        }
    }
}
#endif
