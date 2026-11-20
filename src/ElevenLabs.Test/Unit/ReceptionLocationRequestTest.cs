using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.ReceptionLocationRequest</c>.
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
public class ReceptionLocationRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"do Ut\",\"address\":\"dolore eu offic\",\"notes\":\"nulla occaec\",\"operating_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":9,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"customer_facing_name\":\"voluptate\",\"max_concurrent_appointments\":3,\"is_active\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.Reception.ReceptionLocationRequest>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.ReceptionLocationRequest did not round-trip."
        );
    }
}
