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
public record DirectPublishingReadResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("read_id")]
    public required string ReadId { get; set; }

    [JsonPropertyName("created_at_unix")]
    public required int CreatedAtUnix { get; set; }

    [JsonPropertyName("updated_at_unix")]
    public required int UpdatedAtUnix { get; set; }

    [JsonPropertyName("word_count")]
    public required int WordCount { get; set; }

    [JsonPropertyName("char_count")]
    public required int CharCount { get; set; }

    [JsonPropertyName("chapters")]
    public IEnumerable<ReadMetadataChapterDbModel> Chapters { get; set; } =
        new List<ReadMetadataChapterDbModel>();

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("article_image_url")]
    public string? ArticleImageUrl { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("display_mode")]
    public DirectPublishingReadResponseModelDisplayMode? DisplayMode { get; set; }

    [JsonPropertyName("genre")]
    public IEnumerable<DirectPublishingReadResponseModelGenreItem>? Genre { get; set; }

    [JsonPropertyName("fiction")]
    public string? Fiction { get; set; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    [JsonPropertyName("original_file_type")]
    public string? OriginalFileType { get; set; }

    [JsonPropertyName("target_audience")]
    public DirectPublishingReadResponseModelTargetAudience? TargetAudience { get; set; }

    [JsonPropertyName("mature_content")]
    public bool? MatureContent { get; set; }

    [JsonPropertyName("safesearch_adult")]
    public bool? SafesearchAdult { get; set; }

    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    [JsonPropertyName("publication_date")]
    public string? PublicationDate { get; set; }

    [JsonPropertyName("isbn")]
    public string? Isbn { get; set; }

    [JsonPropertyName("ean")]
    public string? Ean { get; set; }

    [JsonPropertyName("legal_terms")]
    public ReadLegalTerms? LegalTerms { get; set; }

    [JsonPropertyName("content_guidelines_terms")]
    public ReadLegalTerms? ContentGuidelinesTerms { get; set; }

    [JsonPropertyName("last_updated_from_project_unix")]
    public int? LastUpdatedFromProjectUnix { get; set; }

    [JsonPropertyName("publishing_project_id")]
    public string? PublishingProjectId { get; set; }

    [JsonPropertyName("publishing_state")]
    public string? PublishingState { get; set; }

    [JsonPropertyName("publisher_profile_id")]
    public string? PublisherProfileId { get; set; }

    [JsonPropertyName("quality_score")]
    public int? QualityScore { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("copyright")]
    public string? Copyright { get; set; }

    [JsonPropertyName("subtitle")]
    public string? Subtitle { get; set; }

    [JsonPropertyName("distribution_territories")]
    public IEnumerable<string>? DistributionTerritories { get; set; }

    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("contributors")]
    public IEnumerable<Contributor>? Contributors { get; set; }

    [JsonPropertyName("payout_type")]
    public DirectPublishingReadResponseModelPayoutType? PayoutType { get; set; }

    [JsonPropertyName("list_price")]
    public double? ListPrice { get; set; }

    [JsonPropertyName("currency")]
    public DirectPublishingReadResponseModelCurrency? Currency { get; set; }

    [JsonPropertyName("original_audio_project_export_id")]
    public string? OriginalAudioProjectExportId { get; set; }

    [JsonPropertyName("original_audio_document_id")]
    public string? OriginalAudioDocumentId { get; set; }

    [JsonPropertyName("series_id")]
    public string? SeriesId { get; set; }

    [JsonPropertyName("volume")]
    public int? Volume { get; set; }

    [JsonPropertyName("published_at_unix")]
    public int? PublishedAtUnix { get; set; }

    [JsonPropertyName("read_slug")]
    public string? ReadSlug { get; set; }

    [JsonPropertyName("preview_audio_object")]
    public PreviewAudioDbModel? PreviewAudioObject { get; set; }

    [JsonPropertyName("sample_config")]
    public SampleConfigDbModel? SampleConfig { get; set; }

    [JsonPropertyName("review")]
    public ReviewResponseModel? Review { get; set; }

    [JsonPropertyName("voice_id")]
    public string? VoiceId { get; set; }

    [JsonPropertyName("can_use_assistant")]
    public bool? CanUseAssistant { get; set; }

    [JsonPropertyName("is_voice_changer_on")]
    public bool? IsVoiceChangerOn { get; set; }

    [JsonPropertyName("restricted_to_user_email_domains")]
    public IEnumerable<string>? RestrictedToUserEmailDomains { get; set; }

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
    public virtual bool Equals(DirectPublishingReadResponseModel? other)
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
            && ValueEquality.AreEqual(ReadId, other.ReadId)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(UpdatedAtUnix, other.UpdatedAtUnix)
            && ValueEquality.AreEqual(WordCount, other.WordCount)
            && ValueEquality.AreEqual(CharCount, other.CharCount)
            && ValueEquality.AreEqual(Chapters, other.Chapters)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(Author, other.Author)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(ArticleImageUrl, other.ArticleImageUrl)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(Locale, other.Locale)
            && ValueEquality.AreEqual(DisplayMode, other.DisplayMode)
            && ValueEquality.AreEqual(Genre, other.Genre)
            && ValueEquality.AreEqual(Fiction, other.Fiction)
            && ValueEquality.AreEqual(ContentType, other.ContentType)
            && ValueEquality.AreEqual(OriginalFileType, other.OriginalFileType)
            && ValueEquality.AreEqual(TargetAudience, other.TargetAudience)
            && ValueEquality.AreEqual(MatureContent, other.MatureContent)
            && ValueEquality.AreEqual(SafesearchAdult, other.SafesearchAdult)
            && ValueEquality.AreEqual(Origin, other.Origin)
            && ValueEquality.AreEqual(PublicationDate, other.PublicationDate)
            && ValueEquality.AreEqual(Isbn, other.Isbn)
            && ValueEquality.AreEqual(Ean, other.Ean)
            && ValueEquality.AreEqual(LegalTerms, other.LegalTerms)
            && ValueEquality.AreEqual(ContentGuidelinesTerms, other.ContentGuidelinesTerms)
            && ValueEquality.AreEqual(LastUpdatedFromProjectUnix, other.LastUpdatedFromProjectUnix)
            && ValueEquality.AreEqual(PublishingProjectId, other.PublishingProjectId)
            && ValueEquality.AreEqual(PublishingState, other.PublishingState)
            && ValueEquality.AreEqual(PublisherProfileId, other.PublisherProfileId)
            && ValueEquality.AreEqual(QualityScore, other.QualityScore)
            && ValueEquality.AreEqual(Publisher, other.Publisher)
            && ValueEquality.AreEqual(Copyright, other.Copyright)
            && ValueEquality.AreEqual(Subtitle, other.Subtitle)
            && ValueEquality.AreEqual(DistributionTerritories, other.DistributionTerritories)
            && ValueEquality.AreEqual(Edition, other.Edition)
            && ValueEquality.AreEqual(Contributors, other.Contributors)
            && ValueEquality.AreEqual(PayoutType, other.PayoutType)
            && ValueEquality.AreEqual(ListPrice, other.ListPrice)
            && ValueEquality.AreEqual(Currency, other.Currency)
            && ValueEquality.AreEqual(
                OriginalAudioProjectExportId,
                other.OriginalAudioProjectExportId
            )
            && ValueEquality.AreEqual(OriginalAudioDocumentId, other.OriginalAudioDocumentId)
            && ValueEquality.AreEqual(SeriesId, other.SeriesId)
            && ValueEquality.AreEqual(Volume, other.Volume)
            && ValueEquality.AreEqual(PublishedAtUnix, other.PublishedAtUnix)
            && ValueEquality.AreEqual(ReadSlug, other.ReadSlug)
            && ValueEquality.AreEqual(PreviewAudioObject, other.PreviewAudioObject)
            && ValueEquality.AreEqual(SampleConfig, other.SampleConfig)
            && ValueEquality.AreEqual(Review, other.Review)
            && ValueEquality.AreEqual(VoiceId, other.VoiceId)
            && ValueEquality.AreEqual(CanUseAssistant, other.CanUseAssistant)
            && ValueEquality.AreEqual(IsVoiceChangerOn, other.IsVoiceChangerOn)
            && ValueEquality.AreEqual(
                RestrictedToUserEmailDomains,
                other.RestrictedToUserEmailDomains
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReadId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Chapters);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Author);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ArticleImageUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Locale);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisplayMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Genre);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Fiction);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalFileType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetAudience);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MatureContent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SafesearchAdult);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Origin);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublicationDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Isbn);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Ean);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LegalTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentGuidelinesTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastUpdatedFromProjectUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublishingProjectId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublishingState);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublisherProfileId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QualityScore);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Publisher);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Copyright);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Subtitle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DistributionTerritories);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Edition);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Contributors);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PayoutType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ListPrice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Currency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalAudioProjectExportId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalAudioDocumentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SeriesId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Volume);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublishedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReadSlug);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviewAudioObject);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SampleConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Review);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanUseAssistant);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsVoiceChangerOn);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RestrictedToUserEmailDomains);
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
