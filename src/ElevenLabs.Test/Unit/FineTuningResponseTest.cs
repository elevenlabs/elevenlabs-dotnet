using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.FineTuningResponse</c>.
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
public class FineTuningResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"is_allowed_to_fine_tune\":true,\"state\":{\"key\":\"not_started\"},\"verification_failures\":[\"verification_failures\"],\"verification_attempts_count\":9,\"manual_verification_requested\":true,\"language\":\"language\",\"progress\":{\"key\":0.59},\"message\":{\"key\":\"message\"},\"dataset_duration_seconds\":9.9,\"verification_attempts\":[{\"text\":\"text\",\"date_unix\":3,\"accepted\":true,\"similarity\":4.96,\"levenshtein_distance\":8.66,\"recording\":{\"recording_id\":\"recording_id\",\"mime_type\":\"mime_type\",\"size_bytes\":5,\"upload_date_unix\":0,\"transcription\":\"transcription\"}}],\"slice_ids\":[\"slice_ids\"],\"manual_verification\":{\"extra_text\":\"extra_text\",\"request_time_unix\":0,\"files\":[{\"file_id\":\"file_id\",\"file_name\":\"file_name\",\"mime_type\":\"mime_type\",\"size_bytes\":10,\"upload_date_unix\":4}]},\"max_verification_attempts\":1,\"next_max_verification_attempts_reset_unix_ms\":3,\"finetuning_state\":{}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.FineTuningResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.FineTuningResponse did not round-trip."
        );
    }
}
