using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionAgentInfoResponse</c>.
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
public class ReceptionAgentInfoResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"business_name\":\"Bloom Salon\",\"business_country\":\"quis i\",\"business_description\":\"A hair salon offering cuts, color and styling.\",\"timezone\":\"America/New_York\",\"currency\":\"USD\",\"operating_hours\":{\"hours\":{\"key\":[{\"start_hour\":9,\"start_minute\":4,\"end_hour\":17,\"end_minute\":30}]},\"timezone\":\"timezone\"},\"tool_call_sound\":\"typing\",\"id\":\"agentinfo_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":1767225600,\"updated_at_unix\":1767225600}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionAgentInfoResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionAgentInfoResponse did not round-trip."
        );
    }
}
