using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.DubbingResource</c>.
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
public class DubbingResourceTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"id\",\"version\":5,\"source_language\":\"source_language\",\"target_languages\":[\"target_languages\"],\"input\":{\"src\":\"src\",\"content_type\":\"content_type\",\"bucket_name\":\"bucket_name\",\"random_path_slug\":\"random_path_slug\",\"duration_secs\":8.26,\"is_audio\":true,\"url\":\"url\"},\"background\":{\"src\":\"src\",\"content_type\":\"content_type\",\"bucket_name\":\"bucket_name\",\"random_path_slug\":\"random_path_slug\",\"duration_secs\":8.26,\"is_audio\":true,\"url\":\"url\"},\"foreground\":{\"src\":\"src\",\"content_type\":\"content_type\",\"bucket_name\":\"bucket_name\",\"random_path_slug\":\"random_path_slug\",\"duration_secs\":8.26,\"is_audio\":true,\"url\":\"url\"},\"speaker_tracks\":{\"key\":{\"id\":\"id\",\"media_ref\":{\"src\":\"src\",\"content_type\":\"content_type\",\"bucket_name\":\"bucket_name\",\"random_path_slug\":\"random_path_slug\",\"duration_secs\":8.26,\"is_audio\":true,\"url\":\"url\"},\"speaker_name\":\"speaker_name\",\"voices\":{\"key\":\"voices\"},\"segments\":[\"segments\"]}},\"speaker_segments\":{\"key\":{\"id\":\"id\",\"start_time\":7.91,\"end_time\":1.24,\"text\":\"text\",\"subtitles\":[{\"start_time\":6.62,\"end_time\":3.51,\"lines\":[\"lines\"]}],\"dubs\":{\"key\":{\"start_time\":5.49,\"end_time\":1.04,\"text\":\"text\",\"subtitles\":[{\"start_time\":6.62,\"end_time\":3.51,\"lines\":[\"lines\"]}],\"audio_stale\":true,\"media_ref\":{\"src\":\"src\",\"content_type\":\"content_type\",\"bucket_name\":\"bucket_name\",\"random_path_slug\":\"random_path_slug\",\"duration_secs\":8.26,\"is_audio\":true,\"url\":\"url\"}}}}},\"renders\":{\"key\":{\"id\":\"id\",\"version\":1,\"language\":\"language\",\"type\":\"mp4\",\"media_ref\":{\"src\":\"src\",\"content_type\":\"content_type\",\"bucket_name\":\"bucket_name\",\"random_path_slug\":\"random_path_slug\",\"duration_secs\":8.26,\"is_audio\":true,\"url\":\"url\"},\"status\":\"complete\"}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.DubbingResource>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.DubbingResource did not round-trip."
        );
    }
}
