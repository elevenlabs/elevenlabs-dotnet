using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetAgentConversationTicketsPageResponseModel</c>.
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
public class GetAgentConversationTicketsPageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"agent_conversation_tickets\":[{\"agentqa_ticket_id\":\"agentqa_ticket_id\",\"workspace_id\":\"workspace_id\",\"owner_user_id\":\"owner_user_id\",\"agent_id\":\"agent_id\",\"needs_clustering\":true,\"title\":\"title\",\"issue_type\":\"knowledge_gap\",\"labels\":[\"labels\"],\"conversation_ids\":[\"conversation_ids\"],\"first_seen_unix_secs\":9,\"last_seen_unix_secs\":1,\"qa_comment\":\"qa_comment\",\"ticket_comments\":[{\"comment\":\"comment\",\"created_at_unix_secs\":8,\"owner_user_id\":\"owner_user_id\"}],\"turn_comments\":[{\"turn_index\":7,\"comment\":\"comment\",\"created_at_unix_secs\":4,\"owner_user_id\":\"owner_user_id\"}],\"status\":\"open\",\"priority\":\"low\",\"priority_changes\":[{\"priority\":\"low\",\"changed_by_user_id\":\"changed_by_user_id\",\"changed_at_unix_secs\":10}],\"status_changes\":[{\"status\":\"open\",\"changed_by_user_id\":\"changed_by_user_id\",\"changed_at_unix_secs\":6}],\"merged_into_ticket_id\":\"merged_into_ticket_id\",\"source\":\"qa\",\"assignee_user_id\":\"assignee_user_id\",\"created_at_unix_secs\":2,\"updated_at_unix_secs\":5,\"search_match\":{\"field\":\"title\",\"snippet\":\"snippet\",\"highlight_start\":10,\"highlight_end\":2,\"turn_index\":3}}],\"next_cursor\":\"next_cursor\",\"has_more\":false}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.GetAgentConversationTicketsPageResponseModel>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetAgentConversationTicketsPageResponseModel did not round-trip."
        );
    }
}
