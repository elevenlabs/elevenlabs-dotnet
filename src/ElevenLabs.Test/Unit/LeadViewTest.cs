using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.LeadView</c>.
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
public class LeadViewTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"lead_id\":\"lead_id\",\"recipient_id\":\"recipient_id\",\"phone_number\":\"phone_number\",\"phone_numbers\":[\"phone_numbers\"],\"phone_numbers_index\":6,\"user_id\":\"user_id\",\"attempt_count\":1,\"failure_count\":9,\"callback_count\":2,\"redirect_count\":10,\"do_not_call\":false,\"terminal_disposition\":\"campaign_ended\",\"created_at_unix\":3,\"updated_at_unix\":9,\"dynamic_variables\":{\"key\":{}},\"overrides\":{\"language\":\"language\",\"first_message\":\"first_message\",\"prompt\":\"prompt\",\"voice_id\":\"voice_id\"},\"delivery\":{\"status\":\"pending\",\"stage\":\"queued\",\"sent_at_unix\":10,\"delivered_at_unix\":4,\"read_at_unix\":0,\"replied_at_unix\":7,\"failed_at_unix\":7,\"error_message\":\"error_message\"}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.LeadView>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.LeadView did not round-trip."
        );
    }
}
