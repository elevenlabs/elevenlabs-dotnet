using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Workspace.BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePost</c>.
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
public class BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"start_time\":2147483647,\"end_time\":2147483647,\"interval_seconds\":60,\"group_by\":[\"product_type\"],\"filters\":[{\"column\":\"column\",\"operation\":\"in\",\"values\":[\"veniam\"]}],\"time_zone\":\"UTC\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Workspace.BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Workspace.BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePost did not round-trip."
        );
    }
}
