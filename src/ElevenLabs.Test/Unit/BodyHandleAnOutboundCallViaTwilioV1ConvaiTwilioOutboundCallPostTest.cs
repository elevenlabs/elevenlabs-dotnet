using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Agents.BodyHandleAnOutboundCallViaTwilioV1ConvaiTwilioOutboundCallPost</c>.
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
public class BodyHandleAnOutboundCallViaTwilioV1ConvaiTwilioOutboundCallPostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"agent_id\":\"agent_id\",\"agent_phone_number_id\":\"agent_phone_number_id\",\"to_number\":\"to_number\",\"conversation_initiation_client_data\":{\"conversation_config_override\":{\"asr\":{\"keywords\":[\"keywords\"]},\"turn\":{\"soft_timeout_config\":{\"message\":\"message\",\"additional_soft_timeout_messages\":[\"additional_soft_timeout_messages\"]},\"noisy_environment_message\":\"noisy_environment_message\"},\"tts\":{\"model_id\":\"eleven_turbo_v2\",\"voice_id\":\"voice_id\",\"supported_voices\":[{\"label\":\"label\",\"voice_id\":\"voice_id\",\"description\":\"description\",\"language\":\"language\",\"model_family\":\"turbo\",\"optimize_streaming_latency\":3,\"stability\":0.58,\"speed\":1.04,\"similarity_boost\":0.07,\"clone_strength\":0.46}],\"stability\":6.04,\"speed\":4.81,\"similarity_boost\":2.65,\"clone_strength\":2.71,\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}]},\"conversation\":{\"text_only\":true,\"max_duration_seconds\":7},\"agent\":{\"first_message\":\"first_message\",\"language\":\"language\",\"max_conversation_duration_message\":\"max_conversation_duration_message\",\"prompt\":{\"prompt\":\"prompt\",\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"tool_ids\":[\"tool_ids\"],\"tool_ids_strict\":false,\"native_mcp_server_ids\":[\"native_mcp_server_ids\"],\"knowledge_base\":[{\"type\":\"file\",\"name\":\"name\",\"id\":\"id\",\"usage_mode\":\"prompt\"}]}}},\"custom_llm_extra_body\":{\"key\":{}},\"user_id\":\"user_id\",\"source_info\":{\"source\":\"unknown\",\"version\":\"version\"},\"branch_id\":\"branch_id\",\"environment\":\"environment\",\"starting_workflow_node_id\":\"starting_workflow_node_id\",\"procedure_ids\":[\"procedure_ids\"],\"start_procedure_ids\":[\"start_procedure_ids\"],\"dynamic_variables\":{\"key\":{}}},\"call_recording_enabled\":true,\"telephony_call_config\":{\"ringing_timeout_secs\":60,\"twilio_call_recording_enabled\":true,\"twilio_machine_detection\":{\"mode\":\"enable\",\"actions\":[{\"action\":\"hang_up\",\"answered_by\":[\"human\"]}]}}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Agents.BodyHandleAnOutboundCallViaTwilioV1ConvaiTwilioOutboundCallPost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Agents.BodyHandleAnOutboundCallViaTwilioV1ConvaiTwilioOutboundCallPost did not round-trip."
        );
    }
}
