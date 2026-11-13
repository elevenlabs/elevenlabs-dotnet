using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ProjectVideoResponseModel</c>.
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
public class ProjectVideoResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"video_id\":\"video_id\",\"filename\":\"filename\",\"signed_url\":\"signed_url\",\"signed_preview_url\":\"signed_preview_url\",\"offset_ms\":1,\"duration_ms\":8,\"volume_gain_db\":2.48,\"muted\":true,\"fade_in_ms\":2,\"fade_out_ms\":7,\"width\":1,\"height\":6,\"codec\":\"codec\",\"order\":\"order\",\"created_at_ms\":1,\"updated_at_ms\":7,\"error\":\"error\",\"thumbnail_interval_seconds\":0.91,\"thumbnail_size\":[7],\"thumbnail_sheets\":[{\"start_thumbnail_index\":10,\"thumbnail_count\":3,\"signed_cloud_url\":\"signed_cloud_url\"}],\"start_time_ms\":4,\"end_time_ms\":8,\"asset_preview_signed_url\":\"asset_preview_signed_url\",\"source_video_id\":\"source_video_id\",\"source_asset_id\":\"source_asset_id\",\"source_platform_asset_id\":\"source_platform_asset_id\",\"pending_blocks_metadata\":{\"target_global_offset_ms\":0,\"block_ids\":[\"block_ids\"]},\"pending_external_audios_metadata\":{\"target_global_offset_ms\":8,\"external_audio_ids\":[\"external_audio_ids\"]},\"speech_imported\":true,\"pending_task\":{\"type\":\"preprocessing\",\"progress\":4.43,\"started_at_ms\":6,\"updated_at_ms\":1,\"metadata\":{\"key\":{}}},\"audio_track_ready\":true,\"export_format_ready\":true,\"current_snapshot_id\":\"current_snapshot_id\",\"source_context\":{\"source_type\":\"generation\",\"generation_id\":\"generation_id\",\"prompt\":\"prompt\",\"model_id\":\"model_id\",\"model_provider\":\"model_provider\",\"generation_session_id\":\"generation_session_id\",\"session_iteration_id\":\"session_iteration_id\",\"model_parameters\":{\"key\":{}},\"extend_video\":{\"generation_id\":\"generation_id\",\"content_asset_id\":\"content_asset_id\",\"template_node_id\":\"template_node_id\",\"studio_clip\":{\"project_id\":\"project_id\",\"chapter_id\":\"chapter_id\",\"clip_type\":\"video\",\"clip_id\":\"clip_id\",\"block_id\":\"block_id\",\"preview_url\":\"preview_url\"}}},\"analysis\":{\"status\":\"processing\",\"data\":{\"title\":\"title\",\"description\":\"description\",\"content_type\":\"content_type\",\"overall_pacing\":\"overall_pacing\",\"subjects\":[{\"name\":\"name\",\"description\":\"description\"}],\"segments\":[{\"start_ms\":4,\"end_ms\":9,\"description\":\"description\",\"subjects\":[\"subjects\"],\"shot_type\":\"shot_type\",\"camera_movement\":\"camera_movement\",\"transition_in\":\"transition_in\",\"has_speech\":true,\"has_music\":false,\"pacing\":\"pacing\"}],\"key_moments\":[{\"timestamp_ms\":6,\"type\":\"type\",\"description\":\"description\"}]},\"updated_at_ms\":9},\"transcription\":{\"status\":\"processing\",\"data\":{\"language_code\":\"language_code\",\"text\":\"text\",\"words\":[\"words\"],\"word_start_times_ms\":[2],\"word_end_times_ms\":[0],\"word_speaker_ids\":[\"word_speaker_ids\"]},\"updated_at_ms\":7},\"type\":\"video\",\"canvas_placement\":{\"x_relative\":0.5,\"y_relative\":0.5,\"scale_x\":1,\"scale_y\":1,\"pivot_x\":0.53,\"pivot_y\":2.54,\"skew_x\":4.32,\"skew_y\":8.11,\"crop_top\":5.13,\"crop_right\":2.85,\"crop_bottom\":3.98,\"crop_left\":0.23,\"flip_x\":false,\"flip_y\":true},\"animation\":{\"enter_effect\":\"none\",\"enter_duration_ms\":9,\"exit_effect\":\"none\",\"exit_duration_ms\":9},\"playback_speed\":1,\"opacity\":1,\"track_id\":\"v0\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ProjectVideoResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ProjectVideoResponseModel did not round-trip."
        );
    }
}
