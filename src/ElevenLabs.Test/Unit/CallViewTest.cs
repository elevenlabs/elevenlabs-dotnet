using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CallView</c>.
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
public class CallViewTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"intent_id\":\"intent_id\",\"lead_id\":\"lead_id\",\"intent_type\":\"initial\",\"cold_attempt\":8,\"status\":\"queued\",\"phone_number\":\"phone_number\",\"scheduled_time_unix\":1,\"conversation_id\":\"conversation_id\",\"outcome\":\"pending\",\"call_result\":\"answered\",\"outcome_at_unix\":7,\"decision_disposition\":\"completed\",\"collected_dynamic_variables\":{\"key\":{}},\"delivery\":{\"status\":\"pending\",\"stage\":\"queued\",\"sent_at_unix\":3,\"delivered_at_unix\":4,\"read_at_unix\":8,\"replied_at_unix\":6,\"failed_at_unix\":4,\"error_message\":\"error_message\"}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CallView>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CallView did not round-trip."
        );
    }
}
