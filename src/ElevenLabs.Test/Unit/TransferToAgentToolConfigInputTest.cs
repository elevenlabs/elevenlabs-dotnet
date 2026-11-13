using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.TransferToAgentToolConfigInput</c>.
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
public class TransferToAgentToolConfigInputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"system_tool_type\":\"transfer_to_agent\",\"transfers\":[{\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"node_id\":\"node_id\",\"condition\":\"condition\",\"delay_ms\":3,\"transfer_message\":\"transfer_message\",\"enable_transferred_agent_first_message\":true,\"is_workflow_node_transfer\":true,\"preserve_client_tts_overrides\":false,\"preserve_voice_settings\":true}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.TransferToAgentToolConfigInput>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.TransferToAgentToolConfigInput did not round-trip."
        );
    }
}
