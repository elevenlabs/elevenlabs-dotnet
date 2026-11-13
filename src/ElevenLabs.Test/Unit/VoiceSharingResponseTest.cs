using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.VoiceSharingResponse</c>.
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
public class VoiceSharingResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"status\":\"enabled\",\"history_item_sample_id\":\"history_item_sample_id\",\"date_unix\":6,\"whitelisted_emails\":[\"whitelisted_emails\"],\"public_owner_id\":\"public_owner_id\",\"original_voice_id\":\"original_voice_id\",\"financial_rewards_enabled\":false,\"free_users_allowed\":false,\"live_moderation_enabled\":false,\"rate\":9.87,\"fiat_rate\":1.48,\"notice_period\":1,\"disable_at_unix\":6,\"voice_mixing_allowed\":false,\"featured\":false,\"category\":\"generated\",\"reader_app_enabled\":false,\"image_url\":\"image_url\",\"ban_reason\":\"ban_reason\",\"liked_by_count\":9,\"cloned_by_count\":7,\"name\":\"name\",\"description\":\"description\",\"labels\":{\"key\":\"labels\"},\"review_status\":\"not_requested\",\"review_message\":\"review_message\",\"enabled_in_library\":true,\"instagram_username\":\"instagram_username\",\"twitter_username\":\"twitter_username\",\"youtube_username\":\"youtube_username\",\"tiktok_username\":\"tiktok_username\",\"moderation_check\":{\"date_checked_unix\":9,\"name_value\":\"name_value\",\"name_check\":false,\"description_value\":\"description_value\",\"description_check\":false,\"sample_ids\":[\"sample_ids\"],\"sample_checks\":[3.88],\"captcha_ids\":[\"captcha_ids\"],\"captcha_checks\":[7.9]},\"reader_restricted_on\":[{\"resource_type\":\"read\",\"resource_id\":\"resource_id\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.VoiceSharingResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.VoiceSharingResponse did not round-trip."
        );
    }
}
