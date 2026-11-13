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
public record VoiceRemixRequestModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Description of the changes to make to the voice.</value>
    [JsonPropertyName("voice_description")]
    public required string VoiceDescription { get; set; }

    /// <value>Text to generate, text length has to be between 100 and 1000.</value>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <value>Whether to automatically generate a text suitable for the voice description.</value>
    [JsonPropertyName("auto_generate_text")]
    public bool? AutoGenerateText { get; set; }

    /// <value>Controls the volume level of the generated voice. -1 is quietest, 1 is loudest, 0 corresponds to roughly -24 LUFS.</value>
    [JsonPropertyName("loudness")]
    public double? Loudness { get; set; }

    /// <value>Random number that controls the voice generation. Same seed with same inputs produces same voice.</value>
    [JsonPropertyName("seed")]
    public int? Seed { get; set; }

    /// <value>Controls how closely the AI follows the prompt. Lower numbers give the AI more freedom to be creative, while higher numbers force it to stick more to the prompt. High numbers can cause voice to sound artificial or robotic. We recommend to use longer, more detailed prompts at lower Guidance Scale.</value>
    [JsonPropertyName("guidance_scale")]
    public double? GuidanceScale { get; set; }

    /// <value>Determines whether the Text to Voice previews should be included in the response. If true, only the generated IDs will be returned which can then be streamed via the /v1/text-to-voice/:generated_voice_id/stream endpoint.</value>
    [JsonPropertyName("stream_previews")]
    public bool? StreamPreviews { get; set; }

    /// <value>The remixing session id.</value>
    [JsonPropertyName("remixing_session_id")]
    public string? RemixingSessionId { get; set; }

    /// <value>The id of the remixing session iteration where these generations should be attached to. If not provided, a new iteration will be created.</value>
    [JsonPropertyName("remixing_session_iteration_id")]
    public string? RemixingSessionIterationId { get; set; }

    /// <value>Controls the balance of prompt versus reference audio when generating voice samples. 0 means almost no prompt influence, 1 means almost no reference audio influence. Only supported when using the eleven_ttv_v3 model.</value>
    [JsonPropertyName("prompt_strength")]
    public double? PromptStrength { get; set; }

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
    public virtual bool Equals(VoiceRemixRequestModel? other)
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
            && ValueEquality.AreEqual(VoiceDescription, other.VoiceDescription)
            && ValueEquality.AreEqual(Text, other.Text)
            && ValueEquality.AreEqual(AutoGenerateText, other.AutoGenerateText)
            && ValueEquality.AreEqual(Loudness, other.Loudness)
            && ValueEquality.AreEqual(Seed, other.Seed)
            && ValueEquality.AreEqual(GuidanceScale, other.GuidanceScale)
            && ValueEquality.AreEqual(StreamPreviews, other.StreamPreviews)
            && ValueEquality.AreEqual(RemixingSessionId, other.RemixingSessionId)
            && ValueEquality.AreEqual(RemixingSessionIterationId, other.RemixingSessionIterationId)
            && ValueEquality.AreEqual(PromptStrength, other.PromptStrength)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceDescription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Text);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoGenerateText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Loudness);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Seed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GuidanceScale);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StreamPreviews);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RemixingSessionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RemixingSessionIterationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PromptStrength);
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
