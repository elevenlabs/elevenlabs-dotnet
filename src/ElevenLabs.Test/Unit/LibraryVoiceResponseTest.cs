using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.LibraryVoiceResponse</c>.
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
public class LibraryVoiceResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"public_owner_id\":\"public_owner_id\",\"voice_id\":\"voice_id\",\"date_unix\":4,\"name\":\"name\",\"accent\":\"accent\",\"gender\":\"gender\",\"age\":\"age\",\"descriptive\":\"descriptive\",\"use_case\":\"use_case\",\"category\":\"generated\",\"language\":\"language\",\"locale\":\"locale\",\"description\":\"description\",\"preview_url\":\"preview_url\",\"usage_character_count_1y\":4,\"usage_character_count_7d\":2,\"play_api_usage_character_count_1y\":3,\"cloned_by_count\":3,\"rate\":2.97,\"fiat_rate\":1.82,\"free_users_allowed\":false,\"live_moderation_enabled\":false,\"featured\":true,\"verified_languages\":[{\"language\":\"language\",\"model_id\":\"model_id\",\"accent\":\"accent\",\"locale\":\"locale\",\"preview_url\":\"preview_url\"}],\"notice_period\":10,\"instagram_username\":\"instagram_username\",\"twitter_username\":\"twitter_username\",\"youtube_username\":\"youtube_username\",\"tiktok_username\":\"tiktok_username\",\"image_url\":\"image_url\",\"is_added_by_user\":false,\"is_bookmarked\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.LibraryVoiceResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.LibraryVoiceResponse did not round-trip."
        );
    }
}
