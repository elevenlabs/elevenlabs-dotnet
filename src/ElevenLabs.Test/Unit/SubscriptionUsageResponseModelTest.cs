using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SubscriptionUsageResponseModel</c>.
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
public class SubscriptionUsageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"rollover_credits_quota\":1,\"subscription_cycle_credits_quota\":2,\"manually_gifted_credits_quota\":0,\"payg_credits_quota\":10,\"rollover_credits_used\":10,\"subscription_cycle_credits_used\":9,\"manually_gifted_credits_used\":3,\"payg_credits_used\":2,\"paid_usage_based_credits_used\":5,\"actual_reported_credits\":3}";

        var instance = TestJson.Deserialize<global::ElevenLabs.SubscriptionUsageResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SubscriptionUsageResponseModel did not round-trip."
        );
    }
}
