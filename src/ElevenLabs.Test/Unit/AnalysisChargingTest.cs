using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AnalysisCharging</c>.
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
public class AnalysisChargingTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"total\":{\"price\":9.34,\"charge\":5,\"runs\":3,\"price_per_feature\":{\"key\":9.25},\"charge_per_feature\":{\"key\":10}},\"last_run\":{\"price\":9.12,\"charge\":4,\"price_per_feature\":{\"key\":6.52},\"charge_per_feature\":{\"key\":5}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AnalysisCharging>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AnalysisCharging did not round-trip."
        );
    }
}
