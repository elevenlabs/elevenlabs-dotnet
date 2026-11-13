using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ClientSecretResponse</c>.
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
public class ClientSecretResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"value\":\"value\",\"expires_at\":8,\"session\":{\"type\":\"realtime\",\"model\":\"eleven_realtime_v1_mini\",\"instructions\":\"instructions\",\"output_modalities\":[\"output_modalities\"],\"audio\":{\"input\":{\"format\":{\"type\":\"audio/pcm\",\"rate\":24000},\"transcription\":{\"language\":\"language\"},\"turn_detection\":{\"type\":\"semantic_vad\",\"eagerness\":\"low\",\"create_response\":true,\"interrupt_response\":true,\"threshold\":8.76,\"prefix_padding_ms\":1,\"silence_duration_ms\":4,\"turn_timeout\":-1},\"pacing\":\"realtime\"},\"output\":{\"format\":{\"type\":\"audio/pcm\"},\"voice\":\"brian\"}},\"tools\":[{\"type\":\"function\",\"name\":\"name\",\"description\":\"description\",\"parameters\":{\"key\":{}}}],\"tool_choice\":\"elit adipisici\",\"temperature\":0.7,\"max_response_output_tokens\":1676,\"max_duration_seconds\":600,\"tracing\":\"auto\"}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ClientSecretResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ClientSecretResponse did not round-trip."
        );
    }
}
