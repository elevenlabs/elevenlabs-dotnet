using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AudioEffectsCatalogResponseModel</c>.
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
public class AudioEffectsCatalogResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"filter_presets\":[{\"filter_preset_id\":\"filter_preset_id\",\"name\":\"name\",\"description\":\"description\"}],\"environments\":[{\"environment_id\":\"environment_id\",\"name\":\"name\",\"description\":\"description\"}],\"background_noises\":[{\"background_noise_id\":\"background_noise_id\",\"name\":\"name\",\"description\":\"description\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AudioEffectsCatalogResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AudioEffectsCatalogResponseModel did not round-trip."
        );
    }
}
