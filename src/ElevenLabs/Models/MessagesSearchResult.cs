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
/// transcript_index: index of the message in the conversation transcript
/// chunk_text: text of the transcript; transcript messages if very long could have several chunks.
/// chunk_highlights: chunk_text split into matched/unmatched segments for highlighting.
///     Only populated for keyword/text search, not semantic search.
/// score: similarity score of the message to the search query
/// </summary>
[Serializable]
public record MessagesSearchResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("conversation_id")]
    public required string ConversationId { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("agent_name")]
    public string? AgentName { get; set; }

    [JsonPropertyName("transcript_index")]
    public required int TranscriptIndex { get; set; }

    [JsonPropertyName("chunk_text")]
    public required string ChunkText { get; set; }

    [JsonPropertyName("chunk_highlights")]
    public IEnumerable<SearchHighlightSegment>? ChunkHighlights { get; set; }

    [JsonPropertyName("score")]
    public required double Score { get; set; }

    [JsonPropertyName("conversation_start_time_unix_secs")]
    public required int ConversationStartTimeUnixSecs { get; set; }

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
    public virtual bool Equals(MessagesSearchResult? other)
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
            && ValueEquality.AreEqual(ConversationId, other.ConversationId)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(AgentName, other.AgentName)
            && ValueEquality.AreEqual(TranscriptIndex, other.TranscriptIndex)
            && ValueEquality.AreEqual(ChunkText, other.ChunkText)
            && ValueEquality.AreEqual(ChunkHighlights, other.ChunkHighlights)
            && ValueEquality.AreEqual(Score, other.Score)
            && ValueEquality.AreEqual(
                ConversationStartTimeUnixSecs,
                other.ConversationStartTimeUnixSecs
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscriptIndex);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChunkText);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChunkHighlights);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Score);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationStartTimeUnixSecs);
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
