using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.VideoAnalysisResult</c>.
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
public class VideoAnalysisResultTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"title\":\"title\",\"description\":\"description\",\"content_type\":\"content_type\",\"overall_pacing\":\"overall_pacing\",\"subjects\":[{\"name\":\"name\",\"description\":\"description\"}],\"segments\":[{\"start_ms\":4,\"end_ms\":9,\"description\":\"description\",\"subjects\":[\"subjects\"],\"shot_type\":\"shot_type\",\"camera_movement\":\"camera_movement\",\"transition_in\":\"transition_in\",\"has_speech\":true,\"has_music\":false,\"pacing\":\"pacing\"}],\"key_moments\":[{\"timestamp_ms\":6,\"type\":\"type\",\"description\":\"description\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.VideoAnalysisResult>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.VideoAnalysisResult did not round-trip."
        );
    }
}
