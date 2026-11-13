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

/// <summary>
/// Audio effects applied to generated speech: a filter preset, perceived distance, a reverb
/// environment, a background noise bed, and stereo panning. Leave every field at its default
/// to get unprocessed audio.
/// </summary>
[Serializable]
public record EffectsSpecInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of a filter preset that colors the voice, such as `phone` or `old_radio`. List valid IDs with `GET /v1/audio-effects/catalog`.</value>
    [JsonPropertyName("filter_preset_id")]
    public string? FilterPresetId { get; set; }

    /// <value>How far the speaker sounds from the microphone, from 0 (close, unchanged) to 1 (far). Higher values roll off low and high frequencies and, when an environment is set, shift the balance from the dry voice toward the reverb.</value>
    [JsonPropertyName("distance")]
    public double? Distance { get; set; }

    /// <value>ID of a reverb environment that places the voice in a space, such as `small_room` or `hall`. List valid IDs with `GET /v1/audio-effects/catalog`. Reverb is rendered in stereo and adds a tail of up to several seconds after the speech ends.</value>
    [JsonPropertyName("environment_id")]
    public string? EnvironmentId { get; set; }

    /// <value>ID of a background noise bed looped under the voice, such as `cafe` or `keyboard`. List valid IDs with `GET /v1/audio-effects/catalog`.</value>
    [JsonPropertyName("background_noise_id")]
    public string? BackgroundNoiseId { get; set; }

    /// <value>How much of the voice feeds the reverb, from 0 (none) to 1 (full). Only applies when `environment_id` is set; 0 turns the reverb off.</value>
    [JsonPropertyName("send_level")]
    public double? SendLevel { get; set; }

    /// <value>Stereo position of the voice, from -1 (hard left) through 0 (center) to 1 (hard right). Only the voice is panned; reverb and background noise stay centered.</value>
    [JsonPropertyName("pan")]
    public double? Pan { get; set; }

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
    public virtual bool Equals(EffectsSpecInput? other)
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
            && ValueEquality.AreEqual(FilterPresetId, other.FilterPresetId)
            && ValueEquality.AreEqual(Distance, other.Distance)
            && ValueEquality.AreEqual(EnvironmentId, other.EnvironmentId)
            && ValueEquality.AreEqual(BackgroundNoiseId, other.BackgroundNoiseId)
            && ValueEquality.AreEqual(SendLevel, other.SendLevel)
            && ValueEquality.AreEqual(Pan, other.Pan)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FilterPresetId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Distance);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnvironmentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundNoiseId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SendLevel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Pan);
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
