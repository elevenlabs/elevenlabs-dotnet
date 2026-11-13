using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Studio.BodyUpdateStudioProjectV1StudioProjectsProjectIdPost</c>.
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
public class BodyUpdateStudioProjectV1StudioProjectsProjectIdPostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"Project 1\",\"default_title_voice_id\":\"21m00Tcm4TlvDq8ikWAM\",\"default_paragraph_voice_id\":\"21m00Tcm4TlvDq8ikWAM\",\"title\":\"title\",\"author\":\"author\",\"isbn_number\":\"isbn_number\",\"volume_normalization\":false}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Studio.BodyUpdateStudioProjectV1StudioProjectsProjectIdPost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Studio.BodyUpdateStudioProjectV1StudioProjectsProjectIdPost did not round-trip."
        );
    }
}
