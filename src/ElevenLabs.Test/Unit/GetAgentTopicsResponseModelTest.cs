using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetAgentTopicsResponseModel</c>.
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
public class GetAgentTopicsResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"topics\":[{\"topic_id\":\"topic_id\",\"label\":\"label\",\"description\":\"description\",\"conversation_count\":8,\"parent_topic_id\":\"parent_topic_id\",\"x_2d\":0.89,\"y_2d\":7.27,\"metrics\":{\"conversation_count\":0,\"sentiment\":{\"sentiment\":{\"count\":10,\"sum\":7.18,\"min\":0.12,\"max\":5.57},\"frustration\":{\"count\":10,\"sum\":7.18,\"min\":0.12,\"max\":5.57},\"positive_count\":4,\"neutral_count\":4,\"negative_count\":4},\"evaluation_criteria\":[{\"criteria_id\":\"criteria_id\",\"success_count\":2,\"failure_count\":8,\"unknown_count\":0}]},\"success_rate\":5.39}],\"window_start_unix_secs\":10,\"window_end_unix_secs\":9,\"aggregated_run_count\":0,\"has_more\":false,\"next_cursor\":\"next_cursor\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetAgentTopicsResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetAgentTopicsResponseModel did not round-trip."
        );
    }
}
