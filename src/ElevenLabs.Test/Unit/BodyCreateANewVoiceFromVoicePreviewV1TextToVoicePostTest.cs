using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.BodyCreateANewVoiceFromVoicePreviewV1TextToVoicePost</c>.
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
public class BodyCreateANewVoiceFromVoicePreviewV1TextToVoicePostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"voice_name\":\"Sassy squeaky mouse\",\"voice_description\":\"A sassy squeaky mouse\",\"generated_voice_id\":\"37HceQefKmEi3bGovXjL\",\"labels\":{\"key\":\"labels\"},\"played_not_selected_voice_ids\":[\"played_not_selected_voice_ids\"]}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.BodyCreateANewVoiceFromVoicePreviewV1TextToVoicePost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.BodyCreateANewVoiceFromVoicePreviewV1TextToVoicePost did not round-trip."
        );
    }
}
