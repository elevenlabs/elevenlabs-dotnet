using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AgentResponseCorrectionAgentResponseCorrectionEvent</c>.
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
public class AgentResponseCorrectionAgentResponseCorrectionEventTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"original_agent_response\":\"original_agent_response\",\"corrected_agent_response\":\"corrected_agent_response\",\"event_id\":0,\"response_id\":\"response_id\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.AgentResponseCorrectionAgentResponseCorrectionEvent>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AgentResponseCorrectionAgentResponseCorrectionEvent did not round-trip."
        );
    }
}
