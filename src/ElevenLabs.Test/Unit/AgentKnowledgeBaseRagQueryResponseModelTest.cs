using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AgentKnowledgeBaseRagQueryResponseModel</c>.
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
public class AgentKnowledgeBaseRagQueryResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"strategy\":\"cat\",\"retrieval_query\":\"retrieval_query\",\"chunks\":[{\"document_id\":\"document_id\",\"document_name\":\"document_name\",\"source_url\":\"source_url\",\"chunk_id\":\"chunk_id\",\"text\":\"text\",\"vector_distance\":6.86,\"content_format\":\"html\",\"document_type\":\"file\"}],\"document\":{\"document_id\":\"document_id\",\"document_name\":\"document_name\",\"source_url\":\"source_url\",\"content\":\"content\",\"truncated\":false,\"content_format\":\"html\",\"document_type\":\"file\"},\"listing\":{\"entries\":[{\"id\":\"id\",\"name\":\"name\",\"is_folder\":true}],\"total_count\":1}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.AgentKnowledgeBaseRagQueryResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AgentKnowledgeBaseRagQueryResponseModel did not round-trip."
        );
    }
}
