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
            "{\"topics\":[{\"topic_id\":\"topic_id\",\"label\":\"label\",\"description\":\"description\",\"conversation_count\":2,\"parent_topic_id\":\"parent_topic_id\",\"x_2d\":2.5,\"y_2d\":3.56,\"metrics\":{\"conversation_count\":7,\"sentiment\":{\"sentiment\":{\"count\":0,\"sum\":7.83,\"min\":2.07,\"max\":0.43},\"frustration\":{\"count\":0,\"sum\":7.83,\"min\":2.07,\"max\":0.43},\"positive_count\":5,\"neutral_count\":7,\"negative_count\":10},\"evaluation_criteria\":[{\"criteria_id\":\"criteria_id\",\"success_count\":2,\"failure_count\":4,\"unknown_count\":5}]},\"success_rate\":5.33}],\"window_start_unix_secs\":6,\"window_end_unix_secs\":8,\"aggregated_run_count\":3,\"has_more\":true,\"next_cursor\":\"next_cursor\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetAgentTopicsResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetAgentTopicsResponseModel did not round-trip."
        );
    }
}
