using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput</c>.
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
public class WorkflowStandaloneAgentNodeModelOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"type\":\"standalone_agent\",\"position\":{\"x\":1.11,\"y\":8.94},\"edge_order\":[\"edge_order\"],\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"node_id\":\"node_id\",\"delay_ms\":8,\"transfer_message\":\"transfer_message\",\"enable_transferred_agent_first_message\":false,\"preserve_client_tts_overrides\":false,\"preserve_voice_settings\":false}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WorkflowStandaloneAgentNodeModelOutput did not round-trip."
        );
    }
}
