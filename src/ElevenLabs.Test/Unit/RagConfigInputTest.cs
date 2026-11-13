using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.RagConfigInput</c>.
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
public class RagConfigInputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"enabled\":false,\"embedding_model\":\"e5_mistral_7b_instruct\",\"max_vector_distance\":0.5,\"max_documents_length\":50000,\"max_retrieved_rag_chunks_count\":5,\"num_candidates\":6414,\"query_rewrite_prompt_override\":\"query_rewrite_prompt_override\",\"knowledge_base_tool_info\":{\"enabled_strategies\":[\"cat\"]}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.RagConfigInput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.RagConfigInput did not round-trip."
        );
    }
}
