using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Model</c>.
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
public class ModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"model_id\":\"model_id\",\"name\":\"name\",\"can_be_finetuned\":true,\"can_do_text_to_speech\":false,\"can_do_voice_conversion\":true,\"can_use_style\":false,\"can_use_speaker_boost\":false,\"serves_pro_voices\":false,\"token_cost_factor\":1.83,\"description\":\"description\",\"requires_alpha_access\":false,\"max_characters_request_free_user\":0,\"max_characters_request_subscribed_user\":4,\"maximum_text_length_per_request\":0,\"languages\":[{\"language_id\":\"language_id\",\"name\":\"name\"}],\"model_rates\":{\"character_cost_multiplier\":9.89,\"cost_discount_multiplier\":1},\"concurrency_group\":\"concurrency_group\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.Model>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(wire, serialized, "global::ElevenLabs.Model did not round-trip.");
    }
}
