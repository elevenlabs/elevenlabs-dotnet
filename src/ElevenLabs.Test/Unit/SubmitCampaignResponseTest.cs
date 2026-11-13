using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SubmitCampaignResponse</c>.
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
public class SubmitCampaignResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"campaign\":{\"campaign_id\":\"campaign_id\",\"call_name\":\"call_name\",\"agent_id\":\"agent_id\",\"channel_config\":{\"channel\":\"phone\",\"agent_phone_number_id\":\"agent_phone_number_id\",\"mode_config\":{\"ringing_timeout_secs\":60,\"twilio_call_recording_enabled\":true,\"twilio_machine_detection\":{\"mode\":\"enable\",\"actions\":[{\"action\":\"hang_up\",\"answered_by\":[\"human\"]}]},\"mode\":\"voice\"}},\"status\":\"active\",\"policy\":{\"timezone\":\"timezone\",\"retry\":{\"retry_delay_seconds\":600,\"max_short_retries\":1,\"max_total_calls\":6,\"max_callbacks\":2,\"max_redirects\":2,\"interval_placement\":\"start\",\"rotate_step_seconds\":900,\"max_consecutive_failures_per_number\":8},\"calling_periods\":[{\"weekdays\":[3],\"intervals\":[{\"start\":\"20:27\",\"end\":\"24:00\"}]}],\"data_collection\":{\"callback_time\":\"callback_time\",\"redirect_phone_number\":\"redirect_phone_number\",\"stop\":\"stop\",\"mappings\":{\"key\":\"mappings\"}},\"followup_context\":{\"call_type\":true,\"previous_conversation_id\":true,\"previous_summary\":true,\"previous_transcript\":true}},\"variant\":\"simple\",\"source\":\"ui\",\"created_at_unix\":1,\"scheduled_time_unix\":7,\"updated_at_unix\":4,\"branch_id\":\"branch_id\",\"environment\":\"environment\",\"target_concurrency_limit\":4,\"channel\":\"phone\",\"mode\":\"voice\",\"counts\":{\"leads\":9,\"terminal_leads\":6,\"open_attention\":6,\"delivery\":{\"sent\":1,\"delivered\":1,\"read\":3,\"replied\":3,\"failed\":1}},\"agent_name\":\"agent_name\"},\"created\":true,\"within_calling_window\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.SubmitCampaignResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SubmitCampaignResponse did not round-trip."
        );
    }
}
