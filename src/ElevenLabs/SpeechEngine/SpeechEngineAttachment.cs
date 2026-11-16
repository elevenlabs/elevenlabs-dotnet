#if NET8_0_OR_GREATER
using System;
using System.Threading;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// Returned by <see cref="SpeechEngineResource.Attach"/>. Call <see cref="Close"/> to stop accepting
/// new connections and cancel in-flight sessions without affecting the host ASP.NET Core application.
/// </summary>
public sealed class SpeechEngineAttachment : IDisposable
{
    private readonly CancellationTokenSource _cts;

    internal SpeechEngineAttachment(CancellationTokenSource cts)
    {
        _cts = cts;
    }

    /// <summary>Whether this attachment has been closed.</summary>
    public bool IsClosed => _cts.IsCancellationRequested;

    /// <summary>
    /// Stop accepting new connections and cancel active sessions. The middleware stays registered on
    /// the host pipeline (ASP.NET Core cannot unregister middleware) but short-circuits to the next
    /// handler once closed.
    /// </summary>
    public void Close()
    {
        try
        {
            _cts.Cancel();
        }
        catch (ObjectDisposedException) { }
    }

    /// <inheritdoc />
    public void Dispose() => Close();
}
#endif
