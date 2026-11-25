using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.ReceptionConfirmServiceUpdateRequest</c>.
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
public class ReceptionConfirmServiceUpdateRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"pricing_mode\":\"fixed\",\"intake_questions\":[{\"id\":\"intakeq_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"label\":\"laboris Lo\",\"kind\":\"text\",\"options\":[\"ad reprehende\"],\"required\":false,\"is_active\":true}],\"groups\":[{\"label\":\"eu ullamco\",\"rank\":3}],\"ungrouped_rank\":5,\"name\":\"ex in labore U\",\"description\":\"ex mollit\",\"variants\":[{\"id\":\"variant_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"duration_minutes\":60,\"price\":1.91,\"is_active\":true}],\"kind\":\"classic\",\"buffer_minutes\":15,\"service_location\":\"business\",\"add_ons\":[{\"id\":\"addon_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"name\":\"Excep\",\"description\":\"ut ipsum\",\"add_duration_minutes\":10,\"add_price\":5}],\"max_participants\":21,\"capacity\":8,\"is_active\":true,\"any_staff_member\":false,\"staff_ids\":[\"staff_ids\"],\"asset_ids\":[\"asset_ids\"],\"advance_booking_minutes\":10080,\"location_ids\":[\"location_ids\"],\"display_on_booking_page\":false,\"travel_minutes\":15,\"travel_before\":true,\"travel_after\":false,\"promotions\":[{\"id\":\"promo_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"name\":\"Duis irure id o\",\"target\":\"service\",\"variant_id\":\"variant_id\",\"add_on_id\":\"add_on_id\",\"promotional_price\":35,\"days_of_week\":[1],\"start_date\":\"2026-12-01\",\"end_date\":\"2026-12-31\",\"is_active\":true}],\"duration_minutes\":27856,\"price\":0.96}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Reception.ReceptionConfirmServiceUpdateRequest>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.ReceptionConfirmServiceUpdateRequest did not round-trip."
        );
    }
}
