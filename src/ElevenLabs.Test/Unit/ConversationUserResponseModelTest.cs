using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationUserResponseModel</c>.
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
public class ConversationUserResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"user_id\":\"user_id\",\"last_contact_unix_secs\":1,\"first_contact_unix_secs\":4,\"conversation_count\":9,\"last_contact_agent_id\":\"last_contact_agent_id\",\"last_contact_conversation_id\":\"last_contact_conversation_id\",\"last_contact_agent_name\":\"last_contact_agent_name\",\"sentiment\":{\"scored_conversation_count\":4,\"positive_count\":0,\"neutral_count\":7,\"negative_count\":3,\"average_sentiment_score\":9.64,\"average_frustration_score\":2.02,\"recent_scored_conversation_count\":4,\"recent_positive_count\":1,\"recent_neutral_count\":1,\"recent_negative_count\":5,\"recent_average_sentiment_score\":8.18,\"recent_average_frustration_score\":8.99},\"most_frustrated_conversations\":[{\"conversation_id\":\"conversation_id\",\"agent_id\":\"agent_id\",\"start_time_unix_secs\":3,\"overall_label\":\"positive\",\"overall_sentiment_score\":0.45,\"overall_frustration_score\":2.27}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ConversationUserResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationUserResponseModel did not round-trip."
        );
    }
}
