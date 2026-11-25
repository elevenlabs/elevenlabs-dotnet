using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionKnowledgeSource</c>.
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
public class ReceptionKnowledgeSourceTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"source_type\":\"file\",\"source_url\":\"source_url\",\"last_scraped_at_unix\":2,\"original_filename\":\"price-list.pdf\",\"content_type\":\"application/pdf\",\"file_size_bytes\":204800,\"status\":\"processing\",\"error_message\":\"error_message\",\"failure_reason\":\"blocked_url\",\"crawl_entire_site\":true,\"scraped_pages_count\":12,\"content_preview\":\"content_preview\",\"processing_started_at_unix\":3,\"id\":\"ksource_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":0,\"updated_at_unix\":5}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionKnowledgeSource>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionKnowledgeSource did not round-trip."
        );
    }
}
