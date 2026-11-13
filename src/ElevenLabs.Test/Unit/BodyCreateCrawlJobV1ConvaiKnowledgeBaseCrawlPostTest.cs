using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Agents.KnowledgeBase.BodyCreateCrawlJobV1ConvaiKnowledgeBaseCrawlPost</c>.
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
public class BodyCreateCrawlJobV1ConvaiKnowledgeBaseCrawlPostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"url\":\"url\",\"max_depth\":3,\"max_pages\":1000,\"pattern\":\"pattern\",\"exclude_patterns\":[\"exclude_patterns\"],\"sitemap_urls\":[\"sitemap_urls\"],\"parent_folder_id\":\"parent_folder_id\",\"enable_auto_sync\":true,\"auto_remove\":true,\"auto_discover\":false,\"minimum_frequency_days\":26}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Agents.KnowledgeBase.BodyCreateCrawlJobV1ConvaiKnowledgeBaseCrawlPost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Agents.KnowledgeBase.BodyCreateCrawlJobV1ConvaiKnowledgeBaseCrawlPost did not round-trip."
        );
    }
}
