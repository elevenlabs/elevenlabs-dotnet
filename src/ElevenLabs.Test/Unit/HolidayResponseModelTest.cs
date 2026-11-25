using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.HolidayResponseModel</c>.
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
public class HolidayResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"Christmas Eve\",\"start_date\":{\"year\":2026,\"month\":12,\"day\":25},\"end_date\":{\"year\":2026,\"month\":12,\"day\":25},\"holiday_type\":\"closed\",\"override_hours\":[{\"start_hour\":9,\"start_minute\":4,\"end_hour\":17,\"end_minute\":30}],\"time_off_type\":\"staff\",\"resource_id\":\"resource_id\",\"location_id\":\"location_id\",\"reason\":\"reason\",\"id\":\"holiday_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":1767225600,\"updated_at_unix\":1767225600}";

        var instance = TestJson.Deserialize<global::ElevenLabs.HolidayResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.HolidayResponseModel did not round-trip."
        );
    }
}
