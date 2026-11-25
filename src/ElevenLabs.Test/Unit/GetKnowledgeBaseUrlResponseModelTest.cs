using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetKnowledgeBaseUrlResponseModel</c>.
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
public class GetKnowledgeBaseUrlResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"id\",\"name\":\"name\",\"metadata\":{\"created_at_unix_secs\":5,\"last_updated_at_unix_secs\":9,\"size_bytes\":10},\"supported_usages\":[\"prompt\"],\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"folder_parent_id\":\"folder_parent_id\",\"chunking_override\":{\"max_chunk_size\":8,\"overlap_percentage\":0,\"custom_separators\":[\"custom_separators\"]},\"folder_path\":[{\"id\":\"id\",\"name\":\"name\"}],\"type\":\"url\",\"url\":\"url\",\"extracted_inner_html\":\"extracted_inner_html\",\"content_format\":\"html\",\"auto_sync_info\":{\"minimum_frequency_days\":7,\"auto_remove\":true,\"consec_failures\":1,\"next_refresh_by\":2}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetKnowledgeBaseUrlResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetKnowledgeBaseUrlResponseModel did not round-trip."
        );
    }
}
