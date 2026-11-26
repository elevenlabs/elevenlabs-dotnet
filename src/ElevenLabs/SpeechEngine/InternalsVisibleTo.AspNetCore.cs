// Hand-written (listed in .fernignore). The companion package ElevenLabs.AspNetCore reuses the
// internal SpeechEngineWebSocketRunner and SpeechEngineCallbacks.WireTo. The attribute lives here, not
// in the generated ElevenLabs.csproj, because regeneration rewrites the csproj and dropped it once.
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ElevenLabs.AspNetCore")]
