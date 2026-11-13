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

/// <summary>The accepted re-dub: what it covers and what it cost.</summary>
[Serializable]
public record DubbingRegenerateResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The segments this re-dub re-synthesizes: those with edits to apply.</value>
    [JsonPropertyName("regenerated_segment_ids")]
    public IEnumerable<string> RegeneratedSegmentIds { get; set; } = new List<string>();

    /// <value>Seconds of audio this re-dub covers — the edited regions only, never the whole target. `charged_seconds` is the part of it that was billed.</value>
    [JsonPropertyName("regenerated_seconds")]
    public required double RegeneratedSeconds { get; set; }

    /// <value>Seconds actually billed, after the free-regeneration allowance. Zero when the re-dub cost nothing — either the allowance covered all of it, or the project's included generation did.</value>
    [JsonPropertyName("charged_seconds")]
    public required double ChargedSeconds { get; set; }

    /// <value>Free-regeneration seconds left for this language target after this re-dub. The allowance is the source's own duration.</value>
    [JsonPropertyName("free_regeneration_seconds_remaining")]
    public required double FreeRegenerationSecondsRemaining { get; set; }

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
    public virtual bool Equals(DubbingRegenerateResponse? other)
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
            && ValueEquality.AreEqual(RegeneratedSegmentIds, other.RegeneratedSegmentIds)
            && ValueEquality.AreEqual(RegeneratedSeconds, other.RegeneratedSeconds)
            && ValueEquality.AreEqual(ChargedSeconds, other.ChargedSeconds)
            && ValueEquality.AreEqual(
                FreeRegenerationSecondsRemaining,
                other.FreeRegenerationSecondsRemaining
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RegeneratedSegmentIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RegeneratedSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChargedSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FreeRegenerationSecondsRemaining);
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
