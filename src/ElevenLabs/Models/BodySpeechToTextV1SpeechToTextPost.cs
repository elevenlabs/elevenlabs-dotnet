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
public record BodySpeechToTextV1SpeechToTextPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the model to use for transcription.</value>
    [JsonPropertyName("model_id")]
    public required string ModelId { get; set; }

    /// <value>The file to transcribe (100ms minimum audio length). All major audio and video formats are supported. Exactly one of the file or cloud_storage_url parameters must be provided. The file size must be less than 5.0GB.</value>
    [JsonPropertyName("file")]
    public FileParameter? File { get; set; }

    /// <value>An ISO-639-1 or ISO-639-3 language_code corresponding to the language of the audio file. Can sometimes improve transcription performance if known beforehand. Defaults to null, in this case the language is predicted automatically.</value>
    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    /// <value>Additional ISO-639-1 or ISO-639-3 language codes that may be present in the audio, alongside language_code. Improves transcription accuracy for multilingual audio. Supported by scribe_v3.</value>
    [JsonPropertyName("secondary_language_codes")]
    public IEnumerable<string>? SecondaryLanguageCodes { get; set; }

    /// <value>How numbers are formatted in the transcript: 'digits' (e.g. '42') or 'words' (e.g. 'forty-two'). Supported by scribe_v3.</value>
    [JsonPropertyName("numbers_format")]
    public BodySpeechToTextV1SpeechToTextPostNumbersFormat? NumbersFormat { get; set; }

    /// <value>Natural-language instruction applied to the final transcript (max 2000 characters). The edited text is returned in 'edited_transcript' alongside the original transcript. Cannot be combined with entity_detection, entity_redaction or use_multi_channel. Usage of this parameter will incur an additional 30% surcharge on the base transcription cost, billed for at least 10 seconds of audio.</value>
    [JsonPropertyName("transcript_edit")]
    public string? TranscriptEdit { get; set; }

    /// <value>Whether to tag audio events like (laughter), (footsteps), etc. in the transcription.</value>
    [JsonPropertyName("tag_audio_events")]
    public bool? TagAudioEvents { get; set; }

    /// <value>The maximum amount of speakers talking in the uploaded file. Can help with predicting who speaks when. The maximum amount of speakers that can be predicted is 32. Defaults to null, in this case the amount of speakers is set to the maximum value the model supports.</value>
    [JsonPropertyName("num_speakers")]
    public int? NumSpeakers { get; set; }

    /// <value>The granularity of the timestamps in the transcription. 'word' provides word-level timestamps and 'character' provides character-level timestamps per word.</value>
    [JsonPropertyName("timestamps_granularity")]
    public BodySpeechToTextV1SpeechToTextPostTimestampsGranularity? TimestampsGranularity { get; set; }

    /// <value>Whether to annotate which speaker is currently talking in the uploaded file.</value>
    [JsonPropertyName("diarize")]
    public bool? Diarize { get; set; }

    /// <value>Diarization threshold to apply during speaker diarization. A higher value means there will be a lower chance of one speaker being diarized as two different speakers but also a higher chance of two different speakers being diarized as one speaker (less total speakers predicted). A low value means there will be a higher chance of one speaker being diarized as two different speakers but also a lower chance of two different speakers being diarized as one speaker (more total speakers predicted). Can only be set when diarize=True and num_speakers=None. Defaults to None, in which case we will choose a threshold based on the model_id (0.22 usually).</value>
    [JsonPropertyName("diarization_threshold")]
    public double? DiarizationThreshold { get; set; }

    [JsonPropertyName("additional_formats")]
    public IEnumerable<ExportOptions>? AdditionalFormats { get; set; }

    /// <value>The format of input audio. Options are 'pcm_s16le_16' or 'other' For `pcm_s16le_16`, the input audio must be 16-bit PCM at a 16kHz sample rate, single channel (mono), and little-endian byte order. Latency will be lower than with passing an encoded waveform.</value>
    [JsonPropertyName("file_format")]
    public BodySpeechToTextV1SpeechToTextPostFileFormat? FileFormat { get; set; }

    /// <value>The URL of an audio or video file to transcribe. Supports hosted video or audio files, YouTube video URLs, TikTok video URLs, and other video hosting services.</value>
    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; set; }

    /// <value>Whether to send the transcription result to configured speech-to-text webhooks.  If set the request will return early without the transcription, which will be delivered later via webhook.</value>
    [JsonPropertyName("webhook")]
    public bool? Webhook { get; set; }

    /// <value>Optional specific webhook ID to send the transcription result to. Only valid when webhook is set to true. If not provided, transcription will be sent to all configured speech-to-text webhooks.</value>
    [JsonPropertyName("webhook_id")]
    public string? WebhookId { get; set; }

    /// <value>Controls the randomness of the transcription output. Accepts values between 0.0 and 2.0, where higher values result in more diverse and less deterministic results. If omitted, we will use a temperature based on the model you selected which is usually 0.</value>
    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }

    /// <value>If specified, our system will make a best effort to sample deterministically, such that repeated requests with the same seed and parameters should return the same result. Determinism is not guaranteed. Must be an integer between 0 and 2147483647.</value>
    [JsonPropertyName("seed")]
    public int? Seed { get; set; }

    /// <value>Whether the audio file contains multiple channels where each channel contains a single speaker. When enabled, each channel is transcribed independently. By default a separate transcript is returned per channel; set multichannel_output_style='combined' to instead receive a single transcript with all channels merged and sorted by time. Each word in the response includes a 'channel_index' field indicating which channel it was spoken on. A maximum of 5 channels is supported. Each channel is billed independently at the full audio duration, so cost scales linearly with the number of channels.</value>
    [JsonPropertyName("use_multi_channel")]
    public bool? UseMultiChannel { get; set; }

    /// <value>Controls the response shape when use_multi_channel is enabled. 'separate' (default) returns one transcript per channel under 'transcripts'. 'combined' merges all channels into a single transcript whose words are sorted by start time, each carrying a 'channel_index' - matching the single-channel response shape. 'combined' requires timestamps (timestamps_granularity must not be 'none') and does not support entity detection or redaction.</value>
    [JsonPropertyName("multichannel_output_style")]
    public BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle? MultichannelOutputStyle { get; set; }

    /// <value>Optional metadata to be included in the webhook response. This should be a JSON string representing an object with a maximum depth of 2 levels and maximum size of 16KB. Useful for tracking internal IDs, job references, or other contextual information.</value>
    [JsonPropertyName("webhook_metadata")]
    public OneOf<string, Dictionary<string, object?>>? WebhookMetadata { get; set; }

    /// <value>Detect entities in the transcript. Can be 'all' to detect all entities, a single entity type or category string, or a list of entity types/categories. Categories include 'pii', 'phi', 'pci', 'other', 'offensive_language'. When enabled, detected entities will be returned in the 'entities' field with their text, type, and character positions.</value>
    [JsonPropertyName("entity_detection")]
    public OneOf<string, IEnumerable<string>>? EntityDetection { get; set; }

    /// <value>If true, the transcription will not have any filler words, false starts and non-speech sounds. Supported by scribe_v2, scribe_v2_medical and scribe_v3.</value>
    [JsonPropertyName("no_verbatim")]
    public bool? NoVerbatim { get; set; }

    /// <value>Whether to use the speaker library for identifying known speakers during diarization. When enabled and diarize is true, detected speakers will be matched against registered speakers in the workspace's speaker library.</value>
    [JsonPropertyName("use_speaker_library")]
    public bool? UseSpeakerLibrary { get; set; }

    /// <value>Whether to detect speaker roles (agent vs customer). Requires diarize=true. Cannot be used with use_multi_channel=true. When enabled, speaker_id values will be 'agent' and 'customer' instead of 'speaker_0', 'speaker_1', etc. Usage incurs an additional 10% surcharge on base transcription cost.</value>
    [JsonPropertyName("detect_speaker_roles")]
    public bool? DetectSpeakerRoles { get; set; }

    /// <value>Redact entities from the transcript text. Accepts the same format as entity_detection: 'all', a category ('pii', 'phi'), or specific entity types. Must be a subset of entity_detection. When redaction is enabled, the entities field will not be returned.</value>
    [JsonPropertyName("entity_redaction")]
    public OneOf<string, IEnumerable<string>>? EntityRedaction { get; set; }

    /// <value>How to format redacted entities. 'redacted' replaces with {REDACTED}, 'entity_type' replaces with {ENTITY_TYPE}, 'enumerated_entity_type' replaces with {ENTITY_TYPE_N} where N enumerates each occurrence. Only used when entity_redaction is set.</value>
    [JsonPropertyName("entity_redaction_mode")]
    public string? EntityRedactionMode { get; set; }

    /// <value>A list of keyterms to bias the transcription towards.           The keyterms are words or phrases you want the model to recognise more accurately.           The number of keyterms cannot exceed 1000.           The length of each keyterm must be at most 50 characters.           Keyterms can contain at most 5 words (after normalisation).           For example ["hello", "world", "technical term"].           The following characters are not supported: `&lt;`, `&gt;`, `{`, `}`, `[`, `]`, `\`.           Usage of this parameter will incur an additional 20% surcharge on the base transcription cost.           When more than 100 keyterms are provided, a minimum billable duration of 20 seconds applies per request.</value>
    [JsonPropertyName("keyterms")]
    public IEnumerable<string>? Keyterms { get; set; }

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
    public virtual bool Equals(BodySpeechToTextV1SpeechToTextPost? other)
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
            && ValueEquality.AreEqual(File, other.File)
            && ValueEquality.AreEqual(LanguageCode, other.LanguageCode)
            && ValueEquality.AreEqual(SecondaryLanguageCodes, other.SecondaryLanguageCodes)
            && ValueEquality.AreEqual(NumbersFormat, other.NumbersFormat)
            && ValueEquality.AreEqual(TranscriptEdit, other.TranscriptEdit)
            && ValueEquality.AreEqual(TagAudioEvents, other.TagAudioEvents)
            && ValueEquality.AreEqual(NumSpeakers, other.NumSpeakers)
            && ValueEquality.AreEqual(TimestampsGranularity, other.TimestampsGranularity)
            && ValueEquality.AreEqual(Diarize, other.Diarize)
            && ValueEquality.AreEqual(DiarizationThreshold, other.DiarizationThreshold)
            && ValueEquality.AreEqual(AdditionalFormats, other.AdditionalFormats)
            && ValueEquality.AreEqual(FileFormat, other.FileFormat)
            && ValueEquality.AreEqual(SourceUrl, other.SourceUrl)
            && ValueEquality.AreEqual(Webhook, other.Webhook)
            && ValueEquality.AreEqual(WebhookId, other.WebhookId)
            && ValueEquality.AreEqual(Temperature, other.Temperature)
            && ValueEquality.AreEqual(Seed, other.Seed)
            && ValueEquality.AreEqual(UseMultiChannel, other.UseMultiChannel)
            && ValueEquality.AreEqual(MultichannelOutputStyle, other.MultichannelOutputStyle)
            && ValueEquality.AreEqual(WebhookMetadata, other.WebhookMetadata)
            && ValueEquality.AreEqual(EntityDetection, other.EntityDetection)
            && ValueEquality.AreEqual(NoVerbatim, other.NoVerbatim)
            && ValueEquality.AreEqual(UseSpeakerLibrary, other.UseSpeakerLibrary)
            && ValueEquality.AreEqual(DetectSpeakerRoles, other.DetectSpeakerRoles)
            && ValueEquality.AreEqual(EntityRedaction, other.EntityRedaction)
            && ValueEquality.AreEqual(EntityRedactionMode, other.EntityRedactionMode)
            && ValueEquality.AreEqual(Keyterms, other.Keyterms)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(File);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SecondaryLanguageCodes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NumbersFormat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscriptEdit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TagAudioEvents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NumSpeakers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TimestampsGranularity);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Diarize);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DiarizationThreshold);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalFormats);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileFormat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Webhook);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WebhookId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Temperature);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Seed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseMultiChannel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MultichannelOutputStyle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WebhookMetadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntityDetection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NoVerbatim);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseSpeakerLibrary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DetectSpeakerRoles);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntityRedaction);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntityRedactionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Keyterms);
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
