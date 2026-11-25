using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.TtsConversationalConfigOverride</c>.
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
public class TtsConversationalConfigOverrideTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"model_id\":\"eleven_turbo_v2\",\"voice_id\":\"voice_id\",\"supported_voices\":[{\"label\":\"label\",\"voice_id\":\"voice_id\",\"description\":\"description\",\"language\":\"language\",\"model_family\":\"turbo\",\"optimize_streaming_latency\":3,\"stability\":0.88,\"speed\":1.01,\"similarity_boost\":0.22,\"clone_strength\":0.31}],\"stability\":3.87,\"speed\":7.34,\"similarity_boost\":7.78,\"clone_strength\":6.41,\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.TtsConversationalConfigOverride>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.TtsConversationalConfigOverride did not round-trip."
        );
    }
}
