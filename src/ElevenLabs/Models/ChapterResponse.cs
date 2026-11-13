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
public record ChapterResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the chapter.</value>
    [JsonPropertyName("chapter_id")]
    public required string ChapterId { get; set; }

    /// <value>The name of the chapter.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The last conversion date of the chapter.</value>
    [JsonPropertyName("last_conversion_date_unix")]
    public int? LastConversionDateUnix { get; set; }

    /// <value>The conversion progress of the chapter.</value>
    [JsonPropertyName("conversion_progress")]
    public double? ConversionProgress { get; set; }

    /// <value>Whether the chapter can be downloaded.</value>
    [JsonPropertyName("can_be_downloaded")]
    public required bool CanBeDownloaded { get; set; }

    /// <value>The state of the chapter.</value>
    [JsonPropertyName("state")]
    public required ChapterState State { get; set; }

    /// <value>Whether the chapter has a video.</value>
    [JsonPropertyName("has_video")]
    public bool? HasVideo { get; set; }

    /// <value>Whether the chapter has any visual content (video, image, or text clips).</value>
    [JsonPropertyName("has_visual_content")]
    public bool? HasVisualContent { get; set; }

    /// <value>List of voice ids used by the chapter</value>
    [JsonPropertyName("voice_ids")]
    public IEnumerable<string>? VoiceIds { get; set; }

    /// <value>The statistics of the chapter.</value>
    [JsonPropertyName("statistics")]
    public ChapterStatisticsResponse? Statistics { get; set; }

    /// <value>The last conversion error of the chapter.</value>
    [JsonPropertyName("last_conversion_error")]
    public string? LastConversionError { get; set; }

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
    public virtual bool Equals(ChapterResponse? other)
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
            && ValueEquality.AreEqual(ChapterId, other.ChapterId)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(LastConversionDateUnix, other.LastConversionDateUnix)
            && ValueEquality.AreEqual(ConversionProgress, other.ConversionProgress)
            && ValueEquality.AreEqual(CanBeDownloaded, other.CanBeDownloaded)
            && ValueEquality.AreEqual(State, other.State)
            && ValueEquality.AreEqual(HasVideo, other.HasVideo)
            && ValueEquality.AreEqual(HasVisualContent, other.HasVisualContent)
            && ValueEquality.AreEqual(VoiceIds, other.VoiceIds)
            && ValueEquality.AreEqual(Statistics, other.Statistics)
            && ValueEquality.AreEqual(LastConversionError, other.LastConversionError)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChapterId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastConversionDateUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversionProgress);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanBeDownloaded);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(State);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasVideo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasVisualContent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Statistics);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastConversionError);
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
