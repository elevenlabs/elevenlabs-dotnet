using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AttentionView</c>.
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
public class AttentionViewTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"attention_id\":\"attention_id\",\"campaign_id\":\"campaign_id\",\"reason\":\"reason\",\"detail\":\"detail\",\"status\":\"open\",\"retryable\":true,\"resolution\":\"resolution\",\"created_at_unix\":8,\"updated_at_unix\":5}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AttentionView>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AttentionView did not round-trip."
        );
    }
}
