using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionCustomerFacingConfigOutput</c>.
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
public class ReceptionCustomerFacingConfigOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"additional_instructions\":\"dolor\",\"tone_traits\":[\"elitid no\"],\"details_to_collect\":[\"Duisaute i\"],\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"disable_rag\":true,\"background_voice_detection\":true,\"turn_eagerness\":\"patient\",\"voice_id\":\"21m00Tcm4TlvDq8ikWAM\",\"language\":\"irure sit ei\",\"additional_languages\":[\"adipisicing ad \"],\"first_message\":\"Hi, thanks for calling Bloom Salon! How can I help you today?\",\"first_message_mode\":\"interruptible\",\"enable_end_call_tool\":true,\"enable_skip_turn_tool\":true,\"enable_play_keypad_touch_tone_tool\":true,\"agent_rules\":[{\"title\":\"elitin\",\"description\":\"do fugiat c\",\"priority\":\"strict\",\"id\":\"rule_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":10}],\"transfer_rules\":[{\"label\":\"conse\",\"phone_number\":\"Duisest e\",\"condition\":\"conse\",\"post_dial_digits\":\"00w767w\",\"id\":\"transferrule_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":1}],\"hide_caller_number_on_transfers\":true,\"record_after_transfers\":true,\"procedures\":[{\"name\":\"magna in\",\"trigger\":\"eu quis\",\"body\":\"1. Ask for the caller's name and order number.\\n2. Look up the order and read back its status.\",\"id\":\"agtprc_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":6,\"source_key\":\"source_key\"}],\"enable_secure_mode\":true,\"enable_spam_protection\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionCustomerFacingConfigOutput>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionCustomerFacingConfigOutput did not round-trip."
        );
    }
}
