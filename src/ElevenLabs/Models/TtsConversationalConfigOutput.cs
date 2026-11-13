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
public record TtsConversationalConfigOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("model_id")]
    public TtsConversationalModel? ModelId { get; set; }

    /// <value>The voice ID to use for TTS</value>
    [JsonPropertyName("voice_id")]
    public string? VoiceId { get; set; }

    /// <value>Additional supported voices for the agent</value>
    [JsonPropertyName("supported_voices")]
    public IEnumerable<SupportedVoice>? SupportedVoices { get; set; }

    /// <value>When enabled, applies expressive audio tags prompt. Automatically disabled for non-v3 models.</value>
    [JsonPropertyName("expressive_mode")]
    public bool? ExpressiveMode { get; set; }

    /// <value>Suggested audio tags to boost expressive speech (for eleven_v3 and eleven_v3_conversational models). The agent can still use other tags not listed here.</value>
    [JsonPropertyName("suggested_audio_tags")]
    public IEnumerable<SuggestedAudioTag>? SuggestedAudioTags { get; set; }

    [JsonPropertyName("agent_output_audio_format")]
    public TtsOutputFormat? AgentOutputAudioFormat { get; set; }

    [JsonPropertyName("optimize_streaming_latency")]
    public int? OptimizeStreamingLatency { get; set; }

    /// <value>The stability of generated speech</value>
    [JsonPropertyName("stability")]
    public double? Stability { get; set; }

    /// <value>The speed of generated speech</value>
    [JsonPropertyName("speed")]
    public double? Speed { get; set; }

    /// <value>The similarity boost for generated speech</value>
    [JsonPropertyName("similarity_boost")]
    public double? SimilarityBoost { get; set; }

    /// <value>The clone strength for generated speech</value>
    [JsonPropertyName("clone_strength")]
    public double? CloneStrength { get; set; }

    /// <value>Method for converting numbers to words before sending to TTS</value>
    [JsonPropertyName("text_normalisation_type")]
    public TextNormalisationType? TextNormalisationType { get; set; }

    /// <value>The pronunciation dictionary locators</value>
    [JsonPropertyName("pronunciation_dictionary_locators")]
    public IEnumerable<PydanticPronunciationDictionaryVersionLocator>? PronunciationDictionaryLocators { get; set; }

    /// <value>Opt-in to SSML phoneme tag handling for V3 models. When enabled, phoneme tags (inline and from pronunciation dictionaries) are parsed into inline IPA before being sent to the model.</value>
    [JsonPropertyName("enable_phoneme_tags")]
    public bool? EnablePhonemeTags { get; set; }

    /// <value>Optional TTS effects spec: filter preset, distance (proximity EQ), and environment (convolution reverb).</value>
    [JsonPropertyName("audio_effects")]
    public EffectsSpecOutput? AudioEffects { get; set; }

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
    public virtual bool Equals(TtsConversationalConfigOutput? other)
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
            && ValueEquality.AreEqual(VoiceId, other.VoiceId)
            && ValueEquality.AreEqual(SupportedVoices, other.SupportedVoices)
            && ValueEquality.AreEqual(ExpressiveMode, other.ExpressiveMode)
            && ValueEquality.AreEqual(SuggestedAudioTags, other.SuggestedAudioTags)
            && ValueEquality.AreEqual(AgentOutputAudioFormat, other.AgentOutputAudioFormat)
            && ValueEquality.AreEqual(OptimizeStreamingLatency, other.OptimizeStreamingLatency)
            && ValueEquality.AreEqual(Stability, other.Stability)
            && ValueEquality.AreEqual(Speed, other.Speed)
            && ValueEquality.AreEqual(SimilarityBoost, other.SimilarityBoost)
            && ValueEquality.AreEqual(CloneStrength, other.CloneStrength)
            && ValueEquality.AreEqual(TextNormalisationType, other.TextNormalisationType)
            && ValueEquality.AreEqual(
                PronunciationDictionaryLocators,
                other.PronunciationDictionaryLocators
            )
            && ValueEquality.AreEqual(EnablePhonemeTags, other.EnablePhonemeTags)
            && ValueEquality.AreEqual(AudioEffects, other.AudioEffects)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportedVoices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExpressiveMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SuggestedAudioTags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentOutputAudioFormat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OptimizeStreamingLatency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Stability);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Speed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SimilarityBoost);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CloneStrength);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextNormalisationType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryLocators);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnablePhonemeTags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AudioEffects);
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
