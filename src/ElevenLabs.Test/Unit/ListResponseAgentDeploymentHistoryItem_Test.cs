using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ListResponseAgentDeploymentHistoryItem_</c>.
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
public class ListResponseAgentDeploymentHistoryItem_Test
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"meta\":{\"total\":7,\"page\":5,\"page_size\":10},\"results\":[{\"id\":\"id\",\"traffic_percentage_branch_id_map\":{\"key\":4.64},\"deployed_at_unix_secs\":1,\"is_active\":false,\"source\":\"manual\",\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"}}]}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.ListResponseAgentDeploymentHistoryItem_>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ListResponseAgentDeploymentHistoryItem_ did not round-trip."
        );
    }
}
