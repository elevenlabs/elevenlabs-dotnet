using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationConfigInput</c>.
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
public class ConversationConfigInputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"text_only\":true,\"max_duration_seconds\":600,\"client_events\":[\"conversation_initiation_metadata\"],\"file_input\":{\"enabled\":true,\"max_files_in_memory\":10,\"max_files_per_conversation\":10},\"monitoring_enabled\":true,\"monitoring_events\":[\"conversation_initiation_metadata\"],\"dtmf_input_settings\":{\"dtmf_input_timeout\":2,\"hash_terminator\":true,\"redact_input\":true},\"background_sound\":{\"source_type\":\"preset\",\"source_id\":\"office2\",\"volume\":0.15,\"crossfade_loop\":true},\"source_attribution\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ConversationConfigInput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationConfigInput did not round-trip."
        );
    }
}
