using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.InvoiceResponse</c>.
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
public class InvoiceResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"amount_due_cents\":5,\"subtotal_cents\":1,\"tax_cents\":2,\"discount_percent_off\":7.07,\"discount_amount_off\":2.43,\"discounts\":[{\"discount_percent_off\":3.85,\"discount_amount_off\":9.06}],\"next_payment_attempt_unix\":7,\"payment_intent_status\":\"canceled\",\"payment_intent_statusses\":[\"canceled\"]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.InvoiceResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.InvoiceResponse did not round-trip."
        );
    }
}
