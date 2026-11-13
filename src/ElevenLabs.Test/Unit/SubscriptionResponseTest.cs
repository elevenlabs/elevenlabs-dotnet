using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SubscriptionResponse</c>.
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
public class SubscriptionResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"tier\":\"tier\",\"character_count\":4,\"character_limit\":0,\"max_character_limit_extension\":0,\"max_credit_limit_extension\":1,\"can_extend_character_limit\":true,\"allowed_to_extend_character_limit\":false,\"next_character_count_reset_unix\":8,\"voice_slots_used\":9,\"professional_voice_slots_used\":8,\"professional_voice_slots_used_in_workspace\":1,\"voice_limit\":3,\"max_voice_add_edits\":3,\"voice_add_edit_counter\":8,\"professional_voice_limit\":0,\"can_extend_voice_limit\":true,\"can_use_instant_voice_cloning\":false,\"can_use_professional_voice_cloning\":true,\"currency\":\"usd\",\"current_overage\":{\"amount\":\"0000000010.61151\",\"currency\":\"usd\"},\"status\":\"trialing\",\"billing_period\":\"monthly_period\",\"character_refresh_period\":\"monthly_period\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.SubscriptionResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SubscriptionResponse did not round-trip."
        );
    }
}
