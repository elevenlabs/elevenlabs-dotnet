using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationTurn</c>.
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
public class ConversationTurnTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"turn_id\":\"turn_id\",\"status\":\"in_progress\",\"output\":[{\"type\":\"text\",\"role\":\"agent\",\"id\":\"id\",\"text\":\"text\",\"created_at_unix_ms\":1}],\"error\":{\"type\":\"type\",\"code\":\"code\",\"message\":\"message\"},\"required_actions\":[{\"type\":\"client_tool_call\",\"tool_call_id\":\"tool_call_id\",\"tool_name\":\"tool_name\",\"parameters\":{\"key\":{}}}],\"stream_cursor\":\"stream_cursor\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ConversationTurn>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationTurn did not round-trip."
        );
    }
}
