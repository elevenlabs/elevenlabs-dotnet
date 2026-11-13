using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.PrivacyConfigOutput</c>.
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
public class PrivacyConfigOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"record_voice\":true,\"retention_days\":-1,\"delete_transcript_and_pii\":false,\"delete_audio\":true,\"apply_to_existing_conversations\":false,\"zero_retention_mode\":true,\"conversation_history_redaction\":{\"enabled\":true,\"entities\":[\"name\"],\"excluded_data_collection_ids\":[\"excluded_data_collection_ids\"]}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.PrivacyConfigOutput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.PrivacyConfigOutput did not round-trip."
        );
    }
}
