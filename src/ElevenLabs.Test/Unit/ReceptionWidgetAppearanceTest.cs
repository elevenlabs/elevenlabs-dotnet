using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionWidgetAppearance</c>.
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
public class ReceptionWidgetAppearanceTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"orb_color_1\":\"#2792dc\",\"orb_color_2\":\"#9ce6e6\",\"variant\":\"tiny\",\"placement\":\"top-left\",\"dismissible\":false,\"main_label\":\"main_label\",\"start_call\":\"start_call\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionWidgetAppearance>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionWidgetAppearance did not round-trip."
        );
    }
}
