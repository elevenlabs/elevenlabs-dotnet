using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetConversationsPageResponseModel</c>.
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
public class GetConversationsPageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"conversations\":[{\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"version_id\":\"version_id\",\"agent_name\":\"agent_name\",\"conversation_id\":\"conversation_id\",\"start_time_unix_secs\":6,\"call_duration_secs\":7,\"cost\":3,\"cost_fiat\":0.9,\"message_count\":8,\"user_message_count\":5,\"agent_message_count\":4,\"status\":\"initiated\",\"termination_reason\":\"termination_reason\",\"call_successful\":\"success\",\"call_success_score\":4.3,\"transcript_summary\":\"transcript_summary\",\"call_summary_title\":\"call_summary_title\",\"main_language\":\"main_language\",\"conversation_initiation_source\":\"unknown\",\"tool_names\":[\"tool_names\"],\"direction\":\"inbound\",\"rating\":4.3,\"sentiment_analysis\":{\"overall_label\":\"positive\",\"overall_sentiment_score\":-0.52,\"overall_frustration_score\":0.88,\"min_user_sentiment_score\":0.63,\"max_user_frustration_score\":0.69,\"num_scored_user_turns\":2},\"data_collection_results\":{\"key\":{}},\"evaluation_criteria_results\":{\"key\":{\"result\":\"success\",\"score\":3,\"max_score\":6}},\"tag_ids\":[\"tag_ids\"]}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetConversationsPageResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetConversationsPageResponseModel did not round-trip."
        );
    }
}
