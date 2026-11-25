using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionAssetResource</c>.
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
public class ReceptionAssetResourceTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"groups\":[{\"label\":\"eu ullamco\",\"rank\":3}],\"ungrouped_rank\":10,\"name\":\"aliquip\",\"description\":\"officia dolore \",\"is_active\":true,\"available_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":4,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"photo_url\":\"https://male-coal.com/\",\"location_id\":\"location_id\",\"customer_facing_name\":\"occaecat culp\",\"id\":\"asset_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":0,\"updated_at_unix\":10}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionAssetResource>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionAssetResource did not round-trip."
        );
    }
}
