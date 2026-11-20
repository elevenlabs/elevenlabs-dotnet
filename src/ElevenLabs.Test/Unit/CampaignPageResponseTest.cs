using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CampaignPageResponse</c>.
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
public class CampaignPageResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"campaigns\":[{\"campaign_id\":\"campaign_id\",\"call_name\":\"call_name\",\"agent_id\":\"agent_id\",\"channel_config\":{\"channel\":\"phone\",\"agent_phone_number_id\":\"agent_phone_number_id\",\"mode_config\":{\"ringing_timeout_secs\":60,\"twilio_call_recording_enabled\":false,\"twilio_machine_detection\":{\"mode\":\"enable\",\"actions\":[{\"action\":\"hang_up\",\"answered_by\":[\"human\"]}]},\"mode\":\"voice\"}},\"status\":\"active\",\"policy\":{\"timezone\":\"timezone\",\"retry\":{\"retry_delay_seconds\":600,\"max_short_retries\":1,\"max_total_calls\":6,\"max_callbacks\":2,\"max_redirects\":2,\"interval_placement\":\"start\",\"rotate_step_seconds\":900,\"max_consecutive_failures_per_number\":23},\"calling_periods\":[{\"weekdays\":[6],\"intervals\":[{\"start\":\"04:28\",\"end\":\"24:00\"}]}],\"date_overrides\":[{\"start_date\":\"2023-01-18\",\"end_date\":\"2023-05-02\",\"intervals\":[{\"start\":\"04:28\",\"end\":\"24:00\"}],\"name\":\"name\"}],\"data_collection\":{\"callback_time\":\"callback_time\",\"redirect_phone_number\":\"redirect_phone_number\",\"stop\":\"stop\",\"mappings\":{\"key\":\"mappings\"}},\"followup_context\":{\"call_type\":true,\"previous_conversation_id\":true,\"previous_summary\":true,\"previous_transcript\":true}},\"variant\":\"simple\",\"source\":\"ui\",\"created_at_unix\":0,\"scheduled_time_unix\":1,\"updated_at_unix\":4,\"branch_id\":\"branch_id\",\"environment\":\"environment\",\"target_concurrency_limit\":2,\"channel\":\"phone\",\"mode\":\"voice\",\"counts\":{\"leads\":3,\"terminal_leads\":2,\"open_attention\":9,\"delivery\":{\"sent\":6,\"delivered\":9,\"read\":2,\"replied\":0,\"failed\":5}},\"agent_name\":\"agent_name\"}],\"next_cursor\":\"next_cursor\",\"has_more\":false}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CampaignPageResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CampaignPageResponse did not round-trip."
        );
    }
}
