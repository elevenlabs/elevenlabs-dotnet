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
public record BodyTextToSpeechStreamWithTimestamps : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The text that will get converted into speech.</value>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <value>Identifier of the model that will be used, you can query them using GET /v1/models. The model needs to have support for text to speech, you can check this using the can_do_text_to_speech property.</value>
    [JsonPropertyName("model_id")]
    public string? ModelId { get; set; }

    /// <value>Language code (ISO 639-1) used to enforce a language for the model and text normalization. If the model does not support the provided language code, it will be ignored. This parameter is not supported for multilingual_v2 models.</value>
    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    /// <value>Voice settings overriding stored settings for the given voice. They are applied only on the given request.</value>
    [JsonPropertyName("voice_settings")]
    public BodyTextToSpeechFullVoiceSettings? VoiceSettings { get; set; }

    /// <value>A list of pronunciation dictionary locators (id, version_id) to be applied to the text. They will be applied in order. You may have up to 3 locators per request</value>
    [JsonPropertyName("pronunciation_dictionary_locators")]
    public IEnumerable<BodyTextToSpeechFullPronunciationDictionaryLocatorsItem>? PronunciationDictionaryLocators { get; set; }

    /// <value>If specified, our system will make a best effort to sample deterministically, such that repeated requests with the same seed and parameters should return the same result. Determinism is not guaranteed. Must be integer between 0 and 4294967295.</value>
    [JsonPropertyName("seed")]
    public int? Seed { get; set; }

    /// <value>The text that came before the text of the current request. Can be used to improve the speech's continuity when concatenating together multiple generations or to influence the speech's continuity in the current generation.</value>
    [JsonPropertyName("previous_text")]
    public string? PreviousText { get; set; }

    /// <value>The text that comes after the text of the current request. Can be used to improve the speech's continuity when concatenating together multiple generations or to influence the speech's continuity in the current generation.</value>
    [JsonPropertyName("next_text")]
    public string? NextText { get; set; }

    /// <value>A list of request_id of the samples that were generated before this generation. Can be used to improve the speech's continuity when splitting up a large task into multiple requests. The results will be best when the same model is used across the generations. In case both previous_text and previous_request_ids is send, previous_text will be ignored. A maximum of 3 request_ids can be sent.</value>
    [JsonPropertyName("previous_request_ids")]
    public IEnumerable<string>? PreviousRequestIds { get; set; }

    /// <value>A list of request_id of the samples that come after this generation. next_request_ids is especially useful for maintaining the speech's continuity when regenerating a sample that has had some audio quality issues. For example, if you have generated 3 speech clips, and you want to improve clip 2, passing the request id of clip 3 as a next_request_id (and that of clip 1 as a previous_request_id) will help maintain natural flow in the combined speech. The results will be best when the same model is used across the generations. In case both next_text and next_request_ids is send, next_text will be ignored. A maximum of 3 request_ids can be sent.</value>
    [JsonPropertyName("next_request_ids")]
    public IEnumerable<string>? NextRequestIds { get; set; }

    /// <value>Whether to use the IVC version of a professional voice. This may improve expressiveness and reduce latency.</value>
    [JsonPropertyName("use_pvc_as_ivc")]
    public bool? UsePvcAsIvc { get; set; }

    /// <value>This parameter controls text normalization with three modes: 'auto', 'on', and 'off'. When set to 'auto', the system will automatically decide whether to apply text normalization (e.g., spelling out numbers). With 'on', text normalization will always be applied, while with 'off', it will be skipped.</value>
    [JsonPropertyName("apply_text_normalization")]
    public BodyTextToSpeechStreamWithTimestampsApplyTextNormalization? ApplyTextNormalization { get; set; }

    /// <value>This parameter controls language text normalization. This helps with proper pronunciation of text in some supported languages. WARNING: This parameter can heavily increase the latency of the request. Currently only supported for Japanese.</value>
    [JsonPropertyName("apply_language_text_normalization")]
    public bool? ApplyLanguageTextNormalization { get; set; }

    /// <value>Audio effects applied to the generated audio. Unknown IDs return 404 with `param` naming the field. Reverb (`environment_id` with `send_level` above 0) and a non-zero `pan` produce stereo audio and are rejected with 400 for `ulaw_*`, `alaw_*`, and `pcm_*` output formats. Effects don't change the cost of the request.</value>
    [JsonPropertyName("audio_effects")]
    public EffectsSpecInput? AudioEffects { get; set; }

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
    public virtual bool Equals(BodyTextToSpeechStreamWithTimestamps? other)
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
            && ValueEquality.AreEqual(Text, other.Text)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(LanguageCode, other.LanguageCode)
            && ValueEquality.AreEqual(VoiceSettings, other.VoiceSettings)
            && ValueEquality.AreEqual(
                PronunciationDictionaryLocators,
                other.PronunciationDictionaryLocators
            )
            && ValueEquality.AreEqual(Seed, other.Seed)
            && ValueEquality.AreEqual(PreviousText, other.PreviousText)
            && ValueEquality.AreEqual(NextText, other.NextText)
            && ValueEquality.AreEqual(PreviousRequestIds, other.PreviousRequestIds)
            && ValueEquality.AreEqual(NextRequestIds, other.NextRequestIds)
            && ValueEquality.AreEqual(UsePvcAsIvc, other.UsePvcAsIvc)
            && ValueEquality.AreEqual(ApplyTextNormalization, other.ApplyTextNormalization)
            && ValueEquality.AreEqual(
                ApplyLanguageTextNormalization,
                other.ApplyLanguageTextNormalization
            )
            && ValueEquality.AreEqual(AudioEffects, other.AudioEffects)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Text);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryLocators);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Seed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviousText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NextText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviousRequestIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NextRequestIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UsePvcAsIvc);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApplyTextNormalization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApplyLanguageTextNormalization);
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
