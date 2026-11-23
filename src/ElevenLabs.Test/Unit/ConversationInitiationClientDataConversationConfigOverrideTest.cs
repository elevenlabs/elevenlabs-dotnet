using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationInitiationClientDataConversationConfigOverride</c>.
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
public class ConversationInitiationClientDataConversationConfigOverrideTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"asr\":{\"keywords\":[\"keywords\"]},\"turn\":{\"soft_timeout_config\":{\"message\":\"message\",\"additional_soft_timeout_messages\":[\"additional_soft_timeout_messages\"]},\"noisy_environment_message\":\"noisy_environment_message\"},\"tts\":{\"model_id\":\"eleven_turbo_v2\",\"voice_id\":\"voice_id\",\"supported_voices\":[{\"label\":\"label\",\"voice_id\":\"voice_id\",\"description\":\"description\",\"language\":\"language\",\"model_family\":\"turbo\",\"optimize_streaming_latency\":3,\"stability\":0.14,\"speed\":0.9,\"similarity_boost\":0.5,\"clone_strength\":0.27}],\"stability\":7.1,\"speed\":2.87,\"similarity_boost\":9.26,\"clone_strength\":7.12,\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}]},\"conversation\":{\"text_only\":false,\"max_duration_seconds\":6},\"agent\":{\"first_message\":\"first_message\",\"language\":\"language\",\"max_conversation_duration_message\":\"max_conversation_duration_message\",\"prompt\":{\"prompt\":\"prompt\",\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"tool_ids\":[\"tool_ids\"],\"tool_ids_strict\":false,\"native_mcp_server_ids\":[\"native_mcp_server_ids\"],\"knowledge_base\":[{\"type\":\"file\",\"name\":\"name\",\"id\":\"id\",\"usage_mode\":\"prompt\"}]}}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.ConversationInitiationClientDataConversationConfigOverride>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationInitiationClientDataConversationConfigOverride did not round-trip."
        );
    }
}
