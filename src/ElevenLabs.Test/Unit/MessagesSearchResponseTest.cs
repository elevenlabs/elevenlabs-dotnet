using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.MessagesSearchResponse</c>.
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
public class MessagesSearchResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"meta\":{\"total\":0,\"page\":4,\"page_size\":8},\"results\":[{\"conversation_id\":\"conversation_id\",\"agent_id\":\"agent_id\",\"agent_name\":\"agent_name\",\"transcript_index\":2,\"chunk_text\":\"chunk_text\",\"chunk_highlights\":[{\"value\":\"value\",\"is_hit\":true}],\"score\":8.04,\"conversation_start_time_unix_secs\":7}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.MessagesSearchResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.MessagesSearchResponse did not round-trip."
        );
    }
}
