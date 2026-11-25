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
            "{\"dev_discount\":true,\"is_burst\":false,\"tier\":\"tier\",\"llm_usage\":{\"irreversible_generation\":{\"model_usage\":{\"key\":{\"input\":{\"tokens\":4,\"price\":4.4},\"input_cache_read\":{\"tokens\":4,\"price\":4.4},\"input_cache_write\":{\"tokens\":4,\"price\":4.4},\"output_total\":{\"tokens\":4,\"price\":4.4},\"output_total_reasoning_portion\":{\"tokens\":4,\"price\":4.4}}}},\"initiated_generation\":{\"model_usage\":{\"key\":{\"input\":{\"tokens\":4,\"price\":4.4},\"input_cache_read\":{\"tokens\":4,\"price\":4.4},\"input_cache_write\":{\"tokens\":4,\"price\":4.4},\"output_total\":{\"tokens\":4,\"price\":4.4},\"output_total_reasoning_portion\":{\"tokens\":4,\"price\":4.4}}}}},\"llm_price\":8.23,\"llm_charge\":2,\"call_charge\":5,\"platform_charge\":10,\"platform_usage\":{\"category_usage\":{\"key\":{\"credits\":4,\"price\":8.87,\"quantity\":0.18}}},\"platform_price\":1.31,\"free_minutes_consumed\":1.11,\"free_llm_dollars_consumed\":0.44,\"tts_usage\":{\"primary_tts_model\":\"primary_tts_model\",\"total_audio_output_seconds\":3.91,\"total_characters\":2,\"per_voice_usage\":[{\"voice_id\":\"voice_id\",\"audio_output_seconds\":3.7}]},\"asr_usage\":{\"asr_model\":\"asr_model\",\"total_transcription_calls\":3,\"total_audio_input_seconds\":0.72},\"analysis\":{\"total\":{\"price\":9.34,\"charge\":5,\"runs\":3,\"price_per_feature\":{\"key\":9.25},\"charge_per_feature\":{\"key\":10}},\"last_run\":{\"price\":9.12,\"charge\":4,\"price_per_feature\":{\"key\":6.52},\"charge_per_feature\":{\"key\":5}}},\"voice_surcharge_charge\":7}";

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
