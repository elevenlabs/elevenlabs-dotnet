using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.PromptAgentApiModelOverrideOutput</c>.
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
public class PromptAgentApiModelOverrideOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"prompt\":\"prompt\",\"llm\":\"gpt-4o-mini\",\"reasoning_effort\":\"none\",\"tool_ids\":[\"tool_ids\"],\"tool_ids_strict\":true,\"native_mcp_server_ids\":[\"native_mcp_server_ids\"],\"knowledge_base\":[{\"type\":\"file\",\"name\":\"name\",\"id\":\"id\",\"usage_mode\":\"prompt\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.PromptAgentApiModelOverrideOutput>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.PromptAgentApiModelOverrideOutput did not round-trip."
        );
    }
}
