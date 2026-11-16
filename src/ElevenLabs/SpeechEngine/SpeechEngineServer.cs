#if NET8_0_OR_GREATER
using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// Standalone WebSocket server that produces a <see cref="SpeechEngineSession"/> for each inbound
/// connection from the ElevenLabs Speech Engine API.
/// </summary>
/// <remarks>
/// <para>
/// Every connection is verified against the API key (the
/// <c>X-ElevenLabs-Speech-Engine-Authorization</c> JWT) before its session is wired up, unless
/// <see cref="SpeechEngineCallbacks.DisableAuth"/> is set. Built on <see cref="HttpListener"/>, so it
/// owns its own loop — call <see cref="StartAsync"/> from a worker or long-running process.
/// </para>
/// <para>
/// To integrate with an existing ASP.NET Core application instead, use
/// <see cref="SpeechEngineResource.Attach"/>.
/// </para>
/// <para>Hand-written (see <c>.fernignore</c>), mirroring <c>SpeechEngineServer</c> in the other SDKs.</para>
/// </remarks>
public sealed class SpeechEngineServer
{
    private readonly int _port;
    private readonly string? _path;
    private readonly string? _apiKey;
    private readonly SpeechEngineCallbacks _callbacks;
    private readonly Action<string> _log;

    private HttpListener? _listener;
    private CancellationTokenSource? _cts;

    /// <param name="port">Port to listen on. Defaults to 3001.</param>
    /// <param name="path">Optional path to accept connections on; any path when omitted.</param>
    /// <param name="apiKey">
    /// The account API key. Falls back to the <c>ELEVENLABS_API_KEY</c> environment variable.
    /// </param>
    /// <param name="callbacks">Event handlers wired onto each session.</param>
    public SpeechEngineServer(
        int port = 3001,
        string? path = null,
        string? apiKey = null,
        SpeechEngineCallbacks? callbacks = null
    )
    {
        _port = port;
        _path = path;
        _apiKey = apiKey;
        _callbacks = callbacks ?? new SpeechEngineCallbacks();
        _log = _callbacks.Debug
            ? m => Console.Error.WriteLine("[SpeechEngine] " + m)
            : _ => { };
    }

    /// <summary>
    /// Start the server. Completes when <paramref name="cancellationToken"/> fires or
    /// <see cref="Stop"/> is called.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// If no API key is available and authentication is not disabled.
    /// </exception>
    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        var apiKey = string.IsNullOrEmpty(_apiKey)
            ? Environment.GetEnvironmentVariable("ELEVENLABS_API_KEY")
            : _apiKey;
        if (string.IsNullOrEmpty(apiKey) && !_callbacks.DisableAuth)
        {
            throw new InvalidOperationException(
                "SpeechEngineServer requires an API key to verify incoming connections. Pass apiKey: "
                    + "or set the ELEVENLABS_API_KEY environment variable. To run without "
                    + "authentication, pass DisableAuth = true — but only behind an IP allowlist."
            );
        }
        if (_callbacks.DisableAuth)
        {
            Console.Error.WriteLine(
                "[SpeechEngine] authentication is disabled — incoming connections will NOT be verified. "
                    + "Make sure the server is protected by an IP allowlist restricting traffic to ElevenLabs."
            );
        }

        var listener = new HttpListener();
        listener.Prefixes.Add($"http://+:{_port}/");
        _listener = listener;
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        try
        {
            listener.Start();
        }
        catch (HttpListenerException e)
        {
            throw new InvalidOperationException(
                $"Could not bind the Speech Engine server to port {_port}. On Windows, binding "
                    + "http://+ may require an administrator or a netsh URL ACL reservation.",
                e
            );
        }

        _log($"speech engine server listening on port {_port}");

        try
        {
            while (!_cts.IsCancellationRequested)
            {
                HttpListenerContext context;
                try
                {
                    context = await listener.GetContextAsync().ConfigureAwait(false);
                }
                catch (Exception) when (_cts.IsCancellationRequested)
                {
                    break;
                }
                catch (HttpListenerException)
                {
                    break;
                }

                _ = HandleContextAsync(context, apiKey, _cts.Token);
            }
        }
        finally
        {
            Stop();
        }
    }

    /// <summary>Stop accepting connections and shut the listener down.</summary>
    public void Stop()
    {
        try
        {
            _cts?.Cancel();
        }
        catch (ObjectDisposedException) { }

        if (_listener != null)
        {
            try
            {
                _listener.Close();
            }
            catch (Exception)
            {
                // Already closed.
            }
            _listener = null;
        }
    }

    private async Task HandleContextAsync(
        HttpListenerContext context,
        string? apiKey,
        CancellationToken cancellationToken
    )
    {
        if (_path != null && context.Request.Url?.AbsolutePath != _path)
        {
            _log(
                $"rejected connection — path mismatch: expected {_path}, got {context.Request.Url?.AbsolutePath}"
            );
            Reject(context, 404);
            return;
        }

        if (!context.Request.IsWebSocketRequest)
        {
            Reject(context, 400);
            return;
        }

        if (!_callbacks.DisableAuth)
        {
            var header = context.Request.Headers["X-ElevenLabs-Speech-Engine-Authorization"];
            if (string.IsNullOrEmpty(header))
            {
                _log("rejected connection — missing X-ElevenLabs-Speech-Engine-Authorization header");
                Reject(context, 401);
                return;
            }
            try
            {
                SpeechEngineJwtVerifier.Verify(header!, apiKey!);
            }
            catch (Exception e)
            {
                _log("rejected connection — " + e.Message);
                Reject(context, 401);
                return;
            }
        }

        HttpListenerWebSocketContext wsContext;
        try
        {
            wsContext = await context.AcceptWebSocketAsync(subProtocol: null).ConfigureAwait(false);
        }
        catch (Exception)
        {
            Reject(context, 400);
            return;
        }

        _log("verified connection, creating session");
        await SpeechEngineWebSocketRunner
            .RunAsync(wsContext.WebSocket, _callbacks.WireTo, _callbacks.Debug, cancellationToken)
            .ConfigureAwait(false);
    }

    private static void Reject(HttpListenerContext context, int statusCode)
    {
        try
        {
            context.Response.StatusCode = statusCode;
            context.Response.Close();
        }
        catch (Exception)
        {
            // Connection already torn down.
        }
    }
}
#endif
