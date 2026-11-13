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
using OneOf;

namespace ElevenLabs;

[Serializable]
public record BodyCreatePodcastV1StudioPodcastsPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the model to be used for this Studio project, you can query GET /v1/models to list all available models.</value>
    [JsonPropertyName("model_id")]
    public required string ModelId { get; set; }

    /// <value>The type of podcast to generate. Can be 'conversation', an interaction between two voices, or 'bulletin', a monologue.</value>
    [JsonPropertyName("mode")]
    public required Mode Mode { get; set; }

    /// <value>The source content for the Podcast.</value>
    [JsonPropertyName("source")]
    public required OneOf<
        PodcastTextSource,
        PodcastUrlSource,
        IEnumerable<Source3>
    > Source { get; set; }

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

    /// <value>
    /// Duration of the generated podcast. Must be one of:
    /// short - produces podcasts shorter than 3 minutes.
    /// default - produces podcasts roughly between 3-7 minutes.
    /// long - produces podcasts longer than 7 minutes.
    /// </value>
    [JsonPropertyName("duration_scale")]
    public BodyCreatePodcastV1StudioPodcastsPostDurationScale? DurationScale { get; set; }

    /// <value>An optional language of the Studio project. Two-letter language code (ISO 639-1).</value>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <value>The intro text that will always be added to the beginning of the podcast.</value>
    [JsonPropertyName("intro")]
    public string? Intro { get; set; }

    /// <value>The outro text that will always be added to the end of the podcast.</value>
    [JsonPropertyName("outro")]
    public string? Outro { get; set; }

    /// <value>Additional instructions prompt for the podcast generation used to adjust the podcast's style and tone.</value>
    [JsonPropertyName("instructions_prompt")]
    public string? InstructionsPrompt { get; set; }

    /// <value>A brief summary or highlights of the Studio project's content, providing key points or themes. This should be between 10 and 70 characters.</value>
    [JsonPropertyName("highlights")]
    public IEnumerable<string>? Highlights { get; set; }

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

    /// <value>
    /// This parameter controls text normalization with four modes: 'auto', 'on', 'apply_english' and 'off'.
    ///     When set to 'auto', the system will automatically decide whether to apply text normalization
    ///     (e.g., spelling out numbers). With 'on', text normalization will always be applied, while
    ///     with 'off', it will be skipped. 'apply_english' is the same as 'on' but will assume that text is in English.
    /// </value>
    [JsonPropertyName("apply_text_normalization")]
    public BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization? ApplyTextNormalization { get; set; }

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
    public virtual bool Equals(BodyCreatePodcastV1StudioPodcastsPost? other)
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
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(Mode, other.Mode)
            && ValueEquality.AreEqual(Source, other.Source)
            && ValueEquality.AreEqual(QualityPreset, other.QualityPreset)
            && ValueEquality.AreEqual(DurationScale, other.DurationScale)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(Intro, other.Intro)
            && ValueEquality.AreEqual(Outro, other.Outro)
            && ValueEquality.AreEqual(InstructionsPrompt, other.InstructionsPrompt)
            && ValueEquality.AreEqual(Highlights, other.Highlights)
            && ValueEquality.AreEqual(CallbackUrl, other.CallbackUrl)
            && ValueEquality.AreEqual(ApplyTextNormalization, other.ApplyTextNormalization)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Mode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Source);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QualityPreset);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationScale);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Intro);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Outro);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InstructionsPrompt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Highlights);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallbackUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApplyTextNormalization);
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
