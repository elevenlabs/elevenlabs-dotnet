using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationInitiationClientDataConfigOutput</c>.
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
public class ConversationInitiationClientDataConfigOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"conversation_config_override\":{\"asr\":{\"keywords\":true},\"turn\":{\"soft_timeout_config\":{\"message\":false,\"additional_soft_timeout_messages\":false},\"noisy_environment_message\":true},\"tts\":{\"model_id\":true,\"voice_id\":false,\"supported_voices\":true,\"stability\":true,\"speed\":false,\"similarity_boost\":true,\"clone_strength\":false,\"pronunciation_dictionary_locators\":true},\"conversation\":{\"text_only\":true,\"max_duration_seconds\":true},\"agent\":{\"first_message\":false,\"language\":true,\"max_conversation_duration_message\":false,\"prompt\":{\"prompt\":true,\"llm\":false,\"reasoning_effort\":true,\"tool_ids\":true,\"tool_ids_strict\":false,\"native_mcp_server_ids\":true,\"knowledge_base\":true}}},\"custom_llm_extra_body\":false,\"enable_conversation_initiation_client_data_from_webhook\":false,\"enable_starting_workflow_node_id_from_client\":true,\"enable_procedure_ids_from_client\":true}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.ConversationInitiationClientDataConfigOutput>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationInitiationClientDataConfigOutput did not round-trip."
        );
    }
}
