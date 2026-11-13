using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GenerationChunkInput</c>.
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
public class GenerationChunkInputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"text\":\"text\",\"duration_ms\":86116,\"positive_styles\":[\"positive_styles\"],\"negative_styles\":[\"negative_styles\"],\"context_adherence\":\"low\",\"conditioning_ref\":{\"song_id\":\"song_id\",\"range\":{\"start_ms\":8,\"end_ms\":5}},\"condition_strength\":\"low\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GenerationChunkInput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GenerationChunkInput did not round-trip."
        );
    }
}
