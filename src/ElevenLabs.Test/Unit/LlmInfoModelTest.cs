using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.LlmInfoModel</c>.
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
public class LlmInfoModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"llm\":\"gpt-4o-mini\",\"is_checkpoint\":false,\"max_tokens_limit\":3,\"max_context_limit\":3,\"supports_image_input\":false,\"supports_document_input\":false,\"supports_parallel_tool_calls\":false,\"available_reasoning_efforts\":[\"none\"],\"available_service_tiers\":[\"standard\"],\"deprecation_info\":{\"llm\":\"gpt-4o-mini\",\"is_deprecated\":true,\"is_in_warning_period\":false,\"is_in_fallback_period\":false,\"fallback_percentage\":4,\"provider_deprecation_date\":\"2023-07-20T21:03:51.582Z\",\"replacement_model\":\"gpt-4o-mini\",\"deprecation_config\":{\"warning_start_days\":9,\"fallback_start_days\":4,\"fallback_complete_days\":0,\"fallback_start_percentage\":7,\"fallback_complete_percentage\":3}},\"regional_processing_surcharge\":{\"multiplier\":9.64}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.LlmInfoModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.LlmInfoModel did not round-trip."
        );
    }
}
