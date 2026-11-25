using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetKnowledgeBaseFileResponseModel</c>.
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
public class GetKnowledgeBaseFileResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"id\",\"name\":\"name\",\"metadata\":{\"created_at_unix_secs\":5,\"last_updated_at_unix_secs\":9,\"size_bytes\":10},\"supported_usages\":[\"prompt\"],\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"folder_parent_id\":\"folder_parent_id\",\"chunking_override\":{\"max_chunk_size\":8,\"overlap_percentage\":0,\"custom_separators\":[\"custom_separators\"]},\"folder_path\":[{\"id\":\"id\",\"name\":\"name\"}],\"type\":\"file\",\"extracted_inner_html\":\"extracted_inner_html\",\"content_format\":\"html\",\"filename\":\"filename\",\"external_sync_info\":{\"type\":\"google_drive\",\"source_entity_id\":\"source_entity_id\",\"integration_connection_id\":\"integration_connection_id\",\"source_parent_entity_id\":\"source_parent_entity_id\",\"source_mime_type\":\"source_mime_type\",\"source_modified_time\":\"2023-04-01T06:49:54.833Z\",\"root_folder_id\":\"root_folder_id\"},\"auto_sync_info\":{\"minimum_frequency_days\":7,\"auto_remove\":true,\"consec_failures\":1,\"next_refresh_by\":2},\"refresh_status\":{\"status\":\"queued\",\"enqueued_at\":6,\"started_at\":8,\"completed_at\":7,\"last_synced_at\":7,\"error_message\":\"error_message\"},\"is_frozen\":false}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetKnowledgeBaseFileResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetKnowledgeBaseFileResponseModel did not round-trip."
        );
    }
}
