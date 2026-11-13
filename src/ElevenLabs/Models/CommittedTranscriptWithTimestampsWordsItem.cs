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

/// <summary>Word-level detail of the transcription with timing information.</summary>
[Serializable]
public record CommittedTranscriptWithTimestampsWordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The word or sound that was transcribed.</value>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <value>The start time of the word or sound in seconds.</value>
    [JsonPropertyName("start")]
    public double? Start { get; set; }

    /// <value>The end time of the word or sound in seconds.</value>
    [JsonPropertyName("end")]
    public double? End { get; set; }

    /// <value>The type of the word or sound. 'audio_event' is used for non-word sounds like laughter or footsteps.</value>
    [JsonPropertyName("type")]
    public required SpeechToTextWordResponseModelType Type { get; set; }

    /// <value>Unique identifier for the speaker of this word.</value>
    [JsonPropertyName("speaker_id")]
    public string? SpeakerId { get; set; }

    /// <value>The log of the probability with which this word was predicted. Logprobs are in range [-infinity, 0], higher logprobs indicate a higher confidence the model has in its predictions.</value>
    [JsonPropertyName("logprob")]
    public required double Logprob { get; set; }

    /// <value>The characters that make up the word and their timing information.</value>
    [JsonPropertyName("characters")]
    public IEnumerable<CommittedTranscriptWithTimestampsWordsItemCharactersItem>? Characters { get; set; }

    /// <value>The channel this word was spoken on (for multichannel audio). Null for single-channel transcriptions.</value>
    [JsonPropertyName("channel_index")]
    public int? ChannelIndex { get; set; }

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
    public virtual bool Equals(CommittedTranscriptWithTimestampsWordsItem? other)
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
            && ValueEquality.AreEqual(Start, other.Start)
            && ValueEquality.AreEqual(End, other.End)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(SpeakerId, other.SpeakerId)
            && ValueEquality.AreEqual(Logprob, other.Logprob)
            && ValueEquality.AreEqual(Characters, other.Characters)
            && ValueEquality.AreEqual(ChannelIndex, other.ChannelIndex)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Text);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Start);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(End);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeakerId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Logprob);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Characters);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChannelIndex);
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
