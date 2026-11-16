using System.Threading.Tasks;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// Wires a <see cref="SpeechEngineCallbacks"/> option object onto a <see cref="SpeechEngineSession"/>,
/// shared by the standalone server, the ASP.NET Core attach helper, and the resource's serve path.
/// </summary>
internal static class SpeechEngineCallbacksWiring
{
    public static void WireTo(this SpeechEngineCallbacks callbacks, SpeechEngineSession session)
    {
        if (callbacks.OnInit is { } onInit)
        {
            session.OnInit((id, s) => onInit(id, s));
        }
        if (callbacks.OnTranscript is { } onTranscript)
        {
            session.OnTranscript((transcript, token, s) => onTranscript(transcript, token, s));
        }
        if (callbacks.OnClose is { } onClose)
        {
            session.OnClose(s => onClose(s));
        }
        if (callbacks.OnDisconnect is { } onDisconnect)
        {
            session.OnDisconnected(s => onDisconnect(s));
        }
        if (callbacks.OnError is { } onError)
        {
            session.OnError((err, s) => onError(err, s));
        }
    }
}
