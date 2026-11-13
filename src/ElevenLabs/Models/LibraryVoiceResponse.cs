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
public record LibraryVoiceResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The public owner id of the voice.</value>
    [JsonPropertyName("public_owner_id")]
    public required string PublicOwnerId { get; set; }

    /// <value>The id of the voice.</value>
    [JsonPropertyName("voice_id")]
    public required string VoiceId { get; set; }

    /// <value>The date the voice was added to the library in Unix time.</value>
    [JsonPropertyName("date_unix")]
    public required int DateUnix { get; set; }

    /// <value>The name of the voice.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The accent of the voice.</value>
    [JsonPropertyName("accent")]
    public required string Accent { get; set; }

    /// <value>The gender of the voice.</value>
    [JsonPropertyName("gender")]
    public required string Gender { get; set; }

    /// <value>The age of the voice.</value>
    [JsonPropertyName("age")]
    public required string Age { get; set; }

    /// <value>The descriptive of the voice.</value>
    [JsonPropertyName("descriptive")]
    public required string Descriptive { get; set; }

    /// <value>The use case of the voice.</value>
    [JsonPropertyName("use_case")]
    public required string UseCase { get; set; }

    /// <value>The category of the voice.</value>
    [JsonPropertyName("category")]
    public required LibraryVoiceResponseCategory Category { get; set; }

    /// <value>The language of the voice.</value>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <value>The locale of the voice.</value>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <value>The description of the voice.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>The preview URL of the voice.</value>
    [JsonPropertyName("preview_url")]
    public string? PreviewUrl { get; set; }

    /// <value>The usage character count of the voice in the last year.</value>
    [JsonPropertyName("usage_character_count_1y")]
    public required int UsageCharacterCount1Y { get; set; }

    /// <value>The usage character count of the voice in the last 7 days.</value>
    [JsonPropertyName("usage_character_count_7d")]
    public required int UsageCharacterCount7D { get; set; }

    /// <value>The play API usage character count of the voice in the last year.</value>
    [JsonPropertyName("play_api_usage_character_count_1y")]
    public required int PlayApiUsageCharacterCount1Y { get; set; }

    /// <value>The number of times the voice has been cloned.</value>
    [JsonPropertyName("cloned_by_count")]
    public required int ClonedByCount { get; set; }

    /// <value>The rate multiplier of the voice.</value>
    [JsonPropertyName("rate")]
    public double? Rate { get; set; }

    /// <value>The rate of the voice in USD per 1000 credits. null if default</value>
    [JsonPropertyName("fiat_rate")]
    public double? FiatRate { get; set; }

    /// <value>Whether free users are allowed to use the voice.</value>
    [JsonPropertyName("free_users_allowed")]
    public required bool FreeUsersAllowed { get; set; }

    /// <value>Whether live moderation is enabled for the voice.</value>
    [JsonPropertyName("live_moderation_enabled")]
    public required bool LiveModerationEnabled { get; set; }

    /// <value>Whether the voice is featured.</value>
    [JsonPropertyName("featured")]
    public required bool Featured { get; set; }

    /// <value>The verified languages of the voice.</value>
    [JsonPropertyName("verified_languages")]
    public IEnumerable<VerifiedVoiceLanguageResponseModel>? VerifiedLanguages { get; set; }

    /// <value>The notice period of the voice.</value>
    [JsonPropertyName("notice_period")]
    public int? NoticePeriod { get; set; }

    /// <value>The Instagram username of the voice.</value>
    [JsonPropertyName("instagram_username")]
    public string? InstagramUsername { get; set; }

    /// <value>The Twitter username of the voice.</value>
    [JsonPropertyName("twitter_username")]
    public string? TwitterUsername { get; set; }

    /// <value>The YouTube username of the voice.</value>
    [JsonPropertyName("youtube_username")]
    public string? YoutubeUsername { get; set; }

    /// <value>The TikTok username of the voice.</value>
    [JsonPropertyName("tiktok_username")]
    public string? TiktokUsername { get; set; }

    /// <value>The image URL of the voice.</value>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    /// <value>Whether the voice was added by the user.</value>
    [JsonPropertyName("is_added_by_user")]
    public bool? IsAddedByUser { get; set; }

    /// <value>Whether the voice is bookmarked by the current user. Only relevant when is_added_by_user is True.</value>
    [JsonPropertyName("is_bookmarked")]
    public bool? IsBookmarked { get; set; }

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
    public virtual bool Equals(LibraryVoiceResponse? other)
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
            && ValueEquality.AreEqual(PublicOwnerId, other.PublicOwnerId)
            && ValueEquality.AreEqual(VoiceId, other.VoiceId)
            && ValueEquality.AreEqual(DateUnix, other.DateUnix)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Accent, other.Accent)
            && ValueEquality.AreEqual(Gender, other.Gender)
            && ValueEquality.AreEqual(Age, other.Age)
            && ValueEquality.AreEqual(Descriptive, other.Descriptive)
            && ValueEquality.AreEqual(UseCase, other.UseCase)
            && ValueEquality.AreEqual(Category, other.Category)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(Locale, other.Locale)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(PreviewUrl, other.PreviewUrl)
            && ValueEquality.AreEqual(UsageCharacterCount1Y, other.UsageCharacterCount1Y)
            && ValueEquality.AreEqual(UsageCharacterCount7D, other.UsageCharacterCount7D)
            && ValueEquality.AreEqual(
                PlayApiUsageCharacterCount1Y,
                other.PlayApiUsageCharacterCount1Y
            )
            && ValueEquality.AreEqual(ClonedByCount, other.ClonedByCount)
            && ValueEquality.AreEqual(Rate, other.Rate)
            && ValueEquality.AreEqual(FiatRate, other.FiatRate)
            && ValueEquality.AreEqual(FreeUsersAllowed, other.FreeUsersAllowed)
            && ValueEquality.AreEqual(LiveModerationEnabled, other.LiveModerationEnabled)
            && ValueEquality.AreEqual(Featured, other.Featured)
            && ValueEquality.AreEqual(VerifiedLanguages, other.VerifiedLanguages)
            && ValueEquality.AreEqual(NoticePeriod, other.NoticePeriod)
            && ValueEquality.AreEqual(InstagramUsername, other.InstagramUsername)
            && ValueEquality.AreEqual(TwitterUsername, other.TwitterUsername)
            && ValueEquality.AreEqual(YoutubeUsername, other.YoutubeUsername)
            && ValueEquality.AreEqual(TiktokUsername, other.TiktokUsername)
            && ValueEquality.AreEqual(ImageUrl, other.ImageUrl)
            && ValueEquality.AreEqual(IsAddedByUser, other.IsAddedByUser)
            && ValueEquality.AreEqual(IsBookmarked, other.IsBookmarked)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublicOwnerId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DateUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Accent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Gender);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Age);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Descriptive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseCase);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Category);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Locale);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviewUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UsageCharacterCount1Y);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UsageCharacterCount7D);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlayApiUsageCharacterCount1Y);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ClonedByCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Rate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FiatRate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FreeUsersAllowed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LiveModerationEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Featured);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VerifiedLanguages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NoticePeriod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InstagramUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TwitterUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(YoutubeUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TiktokUsername);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ImageUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsAddedByUser);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsBookmarked);
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
