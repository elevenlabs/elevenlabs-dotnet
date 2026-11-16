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
        var message = new StringBuilder();
        try
        {
            while (socket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
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

                message.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                if (!result.EndOfMessage)
                {
                    continue;
                }

                var raw = message.ToString();
                message.Clear();
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    session.HandleRawMessage(raw);
                }
            }
        }
        finally
        {
            session.HandleDisconnect();
            sendGate.Dispose();
        }
    }
}
#endif
