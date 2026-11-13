using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WorkspaceBatchCallsResponse</c>.
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
public class WorkspaceBatchCallsResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"batch_calls\":[{\"id\":\"id\",\"phone_number_id\":\"phone_number_id\",\"phone_provider\":\"twilio\",\"whatsapp_params\":{\"whatsapp_phone_number_id\":\"whatsapp_phone_number_id\",\"whatsapp_call_permission_request_template_name\":\"whatsapp_call_permission_request_template_name\",\"whatsapp_call_permission_request_template_language_code\":\"whatsapp_call_permission_request_template_language_code\"},\"name\":\"name\",\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"environment\":\"environment\",\"created_at_unix\":2,\"scheduled_time_unix\":9,\"timezone\":\"timezone\",\"total_calls_dispatched\":5,\"total_calls_scheduled\":6,\"total_calls_finished\":4,\"last_updated_at_unix\":2,\"status\":\"pending\",\"retry_count\":10,\"telephony_call_config\":{\"ringing_timeout_secs\":60,\"twilio_call_recording_enabled\":false,\"twilio_machine_detection\":{\"mode\":\"enable\",\"actions\":[{\"action\":\"hang_up\",\"answered_by\":[\"human\"]}]}},\"target_concurrency_limit\":2,\"agent_name\":\"agent_name\",\"branch_name\":\"branch_name\"}],\"next_doc\":\"next_doc\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WorkspaceBatchCallsResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WorkspaceBatchCallsResponse did not round-trip."
        );
    }
}
