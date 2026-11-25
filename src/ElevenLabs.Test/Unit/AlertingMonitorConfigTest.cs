using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.AlertingMonitorConfig</c>.
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
public class AlertingMonitorConfigTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"enabled\":true,\"threshold\":0.63,\"relative_increase_threshold\":2.45,\"min_failure_count\":5,\"min_history_bucket_count\":9,\"min_sample_count\":9,\"suspect_trigger_threshold\":1,\"auto_resolve_after_inactive_minutes\":7}";

        var instance = TestJson.Deserialize<global::ElevenLabs.AlertingMonitorConfig>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.AlertingMonitorConfig did not round-trip."
        );
    }
}
