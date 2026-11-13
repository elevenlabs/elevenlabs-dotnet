using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GenerationSourceContext</c>.
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
public class GenerationSourceContextTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"source_type\":\"generation\",\"generation_id\":\"generation_id\",\"prompt\":\"prompt\",\"model_id\":\"model_id\",\"model_provider\":\"model_provider\",\"generation_session_id\":\"generation_session_id\",\"session_iteration_id\":\"session_iteration_id\",\"model_parameters\":{\"key\":{}},\"extend_video\":{\"generation_id\":\"generation_id\",\"content_asset_id\":\"content_asset_id\",\"template_node_id\":\"template_node_id\",\"studio_clip\":{\"project_id\":\"project_id\",\"chapter_id\":\"chapter_id\",\"clip_type\":\"video\",\"clip_id\":\"clip_id\",\"block_id\":\"block_id\",\"preview_url\":\"preview_url\"}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GenerationSourceContext>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GenerationSourceContext did not round-trip."
        );
    }
}
