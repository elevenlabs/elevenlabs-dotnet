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
public record GetConversationSummaryResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("conversation_id")]
    public required string ConversationId { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("status")]
    public required GetConversationSummaryResponseModelStatus Status { get; set; }

    /// <value>Short generated title for the conversation.</value>
    [JsonPropertyName("call_summary_title")]
    public string? CallSummaryTitle { get; set; }

    /// <value>Generated natural-language summary of the call.</value>
    [JsonPropertyName("transcript_summary")]
    public string? TranscriptSummary { get; set; }

    [JsonPropertyName("call_successful")]
    public EvaluationSuccessResult? CallSuccessful { get; set; }

    /// <value>Number of plain chat message turns in the conversation.</value>
    [JsonPropertyName("message_count")]
    public required int MessageCount { get; set; }

    /// <value>The plain chat messages (role and text only). Included only when message_count does not exceed the requested max_messages; otherwise null and messages_omitted is true.</value>
    [JsonPropertyName("messages")]
    public IEnumerable<ConversationSummaryMessageModel>? Messages { get; set; }

    /// <value>True when the chat messages were omitted because the conversation was too long. Fetch the full transcript for the messages.</value>
    [JsonPropertyName("messages_omitted")]
    public bool? MessagesOmitted { get; set; }

    /// <value>Guidance telling the agent how to get the full transcript.</value>
    [JsonPropertyName("note")]
    public required string Note { get; set; }

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
    public virtual bool Equals(GetConversationSummaryResponseModel? other)
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
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(CallSummaryTitle, other.CallSummaryTitle)
            && ValueEquality.AreEqual(TranscriptSummary, other.TranscriptSummary)
            && ValueEquality.AreEqual(CallSuccessful, other.CallSuccessful)
            && ValueEquality.AreEqual(MessageCount, other.MessageCount)
            && ValueEquality.AreEqual(Messages, other.Messages)
            && ValueEquality.AreEqual(MessagesOmitted, other.MessagesOmitted)
            && ValueEquality.AreEqual(Note, other.Note)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallSummaryTitle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscriptSummary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallSuccessful);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MessageCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Messages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MessagesOmitted);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Note);
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
