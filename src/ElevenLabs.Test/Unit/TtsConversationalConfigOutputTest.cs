using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.TtsConversationalConfigOutput</c>.
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
public class TtsConversationalConfigOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"model_id\":\"eleven_turbo_v2\",\"voice_id\":\"cjVigY5qzO86Huf0OWal\",\"supported_voices\":[{\"label\":\"label\",\"voice_id\":\"voice_id\",\"description\":\"description\",\"language\":\"language\",\"model_family\":\"turbo\",\"optimize_streaming_latency\":3,\"stability\":0.58,\"speed\":1.04,\"similarity_boost\":0.07,\"clone_strength\":0.46}],\"expressive_mode\":true,\"suggested_audio_tags\":[{\"tag\":\"tag\",\"description\":\"description\"}],\"agent_output_audio_format\":\"pcm_8000\",\"optimize_streaming_latency\":3,\"stability\":0.5,\"speed\":1,\"similarity_boost\":0.8,\"clone_strength\":0.06,\"text_normalisation_type\":\"system_prompt\",\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}],\"enable_phoneme_tags\":true,\"audio_effects\":{\"filter_preset_id\":\"filter_preset_id\",\"distance\":0.89,\"environment_id\":\"environment_id\",\"background_noise_id\":\"background_noise_id\",\"send_level\":1,\"pan\":0.13}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.TtsConversationalConfigOutput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.TtsConversationalConfigOutput did not round-trip."
        );
    }
}
