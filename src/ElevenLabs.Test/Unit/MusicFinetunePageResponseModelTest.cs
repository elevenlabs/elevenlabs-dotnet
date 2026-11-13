using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.MusicFinetunePageResponseModel</c>.
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
public class MusicFinetunePageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"finetunes\":[{\"id\":\"id\",\"name\":\"name\",\"tags\":[\"tags\"],\"primary_genre\":\"primary_genre\",\"model_id\":\"music_v1\",\"created_at\":\"2023-05-26T02:07:38.965Z\",\"visibility\":\"private\",\"created_by\":\"self\",\"status\":\"pending\",\"training_progress\":5.02,\"failure_reason\":\"audio_processing_failed\"}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.MusicFinetunePageResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.MusicFinetunePageResponseModel did not round-trip."
        );
    }
}
