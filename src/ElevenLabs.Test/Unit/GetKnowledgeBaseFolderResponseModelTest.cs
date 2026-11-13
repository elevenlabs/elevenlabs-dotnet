using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetKnowledgeBaseFolderResponseModel</c>.
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
public class GetKnowledgeBaseFolderResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"id\",\"name\":\"name\",\"metadata\":{\"created_at_unix_secs\":3,\"last_updated_at_unix_secs\":4,\"size_bytes\":0},\"supported_usages\":[\"prompt\"],\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"folder_parent_id\":\"folder_parent_id\",\"folder_path\":[{\"id\":\"id\",\"name\":\"name\"}],\"type\":\"folder\",\"children_count\":1,\"document_count\":8,\"auto_sync_info\":{\"minimum_frequency_days\":7,\"auto_remove\":true,\"consec_failures\":4,\"next_refresh_by\":4},\"external_sync_info\":{\"type\":\"google_drive\",\"source_entity_id\":\"source_entity_id\",\"integration_connection_id\":\"integration_connection_id\",\"root_folder_id\":\"root_folder_id\",\"sync_cursor\":\"sync_cursor\",\"last_sync_at\":6},\"is_frozen\":true,\"active_sync_job\":{\"type\":\"google_drive\",\"folder_id\":\"folder_id\",\"integration_connection_id\":\"integration_connection_id\",\"triggered_by\":\"on_demand\",\"status\":\"queued\",\"sync_type\":\"full\",\"items_identified\":7,\"items_processed\":7,\"error_message\":\"error_message\",\"started_at\":7,\"completed_at\":4,\"updated_at\":5,\"id\":\"id\",\"created_at\":10}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetKnowledgeBaseFolderResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetKnowledgeBaseFolderResponseModel did not round-trip."
        );
    }
}
