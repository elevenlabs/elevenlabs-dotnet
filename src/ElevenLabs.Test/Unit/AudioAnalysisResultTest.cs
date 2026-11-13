using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AudioAnalysisResult</c>.
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
public class AudioAnalysisResultTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"title\":\"title\",\"description\":\"description\",\"content_type\":\"content_type\",\"overall_pacing\":\"overall_pacing\",\"segments\":[{\"start_ms\":3,\"end_ms\":8,\"description\":\"description\",\"segment_type\":\"segment_type\",\"has_speech\":false,\"has_music\":false,\"pacing\":\"pacing\"}],\"key_moments\":[{\"timestamp_ms\":0,\"type\":\"type\",\"description\":\"description\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AudioAnalysisResult>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AudioAnalysisResult did not round-trip."
        );
    }
}
