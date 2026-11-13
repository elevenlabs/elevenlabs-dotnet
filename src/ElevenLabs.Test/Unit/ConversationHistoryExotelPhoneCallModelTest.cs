using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationHistoryExotelPhoneCallModel</c>.
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
public class ConversationHistoryExotelPhoneCallModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"direction\":\"inbound\",\"phone_number_id\":\"phone_number_id\",\"agent_number\":\"agent_number\",\"external_number\":\"external_number\",\"call_result\":\"answered\",\"type\":\"exotel\",\"stream_sid\":\"stream_sid\",\"call_sid\":\"call_sid\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.ConversationHistoryExotelPhoneCallModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationHistoryExotelPhoneCallModel did not round-trip."
        );
    }
}
