using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SubscriptionExtrasResponseModel</c>.
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
public class SubscriptionExtrasResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"concurrency\":7,\"convai_concurrency\":6,\"enterprise_music_concurrency\":5,\"music_finetunes_total_limit\":2,\"music_finetunes_monthly_limit\":5,\"music_finetunes_concurrency_limit\":2,\"convai_chars_per_minute\":9,\"convai_asr_chars_per_minute\":8,\"force_logging_disabled\":false,\"can_request_manual_pro_voice_verification\":false,\"can_bypass_voice_captcha\":true,\"moderation\":{\"is_in_probation\":false,\"enterprise_check_nogo_voice\":true,\"enterprise_check_block_nogo_voice\":true,\"never_live_moderate\":true,\"nogo_voice_similar_voice_upload_count\":3,\"enterprise_background_moderation_enabled\":false,\"is_ivc_captcha_required\":false,\"safety_status\":\"appeal_approved\",\"warning_status\":\"warning\",\"on_watchlist\":false},\"unused_characters_rolled_over_from_previous_period\":3,\"overused_characters_rolled_over_from_previous_period\":8,\"usage\":{\"rollover_credits_quota\":2,\"subscription_cycle_credits_quota\":10,\"manually_gifted_credits_quota\":6,\"payg_credits_quota\":4,\"rollover_credits_used\":5,\"subscription_cycle_credits_used\":10,\"manually_gifted_credits_used\":1,\"payg_credits_used\":10,\"paid_usage_based_credits_used\":5,\"actual_reported_credits\":3}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.SubscriptionExtrasResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SubscriptionExtrasResponseModel did not round-trip."
        );
    }
}
