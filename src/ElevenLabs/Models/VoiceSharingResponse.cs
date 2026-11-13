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
public record VoiceSharingResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The status of the voice sharing.</value>
    [JsonPropertyName("status")]
    public VoiceSharingState? Status { get; set; }

    /// <value>The sample ID of the history item.</value>
    [JsonPropertyName("history_item_sample_id")]
    public string? HistoryItemSampleId { get; set; }

    /// <value>The Unix time, in seconds, at which the voice was shared.</value>
    [JsonPropertyName("date_unix")]
    public int? DateUnix { get; set; }

    /// <value>A list of whitelisted emails.</value>
    [JsonPropertyName("whitelisted_emails")]
    public IEnumerable<string>? WhitelistedEmails { get; set; }

    /// <value>The ID of the public owner.</value>
    [JsonPropertyName("public_owner_id")]
    public string? PublicOwnerId { get; set; }

    /// <value>The ID of the original voice.</value>
    [JsonPropertyName("original_voice_id")]
    public string? OriginalVoiceId { get; set; }

    /// <value>Whether financial rewards are enabled.</value>
    [JsonPropertyName("financial_rewards_enabled")]
    public bool? FinancialRewardsEnabled { get; set; }

    /// <value>Whether free users are allowed.</value>
    [JsonPropertyName("free_users_allowed")]
    public bool? FreeUsersAllowed { get; set; }

    /// <value>Whether live moderation is enabled.</value>
    [JsonPropertyName("live_moderation_enabled")]
    public bool? LiveModerationEnabled { get; set; }

    /// <value>The rate of the voice sharing.</value>
    [JsonPropertyName("rate")]
    public double? Rate { get; set; }

    /// <value>The rate of the voice sharing in USD per 1000 credits.</value>
    [JsonPropertyName("fiat_rate")]
    public double? FiatRate { get; set; }

    /// <value>The notice period of the voice sharing.</value>
    [JsonPropertyName("notice_period")]
    public int? NoticePeriod { get; set; }

    /// <value>The Unix time, in seconds, at which users who added the voice from the Voice Library lose access to it.</value>
    [JsonPropertyName("disable_at_unix")]
    public int? DisableAtUnix { get; set; }

    /// <value>Whether voice mixing is allowed.</value>
    [JsonPropertyName("voice_mixing_allowed")]
    public bool? VoiceMixingAllowed { get; set; }

    /// <value>Whether the voice is featured.</value>
    [JsonPropertyName("featured")]
    public bool? Featured { get; set; }

    /// <value>The category of the voice.</value>
    [JsonPropertyName("category")]
    public VoiceSharingResponseCategory? Category { get; set; }

    /// <value>Whether the reader app is enabled.</value>
    [JsonPropertyName("reader_app_enabled")]
    public bool? ReaderAppEnabled { get; set; }

    /// <value>The image URL of the voice.</value>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    /// <value>The ban reason of the voice.</value>
    [JsonPropertyName("ban_reason")]
    public string? BanReason { get; set; }

    /// <value>The number of likes on the voice.</value>
    [JsonPropertyName("liked_by_count")]
    public int? LikedByCount { get; set; }

    /// <value>The number of clones on the voice.</value>
    [JsonPropertyName("cloned_by_count")]
    public int? ClonedByCount { get; set; }

    /// <value>The name of the voice.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>The description of the voice.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>The labels of the voice.</value>
    [JsonPropertyName("labels")]
    public Dictionary<string, string>? Labels { get; set; }

    /// <value>The review status of the voice.</value>
    [JsonPropertyName("review_status")]
    public ReviewStatus? ReviewStatus { get; set; }

    /// <value>The review message of the voice.</value>
    [JsonPropertyName("review_message")]
    public string? ReviewMessage { get; set; }

    /// <value>Whether the voice is enabled in the library.</value>
    [JsonPropertyName("enabled_in_library")]
    public bool? EnabledInLibrary { get; set; }

    /// <value>The Instagram username of the voice.</value>
    [JsonPropertyName("instagram_username")]
    public string? InstagramUsername { get; set; }

    /// <value>The Twitter/X username of the voice.</value>
    [JsonPropertyName("twitter_username")]
    public string? TwitterUsername { get; set; }

    /// <value>The YouTube username of the voice.</value>
    [JsonPropertyName("youtube_username")]
    public string? YoutubeUsername { get; set; }

    /// <value>The TikTok username of the voice.</value>
    [JsonPropertyName("tiktok_username")]
    public string? TiktokUsername { get; set; }

    /// <value>The moderation check of the voice.</value>
    [JsonPropertyName("moderation_check")]
    public VoiceSharingModerationCheckResponseModel? ModerationCheck { get; set; }

    /// <value>The reader restricted on of the voice.</value>
    [JsonPropertyName("reader_restricted_on")]
    public IEnumerable<ReaderResourceResponseModel>? ReaderRestrictedOn { get; set; }

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
    public virtual bool Equals(VoiceSharingResponse? other)
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
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(HistoryItemSampleId, other.HistoryItemSampleId)
            && ValueEquality.AreEqual(DateUnix, other.DateUnix)
            && ValueEquality.AreEqual(WhitelistedEmails, other.WhitelistedEmails)
            && ValueEquality.AreEqual(PublicOwnerId, other.PublicOwnerId)
            && ValueEquality.AreEqual(OriginalVoiceId, other.OriginalVoiceId)
            && ValueEquality.AreEqual(FinancialRewardsEnabled, other.FinancialRewardsEnabled)
            && ValueEquality.AreEqual(FreeUsersAllowed, other.FreeUsersAllowed)
            && ValueEquality.AreEqual(LiveModerationEnabled, other.LiveModerationEnabled)
            && ValueEquality.AreEqual(Rate, other.Rate)
            && ValueEquality.AreEqual(FiatRate, other.FiatRate)
            && ValueEquality.AreEqual(NoticePeriod, other.NoticePeriod)
            && ValueEquality.AreEqual(DisableAtUnix, other.DisableAtUnix)
            && ValueEquality.AreEqual(VoiceMixingAllowed, other.VoiceMixingAllowed)
            && ValueEquality.AreEqual(Featured, other.Featured)
            && ValueEquality.AreEqual(Category, other.Category)
            && ValueEquality.AreEqual(ReaderAppEnabled, other.ReaderAppEnabled)
            && ValueEquality.AreEqual(ImageUrl, other.ImageUrl)
            && ValueEquality.AreEqual(BanReason, other.BanReason)
            && ValueEquality.AreEqual(LikedByCount, other.LikedByCount)
            && ValueEquality.AreEqual(ClonedByCount, other.ClonedByCount)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(Labels, other.Labels)
            && ValueEquality.AreEqual(ReviewStatus, other.ReviewStatus)
            && ValueEquality.AreEqual(ReviewMessage, other.ReviewMessage)
            && ValueEquality.AreEqual(EnabledInLibrary, other.EnabledInLibrary)
            && ValueEquality.AreEqual(InstagramUsername, other.InstagramUsername)
            && ValueEquality.AreEqual(TwitterUsername, other.TwitterUsername)
            && ValueEquality.AreEqual(YoutubeUsername, other.YoutubeUsername)
            && ValueEquality.AreEqual(TiktokUsername, other.TiktokUsername)
            && ValueEquality.AreEqual(ModerationCheck, other.ModerationCheck)
            && ValueEquality.AreEqual(ReaderRestrictedOn, other.ReaderRestrictedOn)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HistoryItemSampleId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DateUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WhitelistedEmails);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublicOwnerId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalVoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FinancialRewardsEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FreeUsersAllowed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LiveModerationEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Rate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FiatRate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NoticePeriod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceMixingAllowed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Featured);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Category);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReaderAppEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ImageUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BanReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LikedByCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ClonedByCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Labels);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReviewStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReviewMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnabledInLibrary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InstagramUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TwitterUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(YoutubeUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TiktokUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModerationCheck);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReaderRestrictedOn);
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
