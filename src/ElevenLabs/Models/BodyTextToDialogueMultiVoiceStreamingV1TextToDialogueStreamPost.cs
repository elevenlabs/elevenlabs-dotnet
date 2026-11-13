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
public record BodyTextToDialogueMultiVoiceStreamingV1TextToDialogueStreamPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>A list of dialogue inputs, each containing text and a voice ID which will be converted into speech. The maximum number of unique voice IDs is 10. For reliable generation, keep the total character count across all `inputs[].text` values at or below 2,000 characters per request. Longer requests can terminate early in streaming responses or return a validation error.</value>
    [JsonPropertyName("inputs")]
    public IEnumerable<DialogueInput> Inputs { get; set; } = new List<DialogueInput>();

    /// <value>Identifier of the model that will be used, you can query them using GET /v1/models. The model needs to have support for text to speech, you can check this using the can_do_text_to_speech property.</value>
    [JsonPropertyName("model_id")]
    public string? ModelId { get; set; }

    /// <value>Language code (ISO 639-1) used to enforce a language for the model and text normalization. If the model does not support the provided language code, it will be ignored. This parameter is not supported for multilingual_v2 models.</value>
    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    /// <value>Settings controlling the dialogue generation.</value>
    [JsonPropertyName("settings")]
    public ToDialogueSettingsResponseModel? Settings { get; set; }

    /// <value>The text that comes immediately before this generation, used to condition the model for prosodic continuity. A maximum of 100 characters can be sent. Not supported by every model.</value>
    [JsonPropertyName("previous_text")]
    public string? PreviousText { get; set; }

    /// <value>The text that comes immediately after this generation, used to condition the model for prosodic continuity. A maximum of 100 characters can be sent. Not supported by every model.</value>
    [JsonPropertyName("future_text")]
    public string? FutureText { get; set; }

    /// <value>A list of pronunciation dictionary locators (id, version_id) to be applied to the text. They will be applied in order. You may have up to 3 locators per request</value>
    [JsonPropertyName("pronunciation_dictionary_locators")]
    public IEnumerable<BodyTextToSpeechFullPronunciationDictionaryLocatorsItem>? PronunciationDictionaryLocators { get; set; }

    /// <value>If specified, our system will make a best effort to sample deterministically, such that repeated requests with the same seed and parameters should return the same result. Determinism is not guaranteed. Must be integer between 0 and 4294967295.</value>
    [JsonPropertyName("seed")]
    public int? Seed { get; set; }

    /// <value>This parameter controls text normalization with three modes: 'auto', 'on', and 'off'. When set to 'auto', the system will automatically decide whether to apply text normalization (e.g., spelling out numbers). With 'on', text normalization will always be applied, while with 'off', it will be skipped.</value>
    [JsonPropertyName("apply_text_normalization")]
    public BodyTextToDialogueMultiVoiceStreamingV1TextToDialogueStreamPostApplyTextNormalization? ApplyTextNormalization { get; set; }

    /// <value>Whether to use the IVC version of a professional voice. This may improve expressiveness and reduce latency.</value>
    [JsonPropertyName("use_pvc_as_ivc")]
    public bool? UsePvcAsIvc { get; set; }

    /// <value>A list of request_ids of dialogue generations that came before this one. Used to condition the model for continuity when splitting a large task into multiple requests. A maximum of 3 request_ids can be sent. The last request_id is the audio which is closest to the current request. Not supported by every model.</value>
    [JsonPropertyName("previous_request_ids")]
    public IEnumerable<string>? PreviousRequestIds { get; set; }

    /// <value>A list of request_ids of dialogue generations that come after this one. Useful for maintaining continuity when regenerating a clip in the middle of a sequence. A maximum of 3 request_ids can be sent. The first request_id is the audio which is closest to the current request. Not supported by every model.</value>
    [JsonPropertyName("next_request_ids")]
    public IEnumerable<string>? NextRequestIds { get; set; }

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
    public virtual bool Equals(
        BodyTextToDialogueMultiVoiceStreamingV1TextToDialogueStreamPost? other
    )
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
            && ValueEquality.AreEqual(Inputs, other.Inputs)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(LanguageCode, other.LanguageCode)
            && ValueEquality.AreEqual(Settings, other.Settings)
            && ValueEquality.AreEqual(PreviousText, other.PreviousText)
            && ValueEquality.AreEqual(FutureText, other.FutureText)
            && ValueEquality.AreEqual(
                PronunciationDictionaryLocators,
                other.PronunciationDictionaryLocators
            )
            && ValueEquality.AreEqual(Seed, other.Seed)
            && ValueEquality.AreEqual(ApplyTextNormalization, other.ApplyTextNormalization)
            && ValueEquality.AreEqual(UsePvcAsIvc, other.UsePvcAsIvc)
            && ValueEquality.AreEqual(PreviousRequestIds, other.PreviousRequestIds)
            && ValueEquality.AreEqual(NextRequestIds, other.NextRequestIds)
            && ValueEquality.AreEqual(AudioEffects, other.AudioEffects)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Inputs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Settings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviousText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FutureText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryLocators);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Seed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApplyTextNormalization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UsePvcAsIvc);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviousRequestIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NextRequestIds);
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
