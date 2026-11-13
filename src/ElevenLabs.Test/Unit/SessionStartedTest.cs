using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SessionStarted</c>.
/// </summary>
/// <remarks>
/// Asserts the wire document the model was built from comes back out of it unchanged — not merely
/// that serialization runs. Starting from JSON rather than from a constructed instance is what
/// makes one emitter cover both output modes: the legacy positional record and the fernMode
/// `required`/`init` record are constructed differently but deserialize from the same document, so
/// nothing here has to know which shape it is looking at. It is also the stronger assertion, since
/// a property whose C# name diverges from its wire name fails this and would pass a test that only
/// compared an instance to itself.
/// </remarks>
[TestFixture]
public class SessionStartedTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"message_type\":\"session_started\",\"session_id\":\"session_id\",\"config\":{\"sample_rate\":6,\"audio_format\":\"pcm_8000\",\"language_code\":\"language_code\",\"secondary_languages\":[\"secondary_languages\"],\"timestamps_granularity\":\"none\",\"vad_commit_strategy\":true,\"vad_silence_threshold_secs\":1.5,\"vad_threshold\":0.4,\"min_speech_duration_ms\":100,\"min_silence_duration_ms\":100,\"max_tokens_to_recompute\":5,\"model_id\":\"scribe_v2_realtime\",\"disable_logging\":true,\"include_timestamps\":true,\"include_language_detection\":true,\"filter_background_audio\":false,\"keyterms\":[\"keyterms\"],\"no_verbatim\":false,\"entity_detection\":[\"entity_detection\"],\"entity_redaction\":[\"entity_redaction\"],\"entity_redaction_mode\":\"enumerated_entity_type\",\"keepalive_interval_ms\":9}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.SessionStarted>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SessionStarted did not round-trip."
        );
    }
}
