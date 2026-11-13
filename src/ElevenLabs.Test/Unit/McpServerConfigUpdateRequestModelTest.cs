using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Agents.McpServerConfigUpdateRequestModel</c>.
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
public class McpServerConfigUpdateRequestModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"approval_policy\":\"auto_approve_all\",\"force_pre_tool_speech\":false,\"pre_tool_speech\":\"auto\",\"disable_interruptions\":true,\"interruption_mode\":\"allow\",\"tool_call_sound\":\"typing\",\"tool_call_sound_behavior\":\"auto\",\"execution_mode\":\"immediate\",\"response_timeout_secs\":26,\"request_headers\":{\"key\":\"sunt pariat\"},\"request_meta\":{\"key\":\"sed nulla con\"},\"disable_compression\":false,\"secret_token\":{\"secret_id\":\"secret_id\"},\"auth_connection\":{\"auth_connection_id\":\"auth_connection_id\"}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Agents.McpServerConfigUpdateRequestModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Agents.McpServerConfigUpdateRequestModel did not round-trip."
        );
    }
}
