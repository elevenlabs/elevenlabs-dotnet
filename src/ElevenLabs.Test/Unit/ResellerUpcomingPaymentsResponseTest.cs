using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ResellerUpcomingPaymentsResponse</c>.
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
public class ResellerUpcomingPaymentsResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"payments\":[{\"workspace_id\":\"workspace_id\",\"workspace_name\":\"workspace_name\",\"subscription\":{\"tier_id\":\"tier_id\",\"billing_period\":\"monthly_period\",\"billing_period_end_unix\":5,\"cancel_at_unix\":5,\"pending_downgrade_tier\":\"pending_downgrade_tier\",\"pending_downgrade_at_unix\":8},\"plan_usd\":0.46,\"overage_so_far_usd\":8.7}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ResellerUpcomingPaymentsResponse>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ResellerUpcomingPaymentsResponse did not round-trip."
        );
    }
}
