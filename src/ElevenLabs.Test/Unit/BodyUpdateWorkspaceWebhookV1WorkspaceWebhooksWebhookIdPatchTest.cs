using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.BodyUpdateWorkspaceWebhookV1WorkspaceWebhooksWebhookIdPatch</c>.
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
public class BodyUpdateWorkspaceWebhookV1WorkspaceWebhooksWebhookIdPatchTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"is_disabled\":true,\"name\":\"My Callback Webhook\",\"retry_enabled\":true,\"request_headers\":{\"key\":\"request_headers\"},\"events\":[\"voice_library_removal_notice\"]}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.BodyUpdateWorkspaceWebhookV1WorkspaceWebhooksWebhookIdPatch>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.BodyUpdateWorkspaceWebhookV1WorkspaceWebhooksWebhookIdPatch did not round-trip."
        );
    }
}
