using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.KbExternalSyncJob</c>.
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
public class KbExternalSyncJobTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"type\":\"google_drive\",\"folder_id\":\"folder_id\",\"integration_connection_id\":\"integration_connection_id\",\"triggered_by\":\"on_demand\",\"status\":\"queued\",\"sync_type\":\"full\",\"items_identified\":7,\"items_processed\":7,\"error_message\":\"error_message\",\"started_at\":7,\"completed_at\":4,\"updated_at\":5,\"id\":\"id\",\"created_at\":10}";

        var instance = TestJson.Deserialize<global::ElevenLabs.KbExternalSyncJob>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.KbExternalSyncJob did not round-trip."
        );
    }
}
