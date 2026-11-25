using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionProduct</c>.
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
public class ReceptionProductTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"pricing_mode\":\"fixed\",\"intake_questions\":[{\"id\":\"intakeq_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"label\":\"laboris Lo\",\"kind\":\"text\",\"options\":[\"ad reprehende\"],\"required\":false,\"is_active\":true}],\"groups\":[{\"label\":\"eu ullamco\",\"rank\":3}],\"ungrouped_rank\":2,\"name\":\"mollit velit \",\"description\":\"dolore \",\"price\":1.33,\"is_active\":true,\"orderable\":true,\"allowed_fulfillment_types\":[\"pickup\"],\"location_ids\":[\"location_ids\"],\"stock\":{\"key\":9},\"id\":\"product_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":2,\"updated_at_unix\":9}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionProduct>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionProduct did not round-trip."
        );
    }
}
