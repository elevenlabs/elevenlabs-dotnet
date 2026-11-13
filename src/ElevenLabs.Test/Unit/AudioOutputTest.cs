using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AudioOutput</c>.
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
public class AudioOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"audio\":\"audio\",\"is_final\":true,\"normalized_alignment\":{\"chars\":[\"chars\"],\"char_start_times_ms\":[5],\"char_durations_ms\":[2]},\"alignment\":{\"chars\":[\"chars\"],\"char_start_times_ms\":[3],\"char_durations_ms\":[4]}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AudioOutput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AudioOutput did not round-trip."
        );
    }
}
