using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ProjectVoiceResponseModel</c>.
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
public class ProjectVoiceResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"project_voice_ref_id\":\"project_voice_ref_id\",\"voice_id\":\"voice_id\",\"alias\":\"alias\",\"stability\":6.82,\"similarity_boost\":9.03,\"style\":7.34,\"is_pinned\":true,\"use_speaker_boost\":false,\"volume_gain\":7.87,\"speed\":9.19}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ProjectVoiceResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ProjectVoiceResponseModel did not round-trip."
        );
    }
}
