using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.VoiceDesignRequestModel</c>.
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
public class VoiceDesignRequestModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"voice_description\":\"A sassy squeaky mouse\",\"model_id\":\"eleven_multilingual_ttv_v2\",\"text\":\"Lorem consectetur sunt seddolore aliqua minim labore Utut laborum proidentculpa non reprehenderit nostrud\",\"auto_generate_text\":false,\"loudness\":0.5,\"seed\":1286507576,\"guidance_scale\":5,\"stream_previews\":true,\"should_enhance\":true,\"remixing_session_id\":\"remixing_session_id\",\"remixing_session_iteration_id\":\"remixing_session_iteration_id\",\"quality\":0.53,\"reference_audio_base64\":\"reference_audio_base64\",\"prompt_strength\":0.27}";

        var instance = TestJson.Deserialize<global::ElevenLabs.VoiceDesignRequestModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.VoiceDesignRequestModel did not round-trip."
        );
    }
}
