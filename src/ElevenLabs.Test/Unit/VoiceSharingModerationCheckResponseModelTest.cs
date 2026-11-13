using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.VoiceSharingModerationCheckResponseModel</c>.
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
public class VoiceSharingModerationCheckResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"date_checked_unix\":9,\"name_value\":\"name_value\",\"name_check\":false,\"description_value\":\"description_value\",\"description_check\":false,\"sample_ids\":[\"sample_ids\"],\"sample_checks\":[3.88],\"captcha_ids\":[\"captcha_ids\"],\"captcha_checks\":[7.9]}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.VoiceSharingModerationCheckResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.VoiceSharingModerationCheckResponseModel did not round-trip."
        );
    }
}
