using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WorkspaceApiKeyListResponseModel</c>.
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
public class WorkspaceApiKeyListResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"api-keys\":[{\"name\":\"name\",\"hint\":\"hint\",\"key_id\":\"key_id\",\"service_account_user_id\":\"service_account_user_id\",\"created_at_unix\":9,\"is_disabled\":false,\"permissions\":[\"text_to_speech\"],\"disable_reason\":\"trial_ended\",\"character_limit\":2,\"character_count\":2,\"hashed_xi_api_key\":\"hashed_xi_api_key\",\"allowed_ips\":[\"allowed_ips\"],\"third_party_disable_allowed\":false,\"platform_limits\":{\"credits\":{\"limit\":5,\"usage\":7},\"pvc\":{\"limit\":1},\"concurrency\":{\"limit\":1},\"dubbing_concurrency\":{\"limit\":1},\"music_concurrency\":{\"limit\":1}},\"expires_at_unix\":1}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WorkspaceApiKeyListResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WorkspaceApiKeyListResponseModel did not round-trip."
        );
    }
}
