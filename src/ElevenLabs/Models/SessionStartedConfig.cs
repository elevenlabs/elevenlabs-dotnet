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
public record SessionStartedConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("sample_rate")]
    public required int SampleRate { get; set; }

    [JsonPropertyName("audio_format")]
    public required SessionStartedConfigAudioFormat AudioFormat { get; set; }

    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    [JsonPropertyName("secondary_languages")]
    public IEnumerable<string>? SecondaryLanguages { get; set; }

    [JsonPropertyName("timestamps_granularity")]
    public SessionStartedConfigTimestampsGranularity? TimestampsGranularity { get; set; }

    [JsonPropertyName("vad_commit_strategy")]
    public bool? VadCommitStrategy { get; set; }

    [JsonPropertyName("vad_silence_threshold_secs")]
    public double? VadSilenceThresholdSecs { get; set; }

    [JsonPropertyName("vad_threshold")]
    public double? VadThreshold { get; set; }

    [JsonPropertyName("min_speech_duration_ms")]
    public int? MinSpeechDurationMs { get; set; }

    [JsonPropertyName("min_silence_duration_ms")]
    public int? MinSilenceDurationMs { get; set; }

    [JsonPropertyName("max_tokens_to_recompute")]
    public int? MaxTokensToRecompute { get; set; }

    [JsonPropertyName("model_id")]
    public SessionStartedConfigModelId? ModelId { get; set; }

    [JsonPropertyName("disable_logging")]
    public bool? DisableLogging { get; set; }

    [JsonPropertyName("include_timestamps")]
    public bool? IncludeTimestamps { get; set; }

    [JsonPropertyName("include_language_detection")]
    public bool? IncludeLanguageDetection { get; set; }

    [JsonPropertyName("filter_background_audio")]
    public bool? FilterBackgroundAudio { get; set; }

    [JsonPropertyName("keyterms")]
    public IEnumerable<string>? Keyterms { get; set; }

    [JsonPropertyName("no_verbatim")]
    public bool? NoVerbatim { get; set; }

    [JsonPropertyName("entity_detection")]
    public IEnumerable<string>? EntityDetection { get; set; }

    [JsonPropertyName("entity_redaction")]
    public IEnumerable<string>? EntityRedaction { get; set; }

    [JsonPropertyName("entity_redaction_mode")]
    public string? EntityRedactionMode { get; set; }

    [JsonPropertyName("keepalive_interval_ms")]
    public int? KeepaliveIntervalMs { get; set; }

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
    public virtual bool Equals(SessionStartedConfig? other)
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
            && ValueEquality.AreEqual(SampleRate, other.SampleRate)
            && ValueEquality.AreEqual(AudioFormat, other.AudioFormat)
            && ValueEquality.AreEqual(LanguageCode, other.LanguageCode)
            && ValueEquality.AreEqual(SecondaryLanguages, other.SecondaryLanguages)
            && ValueEquality.AreEqual(TimestampsGranularity, other.TimestampsGranularity)
            && ValueEquality.AreEqual(VadCommitStrategy, other.VadCommitStrategy)
            && ValueEquality.AreEqual(VadSilenceThresholdSecs, other.VadSilenceThresholdSecs)
            && ValueEquality.AreEqual(VadThreshold, other.VadThreshold)
            && ValueEquality.AreEqual(MinSpeechDurationMs, other.MinSpeechDurationMs)
            && ValueEquality.AreEqual(MinSilenceDurationMs, other.MinSilenceDurationMs)
            && ValueEquality.AreEqual(MaxTokensToRecompute, other.MaxTokensToRecompute)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(DisableLogging, other.DisableLogging)
            && ValueEquality.AreEqual(IncludeTimestamps, other.IncludeTimestamps)
            && ValueEquality.AreEqual(IncludeLanguageDetection, other.IncludeLanguageDetection)
            && ValueEquality.AreEqual(FilterBackgroundAudio, other.FilterBackgroundAudio)
            && ValueEquality.AreEqual(Keyterms, other.Keyterms)
            && ValueEquality.AreEqual(NoVerbatim, other.NoVerbatim)
            && ValueEquality.AreEqual(EntityDetection, other.EntityDetection)
            && ValueEquality.AreEqual(EntityRedaction, other.EntityRedaction)
            && ValueEquality.AreEqual(EntityRedactionMode, other.EntityRedactionMode)
            && ValueEquality.AreEqual(KeepaliveIntervalMs, other.KeepaliveIntervalMs)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SampleRate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AudioFormat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SecondaryLanguages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TimestampsGranularity);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VadCommitStrategy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VadSilenceThresholdSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VadThreshold);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MinSpeechDurationMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MinSilenceDurationMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxTokensToRecompute);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableLogging);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IncludeTimestamps);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IncludeLanguageDetection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FilterBackgroundAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Keyterms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NoVerbatim);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntityDetection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntityRedaction);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntityRedactionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(KeepaliveIntervalMs);
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
