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
            "{\"dev_discount\":false,\"is_burst\":true,\"tier\":\"tier\",\"llm_usage\":{\"irreversible_generation\":{\"model_usage\":{\"key\":{\"input\":{\"tokens\":0,\"price\":9.52},\"input_cache_read\":{\"tokens\":0,\"price\":9.52},\"input_cache_write\":{\"tokens\":0,\"price\":9.52},\"output_total\":{\"tokens\":0,\"price\":9.52}}}},\"initiated_generation\":{\"model_usage\":{\"key\":{\"input\":{\"tokens\":0,\"price\":9.52},\"input_cache_read\":{\"tokens\":0,\"price\":9.52},\"input_cache_write\":{\"tokens\":0,\"price\":9.52},\"output_total\":{\"tokens\":0,\"price\":9.52}}}}},\"llm_price\":6.57,\"llm_charge\":6,\"call_charge\":1,\"platform_charge\":0,\"platform_usage\":{\"category_usage\":{\"key\":{\"credits\":4,\"price\":4.4,\"quantity\":7.51}}},\"platform_price\":5.32,\"free_minutes_consumed\":7.99,\"free_llm_dollars_consumed\":2.41,\"tts_usage\":{\"primary_tts_model\":\"primary_tts_model\",\"total_audio_output_seconds\":6.2,\"total_characters\":6,\"per_voice_usage\":[{\"voice_id\":\"voice_id\",\"audio_output_seconds\":4.06}]},\"asr_usage\":{\"asr_model\":\"asr_model\",\"total_transcription_calls\":0,\"total_audio_input_seconds\":6.11},\"analysis\":{\"total\":{\"price\":0.83,\"charge\":3,\"runs\":3,\"price_per_feature\":{\"key\":9.79},\"charge_per_feature\":{\"key\":9}},\"last_run\":{\"price\":9.44,\"charge\":5,\"price_per_feature\":{\"key\":5.33},\"charge_per_feature\":{\"key\":10}}},\"voice_surcharge_charge\":0}";

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
