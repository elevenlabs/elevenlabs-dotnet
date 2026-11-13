using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WorkspaceGroupResponseModel</c>.
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
public class WorkspaceGroupResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"name\",\"id\":\"id\",\"members\":[\"members\"],\"permissions\":[\"text_to_speech\"],\"group_usage_limit\":1,\"group_pvc_limit\":2,\"group_concurrency_limit\":9,\"group_dubbing_concurrency_limit\":0,\"group_music_concurrency_limit\":4,\"character_count\":0,\"is_scim_synced\":false,\"scim_group\":{\"scim_external_id\":\"scim_external_id\",\"display_name\":\"display_name\",\"created_at_unix\":9,\"updated_at_unix\":4,\"seat_type\":\"workspace_admin\"},\"scim_frozen\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WorkspaceGroupResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WorkspaceGroupResponseModel did not round-trip."
        );
    }
}
