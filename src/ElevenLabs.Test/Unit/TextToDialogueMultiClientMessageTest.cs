using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.TextToDialogueMultiClientMessage</c>.
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
public class TextToDialogueMultiClientMessageTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"inputs\":[{\"text\":\"text\",\"voice_id\":\"voice_id\",\"new_turn\":false}],\"flush\":false,\"close_socket\":false,\"keep_alive\":false,\"xi_api_key\":\"xi_api_key\",\"authorization\":\"authorization\",\"single_use_token\":\"single_use_token\",\"voices\":[\"voices\"],\"voice_settings\":{\"stability\":0.5},\"pronunciation_dictionary_locators\":[{\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"version_id\":\"version_id\"}],\"context_id\":\"context_id\",\"close_context\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.TextToDialogueMultiClientMessage>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.TextToDialogueMultiClientMessage did not round-trip."
        );
    }
}
