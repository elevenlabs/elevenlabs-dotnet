using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ResellerWorkspacesResponse</c>.
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
public class ResellerWorkspacesResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"workspaces\":[{\"workspace_id\":\"workspace_id\",\"business_name\":\"business_name\",\"billing_tier\":\"billing_tier\",\"receptionist_count\":3,\"calls_last_30_days\":6,\"created_at_unix\":10,\"subscription\":{\"tier_id\":\"tier_id\",\"billing_period\":\"monthly_period\",\"billing_period_end_unix\":5,\"cancel_at_unix\":5,\"pending_downgrade_tier\":\"pending_downgrade_tier\",\"pending_downgrade_at_unix\":8},\"charge_customer\":true,\"has_payment_issue\":true,\"onboarding_completed_at_unix\":9}],\"next_cursor\":\"next_cursor\",\"has_more\":false}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ResellerWorkspacesResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ResellerWorkspacesResponse did not round-trip."
        );
    }
}
