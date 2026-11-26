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
            "{\"additional_instructions\":\"eu co\",\"tone_traits\":[\"cupidatat \"],\"details_to_collect\":[\"non in\"],\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"disable_rag\":false,\"background_voice_detection\":true,\"turn_eagerness\":\"patient\",\"voice_id\":\"21m00Tcm4TlvDq8ikWAM\",\"language\":\"Duis iru\",\"additional_languages\":[\"sint laborum e\"],\"first_message\":\"Hi, thanks for calling Bloom Salon! How can I help you today?\",\"first_message_mode\":\"interruptible\",\"enable_end_call_tool\":true,\"enable_skip_turn_tool\":true,\"enable_play_keypad_touch_tone_tool\":false,\"agent_rules\":[{\"title\":\"aliquip Duis\",\"description\":\"ad qui\",\"priority\":\"strict\",\"id\":\"rule_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":4}],\"transfer_rules\":[{\"label\":\"eiusmod\",\"phone_number\":\"do labore\",\"condition\":\"tempor aliqua\",\"post_dial_digits\":\"0#66\",\"id\":\"transferrule_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":5}],\"hide_caller_number_on_transfers\":false,\"record_after_transfers\":true,\"procedures\":[{\"name\":\"aliqui\",\"trigger\":\"conse\",\"body\":\"1. Ask for the caller's name and order number.\\n2. Look up the order and read back its status.\",\"id\":\"agtprc_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":10,\"source_key\":\"source_key\"}],\"enable_secure_mode\":false,\"enable_spam_protection\":false}";

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
