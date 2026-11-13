using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CaptionStyleModel</c>.
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
public class CaptionStyleModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"template\":{\"key\":\"key\",\"label\":\"label\",\"requires_high_fps\":true},\"text_font\":\"text_font\",\"text_scale\":5.28,\"text_color\":\"text_color\",\"text_align\":\"start\",\"text_style\":\"normal\",\"text_weight\":\"normal\",\"text_transform\":\"none\",\"text_blend_mode\":\"normal\",\"text_shadow\":{\"enabled\":false,\"color\":\"color\",\"opacity\":4.97,\"blur\":5.7,\"offset_x\":4.16,\"offset_y\":2.68},\"text_outline\":{\"enabled\":false,\"color\":\"color\",\"opacity\":3.06,\"width\":8.86},\"background_enabled\":true,\"background_color\":\"background_color\",\"background_opacity\":9.65,\"background_blur\":6.04,\"background_border_radius\":9.76,\"word_highlights_enabled\":true,\"word_highlights_color\":\"word_highlights_color\",\"word_highlights_background_color\":\"word_highlights_background_color\",\"word_highlights_opacity\":8.28,\"word_highlights_border_radius\":5.65,\"word_highlights_blur\":4.63,\"section_animation\":{\"enter_type\":\"none\",\"exit_type\":\"none\"},\"word_animation\":{\"enter_type\":\"none\",\"exit_type\":\"none\"},\"character_animation\":{\"enter_type\":\"none\",\"exit_type\":\"none\"},\"cursor_enabled\":true,\"width_pct\":8.59,\"horizontal_placement\":{\"align\":\"left\",\"translate_pct\":1.83},\"vertical_placement\":{\"align\":\"top\",\"translate_pct\":1.05},\"auto_break_enabled\":false,\"max_lines_per_section\":2,\"max_words_per_line\":5}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CaptionStyleModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CaptionStyleModel did not round-trip."
        );
    }
}
