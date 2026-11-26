using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionLocationResponse</c>.
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
public class ReceptionLocationResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"consequa\",\"address\":\"aliqua ipsum \",\"notes\":\"consequat la\",\"operating_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":6,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"customer_facing_name\":\"aliquip\",\"max_concurrent_appointments\":3,\"id\":\"location_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"deactivated_at_unix\":3,\"deactivation_reason\":\"tier_downgrade\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionLocationResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionLocationResponse did not round-trip."
        );
    }
}
