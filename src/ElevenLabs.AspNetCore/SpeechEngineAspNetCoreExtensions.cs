using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// ASP.NET Core integration for <see cref="SpeechEngineResource"/>, shipped in the
/// <c>elevenlabs-dotnet-aspnetcore</c> package. These are extension methods rather than members of
/// the core type so that the core <c>elevenlabs-dotnet-sdk</c> package carries no dependency on the
/// ASP.NET Core shared framework. The call sites are unchanged — <c>resource.Attach(app, path,
/// callbacks)</c> and <c>resource.VerifyRequest(httpRequest)</c> still work once this package is
/// referenced and <c>ElevenLabs.SpeechEngine</c> is in scope.
/// </summary>
public static class SpeechEngineAspNetCoreExtensions
{
    private const string AuthHeader = "X-ElevenLabs-Speech-Engine-Authorization";

    /// <summary>
    /// Verify an incoming ASP.NET Core request. Returns <c>false</c> (never throws) when the API key
    /// is missing, the header is absent, or the token is invalid.
    /// </summary>
    public static bool VerifyRequest(this SpeechEngineResource resource, HttpRequest request)
    {
        if (resource == null)
        {
            throw new ArgumentNullException(nameof(resource));
        }
        return resource.VerifyRequestHeader(request?.Headers[AuthHeader].ToString());
    }

    /// <summary>
    /// Attach to an existing ASP.NET Core application and begin accepting Speech Engine connections at
    /// <paramref name="path"/>. Enables WebSockets, routes the path, and verifies each request's JWT.
    /// Returns a <see cref="SpeechEngineAttachment"/> whose <see cref="SpeechEngineAttachment.Close"/>
    /// stops accepting connections without affecting the host application.
    /// </summary>
    public static SpeechEngineAttachment Attach(
        this SpeechEngineResource resource,
        IApplicationBuilder app,
        string path,
        SpeechEngineCallbacks callbacks
    )
    {
        if (resource == null)
        {
            throw new ArgumentNullException(nameof(resource));
        }
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
                if (!callbacks.DisableAuth && !resource.VerifyRequest(context.Request))
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
}
