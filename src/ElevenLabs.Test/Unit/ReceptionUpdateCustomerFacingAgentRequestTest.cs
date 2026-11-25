using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.ReceptionUpdateCustomerFacingAgentRequest</c>.
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
public class ReceptionUpdateCustomerFacingAgentRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"config\":{\"additional_instructions\":\"amet minim\",\"tone_traits\":[\"qui sed in\"],\"details_to_collect\":[\"ipsum anim q\"],\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"disable_rag\":true,\"background_voice_detection\":true,\"turn_eagerness\":\"patient\",\"voice_id\":\"21m00Tcm4TlvDq8ikWAM\",\"language\":\"quis Ex\",\"additional_languages\":[\"exercitatio\"],\"first_message\":\"Hi, thanks for calling Bloom Salon! How can I help you today?\",\"first_message_mode\":\"interruptible\",\"enable_end_call_tool\":false,\"enable_skip_turn_tool\":true,\"enable_play_keypad_touch_tone_tool\":false,\"hide_caller_number_on_transfers\":true,\"record_after_transfers\":false,\"enable_secure_mode\":false,\"enable_spam_protection\":true},\"name\":\"name\",\"widget\":{\"orb_color_1\":\"#2792dc\",\"orb_color_2\":\"#9ce6e6\",\"variant\":\"tiny\",\"placement\":\"top-left\",\"dismissible\":false,\"main_label\":\"main_label\",\"start_call\":\"start_call\"}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Reception.ReceptionUpdateCustomerFacingAgentRequest>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.ReceptionUpdateCustomerFacingAgentRequest did not round-trip."
        );
    }
}
