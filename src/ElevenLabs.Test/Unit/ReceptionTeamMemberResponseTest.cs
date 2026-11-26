using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionTeamMemberResponse</c>.
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
public class ReceptionTeamMemberResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"user_id\":\"Xr8bG2kQ9PZt4vLmN1aY6cDe3Hf2\",\"email\":\"jane@example.com\",\"first_name\":\"first_name\",\"is_owner\":true,\"is_admin\":false,\"picture_url\":\"picture_url\",\"is_suspended\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionTeamMemberResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionTeamMemberResponse did not round-trip."
        );
    }
}
