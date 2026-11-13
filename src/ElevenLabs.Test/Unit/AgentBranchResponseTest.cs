using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AgentBranchResponse</c>.
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
public class AgentBranchResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"id\",\"name\":\"name\",\"agent_id\":\"agent_id\",\"description\":\"description\",\"created_at\":10,\"last_committed_at\":1,\"is_archived\":false,\"protection_status\":\"writer_perms_required\",\"auto_rebase\":true,\"sync_status\":{\"last_attempt\":{\"outcome\":\"succeeded\",\"attempted_at\":9}},\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"current_live_percentage\":1.84,\"parent_branch\":{\"id\":\"id\",\"name\":\"name\"},\"most_recent_versions\":[{\"id\":\"id\",\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"version_description\":\"version_description\",\"seq_no_in_branch\":6,\"time_committed_secs\":7,\"parents\":{\"in_branch_parent_id\":\"in_branch_parent_id\",\"out_of_branch_parent_id\":\"out_of_branch_parent_id\",\"merged_into_branch_id\":\"merged_into_branch_id\",\"merged_from_branch_id\":\"merged_from_branch_id\",\"merged_from_version_id\":\"merged_from_version_id\",\"rebased_from_version_id\":\"rebased_from_version_id\"},\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"merged_authors\":[{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"}]}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AgentBranchResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AgentBranchResponse did not round-trip."
        );
    }
}
