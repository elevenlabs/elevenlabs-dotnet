using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetTestInvocationsPageResponseModel</c>.
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
public class GetTestInvocationsPageResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"meta\":{\"total\":7,\"page\":5,\"page_size\":10},\"results\":[{\"id\":\"id\",\"name\":\"name\",\"agent_id\":\"agent_id\",\"branch_id\":\"branch_id\",\"version_id\":\"version_id\",\"ran_against_draft\":true,\"runs_diverged_from_version\":false,\"created_at_unix_secs\":5,\"test_run_count\":10,\"passed_count\":8,\"failed_count\":1,\"pending_count\":10,\"cancelled_count\":9,\"title\":\"title\",\"access_info\":{\"is_creator\":true,\"creator_name\":\"creator_name\",\"creator_email\":\"creator_email\",\"role\":\"admin\",\"anonymous_access_level_override\":\"admin\",\"access_source\":\"creator\"},\"repeat_count\":1,\"cancelled\":false,\"credits_used\":0,\"total_price\":0.6}],\"next_cursor\":\"next_cursor\",\"has_more\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetTestInvocationsPageResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetTestInvocationsPageResponseModel did not round-trip."
        );
    }
}
