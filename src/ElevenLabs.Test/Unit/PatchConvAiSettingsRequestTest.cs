using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Agents.PatchConvAiSettingsRequest</c>.
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
public class PatchConvAiSettingsRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"conversation_initiation_client_data_webhook\":{\"url\":\"url\",\"request_headers\":{\"key\":\"nisieu\"}},\"webhooks\":{\"post_call_webhook_id\":\"post_call_webhook_id\",\"events\":[\"transcript\"],\"transcript_format\":\"json\",\"exclude_transcript\":true,\"send_audio\":false},\"can_use_mcp_servers\":false,\"rag_retention_period_days\":10,\"conversation_embedding_retention_days\":102,\"default_livekit_stack\":\"standard\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.Agents.PatchConvAiSettingsRequest>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Agents.PatchConvAiSettingsRequest did not round-trip."
        );
    }
}
