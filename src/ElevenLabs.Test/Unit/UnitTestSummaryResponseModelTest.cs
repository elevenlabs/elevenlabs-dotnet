using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.UnitTestSummaryResponseModel</c>.
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
public class UnitTestSummaryResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"id\",\"name\":\"name\",\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"created_at_unix_secs\":7,\"last_updated_at_unix_secs\":9,\"type\":\"llm\",\"entity_type\":\"test\",\"folder_parent_id\":\"folder_parent_id\",\"folder_path\":[{\"id\":\"id\",\"name\":\"name\"}],\"children_count\":8,\"conversation_initiation_source\":\"unknown\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.UnitTestSummaryResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.UnitTestSummaryResponseModel did not round-trip."
        );
    }
}
