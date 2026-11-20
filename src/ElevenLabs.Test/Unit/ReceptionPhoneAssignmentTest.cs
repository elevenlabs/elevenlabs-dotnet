using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionPhoneAssignment</c>.
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
public class ReceptionPhoneAssignmentTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"phone_number\":\"in cup\",\"is_byo\":true,\"provider\":\"twilio\",\"nanp_area_code\":415,\"customer_facing_agent_id\":\"customer_facing_agent_id\",\"deactivated_at_unix\":3,\"deactivation_reason\":\"tier_downgrade\",\"regulatory_status\":\"held\",\"regulatory_number_type\":\"local\",\"regulatory_country\":\"adipisi\",\"id\":\"phone_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":0,\"updated_at_unix\":6}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionPhoneAssignment>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionPhoneAssignment did not round-trip."
        );
    }
}
