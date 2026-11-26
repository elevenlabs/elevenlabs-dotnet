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
            "{\"groups\":[{\"label\":\"voluptate magna\",\"rank\":2}],\"ungrouped_rank\":3,\"name\":\"in dolore irur\",\"description\":\"exercitation qu\",\"is_active\":true,\"available_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":6,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"photo_url\":\"https://male-coal.com/\",\"location_id\":\"location_id\",\"customer_facing_name\":\"qui i\",\"id\":\"asset_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":9,\"updated_at_unix\":2}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionAssetResource>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionAssetResource did not round-trip."
        );
    }
}
