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
public record BodyTextToSpeechFullVoiceSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Determines how stable the voice is and the randomness between each generation. Lower values introduce broader emotional range for the voice. Higher values can result in a monotonous voice with limited emotion.</value>
    [JsonPropertyName("stability")]
    public double? Stability { get; set; }

    /// <value>This setting boosts the similarity to the original speaker. Using this setting requires a slightly higher computational load, which in turn increases latency.</value>
    [JsonPropertyName("use_speaker_boost")]
    public bool? UseSpeakerBoost { get; set; }

    /// <value>Determines how closely the AI should adhere to the original voice when attempting to replicate it.</value>
    [JsonPropertyName("similarity_boost")]
    public double? SimilarityBoost { get; set; }

    /// <value>Determines the style exaggeration of the voice. This setting attempts to amplify the style of the original speaker. It does consume additional computational resources and might increase latency if set to anything other than 0.</value>
    [JsonPropertyName("style")]
    public double? Style { get; set; }

    /// <value>Adjusts the speed of the voice. A value of 1.0 is the default speed, while values less than 1.0 slow down the speech, and values greater than 1.0 speed it up.</value>
    [JsonPropertyName("speed")]
    public double? Speed { get; set; }

    /// <value>Controls how closely the output matches your professional voice clone samples (0–1). Lower values sound more versatile, while higher values preserve more of the original voice characteristics. We recommend 0 for most use cases, but if you do run into issues 0.5 could be a good fallback. Applies only to professional voice clones fine-tuned for the selected v4 model.</value>
    [JsonPropertyName("clone_strength")]
    public double? CloneStrength { get; set; }

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
    public virtual bool Equals(BodyTextToSpeechFullVoiceSettings? other)
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
            && ValueEquality.AreEqual(Stability, other.Stability)
            && ValueEquality.AreEqual(UseSpeakerBoost, other.UseSpeakerBoost)
            && ValueEquality.AreEqual(SimilarityBoost, other.SimilarityBoost)
            && ValueEquality.AreEqual(Style, other.Style)
            && ValueEquality.AreEqual(Speed, other.Speed)
            && ValueEquality.AreEqual(CloneStrength, other.CloneStrength)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Stability);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseSpeakerBoost);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SimilarityBoost);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Style);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Speed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CloneStrength);
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
