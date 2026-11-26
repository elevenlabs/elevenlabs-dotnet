using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionServicePromotion</c>.
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
public class ReceptionServicePromotionTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"promo_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"name\":\"deserunt\",\"target\":\"service\",\"variant_id\":\"variant_id\",\"add_on_id\":\"add_on_id\",\"promotional_price\":35,\"days_of_week\":[2],\"start_date\":\"2026-12-01\",\"end_date\":\"2026-12-31\",\"is_active\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionServicePromotion>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionServicePromotion did not round-trip."
        );
    }
}
