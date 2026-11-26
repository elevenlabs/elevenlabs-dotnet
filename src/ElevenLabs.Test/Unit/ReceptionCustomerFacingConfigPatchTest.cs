using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionCustomerFacingConfigPatch</c>.
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
public class ReceptionCustomerFacingConfigPatchTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"additional_instructions\":\"labore \",\"tone_traits\":[\"velit esse c\"],\"details_to_collect\":[\"amet \"],\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"disable_rag\":true,\"background_voice_detection\":false,\"turn_eagerness\":\"patient\",\"voice_id\":\"21m00Tcm4TlvDq8ikWAM\",\"language\":\"officia\",\"additional_languages\":[\"irure\"],\"first_message\":\"Hi, thanks for calling Bloom Salon! How can I help you today?\",\"first_message_mode\":\"interruptible\",\"enable_end_call_tool\":false,\"enable_skip_turn_tool\":true,\"enable_play_keypad_touch_tone_tool\":true,\"hide_caller_number_on_transfers\":true,\"record_after_transfers\":false,\"enable_secure_mode\":true,\"enable_spam_protection\":false}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionCustomerFacingConfigPatch>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionCustomerFacingConfigPatch did not round-trip."
        );
    }
}
