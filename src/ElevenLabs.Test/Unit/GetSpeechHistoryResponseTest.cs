using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetSpeechHistoryResponse</c>.
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
public class GetSpeechHistoryResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"history\":[{\"history_item_id\":\"history_item_id\",\"request_id\":\"request_id\",\"voice_id\":\"voice_id\",\"model_id\":\"model_id\",\"voice_name\":\"voice_name\",\"voice_category\":\"premade\",\"text\":\"text\",\"date_unix\":9,\"character_count_change_from\":8,\"character_count_change_to\":2,\"content_type\":\"content_type\",\"state\":{},\"settings\":{\"key\":{}},\"share_link_id\":\"share_link_id\",\"source\":\"TTS\",\"alignments\":{\"alignment\":{\"characters\":[\"characters\"],\"character_start_times_seconds\":[3.34],\"character_end_times_seconds\":[6.14]},\"normalized_alignment\":{\"characters\":[\"characters\"],\"character_start_times_seconds\":[3.34],\"character_end_times_seconds\":[6.14]}},\"dialogue\":[{\"text\":\"text\",\"voice_id\":\"voice_id\",\"voice_name\":\"voice_name\"}],\"output_format\":\"output_format\"}],\"last_history_item_id\":\"last_history_item_id\",\"has_more\":true,\"scanned_until\":1}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetSpeechHistoryResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetSpeechHistoryResponse did not round-trip."
        );
    }
}
