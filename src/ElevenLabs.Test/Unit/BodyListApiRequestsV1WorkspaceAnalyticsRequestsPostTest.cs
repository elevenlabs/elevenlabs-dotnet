using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Workspace.Analytics.BodyListApiRequestsV1WorkspaceAnalyticsRequestsPost</c>.
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
public class BodyListApiRequestsV1WorkspaceAnalyticsRequestsPostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"start_time\":2147483647,\"end_time\":2147483647,\"limit\":100,\"sort\":\"asc\",\"filters\":[{\"column\":\"column\",\"operation\":\"in\",\"values\":[\"veniam\"]}],\"search\":\"search\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Workspace.Analytics.BodyListApiRequestsV1WorkspaceAnalyticsRequestsPost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Workspace.Analytics.BodyListApiRequestsV1WorkspaceAnalyticsRequestsPost did not round-trip."
        );
    }
}
