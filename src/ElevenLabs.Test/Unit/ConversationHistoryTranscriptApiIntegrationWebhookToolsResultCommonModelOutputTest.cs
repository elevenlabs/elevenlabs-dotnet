using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput</c>.
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
public class ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"request_id\":\"request_id\",\"tool_name\":\"tool_name\",\"tool_id\":\"tool_id\",\"result_value\":\"result_value\",\"is_error\":true,\"is_blocked\":false,\"tool_has_been_called\":false,\"tool_latency_secs\":1.11,\"error_type\":\"error_type\",\"raw_error_message\":\"raw_error_message\",\"dynamic_variable_updates\":[{\"variable_name\":\"variable_name\",\"old_value\":\"old_value\",\"new_value\":\"new_value\",\"updated_at\":3.39,\"tool_name\":\"tool_name\",\"tool_request_id\":\"tool_request_id\"}],\"type\":\"api_integration_webhook\",\"integration_id\":\"integration_id\",\"credential_id\":\"credential_id\",\"integration_connection_id\":\"integration_connection_id\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ConversationHistoryTranscriptApiIntegrationWebhookToolsResultCommonModelOutput did not round-trip."
        );
    }
}
