using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Voice</c>.
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
public class VoiceTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"voice_id\":\"voice_id\",\"name\":\"name\",\"samples\":[{\"sample_id\":\"sample_id\",\"file_name\":\"file_name\",\"mime_type\":\"mime_type\",\"size_bytes\":7,\"hash\":\"hash\",\"duration_secs\":7.95,\"remove_background_noise\":false,\"has_isolated_audio\":false,\"has_isolated_audio_preview\":true,\"speaker_separation\":{\"voice_id\":\"voice_id\",\"sample_id\":\"sample_id\",\"status\":\"not_started\",\"speakers\":{\"key\":{\"speaker_id\":\"speaker_id\",\"duration_secs\":3.23,\"utterances\":[{\"start\":5.34,\"end\":6.51}]}},\"selected_speaker_ids\":[\"selected_speaker_ids\"]},\"trim_start\":10,\"trim_end\":4}],\"category\":\"generated\",\"fine_tuning\":{\"is_allowed_to_fine_tune\":true,\"state\":{\"key\":\"not_started\"},\"verification_failures\":[\"verification_failures\"],\"verification_attempts_count\":9,\"manual_verification_requested\":true,\"language\":\"language\",\"progress\":{\"key\":0.59},\"message\":{\"key\":\"message\"},\"dataset_duration_seconds\":9.9,\"verification_attempts\":[{\"text\":\"text\",\"date_unix\":3,\"accepted\":true,\"similarity\":4.96,\"levenshtein_distance\":8.66,\"recording\":{\"recording_id\":\"recording_id\",\"mime_type\":\"mime_type\",\"size_bytes\":5,\"upload_date_unix\":0,\"transcription\":\"transcription\"}}],\"slice_ids\":[\"slice_ids\"],\"manual_verification\":{\"extra_text\":\"extra_text\",\"request_time_unix\":0,\"files\":[{\"file_id\":\"file_id\",\"file_name\":\"file_name\",\"mime_type\":\"mime_type\",\"size_bytes\":10,\"upload_date_unix\":4}]},\"max_verification_attempts\":1,\"next_max_verification_attempts_reset_unix_ms\":3,\"finetuning_state\":{}},\"labels\":{\"key\":\"labels\"},\"description\":\"description\",\"preview_url\":\"preview_url\",\"available_for_tiers\":[\"available_for_tiers\"],\"settings\":{\"stability\":0.62,\"use_speaker_boost\":true,\"similarity_boost\":0.18,\"style\":2.67,\"speed\":5.4,\"clone_strength\":0.53},\"sharing\":{\"status\":\"enabled\",\"history_item_sample_id\":\"history_item_sample_id\",\"date_unix\":6,\"whitelisted_emails\":[\"whitelisted_emails\"],\"public_owner_id\":\"public_owner_id\",\"original_voice_id\":\"original_voice_id\",\"financial_rewards_enabled\":false,\"free_users_allowed\":false,\"live_moderation_enabled\":false,\"rate\":9.87,\"fiat_rate\":1.48,\"notice_period\":1,\"disable_at_unix\":6,\"voice_mixing_allowed\":false,\"featured\":false,\"category\":\"generated\",\"reader_app_enabled\":false,\"image_url\":\"image_url\",\"ban_reason\":\"ban_reason\",\"liked_by_count\":9,\"cloned_by_count\":7,\"name\":\"name\",\"description\":\"description\",\"labels\":{\"key\":\"labels\"},\"review_status\":\"not_requested\",\"review_message\":\"review_message\",\"enabled_in_library\":true,\"instagram_username\":\"instagram_username\",\"twitter_username\":\"twitter_username\",\"youtube_username\":\"youtube_username\",\"tiktok_username\":\"tiktok_username\",\"moderation_check\":{\"date_checked_unix\":9,\"name_value\":\"name_value\",\"name_check\":false,\"description_value\":\"description_value\",\"description_check\":false,\"sample_ids\":[\"sample_ids\"],\"sample_checks\":[3.88],\"captcha_ids\":[\"captcha_ids\"],\"captcha_checks\":[7.9]},\"reader_restricted_on\":[{\"resource_type\":\"read\",\"resource_id\":\"resource_id\"}]},\"high_quality_base_model_ids\":[\"high_quality_base_model_ids\"],\"verified_languages\":[{\"language\":\"language\",\"model_id\":\"model_id\",\"accent\":\"accent\",\"locale\":\"locale\",\"preview_url\":\"preview_url\"}],\"collection_ids\":[\"collection_ids\"],\"safety_control\":\"NONE\",\"voice_verification\":{\"requires_verification\":true,\"is_verified\":false,\"verification_failures\":[\"verification_failures\"],\"verification_attempts_count\":8,\"language\":\"language\",\"verification_attempts\":[{\"text\":\"text\",\"date_unix\":3,\"accepted\":true,\"similarity\":4.96,\"levenshtein_distance\":8.66,\"recording\":{\"recording_id\":\"recording_id\",\"mime_type\":\"mime_type\",\"size_bytes\":5,\"upload_date_unix\":0,\"transcription\":\"transcription\"}}]},\"permission_on_resource\":\"permission_on_resource\",\"is_owner\":true,\"is_legacy\":false,\"is_mixed\":false,\"favorited_at_unix\":0,\"created_at_unix\":6,\"is_bookmarked\":false,\"recording_quality\":\"studio\",\"labelling_status\":\"in_review\",\"recording_quality_reason\":\"recording_quality_reason\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.Voice>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(wire, serialized, "global::ElevenLabs.Voice did not round-trip.");
    }
}
