using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.TopicSentimentAggregate</c>.
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
public class TopicSentimentAggregateTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"sentiment\":{\"count\":10,\"sum\":7.18,\"min\":0.12,\"max\":5.57},\"frustration\":{\"count\":10,\"sum\":7.18,\"min\":0.12,\"max\":5.57},\"positive_count\":4,\"neutral_count\":4,\"negative_count\":4}";

        var instance = TestJson.Deserialize<global::ElevenLabs.TopicSentimentAggregate>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.TopicSentimentAggregate did not round-trip."
        );
    }
}
