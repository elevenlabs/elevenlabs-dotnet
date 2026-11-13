using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.DubbingProjectListResponse</c>.
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
public class DubbingProjectListResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"projects\":[{\"project_id\":\"project_id\",\"status\":\"queued\",\"reference\":\"reference\",\"source_language\":\"source_language\",\"model_id\":\"model_id\",\"media\":{\"filename\":\"filename\",\"duration_s\":0.99,\"has_video\":false,\"mime_type\":\"mime_type\"},\"language_ids\":[\"language_ids\"],\"webhook_ids\":[\"webhook_ids\"],\"revision\":4,\"error\":{\"code\":\"code\",\"message\":\"message\",\"retryable\":false},\"warnings\":[{\"type\":\"voices_not_permitted\",\"speaker_ids\":[\"speaker_ids\"],\"message\":\"message\"}],\"created_at\":\"2023-11-14T12:55:00.697Z\",\"updated_at\":\"2023-01-05T09:58:00.458Z\"}],\"next_cursor\":\"next_cursor\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.DubbingProjectListResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.DubbingProjectListResponse did not round-trip."
        );
    }
}
