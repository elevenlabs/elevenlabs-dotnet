using System;
using System.Collections.Generic;
#if NET8_0_OR_GREATER
using System.Threading;
using System.Threading.Tasks;
#endif

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// A handle to a Speech Engine instance, returned by <c>speechEngine.Create()</c> /
/// <c>speechEngine.Get()</c> once the root client is wired to return it.
/// </summary>
/// <remarks>
/// <para>
/// Use <see cref="ServeAsync"/> to run a standalone WebSocket server for this engine, the
/// <c>Attach</c> extension in the <c>elevenlabs-dotnet-aspnetcore</c> package to add it to an
/// existing ASP.NET Core application, or
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

    // The ASP.NET Core attach helper (Attach / VerifyRequest(HttpRequest)) lives in the companion
    // package elevenlabs-dotnet-aspnetcore as extension methods, so this core package carries no
    // dependency on the ASP.NET Core shared framework.
#endif
}
