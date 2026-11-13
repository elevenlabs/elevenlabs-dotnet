using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SubtitleOrderItemRequest</c>.
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
public class SubtitleOrderItemRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"kind\":\"subtitles\",\"media_ids\":[\"prodmedia_7wassdw4j9zzcgpl3ovy2piv18\"],\"source_language\":\"source_language\",\"destination_languages\":[\"destination_languages\"],\"cue_options\":{\"min_duration_ms\":1000,\"max_duration_ms\":7000,\"max_lines_per_cue\":2,\"max_chars_per_line\":42,\"max_chars_per_s\":16,\"min_gap_between_cues_frames\":3},\"sdh\":false,\"instructions\":\"instructions\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.SubtitleOrderItemRequest>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SubtitleOrderItemRequest did not round-trip."
        );
    }
}
