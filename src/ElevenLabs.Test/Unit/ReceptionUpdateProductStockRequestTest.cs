using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.Products.ReceptionUpdateProductStockRequest</c>.
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
public class ReceptionUpdateProductStockRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"location_id\":\"location_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"on_hand\":24,\"expected_on_hand\":25}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Reception.Products.ReceptionUpdateProductStockRequest>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.Products.ReceptionUpdateProductStockRequest did not round-trip."
        );
    }
}
