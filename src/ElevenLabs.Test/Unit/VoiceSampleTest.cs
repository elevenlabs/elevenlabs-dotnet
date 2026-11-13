using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.VoiceSample</c>.
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
public class VoiceSampleTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"sample_id\":\"sample_id\",\"file_name\":\"file_name\",\"mime_type\":\"mime_type\",\"size_bytes\":7,\"hash\":\"hash\",\"duration_secs\":7.95,\"remove_background_noise\":false,\"has_isolated_audio\":false,\"has_isolated_audio_preview\":true,\"speaker_separation\":{\"voice_id\":\"voice_id\",\"sample_id\":\"sample_id\",\"status\":\"not_started\",\"speakers\":{\"key\":{\"speaker_id\":\"speaker_id\",\"duration_secs\":3.23,\"utterances\":[{\"start\":5.34,\"end\":6.51}]}},\"selected_speaker_ids\":[\"selected_speaker_ids\"]},\"trim_start\":10,\"trim_end\":4}";

        var instance = TestJson.Deserialize<global::ElevenLabs.VoiceSample>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.VoiceSample did not round-trip."
        );
    }
}
