using System;
using System.Collections.Generic;
#if NET8_0_OR_GREATER
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
#endif

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// A handle to a Speech Engine instance, returned by <c>speechEngine.Create()</c> /
/// <c>speechEngine.Get()</c> once the root client is wired to return it.
/// </summary>
/// <remarks>
/// <para>
/// Use <see cref="ServeAsync"/> to run a standalone WebSocket server for this engine,
/// <see cref="Attach"/> to add it to an existing ASP.NET Core application, or
/// <see cref="VerifyRequest(System.Collections.Generic.IReadOnlyDictionary{string,string})"/> plus
/// <see cref="CreateSession"/> to drive a connection you manage yourself.
/// </para>
/// <para>Hand-written (see <c>.fernignore</c>), mirroring <c>SpeechEngineResource</c> in the other SDKs.</para>
/// </remarks>
public sealed class SpeechEngineResource
{
    private const string AuthHeader = "X-ElevenLabs-Speech-Engine-Authorization";

    private readonly string? _apiKey;

    /// <param name="engineId">The speech engine ID.</param>
    /// <param name="apiKey">The account API key used to verify inbound connections.</param>
    /// <param name="config">The full API response, or <c>null</c> when constructed without an API call.</param>
    public SpeechEngineResource(
        string engineId,
        string? apiKey = null,
        SpeechEngineResponse? config = null
    )
    {
        EngineId = engineId;
        _apiKey = apiKey;
        Config = config;
    }

    /// <summary>The speech engine ID.</summary>
    public string EngineId { get; }

    /// <summary>The full API response, or <c>null</c> when constructed without an API call.</summary>
    public SpeechEngineResponse? Config { get; }

    /// <summary>
    /// Verify that an incoming request carries a valid Speech Engine authorization JWT. The header
    /// name is matched case-insensitively. Returns <c>false</c> (never throws) when the key is
    /// missing, the header is absent, or the token is invalid.
    /// </summary>
    public bool VerifyRequest(IReadOnlyDictionary<string, string> headers)
    {
        if (headers == null)
        {
            return false;
        }
        foreach (var pair in headers)
        {
            if (string.Equals(pair.Key, AuthHeader, StringComparison.OrdinalIgnoreCase))
            {
                return VerifyRequestHeader(pair.Value);
            }
        }
        return false;
    }

    /// <summary>
    /// Verify an <c>X-ElevenLabs-Speech-Engine-Authorization</c> header value directly. Returns
    /// <c>false</c> (never throws) when the key is missing, the value is empty, or the token is invalid.
    /// </summary>
    public bool VerifyRequestHeader(string? headerValue)
    {
        if (string.IsNullOrEmpty(_apiKey) || string.IsNullOrEmpty(headerValue))
        {
            return false;
        }
        try
        {
            SpeechEngineJwtVerifier.Verify(headerValue!, _apiKey!);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Create a session over a connection you manage yourself (any transport).
    /// </summary>
    /// <param name="send">Writes a text frame to the connection.</param>
    /// <param name="close">Closes the connection.</param>
    /// <param name="debug">Enable debug logging.</param>
    public SpeechEngineSession CreateSession(
        Action<string> send,
        Action? close = null,
        bool debug = false
    ) => new(send, close, debug);

#if NET8_0_OR_GREATER
    /// <summary>
    /// Verify an incoming ASP.NET Core request. Returns <c>false</c> (never throws) when the API key
    /// is missing, the header is absent, or the token is invalid.
    /// </summary>
    public bool VerifyRequest(HttpRequest request) =>
        VerifyRequestHeader(request?.Headers[AuthHeader].ToString());

    /// <summary>
    /// Start a standalone WebSocket server for this engine. Completes when
    /// <paramref name="cancellationToken"/> fires. Verification uses the engine's API key unless
    /// <see cref="SpeechEngineCallbacks.DisableAuth"/> is set.
    /// </summary>
    public Task ServeAsync(
        int port = 3001,
        string? path = null,
        SpeechEngineCallbacks? callbacks = null,
        CancellationToken cancellationToken = default
    ) => new SpeechEngineServer(port, path, _apiKey, callbacks).StartAsync(cancellationToken);

    /// <summary>
    /// Attach to an existing ASP.NET Core application and begin accepting Speech Engine connections at
    /// <paramref name="path"/>. Enables WebSockets, routes the path, and verifies each request's JWT.
    /// Returns a <see cref="SpeechEngineAttachment"/> whose <see cref="SpeechEngineAttachment.Close"/>
    /// stops accepting connections without affecting the host application.
    /// </summary>
    public SpeechEngineAttachment Attach(
        IApplicationBuilder app,
        string path,
        SpeechEngineCallbacks callbacks
    )
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }
        callbacks ??= new SpeechEngineCallbacks();
        var cts = new CancellationTokenSource();
        var attachment = new SpeechEngineAttachment(cts);
        Action<string> log = callbacks.Debug
            ? m => Console.Error.WriteLine("[SpeechEngine] " + m)
            : _ => { };

        if (callbacks.DisableAuth)
        {
            Console.Error.WriteLine(
                "[SpeechEngine] authentication is disabled on Attach() — incoming connections will NOT "
                    + "be verified. Protect the server with an IP allowlist restricting traffic to ElevenLabs."
            );
        }

        app.UseWebSockets();
        app.Use(
            async (context, next) =>
            {
                if (cts.IsCancellationRequested || context.Request.Path != path)
                {
                    await next(context).ConfigureAwait(false);
                    return;
                }
                if (!context.WebSockets.IsWebSocketRequest)
                {
                    await next(context).ConfigureAwait(false);
                    return;
                }
                if (!callbacks.DisableAuth && !VerifyRequest(context.Request))
                {
                    log("rejected connection — failed verification");
                    context.Response.StatusCode = 401;
                    return;
                }

                var socket = await context.WebSockets.AcceptWebSocketAsync().ConfigureAwait(false);
                using var linked = CancellationTokenSource.CreateLinkedTokenSource(
                    cts.Token,
                    context.RequestAborted
                );
                log("creating new session");
                await SpeechEngineWebSocketRunner
                    .RunAsync(socket, callbacks.WireTo, callbacks.Debug, linked.Token)
                    .ConfigureAwait(false);
            }
        );

        log($"listening for WebSocket upgrades on {path}");
        return attachment;
    }
#endif
}
