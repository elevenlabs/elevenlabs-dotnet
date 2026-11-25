using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetConversationUsersPageResponseModel</c>.
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
public class GetConversationUsersPageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"users\":[{\"user_id\":\"user_id\",\"last_contact_unix_secs\":2,\"first_contact_unix_secs\":8,\"conversation_count\":10,\"last_contact_agent_id\":\"last_contact_agent_id\",\"last_contact_conversation_id\":\"last_contact_conversation_id\",\"last_contact_agent_name\":\"last_contact_agent_name\",\"sentiment\":{\"scored_conversation_count\":0,\"positive_count\":3,\"neutral_count\":7,\"negative_count\":8,\"average_sentiment_score\":9.28,\"average_frustration_score\":9.85,\"recent_scored_conversation_count\":3,\"recent_positive_count\":8,\"recent_neutral_count\":1,\"recent_negative_count\":0,\"recent_average_sentiment_score\":5.66,\"recent_average_frustration_score\":7.01},\"most_frustrated_conversations\":[{\"conversation_id\":\"conversation_id\",\"agent_id\":\"agent_id\",\"start_time_unix_secs\":7,\"overall_label\":\"positive\",\"overall_sentiment_score\":5.86,\"overall_frustration_score\":8.44}]}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.GetConversationUsersPageResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetConversationUsersPageResponseModel did not round-trip."
        );
    }
}
