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
public record WidgetConfigResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("variant")]
    public EmbedVariant? Variant { get; set; }

    [JsonPropertyName("placement")]
    public WidgetPlacement? Placement { get; set; }

    [JsonPropertyName("expandable")]
    public WidgetExpandable? Expandable { get; set; }

    /// <value>The avatar of the widget</value>
    [JsonPropertyName("avatar")]
    public WidgetConfigResponseAvatar? Avatar { get; set; }

    [JsonPropertyName("feedback_mode")]
    public WidgetFeedbackMode? FeedbackMode { get; set; }

    /// <value>Configuration for feedback collected at the end of the conversation</value>
    [JsonPropertyName("end_feedback")]
    public WidgetEndFeedbackConfig? EndFeedback { get; set; }

    /// <value>The background color of the widget</value>
    [JsonPropertyName("bg_color")]
    public string? BgColor { get; set; }

    /// <value>The text color of the widget</value>
    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }

    /// <value>The button color of the widget</value>
    [JsonPropertyName("btn_color")]
    public string? BtnColor { get; set; }

    /// <value>The button text color of the widget</value>
    [JsonPropertyName("btn_text_color")]
    public string? BtnTextColor { get; set; }

    /// <value>The border color of the widget</value>
    [JsonPropertyName("border_color")]
    public string? BorderColor { get; set; }

    /// <value>The focus color of the widget</value>
    [JsonPropertyName("focus_color")]
    public string? FocusColor { get; set; }

    /// <value>The border radius of the widget</value>
    [JsonPropertyName("border_radius")]
    public int? BorderRadius { get; set; }

    /// <value>The button radius of the widget</value>
    [JsonPropertyName("btn_radius")]
    public int? BtnRadius { get; set; }

    /// <value>The action text of the widget</value>
    [JsonPropertyName("action_text")]
    public string? ActionText { get; set; }

    /// <value>The start call text of the widget</value>
    [JsonPropertyName("start_call_text")]
    public string? StartCallText { get; set; }

    /// <value>The end call text of the widget</value>
    [JsonPropertyName("end_call_text")]
    public string? EndCallText { get; set; }

    /// <value>The expand text of the widget</value>
    [JsonPropertyName("expand_text")]
    public string? ExpandText { get; set; }

    /// <value>The text to display when the agent is listening</value>
    [JsonPropertyName("listening_text")]
    public string? ListeningText { get; set; }

    /// <value>The text to display when the agent is speaking</value>
    [JsonPropertyName("speaking_text")]
    public string? SpeakingText { get; set; }

    /// <value>The text to display when sharing</value>
    [JsonPropertyName("shareable_page_text")]
    public string? ShareablePageText { get; set; }

    /// <value>Whether to show terms and conditions on the shareable page</value>
    [JsonPropertyName("shareable_page_show_terms")]
    public bool? ShareablePageShowTerms { get; set; }

    /// <value>The text to display for terms and conditions</value>
    [JsonPropertyName("terms_text")]
    public string? TermsText { get; set; }

    /// <value>The HTML to display for terms and conditions</value>
    [JsonPropertyName("terms_html")]
    public string? TermsHtml { get; set; }

    /// <value>The key to display for terms and conditions</value>
    [JsonPropertyName("terms_key")]
    public string? TermsKey { get; set; }

    /// <value>Whether to show the avatar when the widget is collapsed</value>
    [JsonPropertyName("show_avatar_when_collapsed")]
    public bool? ShowAvatarWhenCollapsed { get; set; }

    /// <value>Whether to disable the banner</value>
    [JsonPropertyName("disable_banner")]
    public bool? DisableBanner { get; set; }

    /// <value>The override link for the widget</value>
    [JsonPropertyName("override_link")]
    public string? OverrideLink { get; set; }

    /// <value>List of allowed hostnames for clickable markdown links. Use { hostname: '*' } to allow any domain. Empty means no links are allowed.</value>
    [JsonPropertyName("markdown_link_allowed_hosts")]
    public IEnumerable<AllowlistItem>? MarkdownLinkAllowedHosts { get; set; }

    /// <value>Whether to automatically include www. variants of allowed hosts</value>
    [JsonPropertyName("markdown_link_include_www")]
    public bool? MarkdownLinkIncludeWww { get; set; }

    /// <value>Whether to allow http:// in addition to https:// for allowed hosts</value>
    [JsonPropertyName("markdown_link_allow_http")]
    public bool? MarkdownLinkAllowHttp { get; set; }

    /// <value>Whether to enable mic muting</value>
    [JsonPropertyName("mic_muting_enabled")]
    public bool? MicMutingEnabled { get; set; }

    /// <value>Whether the widget should show the conversation transcript as it goes on</value>
    [JsonPropertyName("transcript_enabled")]
    public bool? TranscriptEnabled { get; set; }

    /// <value>Whether the user should be able to send text messages</value>
    [JsonPropertyName("text_input_enabled")]
    public bool? TextInputEnabled { get; set; }

    /// <value>Whether to enable the conversation mode toggle in the widget</value>
    [JsonPropertyName("conversation_mode_toggle_enabled")]
    public bool? ConversationModeToggleEnabled { get; set; }

    /// <value>Whether the widget should be expanded by default</value>
    [JsonPropertyName("default_expanded")]
    public bool? DefaultExpanded { get; set; }

    /// <value>Whether the widget should always be expanded</value>
    [JsonPropertyName("always_expanded")]
    public bool? AlwaysExpanded { get; set; }

    /// <value>Whether the widget can be dismissed by the user</value>
    [JsonPropertyName("dismissible")]
    public bool? Dismissible { get; set; }

    /// <value>Whether to show agent working/done/error status during tool use</value>
    [JsonPropertyName("show_agent_status")]
    public bool? ShowAgentStatus { get; set; }

    /// <value>Whether to show the conversation ID after disconnection.</value>
    [JsonPropertyName("show_conversation_id")]
    public bool? ShowConversationId { get; set; }

    /// <value>Whether to strip audio markup from messages.</value>
    [JsonPropertyName("strip_audio_tags")]
    public bool? StripAudioTags { get; set; }

    /// <value>Theme for code block syntax highlighting. Defaults to auto-detection by the widget when not set.</value>
    [JsonPropertyName("syntax_highlight_theme")]
    public WidgetConfigResponseSyntaxHighlightTheme? SyntaxHighlightTheme { get; set; }

    [JsonPropertyName("text_contents")]
    public WidgetTextContents? TextContents { get; set; }

    [JsonPropertyName("styles")]
    public WidgetStyles? Styles { get; set; }

    /// <value>Whether to show the resize button</value>
    [JsonPropertyName("show_resize_button")]
    public bool? ShowResizeButton { get; set; }

    /// <value>Whether to ask the user to confirm before ending a chat or call</value>
    [JsonPropertyName("end_confirmation_enabled")]
    public bool? EndConfirmationEnabled { get; set; }

    /// <value>Whether the widget opens fullscreen on mobile</value>
    [JsonPropertyName("mobile_fullscreen")]
    public bool? MobileFullscreen { get; set; }

    /// <value>Whether voice call transcripts are revealed as the agent speaks</value>
    [JsonPropertyName("transcript_speech_sync_enabled")]
    public bool? TranscriptSpeechSyncEnabled { get; set; }

    [JsonPropertyName("language")]
    public required string Language { get; set; }

    [JsonPropertyName("supported_language_overrides")]
    public IEnumerable<string>? SupportedLanguageOverrides { get; set; }

    /// <value>Language presets for the widget</value>
    [JsonPropertyName("language_presets")]
    public Dictionary<string, WidgetLanguagePresetResponse>? LanguagePresets { get; set; }

    /// <value>Whether the agent uses text-only mode</value>
    [JsonPropertyName("text_only")]
    public bool? TextOnly { get; set; }

    /// <value>Whether the agent can be switched to text-only mode</value>
    [JsonPropertyName("supports_text_only")]
    public bool? SupportsTextOnly { get; set; }

    [JsonPropertyName("first_message")]
    public string? FirstMessage { get; set; }

    /// <value>Whether to use WebRTC for conversation connections</value>
    [JsonPropertyName("use_rtc")]
    public bool? UseRtc { get; set; }

    [JsonPropertyName("file_input_config")]
    public FileInputConfig? FileInputConfig { get; set; }

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
    public virtual bool Equals(WidgetConfigResponse? other)
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
            && ValueEquality.AreEqual(Variant, other.Variant)
            && ValueEquality.AreEqual(Placement, other.Placement)
            && ValueEquality.AreEqual(Expandable, other.Expandable)
            && ValueEquality.AreEqual(Avatar, other.Avatar)
            && ValueEquality.AreEqual(FeedbackMode, other.FeedbackMode)
            && ValueEquality.AreEqual(EndFeedback, other.EndFeedback)
            && ValueEquality.AreEqual(BgColor, other.BgColor)
            && ValueEquality.AreEqual(TextColor, other.TextColor)
            && ValueEquality.AreEqual(BtnColor, other.BtnColor)
            && ValueEquality.AreEqual(BtnTextColor, other.BtnTextColor)
            && ValueEquality.AreEqual(BorderColor, other.BorderColor)
            && ValueEquality.AreEqual(FocusColor, other.FocusColor)
            && ValueEquality.AreEqual(BorderRadius, other.BorderRadius)
            && ValueEquality.AreEqual(BtnRadius, other.BtnRadius)
            && ValueEquality.AreEqual(ActionText, other.ActionText)
            && ValueEquality.AreEqual(StartCallText, other.StartCallText)
            && ValueEquality.AreEqual(EndCallText, other.EndCallText)
            && ValueEquality.AreEqual(ExpandText, other.ExpandText)
            && ValueEquality.AreEqual(ListeningText, other.ListeningText)
            && ValueEquality.AreEqual(SpeakingText, other.SpeakingText)
            && ValueEquality.AreEqual(ShareablePageText, other.ShareablePageText)
            && ValueEquality.AreEqual(ShareablePageShowTerms, other.ShareablePageShowTerms)
            && ValueEquality.AreEqual(TermsText, other.TermsText)
            && ValueEquality.AreEqual(TermsHtml, other.TermsHtml)
            && ValueEquality.AreEqual(TermsKey, other.TermsKey)
            && ValueEquality.AreEqual(ShowAvatarWhenCollapsed, other.ShowAvatarWhenCollapsed)
            && ValueEquality.AreEqual(DisableBanner, other.DisableBanner)
            && ValueEquality.AreEqual(OverrideLink, other.OverrideLink)
            && ValueEquality.AreEqual(MarkdownLinkAllowedHosts, other.MarkdownLinkAllowedHosts)
            && ValueEquality.AreEqual(MarkdownLinkIncludeWww, other.MarkdownLinkIncludeWww)
            && ValueEquality.AreEqual(MarkdownLinkAllowHttp, other.MarkdownLinkAllowHttp)
            && ValueEquality.AreEqual(MicMutingEnabled, other.MicMutingEnabled)
            && ValueEquality.AreEqual(TranscriptEnabled, other.TranscriptEnabled)
            && ValueEquality.AreEqual(TextInputEnabled, other.TextInputEnabled)
            && ValueEquality.AreEqual(
                ConversationModeToggleEnabled,
                other.ConversationModeToggleEnabled
            )
            && ValueEquality.AreEqual(DefaultExpanded, other.DefaultExpanded)
            && ValueEquality.AreEqual(AlwaysExpanded, other.AlwaysExpanded)
            && ValueEquality.AreEqual(Dismissible, other.Dismissible)
            && ValueEquality.AreEqual(ShowAgentStatus, other.ShowAgentStatus)
            && ValueEquality.AreEqual(ShowConversationId, other.ShowConversationId)
            && ValueEquality.AreEqual(StripAudioTags, other.StripAudioTags)
            && ValueEquality.AreEqual(SyntaxHighlightTheme, other.SyntaxHighlightTheme)
            && ValueEquality.AreEqual(TextContents, other.TextContents)
            && ValueEquality.AreEqual(Styles, other.Styles)
            && ValueEquality.AreEqual(ShowResizeButton, other.ShowResizeButton)
            && ValueEquality.AreEqual(EndConfirmationEnabled, other.EndConfirmationEnabled)
            && ValueEquality.AreEqual(MobileFullscreen, other.MobileFullscreen)
            && ValueEquality.AreEqual(
                TranscriptSpeechSyncEnabled,
                other.TranscriptSpeechSyncEnabled
            )
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(SupportedLanguageOverrides, other.SupportedLanguageOverrides)
            && ValueEquality.AreEqual(LanguagePresets, other.LanguagePresets)
            && ValueEquality.AreEqual(TextOnly, other.TextOnly)
            && ValueEquality.AreEqual(SupportsTextOnly, other.SupportsTextOnly)
            && ValueEquality.AreEqual(FirstMessage, other.FirstMessage)
            && ValueEquality.AreEqual(UseRtc, other.UseRtc)
            && ValueEquality.AreEqual(FileInputConfig, other.FileInputConfig)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Variant);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Placement);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Expandable);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Avatar);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FeedbackMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndFeedback);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BgColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BtnColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BtnTextColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BorderColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FocusColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BorderRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BtnRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ActionText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartCallText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndCallText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExpandText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ListeningText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeakingText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShareablePageText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShareablePageShowTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TermsText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TermsHtml);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TermsKey);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShowAvatarWhenCollapsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableBanner);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OverrideLink);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MarkdownLinkAllowedHosts);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MarkdownLinkIncludeWww);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MarkdownLinkAllowHttp);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MicMutingEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscriptEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextInputEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationModeToggleEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultExpanded);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AlwaysExpanded);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Dismissible);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShowAgentStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShowConversationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StripAudioTags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SyntaxHighlightTheme);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextContents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Styles);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShowResizeButton);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndConfirmationEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MobileFullscreen);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscriptSpeechSyncEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportedLanguageOverrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguagePresets);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextOnly);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportsTextOnly);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FirstMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseRtc);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileInputConfig);
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
