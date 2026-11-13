using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ToolExecutionResponseModel</c>.
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
public class ToolExecutionResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"tool_id\":\"tool_id\",\"tool_request_id\":\"tool_request_id\",\"conversation_id\":\"conversation_id\",\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"timestamp\":5.16,\"latency_secs\":7.93,\"is_error\":true,\"request_payload\":\"request_payload\",\"response_payload\":\"response_payload\",\"error_message\":\"error_message\",\"error_type\":\"error_type\",\"id\":\"id\",\"tool_call_details\":{\"type\":\"webhook\",\"method\":\"method\",\"url\":\"url\",\"headers\":{\"key\":\"headers\"},\"path_params\":{\"key\":\"path_params\"},\"query_params\":{\"key\":\"query_params\"},\"body\":\"body\"}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ToolExecutionResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ToolExecutionResponseModel did not round-trip."
        );
    }
}
