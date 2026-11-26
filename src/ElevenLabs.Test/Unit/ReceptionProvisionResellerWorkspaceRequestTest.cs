using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.ReceptionProvisionResellerWorkspaceRequest</c>.
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
public class ReceptionProvisionResellerWorkspaceRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"business_name\":\"business_name\",\"vertical\":\"salon_barbershop\",\"charge_customer\":false,\"subscription\":{\"tier_id\":\"tier_id\",\"billing_period\":\"monthly_period\"},\"phone_number\":\"phone_number\",\"members\":[{\"email\":\"sam@example.com\",\"role\":\"workspace_admin\"}],\"complete_onboarding\":true,\"metadata\":{\"key\":\"metadata\"},\"idempotency_key\":\"idempotency_key\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Reception.ReceptionProvisionResellerWorkspaceRequest>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.ReceptionProvisionResellerWorkspaceRequest did not round-trip."
        );
    }
}
