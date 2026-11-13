using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AgentVersionParents</c>.
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
public class AgentVersionParentsTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"in_branch_parent_id\":\"in_branch_parent_id\",\"out_of_branch_parent_id\":\"out_of_branch_parent_id\",\"merged_into_branch_id\":\"merged_into_branch_id\",\"merged_from_branch_id\":\"merged_from_branch_id\",\"merged_from_version_id\":\"merged_from_version_id\",\"rebased_from_version_id\":\"rebased_from_version_id\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AgentVersionParents>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AgentVersionParents did not round-trip."
        );
    }
}
