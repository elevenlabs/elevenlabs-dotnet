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
public record TtsConversationalConfigOverrideConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Whether to allow overriding the model_id field.</value>
    [JsonPropertyName("model_id")]
    public bool? ModelId { get; set; }

    /// <value>Whether to allow overriding the voice_id field.</value>
    [JsonPropertyName("voice_id")]
    public bool? VoiceId { get; set; }

    /// <value>Whether to allow overriding the supported_voices field.</value>
    [JsonPropertyName("supported_voices")]
    public bool? SupportedVoices { get; set; }

    /// <value>Whether to allow overriding the stability field.</value>
    [JsonPropertyName("stability")]
    public bool? Stability { get; set; }

    /// <value>Whether to allow overriding the speed field.</value>
    [JsonPropertyName("speed")]
    public bool? Speed { get; set; }

    /// <value>Whether to allow overriding the similarity_boost field.</value>
    [JsonPropertyName("similarity_boost")]
    public bool? SimilarityBoost { get; set; }

    /// <value>Whether to allow overriding the clone_strength field.</value>
    [JsonPropertyName("clone_strength")]
    public bool? CloneStrength { get; set; }

    /// <value>Whether to allow overriding the pronunciation_dictionary_locators field.</value>
    [JsonPropertyName("pronunciation_dictionary_locators")]
    public bool? PronunciationDictionaryLocators { get; set; }

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
    public virtual bool Equals(TtsConversationalConfigOverrideConfig? other)
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
            && ValueEquality.AreEqual(Stability, other.Stability)
            && ValueEquality.AreEqual(Speed, other.Speed)
            && ValueEquality.AreEqual(SimilarityBoost, other.SimilarityBoost)
            && ValueEquality.AreEqual(CloneStrength, other.CloneStrength)
            && ValueEquality.AreEqual(
                PronunciationDictionaryLocators,
                other.PronunciationDictionaryLocators
            )
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Stability);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Speed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SimilarityBoost);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CloneStrength);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryLocators);
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
