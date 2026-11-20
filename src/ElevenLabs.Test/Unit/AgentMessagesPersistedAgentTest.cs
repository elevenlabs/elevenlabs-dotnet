using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AgentMessagesPersistedAgent</c>.
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
public class AgentMessagesPersistedAgentTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"type\":\"persisted\",\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"overrides\":{\"prompt\":\"prompt\",\"llm\":\"gpt-4o-mini\",\"language\":\"language\",\"tool_ids\":[\"tool_ids\"],\"native_mcp_server_ids\":[\"native_mcp_server_ids\"],\"knowledge_base_ids\":[\"knowledge_base_ids\"],\"procedure_ids\":[\"procedure_ids\"],\"custom_llm_extra_body\":{\"key\":{}}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AgentMessagesPersistedAgent>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AgentMessagesPersistedAgent did not round-trip."
        );
    }
}
