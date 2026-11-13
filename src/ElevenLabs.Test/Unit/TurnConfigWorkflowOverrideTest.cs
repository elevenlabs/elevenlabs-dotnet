using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.TurnConfigWorkflowOverride</c>.
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
public class TurnConfigWorkflowOverrideTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"turn_timeout\":7,\"initial_wait_time\":0.68,\"silence_end_call_timeout\":2.77,\"turn_eagerness\":\"patient\",\"spelling_patience\":\"auto\",\"speculative_turn\":false,\"retranscribe_on_turn_timeout\":false,\"turn_model\":\"turn_v2\",\"interruption_ignore_terms\":[\"interruption_ignore_terms\"],\"interruption_ignore_term_languages\":[\"interruption_ignore_term_languages\"],\"merge_with_default_ignore_terms\":false,\"transcribe_on_disabled_interruptions\":true,\"soft_timeout_config\":{\"timeout_seconds\":9.54,\"message\":\"message\",\"additional_soft_timeout_messages\":[\"additional_soft_timeout_messages\"],\"use_llm_generated_message\":false,\"randomize_fillers\":false,\"max_soft_timeouts_per_generation\":1,\"llm_generated_message_prompt_override\":\"llm_generated_message_prompt_override\",\"disable_until_first_user_message\":false},\"noisy_environment_message\":\"noisy_environment_message\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.TurnConfigWorkflowOverride>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.TurnConfigWorkflowOverride did not round-trip."
        );
    }
}
