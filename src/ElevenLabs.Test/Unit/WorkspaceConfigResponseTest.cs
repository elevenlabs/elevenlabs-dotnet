using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WorkspaceConfigResponse</c>.
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
public class WorkspaceConfigResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"version\":10,\"config\":{\"policy\":{\"timezone\":\"UTC\",\"retry\":{\"retry_delay_seconds\":600,\"max_short_retries\":1,\"max_total_calls\":6,\"max_callbacks\":2,\"max_redirects\":2,\"interval_placement\":\"start\",\"rotate_step_seconds\":900,\"max_consecutive_failures_per_number\":8},\"calling_periods\":[{\"weekdays\":[3],\"intervals\":[{\"start\":\"20:27\",\"end\":\"24:00\"}]}],\"data_collection\":{\"callback_time\":\"callback_time\",\"redirect_phone_number\":\"redirect_phone_number\",\"stop\":\"stop\",\"mappings\":{\"key\":\"mappings\"}},\"followup_context\":{\"call_type\":true,\"previous_conversation_id\":true,\"previous_summary\":true,\"previous_transcript\":true}},\"agent_policies\":{\"key\":{\"timezone\":\"timezone\",\"retry\":{\"retry_delay_seconds\":600,\"max_short_retries\":1,\"max_total_calls\":6,\"max_callbacks\":2,\"max_redirects\":2,\"interval_placement\":\"start\",\"rotate_step_seconds\":900,\"max_consecutive_failures_per_number\":8},\"calling_periods\":[{\"weekdays\":[3],\"intervals\":[{\"start\":\"20:27\",\"end\":\"24:00\"}]}],\"data_collection\":{\"callback_time\":\"callback_time\",\"redirect_phone_number\":\"redirect_phone_number\",\"stop\":\"stop\",\"mappings\":{\"key\":\"mappings\"}},\"followup_context\":{\"call_type\":true,\"previous_conversation_id\":true,\"previous_summary\":true,\"previous_transcript\":true}}},\"whatsapp_voice_policy\":{\"timezone\":\"timezone\",\"retry\":{\"retry_delay_seconds\":600,\"max_short_retries\":1,\"max_total_calls\":6,\"max_callbacks\":2,\"max_redirects\":2,\"interval_placement\":\"start\",\"rotate_step_seconds\":900,\"max_consecutive_failures_per_number\":8},\"calling_periods\":[{\"weekdays\":[3],\"intervals\":[{\"start\":\"20:27\",\"end\":\"24:00\"}]}],\"data_collection\":{\"callback_time\":\"callback_time\",\"redirect_phone_number\":\"redirect_phone_number\",\"stop\":\"stop\",\"mappings\":{\"key\":\"mappings\"}},\"followup_context\":{\"call_type\":true,\"previous_conversation_id\":true,\"previous_summary\":true,\"previous_transcript\":true}}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WorkspaceConfigResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WorkspaceConfigResponse did not round-trip."
        );
    }
}
