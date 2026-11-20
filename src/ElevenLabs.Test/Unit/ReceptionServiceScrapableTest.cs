using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionServiceScrapable</c>.
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
public class ReceptionServiceScrapableTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"pricing_mode\":\"fixed\",\"groups\":[{\"label\":\"Ut minim c\",\"rank\":5}],\"ungrouped_rank\":9,\"name\":\"culpa\",\"description\":\"do mi\",\"variants\":[{\"id\":\"variant_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"duration_minutes\":60,\"price\":9.01,\"is_active\":true}],\"kind\":\"classic\",\"buffer_minutes\":15,\"service_location\":\"business\",\"add_ons\":[{\"id\":\"addon_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"name\":\"sunt dolore\",\"description\":\"Excep\",\"add_duration_minutes\":10,\"add_price\":5}],\"max_participants\":144}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionServiceScrapable>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionServiceScrapable did not round-trip."
        );
    }
}
