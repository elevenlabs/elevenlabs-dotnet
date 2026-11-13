using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CommittedTranscriptWithTimestamps</c>.
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
public class CommittedTranscriptWithTimestampsTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"message_type\":\"committed_transcript_with_timestamps\",\"text\":\"text\",\"language_code\":\"language_code\",\"words\":[{\"text\":\"text\",\"start\":4.5,\"end\":4.19,\"type\":\"word\",\"speaker_id\":\"speaker_id\",\"logprob\":8.51,\"characters\":[{\"text\":\"text\",\"start\":1.08,\"end\":7.56}],\"channel_index\":3}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CommittedTranscriptWithTimestamps>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CommittedTranscriptWithTimestamps did not round-trip."
        );
    }
}
