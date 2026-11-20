using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WorkspaceServiceAccountListResponseModel</c>.
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
public class WorkspaceServiceAccountListResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"service-accounts\":[{\"service_account_user_id\":\"service_account_user_id\",\"name\":\"name\",\"created_at_unix\":1,\"api-keys\":[{\"name\":\"name\",\"hint\":\"hint\",\"key_id\":\"key_id\",\"service_account_user_id\":\"service_account_user_id\",\"created_at_unix\":0,\"is_disabled\":false,\"permissions\":[\"text_to_speech\"],\"disable_reason\":\"trial_ended\",\"character_limit\":2,\"character_count\":9,\"hashed_xi_api_key\":\"hashed_xi_api_key\",\"allowed_ips\":[\"allowed_ips\"],\"third_party_disable_allowed\":false,\"platform_limits\":{\"credits\":{\"limit\":2,\"usage\":2},\"pvc\":{\"limit\":4},\"concurrency\":{\"limit\":4},\"dubbing_concurrency\":{\"limit\":4},\"music_concurrency\":{\"limit\":4}},\"expires_at_unix\":5}],\"default_sharing_groups\":[{\"group\":{\"name\":\"name\",\"id\":\"id\",\"members\":[\"members\"],\"permissions\":[\"text_to_speech\"],\"group_usage_limit\":2,\"group_pvc_limit\":9,\"group_concurrency_limit\":0,\"group_dubbing_concurrency_limit\":4,\"group_music_concurrency_limit\":0,\"character_count\":2,\"is_scim_synced\":true,\"scim_group\":{\"scim_external_id\":\"scim_external_id\",\"display_name\":\"display_name\",\"created_at_unix\":4,\"updated_at_unix\":10,\"seat_type\":\"workspace_admin\"},\"scim_frozen\":true},\"permission_level\":\"admin\"}]}]}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.WorkspaceServiceAccountListResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WorkspaceServiceAccountListResponseModel did not round-trip."
        );
    }
}
