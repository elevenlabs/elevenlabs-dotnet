using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.DubbingLanguageResponse</c>.
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
public class DubbingLanguageResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"language_id\":\"language_id\",\"project_id\":\"project_id\",\"target_language\":\"target_language\",\"status\":\"queued\",\"model_id\":\"model_id\",\"voice_settings\":{\"cloning_strength\":7},\"outputs\":{\"lossless_audio\":\"lossless_audio\",\"subtitles\":\"subtitles\"},\"revision\":6,\"output_revision\":6,\"error\":{\"code\":\"code\",\"message\":\"message\",\"retryable\":false},\"warnings\":[{\"type\":\"voices_not_permitted\",\"speaker_ids\":[\"speaker_ids\"],\"message\":\"message\"}],\"created_at\":\"2023-02-27T12:13:35.426Z\",\"updated_at\":\"2023-01-11T06:53:39.574Z\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.DubbingLanguageResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.DubbingLanguageResponse did not round-trip."
        );
    }
}
