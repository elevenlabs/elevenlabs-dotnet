using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetAudioNativeProjectSettingsResponseModel</c>.
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
public class GetAudioNativeProjectSettingsResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"enabled\":true,\"snapshot_id\":\"snapshot_id\",\"settings\":{\"title\":\"title\",\"image\":\"image\",\"author\":\"author\",\"small\":true,\"text_color\":\"text_color\",\"background_color\":\"background_color\",\"sessionization\":10,\"audio_path\":\"audio_path\",\"audio_url\":\"audio_url\",\"status\":\"processing\"}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.GetAudioNativeProjectSettingsResponseModel>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetAudioNativeProjectSettingsResponseModel did not round-trip."
        );
    }
}
