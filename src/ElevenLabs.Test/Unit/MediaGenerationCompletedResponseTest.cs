using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.MediaGenerationCompletedResponse</c>.
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
public class MediaGenerationCompletedResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"JWr5N6X9ZTqf8jD2LmQb\",\"status\":\"completed\",\"content_url\":\"https://storage.googleapis.com/generations/JWr5N6X9ZTqf8jD2LmQb\",\"content_mime_type\":\"video/mp4\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.MediaGenerationCompletedResponse>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.MediaGenerationCompletedResponse did not round-trip."
        );
    }
}
