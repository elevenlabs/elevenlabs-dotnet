using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ActorModel</c>.
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
public class ActorModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"user\":{\"name\":\"name\",\"uid\":\"uid\",\"type_id\":0,\"type\":\"type\",\"email_addr\":\"email_addr\",\"full_name\":\"full_name\",\"domain\":\"domain\"},\"app_name\":\"app_name\",\"app_uid\":\"app_uid\",\"session\":{\"key\":{}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ActorModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ActorModel did not round-trip."
        );
    }
}
