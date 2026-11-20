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
            "{\"conversation_config_override\":{\"asr\":{\"keywords\":true},\"turn\":{\"soft_timeout_config\":{\"message\":true,\"additional_soft_timeout_messages\":true},\"noisy_environment_message\":false},\"tts\":{\"model_id\":true,\"voice_id\":true,\"supported_voices\":false,\"stability\":false,\"speed\":false,\"similarity_boost\":true,\"clone_strength\":true,\"pronunciation_dictionary_locators\":false},\"conversation\":{\"text_only\":true,\"max_duration_seconds\":true},\"agent\":{\"first_message\":false,\"language\":false,\"max_conversation_duration_message\":true,\"prompt\":{\"prompt\":true,\"llm\":false,\"reasoning_effort\":true,\"tool_ids\":false,\"tool_ids_strict\":true,\"native_mcp_server_ids\":false,\"knowledge_base\":true}}},\"custom_llm_extra_body\":false,\"enable_conversation_initiation_client_data_from_webhook\":true,\"enable_starting_workflow_node_id_from_client\":false,\"enable_procedure_ids_from_client\":true}";

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
