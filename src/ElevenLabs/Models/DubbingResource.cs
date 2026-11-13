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
public record DubbingResource : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("version")]
    public required int Version { get; set; }

    [JsonPropertyName("source_language")]
    public required string SourceLanguage { get; set; }

    [JsonPropertyName("target_languages")]
    public IEnumerable<string> TargetLanguages { get; set; } = new List<string>();

    [JsonPropertyName("input")]
    public required DubbingMediaReference Input { get; set; }

    [JsonPropertyName("background")]
    public DubbingMediaReference? Background { get; set; }

    [JsonPropertyName("foreground")]
    public DubbingMediaReference? Foreground { get; set; }

    [JsonPropertyName("speaker_tracks")]
    public Dictionary<string, SpeakerTrack> SpeakerTracks { get; set; } =
        new Dictionary<string, SpeakerTrack>();

    [JsonPropertyName("speaker_segments")]
    public Dictionary<string, SpeakerSegment> SpeakerSegments { get; set; } =
        new Dictionary<string, SpeakerSegment>();

    [JsonPropertyName("renders")]
    public Dictionary<string, Render> Renders { get; set; } = new Dictionary<string, Render>();

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
    public virtual bool Equals(DubbingResource? other)
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
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(Version, other.Version)
            && ValueEquality.AreEqual(SourceLanguage, other.SourceLanguage)
            && ValueEquality.AreEqual(TargetLanguages, other.TargetLanguages)
            && ValueEquality.AreEqual(Input, other.Input)
            && ValueEquality.AreEqual(Background, other.Background)
            && ValueEquality.AreEqual(Foreground, other.Foreground)
            && ValueEquality.AreEqual(SpeakerTracks, other.SpeakerTracks)
            && ValueEquality.AreEqual(SpeakerSegments, other.SpeakerSegments)
            && ValueEquality.AreEqual(Renders, other.Renders)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Version);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetLanguages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Input);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Background);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Foreground);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeakerTracks);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeakerSegments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Renders);
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
