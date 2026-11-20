using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.ReceptionUpdateStaffRequestPatch</c>.
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
public class ReceptionUpdateStaffRequestPatchTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"groups\":[{\"label\":\"Ut minim c\",\"rank\":5}],\"ungrouped_rank\":4,\"name\":\"sit aliq\",\"description\":\"officia in\",\"is_active\":true,\"email\":\"jane@example.com\",\"phone\":\"reprehen\",\"sms_notifications_opted_in\":true,\"photo_url\":\"https://male-coal.com/\",\"location_id\":\"location_id\",\"working_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":9,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"display_on_booking_page\":true,\"customer_facing_name\":\"magna\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Reception.ReceptionUpdateStaffRequestPatch>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.ReceptionUpdateStaffRequestPatch did not round-trip."
        );
    }
}
