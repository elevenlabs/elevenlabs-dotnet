using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CampaignLeadsResponse</c>.
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
public class CampaignLeadsResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"leads\":[{\"lead_id\":\"lead_id\",\"recipient_id\":\"recipient_id\",\"phone_number\":\"phone_number\",\"phone_numbers\":[\"phone_numbers\"],\"phone_numbers_index\":6,\"user_id\":\"user_id\",\"attempt_count\":7,\"failure_count\":0,\"callback_count\":0,\"redirect_count\":1,\"do_not_call\":false,\"terminal_disposition\":\"campaign_ended\",\"created_at_unix\":3,\"updated_at_unix\":6,\"dynamic_variables\":{\"key\":{}},\"overrides\":{\"language\":\"language\",\"first_message\":\"first_message\",\"prompt\":\"prompt\",\"voice_id\":\"voice_id\"},\"delivery\":{\"status\":\"pending\",\"stage\":\"queued\",\"sent_at_unix\":3,\"delivered_at_unix\":4,\"read_at_unix\":8,\"replied_at_unix\":6,\"failed_at_unix\":4,\"error_message\":\"error_message\"}}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CampaignLeadsResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CampaignLeadsResponse did not round-trip."
        );
    }
}
