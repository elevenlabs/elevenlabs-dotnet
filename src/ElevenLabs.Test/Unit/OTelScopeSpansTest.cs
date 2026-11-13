using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.OTelScopeSpans</c>.
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
public class OTelScopeSpansTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"scope\":{\"name\":\"name\",\"version\":\"version\"},\"spans\":[{\"traceId\":\"traceId\",\"spanId\":\"spanId\",\"parentSpanId\":\"parentSpanId\",\"name\":\"name\",\"kind\":1,\"startTimeUnixNano\":\"startTimeUnixNano\",\"endTimeUnixNano\":\"endTimeUnixNano\",\"attributes\":[{\"key\":\"key\",\"value\":{\"key\":\"officia\"}}],\"status\":{\"code\":10,\"message\":\"message\"}}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.OTelScopeSpans>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.OTelScopeSpans did not round-trip."
        );
    }
}
