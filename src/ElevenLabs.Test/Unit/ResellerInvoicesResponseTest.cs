using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ResellerInvoicesResponse</c>.
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
public class ResellerInvoicesResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"invoices\":[{\"invoice_id\":\"invoice_id\",\"workspace_id\":\"workspace_id\",\"workspace_name\":\"workspace_name\",\"status\":\"paid\",\"amount_cents\":4,\"currency\":\"currency\",\"created_unix\":10,\"paid_unix\":6,\"pay_url\":\"pay_url\",\"pdf_url\":\"pdf_url\"}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ResellerInvoicesResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ResellerInvoicesResponse did not round-trip."
        );
    }
}
