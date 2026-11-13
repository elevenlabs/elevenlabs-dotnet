using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.TestRunResultSummary</c>.
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
public class TestRunResultSummaryTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"test_id\":\"test_id\",\"test_name\":\"test_name\",\"workflow_node_id\":\"workflow_node_id\",\"buckets\":[{\"test_run_ids\":[\"test_run_ids\"],\"title\":\"title\",\"reason\":\"reason\",\"status\":\"pending\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.TestRunResultSummary>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.TestRunResultSummary did not round-trip."
        );
    }
}
