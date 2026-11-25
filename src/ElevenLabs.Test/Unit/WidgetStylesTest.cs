using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.WidgetStyles</c>.
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
public class WidgetStylesTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"base\":\"base\",\"base_hover\":\"base_hover\",\"base_active\":\"base_active\",\"base_border\":\"base_border\",\"base_subtle\":\"base_subtle\",\"base_primary\":\"base_primary\",\"base_error\":\"base_error\",\"accent\":\"accent\",\"accent_hover\":\"accent_hover\",\"accent_active\":\"accent_active\",\"accent_border\":\"accent_border\",\"accent_subtle\":\"accent_subtle\",\"accent_primary\":\"accent_primary\",\"overlay_padding\":3.56,\"button_radius\":7.68,\"input_radius\":4.57,\"bubble_radius\":1.62,\"sheet_radius\":5.22,\"compact_sheet_radius\":4.03,\"dropdown_sheet_radius\":2.03}";

        var instance = TestJson.Deserialize<global::ElevenLabs.WidgetStyles>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.WidgetStyles did not round-trip."
        );
    }
}
