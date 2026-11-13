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
public record ProjectExtendedResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the project.</value>
    [JsonPropertyName("project_id")]
    public required string ProjectId { get; set; }

    /// <value>The name of the project.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The creation date of the project.</value>
    [JsonPropertyName("create_date_unix")]
    public required int CreateDateUnix { get; set; }

    /// <value>The user ID who created the project.</value>
    [JsonPropertyName("created_by_user_id")]
    public string? CreatedByUserId { get; set; }

    /// <value>The default title project voice reference ID.</value>
    [JsonPropertyName("default_title_voice_ref_id")]
    public required string DefaultTitleVoiceRefId { get; set; }

    /// <value>The default paragraph project voice reference ID.</value>
    [JsonPropertyName("default_paragraph_voice_ref_id")]
    public required string DefaultParagraphVoiceRefId { get; set; }

    /// <value>The default model ID.</value>
    [JsonPropertyName("default_model_id")]
    public required string DefaultModelId { get; set; }

    /// <value>The last conversion date of the project.</value>
    [JsonPropertyName("last_conversion_date_unix")]
    public int? LastConversionDateUnix { get; set; }

    /// <value>Whether the project can be downloaded.</value>
    [JsonPropertyName("can_be_downloaded")]
    public required bool CanBeDownloaded { get; set; }

    /// <value>The title of the project.</value>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <value>The author of the project.</value>
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    /// <value>The description of the project.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>List of genres of the project.</value>
    [JsonPropertyName("genres")]
    public IEnumerable<string>? Genres { get; set; }

    /// <value>The cover image URL of the project.</value>
    [JsonPropertyName("cover_image_url")]
    public string? CoverImageUrl { get; set; }

    /// <value>The target audience of the project.</value>
    [JsonPropertyName("target_audience")]
    public ProjectExtendedResponseTargetAudience? TargetAudience { get; set; }

    /// <value>Two-letter language code (ISO 639-1) of the language of the project.</value>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <value>The content type of the project, e.g. 'Novel' or 'Short Story'</value>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    /// <value>The original publication date of the project.</value>
    [JsonPropertyName("original_publication_date")]
    public string? OriginalPublicationDate { get; set; }

    /// <value>Whether the project contains mature content.</value>
    [JsonPropertyName("mature_content")]
    public bool? MatureContent { get; set; }

    /// <value>The ISBN number of the project.</value>
    [JsonPropertyName("isbn_number")]
    public string? IsbnNumber { get; set; }

    /// <value>Whether the project uses volume normalization.</value>
    [JsonPropertyName("volume_normalization")]
    public required bool VolumeNormalization { get; set; }

    /// <value>The state of the project.</value>
    [JsonPropertyName("state")]
    public required ProjectState State { get; set; }

    /// <value>The access level of the project.</value>
    [JsonPropertyName("access_level")]
    public required ProjectExtendedResponseAccessLevel AccessLevel { get; set; }

    /// <value>Whether the project is fiction.</value>
    [JsonPropertyName("fiction")]
    public ProjectExtendedResponseFiction? Fiction { get; set; }

    /// <value>Whether quality check is enabled for this project.</value>
    [JsonPropertyName("quality_check_on")]
    public required bool QualityCheckOn { get; set; }

    /// <value>Whether quality check is enabled on the project when bulk converting.</value>
    [JsonPropertyName("quality_check_on_when_bulk_convert")]
    public required bool QualityCheckOnWhenBulkConvert { get; set; }

    /// <value>The creation meta of the project.</value>
    [JsonPropertyName("creation_meta")]
    public ProjectCreationMetaResponseModel? CreationMeta { get; set; }

    /// <value>The source type of the project.</value>
    [JsonPropertyName("source_type")]
    public ProjectExtendedResponseSourceType? SourceType { get; set; }

    /// <value>Whether chapters are enabled for the project.</value>
    [JsonPropertyName("chapters_enabled")]
    public bool? ChaptersEnabled { get; set; }

    /// <value>Whether captions are enabled for the project.</value>
    [JsonPropertyName("captions_enabled")]
    public bool? CaptionsEnabled { get; set; }

    /// <value>Global styling to be applied to all captions</value>
    [JsonPropertyName("caption_style")]
    public CaptionStyleModel? CaptionStyle { get; set; }

    /// <value>Styling changes that have been made to the provided templates</value>
    [JsonPropertyName("caption_style_template_overrides")]
    public Dictionary<string, CaptionStyleModel>? CaptionStyleTemplateOverrides { get; set; }

    /// <value>The public share ID of the project.</value>
    [JsonPropertyName("public_share_id")]
    public string? PublicShareId { get; set; }

    /// <value>The aspect ratio of the project.</value>
    [JsonPropertyName("aspect_ratio")]
    public ProjectExtendedResponseAspectRatio? AspectRatio { get; set; }

    /// <value>Agent-related settings for the project</value>
    [JsonPropertyName("agent_settings")]
    public StudioAgentSettingsModel? AgentSettings { get; set; }

    [JsonPropertyName("quality_preset")]
    public required QualityPresetType QualityPreset { get; set; }

    /// <value>List of chapters of the project and their metadata.</value>
    [JsonPropertyName("chapters")]
    public IEnumerable<ChapterResponse> Chapters { get; set; } = new List<ChapterResponse>();

    /// <value>List of pronunciation dictionary versions of the project and their metadata.</value>
    [JsonPropertyName("pronunciation_dictionary_versions")]
    public IEnumerable<PronunciationDictionaryVersionResponseModel> PronunciationDictionaryVersions { get; set; } =
        new List<PronunciationDictionaryVersionResponseModel>();

    /// <value>List of pronunciation dictionary locators.</value>
    [JsonPropertyName("pronunciation_dictionary_locators")]
    public IEnumerable<PronunciationDictionaryLocatorResponseModel> PronunciationDictionaryLocators { get; set; } =
        new List<PronunciationDictionaryLocatorResponseModel>();

    /// <value>Whether text normalization is applied to the project.</value>
    [JsonPropertyName("apply_text_normalization")]
    public required ProjectExtendedResponseApplyTextNormalization ApplyTextNormalization { get; set; }

    /// <value>Experimental features for the project.</value>
    [JsonPropertyName("experimental")]
    public Dictionary<string, object?>? Experimental { get; set; }

    /// <value>List of uploaded assets e.g. videos, audios.</value>
    [JsonPropertyName("assets")]
    public IEnumerable<ProjectExtendedResponseAssetsItem> Assets { get; set; } =
        new List<ProjectExtendedResponseAssetsItem>();

    /// <value>List of configured project voices.</value>
    [JsonPropertyName("voices")]
    public IEnumerable<ProjectVoiceResponseModel> Voices { get; set; } =
        new List<ProjectVoiceResponseModel>();

    /// <value>List of voices used by the project.</value>
    [JsonPropertyName("base_voices")]
    public IEnumerable<Voice>? BaseVoices { get; set; }

    /// <value>The ElevenReader data if the book was published.</value>
    [JsonPropertyName("publishing_read")]
    public DirectPublishingReadResponseModel? PublishingRead { get; set; }

    /// <value>The default title voice ID.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("default_title_voice_id")]
    public string? DefaultTitleVoiceId { get; set; }

    /// <value>The default paragraph voice ID.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("default_paragraph_voice_id")]
    public string? DefaultParagraphVoiceId { get; set; }

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
    public virtual bool Equals(ProjectExtendedResponse? other)
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
            && ValueEquality.AreEqual(ProjectId, other.ProjectId)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(CreateDateUnix, other.CreateDateUnix)
            && ValueEquality.AreEqual(CreatedByUserId, other.CreatedByUserId)
            && ValueEquality.AreEqual(DefaultTitleVoiceRefId, other.DefaultTitleVoiceRefId)
            && ValueEquality.AreEqual(DefaultParagraphVoiceRefId, other.DefaultParagraphVoiceRefId)
            && ValueEquality.AreEqual(DefaultModelId, other.DefaultModelId)
            && ValueEquality.AreEqual(LastConversionDateUnix, other.LastConversionDateUnix)
            && ValueEquality.AreEqual(CanBeDownloaded, other.CanBeDownloaded)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(Author, other.Author)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(Genres, other.Genres)
            && ValueEquality.AreEqual(CoverImageUrl, other.CoverImageUrl)
            && ValueEquality.AreEqual(TargetAudience, other.TargetAudience)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(ContentType, other.ContentType)
            && ValueEquality.AreEqual(OriginalPublicationDate, other.OriginalPublicationDate)
            && ValueEquality.AreEqual(MatureContent, other.MatureContent)
            && ValueEquality.AreEqual(IsbnNumber, other.IsbnNumber)
            && ValueEquality.AreEqual(VolumeNormalization, other.VolumeNormalization)
            && ValueEquality.AreEqual(State, other.State)
            && ValueEquality.AreEqual(AccessLevel, other.AccessLevel)
            && ValueEquality.AreEqual(Fiction, other.Fiction)
            && ValueEquality.AreEqual(QualityCheckOn, other.QualityCheckOn)
            && ValueEquality.AreEqual(
                QualityCheckOnWhenBulkConvert,
                other.QualityCheckOnWhenBulkConvert
            )
            && ValueEquality.AreEqual(CreationMeta, other.CreationMeta)
            && ValueEquality.AreEqual(SourceType, other.SourceType)
            && ValueEquality.AreEqual(ChaptersEnabled, other.ChaptersEnabled)
            && ValueEquality.AreEqual(CaptionsEnabled, other.CaptionsEnabled)
            && ValueEquality.AreEqual(CaptionStyle, other.CaptionStyle)
            && ValueEquality.AreEqual(
                CaptionStyleTemplateOverrides,
                other.CaptionStyleTemplateOverrides
            )
            && ValueEquality.AreEqual(PublicShareId, other.PublicShareId)
            && ValueEquality.AreEqual(AspectRatio, other.AspectRatio)
            && ValueEquality.AreEqual(AgentSettings, other.AgentSettings)
            && ValueEquality.AreEqual(QualityPreset, other.QualityPreset)
            && ValueEquality.AreEqual(Chapters, other.Chapters)
            && ValueEquality.AreEqual(
                PronunciationDictionaryVersions,
                other.PronunciationDictionaryVersions
            )
            && ValueEquality.AreEqual(
                PronunciationDictionaryLocators,
                other.PronunciationDictionaryLocators
            )
            && ValueEquality.AreEqual(ApplyTextNormalization, other.ApplyTextNormalization)
            && ValueEquality.AreEqual(Experimental, other.Experimental)
            && ValueEquality.AreEqual(Assets, other.Assets)
            && ValueEquality.AreEqual(Voices, other.Voices)
            && ValueEquality.AreEqual(BaseVoices, other.BaseVoices)
            && ValueEquality.AreEqual(PublishingRead, other.PublishingRead)
            && ValueEquality.AreEqual(DefaultTitleVoiceId, other.DefaultTitleVoiceId)
            && ValueEquality.AreEqual(DefaultParagraphVoiceId, other.DefaultParagraphVoiceId)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProjectId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreateDateUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedByUserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultTitleVoiceRefId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultParagraphVoiceRefId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastConversionDateUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanBeDownloaded);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Author);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Genres);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CoverImageUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetAudience);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalPublicationDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MatureContent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsbnNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VolumeNormalization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(State);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccessLevel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Fiction);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QualityCheckOn);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QualityCheckOnWhenBulkConvert);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreationMeta);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChaptersEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CaptionsEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CaptionStyle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CaptionStyleTemplateOverrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublicShareId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AspectRatio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QualityPreset);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Chapters);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryVersions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryLocators);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApplyTextNormalization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Experimental);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Assets);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Voices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BaseVoices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PublishingRead);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultTitleVoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultParagraphVoiceId);
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
