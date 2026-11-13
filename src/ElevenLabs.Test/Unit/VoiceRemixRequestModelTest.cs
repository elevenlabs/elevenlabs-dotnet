using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.VoiceRemixRequestModel</c>.
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
public class VoiceRemixRequestModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"voice_description\":\"Make the voice have a higher pitch.\",\"text\":\"quis voluptate deseruntest nostrudcommodocillumculpa doloredolor ullamco nostrud ipsum iruresintdolor id commodo\",\"auto_generate_text\":false,\"loudness\":0.5,\"seed\":196797417,\"guidance_scale\":5,\"stream_previews\":true,\"remixing_session_id\":\"remixing_session_id\",\"remixing_session_iteration_id\":\"remixing_session_iteration_id\",\"prompt_strength\":0.56}";

        var instance = TestJson.Deserialize<global::ElevenLabs.VoiceRemixRequestModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.VoiceRemixRequestModel did not round-trip."
        );
    }
}
