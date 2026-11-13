using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ChapterStatisticsResponse</c>.
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
public class ChapterStatisticsResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"characters_unconverted\":2,\"characters_converted\":5,\"paragraphs_converted\":9,\"paragraphs_unconverted\":1,\"credits_needed_to_convert\":8,\"voice_statistics\":[{\"project_voice_ref_id\":\"project_voice_ref_id\",\"characters_unconverted\":4,\"characters_converted\":10,\"credits_needed_to_convert\":3}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ChapterStatisticsResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ChapterStatisticsResponse did not round-trip."
        );
    }
}
