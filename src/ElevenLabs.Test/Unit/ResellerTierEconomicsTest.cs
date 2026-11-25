using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ResellerTierEconomics</c>.
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
public class ResellerTierEconomicsTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"monthly_price_usd\":99,\"annual_price_usd\":6.83,\"included_minutes_per_month\":300,\"overage_price_per_minute_usd\":3.87,\"max_phone_numbers\":2,\"concurrent_calls\":3,\"max_active_locations\":1,\"max_customer_facing_agents\":1,\"max_team_members\":5,\"assistant_daily_messages\":100}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ResellerTierEconomics>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ResellerTierEconomics did not round-trip."
        );
    }
}
