using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReadMetadataChapterDbModel</c>.
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
public class ReadMetadataChapterDbModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"chapter_name\":\"chapter_name\",\"word_count\":8,\"char_count\":6,\"starting_char_offset\":1,\"has_parsed_html\":true,\"has_summary\":false,\"duration_seconds\":9.41,\"file_number\":\"file_number\",\"is_fallback_name\":false,\"chapter_id\":\"chapter_id\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReadMetadataChapterDbModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReadMetadataChapterDbModel did not round-trip."
        );
    }
}
