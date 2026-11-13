using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationHistoryTranscriptToolCallCommonModelInput</c>.
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
public class ConversationHistoryTranscriptToolCallCommonModelInputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"type\":\"system\",\"request_id\":\"request_id\",\"tool_name\":\"tool_name\",\"tool_id\":\"tool_id\",\"params_as_json\":\"params_as_json\",\"tool_has_been_called\":true,\"tool_details\":{\"type\":\"webhook\",\"method\":\"method\",\"url\":\"url\",\"headers\":{\"key\":\"headers\"},\"path_params\":{\"key\":\"path_params\"},\"query_params\":{\"key\":\"query_params\"},\"body\":\"body\"}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.ConversationHistoryTranscriptToolCallCommonModelInput>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationHistoryTranscriptToolCallCommonModelInput did not round-trip."
        );
    }
}
