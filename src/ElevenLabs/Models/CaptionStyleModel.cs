using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.SpeechEngine;
using ElevenLabs.Studio;
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[Serializable]
public record CaptionStyleModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("template")]
    public CaptionStyleTemplateModel? Template { get; set; }

    [JsonPropertyName("text_font")]
    public string? TextFont { get; set; }

    [JsonPropertyName("text_scale")]
    public double? TextScale { get; set; }

    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }

    [JsonPropertyName("text_align")]
    public CaptionStyleModelTextAlign? TextAlign { get; set; }

    [JsonPropertyName("text_style")]
    public CaptionStyleModelTextStyle? TextStyle { get; set; }

    [JsonPropertyName("text_weight")]
    public CaptionStyleModelTextWeight? TextWeight { get; set; }

    [JsonPropertyName("text_transform")]
    public CaptionStyleModelTextTransform? TextTransform { get; set; }

    [JsonPropertyName("text_blend_mode")]
    public CaptionStyleModelTextBlendMode? TextBlendMode { get; set; }

    [JsonPropertyName("text_shadow")]
    public StudioTextStyleShadowModel? TextShadow { get; set; }

    [JsonPropertyName("text_outline")]
    public StudioTextStyleOutlineModel? TextOutline { get; set; }

    [JsonPropertyName("background_enabled")]
    public bool? BackgroundEnabled { get; set; }

    [JsonPropertyName("background_color")]
    public string? BackgroundColor { get; set; }

    [JsonPropertyName("background_opacity")]
    public double? BackgroundOpacity { get; set; }

    [JsonPropertyName("background_blur")]
    public double? BackgroundBlur { get; set; }

    [JsonPropertyName("background_border_radius")]
    public double? BackgroundBorderRadius { get; set; }

    [JsonPropertyName("word_highlights_enabled")]
    public bool? WordHighlightsEnabled { get; set; }

    [JsonPropertyName("word_highlights_color")]
    public string? WordHighlightsColor { get; set; }

    [JsonPropertyName("word_highlights_background_color")]
    public string? WordHighlightsBackgroundColor { get; set; }

    [JsonPropertyName("word_highlights_opacity")]
    public double? WordHighlightsOpacity { get; set; }

    [JsonPropertyName("word_highlights_border_radius")]
    public double? WordHighlightsBorderRadius { get; set; }

    [JsonPropertyName("word_highlights_blur")]
    public double? WordHighlightsBlur { get; set; }

    [JsonPropertyName("section_animation")]
    public CaptionStyleSectionAnimationModel? SectionAnimation { get; set; }

    [JsonPropertyName("word_animation")]
    public CaptionStyleWordAnimationModel? WordAnimation { get; set; }

    [JsonPropertyName("character_animation")]
    public CaptionStyleCharacterAnimationModel? CharacterAnimation { get; set; }

    [JsonPropertyName("cursor_enabled")]
    public bool? CursorEnabled { get; set; }

    [JsonPropertyName("width_pct")]
    public double? WidthPct { get; set; }

    [JsonPropertyName("horizontal_placement")]
    public CaptionStyleHorizontalPlacementModel? HorizontalPlacement { get; set; }

    [JsonPropertyName("vertical_placement")]
    public CaptionStyleVerticalPlacementModel? VerticalPlacement { get; set; }

    [JsonPropertyName("auto_break_enabled")]
    public bool? AutoBreakEnabled { get; set; }

    [JsonPropertyName("max_lines_per_section")]
    public int? MaxLinesPerSection { get; set; }

    [JsonPropertyName("max_words_per_line")]
    public int? MaxWordsPerLine { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    /// <remarks>
    /// Written out rather than synthesized. A record's generated Equals compares every instance
    /// field, and `_extensionData` is a fresh Dictionary per instance compared by REFERENCE, so two
    /// identical models were never equal — silently defeating ==, Distinct(), HashSet membership,
    /// dictionary keys and test assertions for every model in the SDK. Excluding it loses nothing:
    /// it is a transient deserialization sink whose contents are copied into
    /// AdditionalProperties, which IS compared here.
    /// </remarks>
    public virtual bool Equals(CaptionStyleModel? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // The synthesized record Equals compares EqualityContract, so a base instance never equals a
        // derived one. Hand-writing Equals drops that unless it is restated.
        if (EqualityContract != other.EqualityContract)
        {
            return false;
        }
        // Declared properties first: the additional-properties comparison walks a dictionary and
        // allocates a string per entry, and is the least likely of the three to differ, so letting
        // the cheap scalar comparisons short-circuit ahead of it matters for Distinct/HashSet over
        // large collections. Anchored on `true` so a model with no declared properties still emits
        // a valid expression.
        return true
            && ValueEquality.AreEqual(Template, other.Template)
            && ValueEquality.AreEqual(TextFont, other.TextFont)
            && ValueEquality.AreEqual(TextScale, other.TextScale)
            && ValueEquality.AreEqual(TextColor, other.TextColor)
            && ValueEquality.AreEqual(TextAlign, other.TextAlign)
            && ValueEquality.AreEqual(TextStyle, other.TextStyle)
            && ValueEquality.AreEqual(TextWeight, other.TextWeight)
            && ValueEquality.AreEqual(TextTransform, other.TextTransform)
            && ValueEquality.AreEqual(TextBlendMode, other.TextBlendMode)
            && ValueEquality.AreEqual(TextShadow, other.TextShadow)
            && ValueEquality.AreEqual(TextOutline, other.TextOutline)
            && ValueEquality.AreEqual(BackgroundEnabled, other.BackgroundEnabled)
            && ValueEquality.AreEqual(BackgroundColor, other.BackgroundColor)
            && ValueEquality.AreEqual(BackgroundOpacity, other.BackgroundOpacity)
            && ValueEquality.AreEqual(BackgroundBlur, other.BackgroundBlur)
            && ValueEquality.AreEqual(BackgroundBorderRadius, other.BackgroundBorderRadius)
            && ValueEquality.AreEqual(WordHighlightsEnabled, other.WordHighlightsEnabled)
            && ValueEquality.AreEqual(WordHighlightsColor, other.WordHighlightsColor)
            && ValueEquality.AreEqual(
                WordHighlightsBackgroundColor,
                other.WordHighlightsBackgroundColor
            )
            && ValueEquality.AreEqual(WordHighlightsOpacity, other.WordHighlightsOpacity)
            && ValueEquality.AreEqual(WordHighlightsBorderRadius, other.WordHighlightsBorderRadius)
            && ValueEquality.AreEqual(WordHighlightsBlur, other.WordHighlightsBlur)
            && ValueEquality.AreEqual(SectionAnimation, other.SectionAnimation)
            && ValueEquality.AreEqual(WordAnimation, other.WordAnimation)
            && ValueEquality.AreEqual(CharacterAnimation, other.CharacterAnimation)
            && ValueEquality.AreEqual(CursorEnabled, other.CursorEnabled)
            && ValueEquality.AreEqual(WidthPct, other.WidthPct)
            && ValueEquality.AreEqual(HorizontalPlacement, other.HorizontalPlacement)
            && ValueEquality.AreEqual(VerticalPlacement, other.VerticalPlacement)
            && ValueEquality.AreEqual(AutoBreakEnabled, other.AutoBreakEnabled)
            && ValueEquality.AreEqual(MaxLinesPerSection, other.MaxLinesPerSection)
            && ValueEquality.AreEqual(MaxWordsPerLine, other.MaxWordsPerLine)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Template);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextFont);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextScale);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextAlign);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextStyle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextWeight);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextTransform);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextBlendMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextShadow);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextOutline);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundOpacity);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundBlur);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundBorderRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordHighlightsEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordHighlightsColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordHighlightsBackgroundColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordHighlightsOpacity);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordHighlightsBorderRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordHighlightsBlur);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SectionAnimation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordAnimation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterAnimation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CursorEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WidthPct);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HorizontalPlacement);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VerticalPlacement);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoBreakEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxLinesPerSection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxWordsPerLine);
            hash = (hash * 31) + AdditionalProperties.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
