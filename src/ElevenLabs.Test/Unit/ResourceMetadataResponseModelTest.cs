using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ResourceMetadataResponseModel</c>.
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
public class ResourceMetadataResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"resource_id\":\"resource_id\",\"resource_name\":\"resource_name\",\"resource_type\":\"voice\",\"creator_user_id\":\"creator_user_id\",\"anonymous_access_level_override\":\"admin\",\"role_to_group_ids\":{\"key\":[\"role_to_group_ids\"]},\"share_options\":[{\"name\":\"name\",\"id\":\"id\",\"type\":\"user\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ResourceMetadataResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ResourceMetadataResponseModel did not round-trip."
        );
    }
}
