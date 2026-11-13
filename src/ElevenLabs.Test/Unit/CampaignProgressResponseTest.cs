using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CampaignProgressResponse</c>.
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
public class CampaignProgressResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"leads\":{\"total\":9,\"uncalled\":8,\"leads_needing_attention\":1,\"active\":9,\"finished\":1,\"finished_by_disposition\":{\"key\":9}},\"conversations\":{\"scheduled\":9,\"scheduled_by_type\":{\"key\":1},\"awaiting_permission\":8,\"in_progress\":6,\"awaiting_analysis\":5},\"next_call_time_unix\":2}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CampaignProgressResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CampaignProgressResponse did not round-trip."
        );
    }
}
