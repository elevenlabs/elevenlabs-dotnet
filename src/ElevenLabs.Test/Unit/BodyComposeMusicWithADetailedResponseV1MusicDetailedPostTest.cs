using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.BodyComposeMusicWithADetailedResponseV1MusicDetailedPost</c>.
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
public class BodyComposeMusicWithADetailedResponseV1MusicDetailedPostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"prompt\":\"prompt\",\"composition_plan\":{\"positive_global_styles\":[\"positive_global_styles\"],\"negative_global_styles\":[\"negative_global_styles\"],\"sections\":[{\"section_name\":\"section_name\",\"positive_local_styles\":[\"positive_local_styles\"],\"negative_local_styles\":[\"negative_local_styles\"],\"duration_ms\":104050,\"lines\":[\"lines\"],\"source_from\":{\"song_id\":\"song_id\",\"range\":{\"start_ms\":8,\"end_ms\":5},\"negative_ranges\":[{\"start_ms\":8,\"end_ms\":5}]}}]},\"music_length_ms\":69828,\"model_id\":\"music_v1\",\"seed\":692404708,\"force_instrumental\":false,\"finetune_id\":\"finetune_id\",\"respect_sections_durations\":true,\"store_for_inpainting\":true,\"with_timestamps\":true,\"with_waveform_visual\":true,\"sign_with_c2pa\":false}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.BodyComposeMusicWithADetailedResponseV1MusicDetailedPost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.BodyComposeMusicWithADetailedResponseV1MusicDetailedPost did not round-trip."
        );
    }
}
