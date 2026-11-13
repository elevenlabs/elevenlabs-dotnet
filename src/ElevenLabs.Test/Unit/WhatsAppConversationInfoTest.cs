using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WhatsAppConversationInfo</c>.
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
public class WhatsAppConversationInfoTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"direction\":\"inbound\",\"whatsapp_phone_number_id\":\"whatsapp_phone_number_id\",\"whatsapp_user_id\":\"whatsapp_user_id\",\"awaiting_first_user_message\":false,\"recipient\":{\"phone\":\"phone\",\"bsuid\":\"bsuid\"},\"call_permission_request\":{\"state\":\"blocked\",\"requested_at_unix\":10,\"responded_at_unix\":6,\"permanent\":true,\"granted_by_user_call\":false},\"call_result\":\"answered\",\"opening_message\":{\"template_name\":\"template_name\",\"wamid\":\"wamid\",\"sent_at_unix\":3,\"delivered_at_unix\":0,\"read_at_unix\":8,\"replied_at_unix\":1,\"failed_at_unix\":1,\"error_code\":\"error_code\",\"pricing_category\":\"pricing_category\",\"billable\":false}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WhatsAppConversationInfo>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WhatsAppConversationInfo did not round-trip."
        );
    }
}
