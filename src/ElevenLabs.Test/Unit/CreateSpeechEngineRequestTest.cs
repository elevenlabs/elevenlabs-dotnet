using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SpeechEngine.CreateSpeechEngineRequest</c>.
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
public class CreateSpeechEngineRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"Speech Engine\",\"speech_engine\":{\"ws_url\":\"ws_url\",\"request_headers\":{\"key\":\"qui dolor in\"}},\"asr\":{\"quality\":\"high\",\"provider\":\"elevenlabs\",\"user_input_audio_format\":\"pcm_8000\",\"keywords\":[\"keywords\"]},\"tts\":{\"model_id\":\"eleven_turbo_v2\",\"voice_id\":\"cjVigY5qzO86Huf0OWal\",\"supported_voices\":[{\"label\":\"label\",\"voice_id\":\"voice_id\",\"description\":\"description\",\"language\":\"language\",\"model_family\":\"turbo\",\"optimize_streaming_latency\":3,\"stability\":0.57,\"speed\":0.95,\"similarity_boost\":0.69,\"clone_strength\":0.88}],\"expressive_mode\":true,\"suggested_audio_tags\":[{\"tag\":\"tag\",\"description\":\"description\"}],\"agent_output_audio_format\":\"pcm_8000\",\"optimize_streaming_latency\":3,\"stability\":0.5,\"speed\":1,\"similarity_boost\":0.8,\"clone_strength\":0.24,\"text_normalisation_type\":\"system_prompt\",\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}],\"enable_phoneme_tags\":true,\"audio_effects\":{\"filter_preset_id\":\"filter_preset_id\",\"distance\":0.89,\"environment_id\":\"environment_id\",\"background_noise_id\":\"background_noise_id\",\"send_level\":1,\"pan\":-0.33}},\"turn\":{\"turn_timeout\":7,\"initial_wait_time\":1,\"silence_end_call_timeout\":-1,\"turn_eagerness\":\"patient\",\"spelling_patience\":\"auto\",\"speculative_turn\":true,\"retranscribe_on_turn_timeout\":false,\"turn_model\":\"turn_v2\",\"interruption_ignore_terms\":[\"interruption_ignore_terms\"],\"interruption_ignore_term_languages\":[\"interruption_ignore_term_languages\"],\"merge_with_default_ignore_terms\":false,\"transcribe_on_disabled_interruptions\":false},\"vad\":{},\"conversation\":{\"text_only\":true,\"max_duration_seconds\":600,\"client_events\":[\"conversation_initiation_metadata\"],\"file_input\":{\"enabled\":true,\"max_files_in_memory\":10,\"max_files_per_conversation\":10},\"monitoring_enabled\":true,\"monitoring_events\":[\"conversation_initiation_metadata\"],\"dtmf_input_settings\":{\"dtmf_input_timeout\":2,\"hash_terminator\":true,\"redact_input\":false},\"background_sound\":{\"source_type\":\"preset\",\"source_id\":\"office2\",\"volume\":0.15,\"crossfade_loop\":true},\"source_attribution\":false},\"privacy\":{\"record_voice\":true,\"retention_days\":-1,\"delete_transcript_and_pii\":true,\"delete_audio\":true,\"apply_to_existing_conversations\":true,\"zero_retention_mode\":false,\"conversation_history_redaction\":{\"enabled\":true,\"entities\":[\"name\"],\"excluded_data_collection_ids\":[\"excluded_data_collection_ids\"]}},\"call_limits\":{\"agent_concurrency_limit\":-1,\"daily_limit\":100000,\"bursting_enabled\":true},\"auth\":{\"enable_auth\":true},\"language\":\"en\",\"cascade_timeout_seconds\":4,\"tags\":[\"tags\"],\"overrides\":{\"first_message\":true}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.SpeechEngine.CreateSpeechEngineRequest>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SpeechEngine.CreateSpeechEngineRequest did not round-trip."
        );
    }
}
