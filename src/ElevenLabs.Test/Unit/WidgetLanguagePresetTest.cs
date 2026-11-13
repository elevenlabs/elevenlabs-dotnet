using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WidgetLanguagePreset</c>.
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
public class WidgetLanguagePresetTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"text_contents\":{\"main_label\":\"main_label\",\"start_call\":\"start_call\",\"start_chat\":\"start_chat\",\"new_call\":\"new_call\",\"end_call\":\"end_call\",\"mute_microphone\":\"mute_microphone\",\"change_language\":\"change_language\",\"collapse\":\"collapse\",\"expand\":\"expand\",\"copied\":\"copied\",\"accept_terms\":\"accept_terms\",\"dismiss_terms\":\"dismiss_terms\",\"listening_status\":\"listening_status\",\"speaking_status\":\"speaking_status\",\"connecting_status\":\"connecting_status\",\"chatting_status\":\"chatting_status\",\"queue_waiting_status\":\"queue_waiting_status\",\"queue_waiting_status_short\":\"queue_waiting_status_short\",\"input_label\":\"input_label\",\"input_placeholder\":\"input_placeholder\",\"input_placeholder_text_only\":\"input_placeholder_text_only\",\"input_placeholder_new_conversation\":\"input_placeholder_new_conversation\",\"user_ended_conversation\":\"user_ended_conversation\",\"agent_ended_conversation\":\"agent_ended_conversation\",\"conversation_id\":\"conversation_id\",\"error_occurred\":\"error_occurred\",\"queue_timed_out\":\"queue_timed_out\",\"copy_id\":\"copy_id\",\"initiate_feedback\":\"initiate_feedback\",\"request_follow_up_feedback\":\"request_follow_up_feedback\",\"thanks_for_feedback\":\"thanks_for_feedback\",\"thanks_for_feedback_details\":\"thanks_for_feedback_details\",\"follow_up_feedback_placeholder\":\"follow_up_feedback_placeholder\",\"submit\":\"submit\",\"go_back\":\"go_back\",\"send_message\":\"send_message\",\"text_mode\":\"text_mode\",\"voice_mode\":\"voice_mode\",\"switched_to_text_mode\":\"switched_to_text_mode\",\"switched_to_voice_mode\":\"switched_to_voice_mode\",\"copy\":\"copy\",\"download\":\"download\",\"wrap\":\"wrap\",\"agent_working\":\"agent_working\",\"agent_done\":\"agent_done\",\"agent_error\":\"agent_error\",\"attach_file\":\"attach_file\",\"remove_file\":\"remove_file\",\"file_upload_error\":\"file_upload_error\",\"file_type_unsupported\":\"file_type_unsupported\",\"file_too_large\":\"file_too_large\",\"file_limit_reached\":\"file_limit_reached\",\"typing_indicator\":\"typing_indicator\",\"rich_content_unavailable\":\"rich_content_unavailable\"},\"text_contents_translation\":{\"source\":{\"key\":\"source\"},\"text\":{\"key\":\"text\"}},\"terms_text\":\"terms_text\",\"terms_html\":\"terms_html\",\"terms_key\":\"terms_key\",\"terms_translation\":{\"source_hash\":\"source_hash\",\"text\":\"text\"}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WidgetLanguagePreset>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WidgetLanguagePreset did not round-trip."
        );
    }
}
