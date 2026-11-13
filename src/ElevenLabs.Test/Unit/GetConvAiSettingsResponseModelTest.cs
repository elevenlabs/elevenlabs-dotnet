using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetConvAiSettingsResponseModel</c>.
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
public class GetConvAiSettingsResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"conversation_initiation_client_data_webhook\":{\"url\":\"url\",\"request_headers\":{\"key\":\"nisieu\"}},\"webhooks\":{\"post_call_webhook_id\":\"post_call_webhook_id\",\"events\":[\"transcript\"],\"transcript_format\":\"json\",\"exclude_transcript\":true,\"send_audio\":false},\"can_use_mcp_servers\":true,\"rag_retention_period_days\":10,\"conversation_embedding_retention_days\":258,\"default_livekit_stack\":\"standard\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetConvAiSettingsResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetConvAiSettingsResponseModel did not round-trip."
        );
    }
}
