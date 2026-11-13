using ElevenLabs;
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

namespace ElevenLabs.Studio;

[Serializable]
public record BodyCreateStudioProjectV1StudioProjectsPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The name of the Studio project, used for identification only.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The voice_id that corresponds to the default voice used for new titles.</value>
    [JsonPropertyName("default_title_voice_id")]
    public string? DefaultTitleVoiceId { get; set; }

    /// <value>The voice_id that corresponds to the default voice used for new paragraphs.</value>
    [JsonPropertyName("default_paragraph_voice_id")]
    public string? DefaultParagraphVoiceId { get; set; }

    /// <value>The ID of the model to be used for this Studio project, you can query GET /v1/models to list all available models.</value>
    [JsonPropertyName("default_model_id")]
    public string? DefaultModelId { get; set; }

    /// <value>An optional URL from which we will extract content to initialize the Studio project. If this is set, 'from_url' and 'from_content' must be null. If neither 'from_url', 'from_document', 'from_content' are provided we will initialize the Studio project as blank.</value>
    [JsonPropertyName("from_url")]
    public string? FromUrl { get; set; }

    /// <value>An optional .epub, .pdf, .txt or similar file can be provided. If provided, we will initialize the Studio project with its content. If this is set, 'from_url' and 'from_content' must be null. If neither 'from_url', 'from_document', 'from_content' are provided we will initialize the Studio project as blank.</value>
    [JsonPropertyName("from_document")]
    public FileParameter? FromDocument { get; set; }

    /// <value>
    /// An optional content to initialize the Studio project with. If this is set, 'from_url' and 'from_document' must be null. If neither 'from_url', 'from_document', 'from_content' are provided we will initialize the Studio project as blank.
    ///
    ///     Example:
    ///     [{"name": "Chapter A", "blocks": [{"sub_type": "p", "nodes": [{"voice_id": "6lCwbsX1yVjD49QmpkT0", "text": "A", "type": "tts_node"}, {"voice_id": "6lCwbsX1yVjD49QmpkT1", "text": "B", "type": "tts_node"}]}, {"sub_type": "h1", "nodes": [{"voice_id": "6lCwbsX1yVjD49QmpkT0", "text": "C", "type": "tts_node"}, {"voice_id": "6lCwbsX1yVjD49QmpkT1", "text": "D", "type": "tts_node"}]}]}, {"name": "Chapter B", "blocks": [{"sub_type": "p", "nodes": [{"voice_id": "6lCwbsX1yVjD49QmpkT0", "text": "E", "type": "tts_node"}, {"voice_id": "6lCwbsX1yVjD49QmpkT1", "text": "F", "type": "tts_node"}]}, {"sub_type": "h2", "nodes": [{"voice_id": "6lCwbsX1yVjD49QmpkT0", "text": "G", "type": "tts_node"}, {"voice_id": "6lCwbsX1yVjD49QmpkT1", "text": "H", "type": "tts_node"}]}]}]
    /// </value>
    [JsonPropertyName("from_content_json")]
    public string? FromContentJson { get; set; }

    /// <value>
    /// Output quality of the generated audio. Must be one of:
    /// 'standard' - standard output format, 128kbps with 44.1kHz sample rate.
    /// 'high' - high quality output format, 192kbps with 44.1kHz sample rate and major improvements on our side.
    /// 'ultra' - ultra quality output format, 192kbps with 44.1kHz sample rate and highest improvements on our side.
    /// 'ultra_lossless' - ultra quality output format, 705.6kbps with 44.1kHz sample rate and highest improvements on our side in a fully lossless format.
    /// If not provided, defaults to the highest quality preset available on your subscription tier.
    /// </value>
    [JsonPropertyName("quality_preset")]
    public QualityPresetType? QualityPreset { get; set; }

    /// <value>An optional name of the author of the Studio project, this will be added as metadata to the mp3 file on Studio project or chapter download.</value>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <value>An optional name of the author of the Studio project, this will be added as metadata to the mp3 file on Studio project or chapter download.</value>
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    /// <value>An optional description of the Studio project.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>An optional list of genres associated with the Studio project.</value>
    [JsonPropertyName("genres")]
    public IEnumerable<string>? Genres { get; set; }

    /// <value>An optional target audience of the Studio project.</value>
    [JsonPropertyName("target_audience")]
    public BodyCreateStudioProjectV1StudioProjectsPostTargetAudience? TargetAudience { get; set; }

    /// <value>An optional language of the Studio project. Two-letter language code (ISO 639-1).</value>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <value>An optional content type of the Studio project.</value>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    /// <value>An optional original publication date of the Studio project, in the format YYYY-MM-DD or YYYY.</value>
    [JsonPropertyName("original_publication_date")]
    public string? OriginalPublicationDate { get; set; }

    /// <value>An optional specification of whether this Studio project contains mature content.</value>
    [JsonPropertyName("mature_content")]
    public bool? MatureContent { get; set; }

    /// <value>An optional ISBN number of the Studio project you want to create, this will be added as metadata to the mp3 file on Studio project or chapter download.</value>
    [JsonPropertyName("isbn_number")]
    public string? IsbnNumber { get; set; }

    /// <value>[Deprecated] When the Studio project is downloaded, should the returned audio have postprocessing in order to make it compliant with audiobook normalized volume requirements</value>
    [JsonPropertyName("acx_volume_normalization")]
    public bool? AcxVolumeNormalization { get; set; }

    /// <value>When the Studio project is downloaded, should the returned audio have postprocessing in order to make it compliant with audiobook normalized volume requirements</value>
    [JsonPropertyName("volume_normalization")]
    public bool? VolumeNormalization { get; set; }

    /// <value>A list of pronunciation dictionary locators (pronunciation_dictionary_id, version_id) encoded as a list of JSON strings for pronunciation dictionaries to be applied to the text. A list of json encoded strings is required as adding projects may occur through formData as opposed to jsonBody. To specify multiple dictionaries use multiple --form lines in your curl, such as --form 'pronunciation_dictionary_locators="{\"pronunciation_dictionary_id\":\"Vmd4Zor6fplcA7WrINey\",\"version_id\":\"hRPaxjlTdR7wFMhV4w0b\"}"' --form 'pronunciation_dictionary_locators="{\"pronunciation_dictionary_id\":\"JzWtcGQMJ6bnlWwyMo7e\",\"version_id\":\"lbmwxiLu4q6txYxgdZqn\"}"'.</value>
    [JsonPropertyName("pronunciation_dictionary_locators")]
    public IEnumerable<string>? PronunciationDictionaryLocators { get; set; }

    /// <value>
    /// A url that will be called by our service when the Studio project is converted. Request will contain a json blob containing the status of the conversion
    ///     Messages:
    ///     1. When project was converted successfully:
    ///     {
    ///       type: "project_conversion_status",
    ///       event_timestamp: 1234567890,
    ///       data: {
    ///         request_id: "1234567890",
    ///         project_id: "21m00Tcm4TlvDq8ikWAM",
    ///         conversion_status: "success",
    ///         project_snapshot_id: "22m00Tcm4TlvDq8ikMAT",
    ///         error_details: None,
    ///       }
    ///     }
    ///     2. When project conversion failed:
    ///     {
    ///       type: "project_conversion_status",
    ///       event_timestamp: 1234567890,
    ///       data: {
    ///         request_id: "1234567890",
    ///         project_id: "21m00Tcm4TlvDq8ikWAM",
    ///         conversion_status: "error",
    ///         project_snapshot_id: None,
    ///         error_details: "Error details if conversion failed"
    ///       }
    ///     }
    ///
    ///     3. When chapter was converted successfully:
    ///     {
    ///       type: "chapter_conversion_status",
    ///       event_timestamp: 1234567890,
    ///       data: {
    ///         request_id: "1234567890",
    ///         project_id: "21m00Tcm4TlvDq8ikWAM",
    ///         chapter_id: "22m00Tcm4TlvDq8ikMAT",
    ///         conversion_status: "success",
    ///         chapter_snapshot_id: "23m00Tcm4TlvDq8ikMAV",
    ///         error_details: None,
    ///       }
    ///     }
    ///     4. When chapter conversion failed:
    ///     {
    ///       type: "chapter_conversion_status",
    ///       event_timestamp: 1234567890,
    ///       data: {
    ///         request_id: "1234567890",
    ///         project_id: "21m00Tcm4TlvDq8ikWAM",
    ///         chapter_id: "22m00Tcm4TlvDq8ikMAT",
    ///         conversion_status: "error",
    ///         chapter_snapshot_id: None,
    ///         error_details: "Error details if conversion failed"
    ///       }
    ///     }
    /// </value>
    [JsonPropertyName("callback_url")]
    public string? CallbackUrl { get; set; }

    /// <value>An optional specification of whether the content of this Studio project is fiction.</value>
    [JsonPropertyName("fiction")]
    public BodyCreateStudioProjectV1StudioProjectsPostFiction? Fiction { get; set; }

    /// <value>
    /// This parameter controls text normalization with four modes: 'auto', 'on', 'apply_english' and 'off'.
    ///     When set to 'auto', the system will automatically decide whether to apply text normalization
    ///     (e.g., spelling out numbers). With 'on', text normalization will always be applied, while
    ///     with 'off', it will be skipped. 'apply_english' is the same as 'on' but will assume that text is in English.
    /// </value>
    [JsonPropertyName("apply_text_normalization")]
    public BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization? ApplyTextNormalization { get; set; }

    /// <value>Whether to auto convert the Studio project to audio or not.</value>
    [JsonPropertyName("auto_convert")]
    public bool? AutoConvert { get; set; }

    /// <value>[Alpha Feature] Whether automatically assign voices to phrases in the create Project.</value>
    [JsonPropertyName("auto_assign_voices")]
    public bool? AutoAssignVoices { get; set; }

    /// <value>The type of Studio project to create.</value>
    [JsonPropertyName("source_type")]
    public BodyCreateStudioProjectV1StudioProjectsPostSourceType? SourceType { get; set; }

    /// <value>
    /// Optional voice settings overrides for the project, encoded as a list of JSON strings.
    ///
    ///     Example:
    ///     ["{\"voice_id\": \"21m00Tcm4TlvDq8ikWAM\", \"stability\": 0.7, \"similarity_boost\": 0.8, \"style\": 0.5, \"speed\": 1.0, \"use_speaker_boost\": true}"]
    /// </value>
    [JsonPropertyName("voice_settings")]
    public IEnumerable<string>? VoiceSettings { get; set; }

    /// <value>If true, creates a corresponding read for direct publishing in draft state</value>
    [JsonPropertyName("create_publishing_read")]
    public bool? CreatePublishingRead { get; set; }

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
    public virtual bool Equals(BodyCreateStudioProjectV1StudioProjectsPost? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(DefaultTitleVoiceId, other.DefaultTitleVoiceId)
            && ValueEquality.AreEqual(DefaultParagraphVoiceId, other.DefaultParagraphVoiceId)
            && ValueEquality.AreEqual(DefaultModelId, other.DefaultModelId)
            && ValueEquality.AreEqual(FromUrl, other.FromUrl)
            && ValueEquality.AreEqual(FromDocument, other.FromDocument)
            && ValueEquality.AreEqual(FromContentJson, other.FromContentJson)
            && ValueEquality.AreEqual(QualityPreset, other.QualityPreset)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(Author, other.Author)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(Genres, other.Genres)
            && ValueEquality.AreEqual(TargetAudience, other.TargetAudience)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(ContentType, other.ContentType)
            && ValueEquality.AreEqual(OriginalPublicationDate, other.OriginalPublicationDate)
            && ValueEquality.AreEqual(MatureContent, other.MatureContent)
            && ValueEquality.AreEqual(IsbnNumber, other.IsbnNumber)
            && ValueEquality.AreEqual(AcxVolumeNormalization, other.AcxVolumeNormalization)
            && ValueEquality.AreEqual(VolumeNormalization, other.VolumeNormalization)
            && ValueEquality.AreEqual(
                PronunciationDictionaryLocators,
                other.PronunciationDictionaryLocators
            )
            && ValueEquality.AreEqual(CallbackUrl, other.CallbackUrl)
            && ValueEquality.AreEqual(Fiction, other.Fiction)
            && ValueEquality.AreEqual(ApplyTextNormalization, other.ApplyTextNormalization)
            && ValueEquality.AreEqual(AutoConvert, other.AutoConvert)
            && ValueEquality.AreEqual(AutoAssignVoices, other.AutoAssignVoices)
            && ValueEquality.AreEqual(SourceType, other.SourceType)
            && ValueEquality.AreEqual(VoiceSettings, other.VoiceSettings)
            && ValueEquality.AreEqual(CreatePublishingRead, other.CreatePublishingRead)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultTitleVoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultParagraphVoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FromUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FromDocument);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FromContentJson);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QualityPreset);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Author);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Genres);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetAudience);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalPublicationDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MatureContent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsbnNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AcxVolumeNormalization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VolumeNormalization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryLocators);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallbackUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Fiction);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApplyTextNormalization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoConvert);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoAssignVoices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatePublishingRead);
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
