using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.DubbingMetadataPageResponseModel</c>.
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
public class DubbingMetadataPageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"dubs\":[{\"dubbing_id\":\"dubbing_id\",\"name\":\"name\",\"status\":\"preparing\",\"source_language\":\"source_language\",\"target_languages\":[\"target_languages\"],\"editable\":true,\"created_at\":\"2023-08-02T07:39:50.163Z\",\"media_metadata\":{\"content_type\":\"content_type\",\"duration\":3.17},\"error\":\"error\"}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.DubbingMetadataPageResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.DubbingMetadataPageResponseModel did not round-trip."
        );
    }
}
