using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionStaffResource</c>.
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
public class ReceptionStaffResourceTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"groups\":[{\"label\":\"voluptate magna\",\"rank\":2}],\"ungrouped_rank\":3,\"name\":\"reprehender\",\"description\":\"esse aute no\",\"is_active\":true,\"email\":\"jane@example.com\",\"phone\":\"dolor\",\"sms_notifications_opted_in\":false,\"photo_url\":\"https://male-coal.com/\",\"location_id\":\"location_id\",\"working_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":6,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"display_on_booking_page\":true,\"customer_facing_name\":\"elit no\",\"id\":\"staff_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":9,\"updated_at_unix\":4}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionStaffResource>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionStaffResource did not round-trip."
        );
    }
}
