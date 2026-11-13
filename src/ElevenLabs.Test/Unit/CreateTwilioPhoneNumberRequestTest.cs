using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CreateTwilioPhoneNumberRequest</c>.
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
public class CreateTwilioPhoneNumberRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"phone_number\":\"phone_number\",\"label\":\"label\",\"supports_inbound\":true,\"supports_outbound\":true,\"provider\":\"twilio\",\"agent_id\":\"agent_id\",\"sid\":\"sid\",\"token\":\"token\",\"account_auth_token\":\"account_auth_token\",\"region_config\":{\"region_id\":\"us1\",\"token\":\"token\",\"edge_location\":\"ashburn\"},\"enable_sms\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CreateTwilioPhoneNumberRequest>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CreateTwilioPhoneNumberRequest did not round-trip."
        );
    }
}
