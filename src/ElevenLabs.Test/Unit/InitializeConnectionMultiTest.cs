using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.InitializeConnectionMulti</c>.
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
public class InitializeConnectionMultiTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"text\":\" \",\"voice_settings\":{\"stability\":0.5,\"similarity_boost\":0.75,\"style\":6.76,\"use_speaker_boost\":true,\"speed\":1},\"generation_config\":{\"chunk_length_schedule\":[2]},\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}],\"xi_api_key\":\"xi_api_key\",\"authorization\":\"authorization\",\"context_id\":\"context_id\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.InitializeConnectionMulti>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.InitializeConnectionMulti did not round-trip."
        );
    }
}
