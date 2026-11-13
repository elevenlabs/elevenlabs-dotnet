using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetPhoneNumberOutboundSipTrunkConfigResponseModel</c>.
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
public class GetPhoneNumberOutboundSipTrunkConfigResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"address\":\"address\",\"transport\":\"auto\",\"media_encryption\":\"disabled\",\"headers\":{\"key\":\"headers\"},\"attributes_to_headers\":{\"key\":\"attributes_to_headers\"},\"has_auth_credentials\":true,\"username\":\"username\",\"has_outbound_trunk\":false,\"enabled_codecs\":[\"G722/8000\"]}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.GetPhoneNumberOutboundSipTrunkConfigResponseModel>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetPhoneNumberOutboundSipTrunkConfigResponseModel did not round-trip."
        );
    }
}
