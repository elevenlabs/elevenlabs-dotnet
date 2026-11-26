using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ResellerInvoiceDetail</c>.
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
public class ResellerInvoiceDetailTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"invoice_id\":\"invoice_id\",\"workspace_id\":\"workspace_id\",\"workspace_name\":\"workspace_name\",\"status\":\"paid\",\"amount_cents\":10,\"currency\":\"currency\",\"created_unix\":2,\"paid_unix\":7,\"pay_url\":\"pay_url\",\"pdf_url\":\"pdf_url\",\"lines\":[{\"kind\":\"plan\",\"description\":\"description\",\"quantity\":2,\"amount_cents\":10,\"period_start_unix\":10,\"period_end_unix\":2}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ResellerInvoiceDetail>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ResellerInvoiceDetail did not round-trip."
        );
    }
}
