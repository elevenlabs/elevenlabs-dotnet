using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.DiarizedTranscriptWordsItem</c>.
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
public class DiarizedTranscriptWordsItemTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"text\":\"text\",\"start\":5.6,\"end\":8.47,\"type\":\"word\",\"speaker_id\":\"speaker_id\",\"logprob\":5.89,\"characters\":[{\"text\":\"text\",\"start\":7.59,\"end\":9.22}],\"channel_index\":10}";

        var instance = TestJson.Deserialize<global::ElevenLabs.DiarizedTranscriptWordsItem>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.DiarizedTranscriptWordsItem did not round-trip."
        );
    }
}
