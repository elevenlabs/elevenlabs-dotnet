using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.StreamEnvelope</c>.
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
public class StreamEnvelopeTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"conversation_id\":\"conversation_id\",\"turn_id\":\"turn_id\",\"created_at_unix_ms\":3,\"event\":{\"type\":\"stream_ended\",\"stream_ended_event\":{\"status\":\"in_progress\",\"error\":{\"type\":\"type\",\"code\":\"code\",\"message\":\"message\"},\"required_actions\":[{\"type\":\"client_tool_call\",\"tool_call_id\":\"tool_call_id\",\"tool_name\":\"tool_name\",\"parameters\":{\"key\":{}}}]}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.StreamEnvelope>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.StreamEnvelope did not round-trip."
        );
    }
}
