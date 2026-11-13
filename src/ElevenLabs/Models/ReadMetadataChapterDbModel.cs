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
public record ReadMetadataChapterDbModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("chapter_name")]
    public required string ChapterName { get; set; }

    [JsonPropertyName("word_count")]
    public required int WordCount { get; set; }

    [JsonPropertyName("char_count")]
    public required int CharCount { get; set; }

    [JsonPropertyName("starting_char_offset")]
    public required int StartingCharOffset { get; set; }

    [JsonPropertyName("has_parsed_html")]
    public bool? HasParsedHtml { get; set; }

    [JsonPropertyName("has_summary")]
    public bool? HasSummary { get; set; }

    [JsonPropertyName("duration_seconds")]
    public double? DurationSeconds { get; set; }

    [JsonPropertyName("file_number")]
    public string? FileNumber { get; set; }

    [JsonPropertyName("is_fallback_name")]
    public bool? IsFallbackName { get; set; }

    [JsonPropertyName("chapter_id")]
    public string? ChapterId { get; set; }

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
    public virtual bool Equals(ReadMetadataChapterDbModel? other)
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
            && ValueEquality.AreEqual(ChapterName, other.ChapterName)
            && ValueEquality.AreEqual(WordCount, other.WordCount)
            && ValueEquality.AreEqual(CharCount, other.CharCount)
            && ValueEquality.AreEqual(StartingCharOffset, other.StartingCharOffset)
            && ValueEquality.AreEqual(HasParsedHtml, other.HasParsedHtml)
            && ValueEquality.AreEqual(HasSummary, other.HasSummary)
            && ValueEquality.AreEqual(DurationSeconds, other.DurationSeconds)
            && ValueEquality.AreEqual(FileNumber, other.FileNumber)
            && ValueEquality.AreEqual(IsFallbackName, other.IsFallbackName)
            && ValueEquality.AreEqual(ChapterId, other.ChapterId)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChapterName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WordCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartingCharOffset);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasParsedHtml);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasSummary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsFallbackName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChapterId);
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
