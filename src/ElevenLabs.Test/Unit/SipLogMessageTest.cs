using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.SipLogMessage</c>.
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
public class SipLogMessageTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"call_id\":\"call_id\",\"phone_numbers\":[\"phone_numbers\"],\"local_address\":\"local_address\",\"remote_address\":\"remote_address\",\"transport\":\"transport\",\"raw_message\":\"raw_message\",\"error_message\":\"error_message\",\"direction\":\"in\",\"created_at_unix_micro\":1}";

        var instance = TestJson.Deserialize<global::ElevenLabs.SipLogMessage>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.SipLogMessage did not round-trip."
        );
    }
}
