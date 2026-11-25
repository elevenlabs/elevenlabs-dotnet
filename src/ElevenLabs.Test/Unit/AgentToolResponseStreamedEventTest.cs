using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AgentToolResponseStreamedEvent</c>.
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
public class AgentToolResponseStreamedEventTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"agent_tool_response\":{\"tool_name\":\"tool_name\",\"tool_call_id\":\"tool_call_id\",\"tool_type\":\"tool_type\",\"is_error\":false,\"is_blocked\":false,\"event_id\":9,\"is_called\":true},\"type\":\"agent_tool_response\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AgentToolResponseStreamedEvent>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AgentToolResponseStreamedEvent did not round-trip."
        );
    }
}
