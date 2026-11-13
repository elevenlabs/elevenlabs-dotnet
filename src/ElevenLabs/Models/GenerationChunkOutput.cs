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
public record GenerationChunkOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The text config to be generated for this chunk. Can contain an optional section name in square brackets at the beginning, e.g. [Verse 1], lyrics lines, and inline directions in curly braces, e.g. {scratching}. Section names must be between 1 and 100 characters. At most 30 lines are allowed, each at most 200 characters.</value>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <value>The duration of the chunk in milliseconds. Must be between 3000ms and 120000ms.</value>
    [JsonPropertyName("duration_ms")]
    public required int DurationMs { get; set; }

    /// <value>The styles and musical directions that should be present in this chunk. Use English language for best results. The styles for the first chunk are the most important as they set the overall tone and genre. Styles for subsequent chunks can be used to add nuance, progression, emphasis, or change the direction of the song. Aim to have at least 6-7 styles in early chunks until the direction is established. Generic styles like 'great production quality' are good default styles to append to the list.</value>
    [JsonPropertyName("positive_styles")]
    public IEnumerable<string> PositiveStyles { get; set; } = new List<string>();

    /// <value>The styles and musical directions that should not be present in this chunk. Use English language for best results. Leaving empty is a good default, only use this field if you want to explicitly avoid a particular style or direction.</value>
    [JsonPropertyName("negative_styles")]
    public IEnumerable<string>? NegativeStyles { get; set; }

    /// <value>How much the model adheres to the context of its surrounding chunks. Low adherence means the model can deviate from the context and be more creative. High adherence means the model will be more consistent with the context.</value>
    [JsonPropertyName("context_adherence")]
    public GenerationChunkOutputContextAdherence? ContextAdherence { get; set; }

    /// <value>The audio reference to condition the generation on. The first chunk is the most important as it will influence the generation of all subsequent chunks. Thus, if you want to apply conditioning to the entire song, start conditioning from the first chunk.</value>
    [JsonPropertyName("conditioning_ref")]
    public AudioRefChunk? ConditioningRef { get; set; }

    /// <value>How strongly the model adheres to the conditioning reference. Low strength means the model will be more creative and deviate from the reference. High strength means the model will be more consistent with the reference.</value>
    [JsonPropertyName("condition_strength")]
    public ConditionStrength? ConditionStrength { get; set; }

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
    public virtual bool Equals(GenerationChunkOutput? other)
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
            && ValueEquality.AreEqual(DurationMs, other.DurationMs)
            && ValueEquality.AreEqual(PositiveStyles, other.PositiveStyles)
            && ValueEquality.AreEqual(NegativeStyles, other.NegativeStyles)
            && ValueEquality.AreEqual(ContextAdherence, other.ContextAdherence)
            && ValueEquality.AreEqual(ConditioningRef, other.ConditioningRef)
            && ValueEquality.AreEqual(ConditionStrength, other.ConditionStrength)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Text);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PositiveStyles);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NegativeStyles);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContextAdherence);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConditioningRef);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConditionStrength);
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
