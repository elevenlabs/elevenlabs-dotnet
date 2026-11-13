using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ModerationStatusResponseModel</c>.
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
public class ModerationStatusResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"is_in_probation\":false,\"enterprise_check_nogo_voice\":true,\"enterprise_check_block_nogo_voice\":true,\"never_live_moderate\":true,\"nogo_voice_similar_voice_upload_count\":3,\"enterprise_background_moderation_enabled\":true,\"is_ivc_captcha_required\":true,\"safety_status\":\"appeal_approved\",\"warning_status\":\"warning\",\"on_watchlist\":false}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ModerationStatusResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ModerationStatusResponseModel did not round-trip."
        );
    }
}
