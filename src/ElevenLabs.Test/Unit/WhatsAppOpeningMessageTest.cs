using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WhatsAppOpeningMessage</c>.
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
public class WhatsAppOpeningMessageTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"template_name\":\"template_name\",\"wamid\":\"wamid\",\"sent_at_unix\":3,\"delivered_at_unix\":0,\"read_at_unix\":8,\"replied_at_unix\":1,\"failed_at_unix\":1,\"error_code\":\"error_code\",\"pricing_category\":\"pricing_category\",\"billable\":false}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WhatsAppOpeningMessage>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WhatsAppOpeningMessage did not round-trip."
        );
    }
}
