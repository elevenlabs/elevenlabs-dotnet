using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.KnowledgeBaseRagToolResultModel</c>.
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
public class KnowledgeBaseRagToolResultModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"result_type\":\"knowledge_base_rag_success\",\"status\":\"success\",\"chunk_count\":5,\"message\":\"Referenced knowledge base.\",\"chunks\":[{\"chunk_id\":\"chunk_id\",\"document_id\":\"document_id\",\"content\":\"content\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.KnowledgeBaseRagToolResultModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.KnowledgeBaseRagToolResultModel did not round-trip."
        );
    }
}
