using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.User</c>.
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
public class UserTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"user_id\":\"user_id\",\"workspace_id\":\"workspace_id\",\"subscription\":{\"tier\":\"tier\",\"character_count\":4,\"character_limit\":0,\"max_character_limit_extension\":0,\"max_credit_limit_extension\":1,\"can_extend_character_limit\":true,\"allowed_to_extend_character_limit\":false,\"next_character_count_reset_unix\":8,\"voice_slots_used\":9,\"professional_voice_slots_used\":8,\"professional_voice_slots_used_in_workspace\":1,\"voice_limit\":3,\"max_voice_add_edits\":3,\"voice_add_edit_counter\":8,\"professional_voice_limit\":0,\"can_extend_voice_limit\":true,\"can_use_instant_voice_cloning\":false,\"can_use_professional_voice_cloning\":true,\"currency\":\"usd\",\"current_overage\":{\"amount\":\"0000000010.61151\",\"currency\":\"usd\"},\"status\":\"trialing\",\"billing_period\":\"monthly_period\",\"character_refresh_period\":\"monthly_period\"},\"is_new_user\":true,\"can_use_delayed_payment_methods\":true,\"is_onboarding_completed\":true,\"is_onboarding_checklist_completed\":false,\"show_compliance_terms\":true,\"first_name\":\"first_name\",\"is_api_key_hashed\":false,\"xi_api_key_preview\":\"xi_api_key_preview\",\"referral_link_code\":\"referral_link_code\",\"partnerstack_partner_default_link\":\"partnerstack_partner_default_link\",\"created_at\":2,\"seat_type\":\"workspace_admin\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.User>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(wire, serialized, "global::ElevenLabs.User did not round-trip.");
    }
}
