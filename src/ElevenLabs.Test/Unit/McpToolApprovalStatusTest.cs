using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.McpToolApprovalStatus</c>.
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
public class McpToolApprovalStatusTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"tool_id\":\"tool_id\",\"state\":\"up_to_date\",\"approval_policy\":\"auto_approved\",\"approved_definition\":{\"description\":\"description\",\"input_schema\":{\"key\":{}}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.McpToolApprovalStatus>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.McpToolApprovalStatus did not round-trip."
        );
    }
}
