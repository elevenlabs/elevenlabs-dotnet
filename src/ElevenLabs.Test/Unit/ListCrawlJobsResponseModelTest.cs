using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ListCrawlJobsResponseModel</c>.
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
public class ListCrawlJobsResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"crawl_jobs\":[{\"type\":\"discovery\",\"seed_url\":\"seed_url\",\"pattern\":\"pattern\",\"exclude_patterns\":[\"exclude_patterns\"],\"max_pages\":3,\"auto_discover\":true,\"status\":\"queued\",\"pages_identified\":3,\"pages_scraped\":2,\"pages_skipped\":8,\"pages_failed\":2,\"root_folder_id\":\"root_folder_id\",\"updated_at\":7,\"id\":\"id\",\"created_at\":0}],\"next_cursor\":\"next_cursor\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ListCrawlJobsResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ListCrawlJobsResponseModel did not round-trip."
        );
    }
}
