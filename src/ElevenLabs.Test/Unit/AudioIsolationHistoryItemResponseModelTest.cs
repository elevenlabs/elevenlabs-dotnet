using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AudioIsolationHistoryItemResponseModel</c>.
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
public class AudioIsolationHistoryItemResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"id\",\"title\":\"title\",\"created_at_unix\":4,\"format\":\"format\",\"duration_seconds\":7.37,\"download_url\":\"download_url\",\"icon_url\":\"icon_url\",\"source_video_url\":\"source_video_url\",\"supports_video\":false,\"processing\":false,\"video_processing_failed\":false,\"preview_b64\":\"preview_b64\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.AudioIsolationHistoryItemResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AudioIsolationHistoryItemResponseModel did not round-trip."
        );
    }
}
