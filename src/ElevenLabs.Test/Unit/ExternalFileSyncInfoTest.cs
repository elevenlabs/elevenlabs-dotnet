using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ExternalFileSyncInfo</c>.
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
public class ExternalFileSyncInfoTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"type\":\"google_drive\",\"source_entity_id\":\"source_entity_id\",\"integration_connection_id\":\"integration_connection_id\",\"source_parent_entity_id\":\"source_parent_entity_id\",\"source_mime_type\":\"source_mime_type\",\"source_modified_time\":\"2023-04-01T06:49:54.833Z\",\"root_folder_id\":\"root_folder_id\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ExternalFileSyncInfo>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ExternalFileSyncInfo did not round-trip."
        );
    }
}
