using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AsyncConversationMetadata</c>.
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
public class AsyncConversationMetadataTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"delivery_status\":\"pending\",\"delivery_timestamp\":1,\"delivery_error\":\"delivery_error\",\"external_system\":\"external_system\",\"external_id\":\"external_id\",\"external_link\":\"external_link\",\"retry_count\":4,\"last_retry_timestamp\":6,\"last_processed_external_message_id\":\"last_processed_external_message_id\",\"integration_trigger_id\":\"integration_trigger_id\",\"platform_metadata\":{\"conversation_initiation_source\":\"plain_integration\",\"thread_id\":\"thread_id\",\"workspace_id\":\"workspace_id\"}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AsyncConversationMetadata>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AsyncConversationMetadata did not round-trip."
        );
    }
}
