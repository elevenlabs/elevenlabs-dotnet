using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.BodyTextToSpeechStream</c>.
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
public class BodyTextToSpeechStreamTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"text\":\"This is a test for the API of ElevenLabs.\",\"model_id\":\"eleven_multilingual_v2\",\"language_code\":\"language_code\",\"voice_settings\":{\"stability\":0.62,\"use_speaker_boost\":true,\"similarity_boost\":0.18,\"style\":2.67,\"speed\":5.4,\"clone_strength\":0.53},\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}],\"seed\":1,\"previous_text\":\"previous_text\",\"next_text\":\"next_text\",\"previous_request_ids\":[\"previous_request_ids\"],\"next_request_ids\":[\"next_request_ids\"],\"use_pvc_as_ivc\":false,\"apply_text_normalization\":\"auto\",\"apply_language_text_normalization\":true,\"audio_effects\":{\"filter_preset_id\":\"filter_preset_id\",\"distance\":0.89,\"environment_id\":\"environment_id\",\"background_noise_id\":\"background_noise_id\",\"send_level\":1,\"pan\":-0.33}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.BodyTextToSpeechStream>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.BodyTextToSpeechStream did not round-trip."
        );
    }
}
