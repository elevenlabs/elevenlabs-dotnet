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

/// <summary>Chunk-level detail of the transcription with timing information.</summary>
[Serializable]
public record SpeechToTextChunkResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The detected language code (e.g. 'eng' for English).</value>
    [JsonPropertyName("language_code")]
    public required string LanguageCode { get; set; }

    /// <value>The confidence score of the language detection (0 to 1).</value>
    [JsonPropertyName("language_probability")]
    public required double LanguageProbability { get; set; }

    /// <value>The raw text of the transcription.</value>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <value>List of words with their timing information.</value>
    [JsonPropertyName("words")]
    public IEnumerable<SpeechToTextWordResponseModel> Words { get; set; } =
        new List<SpeechToTextWordResponseModel>();

    /// <value>The channel index this transcript belongs to (for multichannel audio).</value>
    [JsonPropertyName("channel_index")]
    public int? ChannelIndex { get; set; }

    /// <value>Requested additional formats of the transcript.</value>
    [JsonPropertyName("additional_formats")]
    public IEnumerable<AdditionalFormatResponseModel>? AdditionalFormats { get; set; }

    /// <value>The transcription ID of the response.</value>
    [JsonPropertyName("transcription_id")]
    public string? TranscriptionId { get; set; }

    /// <value>List of detected entities with their text, type, and character positions in the transcript.</value>
    [JsonPropertyName("entities")]
    public IEnumerable<DetectedEntity>? Entities { get; set; }

    /// <value>The duration of the audio that was transcribed in seconds.</value>
    [JsonPropertyName("audio_duration_secs")]
    public double? AudioDurationSecs { get; set; }

    /// <value>Result of the optional transcript edit: the edited text, or an error if it could not be produced. Absent when no edit was requested. On success, both `text` and `edited_text` hold the edited transcript; compare them with the top-level `text` to see what changed.</value>
    [JsonPropertyName("edited_transcript")]
    public SpeechToTextChunkResponseModelEditedTranscript? EditedTranscript { get; set; }

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
    public virtual bool Equals(SpeechToTextChunkResponseModel? other)
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
            && ValueEquality.AreEqual(LanguageCode, other.LanguageCode)
            && ValueEquality.AreEqual(LanguageProbability, other.LanguageProbability)
            && ValueEquality.AreEqual(Text, other.Text)
            && ValueEquality.AreEqual(Words, other.Words)
            && ValueEquality.AreEqual(ChannelIndex, other.ChannelIndex)
            && ValueEquality.AreEqual(AdditionalFormats, other.AdditionalFormats)
            && ValueEquality.AreEqual(TranscriptionId, other.TranscriptionId)
            && ValueEquality.AreEqual(Entities, other.Entities)
            && ValueEquality.AreEqual(AudioDurationSecs, other.AudioDurationSecs)
            && ValueEquality.AreEqual(EditedTranscript, other.EditedTranscript)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageProbability);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Text);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Words);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChannelIndex);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalFormats);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscriptionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Entities);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AudioDurationSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EditedTranscript);
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
