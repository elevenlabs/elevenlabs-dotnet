using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ProjectImageResponseModel</c>.
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
public class ProjectImageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"image_id\":\"image_id\",\"filename\":\"filename\",\"signed_url\":\"signed_url\",\"thumbnail_signed_url\":\"thumbnail_signed_url\",\"type\":\"image\",\"source\":\"upload\",\"file_size_bytes\":10,\"width\":0,\"height\":7,\"track_id\":\"v0\",\"offset_ms\":9,\"duration_ms\":8,\"order\":\"order\",\"canvas_placement\":{\"x_relative\":0.5,\"y_relative\":0.5,\"scale_x\":1,\"scale_y\":1,\"pivot_x\":0.53,\"pivot_y\":2.54,\"skew_x\":4.32,\"skew_y\":8.11,\"crop_top\":5.13,\"crop_right\":2.85,\"crop_bottom\":3.98,\"crop_left\":0.23,\"flip_x\":false,\"flip_y\":true},\"animation\":{\"enter_effect\":\"none\",\"enter_duration_ms\":9,\"exit_effect\":\"none\",\"exit_duration_ms\":9},\"opacity\":1,\"created_at_ms\":8,\"updated_at_ms\":5,\"current_snapshot_id\":\"current_snapshot_id\",\"source_asset_id\":\"source_asset_id\",\"source_platform_asset_id\":\"source_platform_asset_id\",\"error\":\"error\",\"pending_task\":{\"type\":\"preprocessing\",\"progress\":4.43,\"started_at_ms\":6,\"updated_at_ms\":1,\"metadata\":{\"key\":{}}},\"analysis\":{\"status\":\"processing\",\"data\":{\"title\":\"title\",\"description\":\"description\",\"content_type\":\"content_type\",\"mood_and_style\":\"mood_and_style\",\"composition_notes\":\"composition_notes\",\"visible_text\":\"visible_text\",\"subjects\":[{\"name\":\"name\",\"description\":\"description\"}]},\"updated_at_ms\":6}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ProjectImageResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ProjectImageResponseModel did not round-trip."
        );
    }
}
