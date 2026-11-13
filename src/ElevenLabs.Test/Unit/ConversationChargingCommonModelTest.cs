using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationChargingCommonModel</c>.
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
public class ConversationChargingCommonModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"dev_discount\":false,\"is_burst\":true,\"tier\":\"tier\",\"llm_usage\":{\"irreversible_generation\":{\"model_usage\":{\"key\":{\"input\":{\"tokens\":10,\"price\":7.64},\"input_cache_read\":{\"tokens\":10,\"price\":7.64},\"input_cache_write\":{\"tokens\":10,\"price\":7.64},\"output_total\":{\"tokens\":10,\"price\":7.64}}}},\"initiated_generation\":{\"model_usage\":{\"key\":{\"input\":{\"tokens\":10,\"price\":7.64},\"input_cache_read\":{\"tokens\":10,\"price\":7.64},\"input_cache_write\":{\"tokens\":10,\"price\":7.64},\"output_total\":{\"tokens\":10,\"price\":7.64}}}}},\"llm_price\":9.32,\"llm_charge\":0,\"call_charge\":3,\"platform_charge\":7,\"platform_usage\":{\"category_usage\":{\"key\":{\"credits\":8,\"price\":9.28,\"quantity\":9.85}}},\"platform_price\":2.95,\"free_minutes_consumed\":7.52,\"free_llm_dollars_consumed\":1.24,\"tts_usage\":{\"primary_tts_model\":\"primary_tts_model\",\"total_audio_output_seconds\":0.77,\"total_characters\":6,\"per_voice_usage\":[{\"voice_id\":\"voice_id\",\"audio_output_seconds\":7.01}]},\"asr_usage\":{\"asr_model\":\"asr_model\",\"total_transcription_calls\":7,\"total_audio_input_seconds\":5.86},\"analysis\":{\"total\":{\"price\":8.44,\"charge\":7,\"runs\":3,\"price_per_feature\":{\"key\":9.94},\"charge_per_feature\":{\"key\":7}},\"last_run\":{\"price\":6.97,\"charge\":10,\"price_per_feature\":{\"key\":4.46},\"charge_per_feature\":{\"key\":3}}},\"voice_surcharge_charge\":10}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ConversationChargingCommonModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationChargingCommonModel did not round-trip."
        );
    }
}
