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
public record BodyComposeMusicWithADetailedResponseV1MusicDetailedPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>A simple text prompt to generate a song from. Cannot be used in conjunction with `composition_plan`.</value>
    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    /// <value>A detailed composition plan to guide music generation. Cannot be used in conjunction with `prompt`.</value>
    [JsonPropertyName("composition_plan")]
    public BodyComposeMusicWithADetailedResponseV1MusicDetailedPostCompositionPlan? CompositionPlan { get; set; }

    /// <value>The length of the song to generate in milliseconds. Used only in conjunction with `prompt`. Must be between 3000ms and 600000ms. Optional - if not provided, the model will choose a length based on the prompt.</value>
    [JsonPropertyName("music_length_ms")]
    public int? MusicLengthMs { get; set; }

    [JsonPropertyName("model_id")]
    public MusicModelId? ModelId { get; set; }

    /// <value>Random seed to initialize the music generation process. Providing the same seed with the same parameters can help achieve more consistent results, but exact reproducibility is not guaranteed and outputs may change across system updates. Cannot be used in conjunction with prompt.</value>
    [JsonPropertyName("seed")]
    public int? Seed { get; set; }

    /// <value>If true, guarantees that the generated song will be instrumental. If false, the song may or may not be instrumental depending on the `prompt`. Can only be used with `prompt`.</value>
    [JsonPropertyName("force_instrumental")]
    public bool? ForceInstrumental { get; set; }

    /// <value>The ID of the finetune to use for the generation</value>
    [JsonPropertyName("finetune_id")]
    public string? FinetuneId { get; set; }

    /// <value>Controls how strictly section durations in the `composition_plan` are enforced. Only used with `composition_plan` and only applies to `music_v1`; for `music_v2` and `music_v2_5` section durations are always enforced and this is ignored. When false for `music_v1`, the model may adjust individual section durations for better quality and latency, while preserving the total song duration from the plan.</value>
    [JsonPropertyName("respect_sections_durations")]
    public bool? RespectSectionsDurations { get; set; }

    /// <value>Whether to store the generated song for inpainting.</value>
    [JsonPropertyName("store_for_inpainting")]
    public bool? StoreForInpainting { get; set; }

    /// <value>Whether to return the timestamps of the words in the generated song.</value>
    [JsonPropertyName("with_timestamps")]
    public bool? WithTimestamps { get; set; }

    /// <value>Whether to return the visual waveform of the generated song.</value>
    [JsonPropertyName("with_waveform_visual")]
    public bool? WithWaveformVisual { get; set; }

    /// <value>Whether to sign the generated song with C2PA. Applicable only for mp3 files.</value>
    [JsonPropertyName("sign_with_c2pa")]
    public bool? SignWithC2Pa { get; set; }

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
    public virtual bool Equals(BodyComposeMusicWithADetailedResponseV1MusicDetailedPost? other)
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
            && ValueEquality.AreEqual(Prompt, other.Prompt)
            && ValueEquality.AreEqual(CompositionPlan, other.CompositionPlan)
            && ValueEquality.AreEqual(MusicLengthMs, other.MusicLengthMs)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(Seed, other.Seed)
            && ValueEquality.AreEqual(ForceInstrumental, other.ForceInstrumental)
            && ValueEquality.AreEqual(FinetuneId, other.FinetuneId)
            && ValueEquality.AreEqual(RespectSectionsDurations, other.RespectSectionsDurations)
            && ValueEquality.AreEqual(StoreForInpainting, other.StoreForInpainting)
            && ValueEquality.AreEqual(WithTimestamps, other.WithTimestamps)
            && ValueEquality.AreEqual(WithWaveformVisual, other.WithWaveformVisual)
            && ValueEquality.AreEqual(SignWithC2Pa, other.SignWithC2Pa)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Prompt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CompositionPlan);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MusicLengthMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Seed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ForceInstrumental);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FinetuneId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RespectSectionsDurations);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StoreForInpainting);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WithTimestamps);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WithWaveformVisual);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SignWithC2Pa);
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
