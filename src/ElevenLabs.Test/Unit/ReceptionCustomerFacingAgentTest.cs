using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionCustomerFacingAgent</c>.
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
public class ReceptionCustomerFacingAgentTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"agent_id\":\"agent_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"config\":{\"additional_instructions\":\"qui sint do\",\"tone_traits\":[\"dolor aliquip \"],\"details_to_collect\":[\"qui voluptate\"],\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"disable_rag\":true,\"background_voice_detection\":true,\"turn_eagerness\":\"patient\",\"voice_id\":\"21m00Tcm4TlvDq8ikWAM\",\"language\":\"magna\",\"additional_languages\":[\"cupidatat\"],\"first_message\":\"Hi, thanks for calling Bloom Salon! How can I help you today?\",\"first_message_mode\":\"interruptible\",\"enable_end_call_tool\":true,\"enable_skip_turn_tool\":true,\"enable_play_keypad_touch_tone_tool\":false,\"agent_rules\":[{\"title\":\"commo\",\"description\":\"laborum nisi \",\"priority\":\"strict\",\"id\":\"rule_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":1}],\"transfer_rules\":[{\"label\":\"docillum ut \",\"phone_number\":\"laboris\",\"condition\":\"repreh\",\"post_dial_digits\":\"#8W17*067#\",\"id\":\"transferrule_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":4}],\"hide_caller_number_on_transfers\":true,\"record_after_transfers\":false,\"procedures\":[{\"name\":\"voluptate e\",\"trigger\":\"eu adipisi\",\"body\":\"1. Ask for the caller's name and order number.\\n2. Look up the order and read back its status.\",\"id\":\"agtprc_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":0,\"source_key\":\"source_key\"}],\"enable_secure_mode\":false,\"enable_spam_protection\":false},\"deactivated_at_unix\":2,\"deactivation_reason\":\"tier_downgrade\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionCustomerFacingAgent>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionCustomerFacingAgent did not round-trip."
        );
    }
}
