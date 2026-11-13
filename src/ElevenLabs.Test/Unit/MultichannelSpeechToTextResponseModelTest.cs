using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.MultichannelSpeechToTextResponseModel</c>.
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
public class MultichannelSpeechToTextResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"transcripts\":[{\"language_code\":\"language_code\",\"language_probability\":4.3,\"text\":\"text\",\"words\":[{\"text\":\"text\",\"start\":1.37,\"end\":5.8,\"type\":\"word\",\"speaker_id\":\"speaker_id\",\"logprob\":6.86,\"characters\":[{\"text\":\"text\",\"start\":0.93,\"end\":8.63}],\"channel_index\":1}],\"channel_index\":9,\"additional_formats\":[{\"requested_format\":\"requested_format\",\"file_extension\":\"file_extension\",\"content_type\":\"content_type\",\"is_base64_encoded\":false,\"content\":\"content\"}],\"transcription_id\":\"transcription_id\",\"entities\":[{\"text\":\"text\",\"entity_type\":\"entity_type\",\"start_char\":7,\"end_char\":0}],\"audio_duration_secs\":4.07,\"edited_transcript\":{\"kind\":\"transcript\",\"text\":\"text\"}}],\"transcription_id\":\"transcription_id\",\"audio_duration_secs\":5.39}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.MultichannelSpeechToTextResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.MultichannelSpeechToTextResponseModel did not round-trip."
        );
    }
}
