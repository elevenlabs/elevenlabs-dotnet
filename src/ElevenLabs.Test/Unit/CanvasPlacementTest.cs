using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CanvasPlacement</c>.
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
public class CanvasPlacementTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"x_relative\":0.5,\"y_relative\":0.5,\"scale_x\":1,\"scale_y\":1,\"pivot_x\":0.53,\"pivot_y\":2.54,\"skew_x\":4.32,\"skew_y\":8.11,\"crop_top\":5.13,\"crop_right\":2.85,\"crop_bottom\":3.98,\"crop_left\":0.23,\"flip_x\":false,\"flip_y\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CanvasPlacement>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CanvasPlacement did not round-trip."
        );
    }
}
