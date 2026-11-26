using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.ReceptionUpdateAgentInfoRequest</c>.
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
public class ReceptionUpdateAgentInfoRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"business_name\":\"Bloom Salon\",\"business_country\":\"aliqua \",\"business_description\":\"A hair salon offering cuts, color and styling.\",\"timezone\":\"America/New_York\",\"currency\":\"USD\",\"operating_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":6,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"tool_call_sound\":\"typing\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Reception.ReceptionUpdateAgentInfoRequest>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.ReceptionUpdateAgentInfoRequest did not round-trip."
        );
    }
}
