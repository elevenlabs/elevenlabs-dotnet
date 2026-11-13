using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ListResponseAgentBranchSummary_</c>.
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
public class ListResponseAgentBranchSummary_Test
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"meta\":{\"total\":0,\"page\":4,\"page_size\":8},\"results\":[{\"id\":\"id\",\"name\":\"name\",\"agent_id\":\"agent_id\",\"description\":\"description\",\"created_at\":2,\"last_committed_at\":6,\"is_archived\":false,\"protection_status\":\"writer_perms_required\",\"auto_rebase\":true,\"sync_status\":{\"last_attempt\":{\"outcome\":\"succeeded\",\"attempted_at\":9}},\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"current_live_percentage\":2.9,\"parent_branch_id\":\"parent_branch_id\",\"draft_exists\":false,\"draft_created_at\":4,\"draft_is_behind_tip\":false,\"calls_7d\":3,\"commits_ahead\":5,\"commits_behind\":5,\"merged_into_branch_id\":\"merged_into_branch_id\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ListResponseAgentBranchSummary_>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ListResponseAgentBranchSummary_ did not round-trip."
        );
    }
}
