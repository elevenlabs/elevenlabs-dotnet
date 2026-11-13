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
public record SongSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The name of the section. Must be between 1 and 100 characters.</value>
    [JsonPropertyName("section_name")]
    public required string SectionName { get; set; }

    /// <value>The styles and musical directions that should be present in this section. Use English language for best result.</value>
    [JsonPropertyName("positive_local_styles")]
    public IEnumerable<string> PositiveLocalStyles { get; set; } = new List<string>();

    /// <value>The styles and musical directions that should not be present in this section. Use English language for best result.</value>
    [JsonPropertyName("negative_local_styles")]
    public IEnumerable<string> NegativeLocalStyles { get; set; } = new List<string>();

    /// <value>The duration of the section in milliseconds. Must be between 3000ms and 120000ms.</value>
    [JsonPropertyName("duration_ms")]
    public required int DurationMs { get; set; }

    /// <value>The lyrics of the section. Max 30 lines per section and max 200 characters per line.</value>
    [JsonPropertyName("lines")]
    public IEnumerable<string> Lines { get; set; } = new List<string>();

    /// <value>Optional source to extract the section from. Used for inpainting.</value>
    [JsonPropertyName("source_from")]
    public SectionSource? SourceFrom { get; set; }

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
    public virtual bool Equals(SongSection? other)
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
            && ValueEquality.AreEqual(SectionName, other.SectionName)
            && ValueEquality.AreEqual(PositiveLocalStyles, other.PositiveLocalStyles)
            && ValueEquality.AreEqual(NegativeLocalStyles, other.NegativeLocalStyles)
            && ValueEquality.AreEqual(DurationMs, other.DurationMs)
            && ValueEquality.AreEqual(Lines, other.Lines)
            && ValueEquality.AreEqual(SourceFrom, other.SourceFrom)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SectionName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PositiveLocalStyles);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NegativeLocalStyles);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Lines);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceFrom);
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
