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
public record ConversationSummaryResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    [JsonPropertyName("version_id")]
    public string? VersionId { get; set; }

    [JsonPropertyName("agent_name")]
    public string? AgentName { get; set; }

    [JsonPropertyName("conversation_id")]
    public required string ConversationId { get; set; }

    [JsonPropertyName("start_time_unix_secs")]
    public required int StartTimeUnixSecs { get; set; }

    [JsonPropertyName("call_duration_secs")]
    public required int CallDurationSecs { get; set; }

    /// <value>Total cost of the conversation in credits.</value>
    [JsonPropertyName("cost")]
    public int? Cost { get; set; }

    /// <value>Total fiat cost of the conversation in USD. `None` for conversations that predate fiat cost tracking.</value>
    [JsonPropertyName("cost_fiat")]
    public double? CostFiat { get; set; }

    /// <value>Number of transcript turns with text; tool-only turns are not counted.</value>
    [JsonPropertyName("message_count")]
    public required int MessageCount { get; set; }

    /// <value>Number of user transcript turns with text; tool-only turns are not counted. `null` for older conversations before this field whose transcript was deleted.</value>
    [JsonPropertyName("user_message_count")]
    public int? UserMessageCount { get; set; }

    /// <value>Number of agent transcript turns with text; tool-only turns are not counted. `null` for older conversations before this field whose transcript was deleted.</value>
    [JsonPropertyName("agent_message_count")]
    public int? AgentMessageCount { get; set; }

    [JsonPropertyName("status")]
    public required ConversationSummaryResponseModelStatus Status { get; set; }

    [JsonPropertyName("termination_reason")]
    public string? TerminationReason { get; set; }

    [JsonPropertyName("call_successful")]
    public required EvaluationSuccessResult CallSuccessful { get; set; }

    [JsonPropertyName("call_success_score")]
    public double? CallSuccessScore { get; set; }

    [JsonPropertyName("transcript_summary")]
    public string? TranscriptSummary { get; set; }

    [JsonPropertyName("call_summary_title")]
    public string? CallSummaryTitle { get; set; }

    [JsonPropertyName("main_language")]
    public string? MainLanguage { get; set; }

    [JsonPropertyName("conversation_initiation_source")]
    public ConversationInitiationSource1? ConversationInitiationSource { get; set; }

    [JsonPropertyName("tool_names")]
    public IEnumerable<string>? ToolNames { get; set; }

    [JsonPropertyName("direction")]
    public TelephonyDirection? Direction { get; set; }

    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    [JsonPropertyName("sentiment_analysis")]
    public ConversationSentimentAnalysis? SentimentAnalysis { get; set; }

    [JsonPropertyName("data_collection_results")]
    public Dictionary<string, object?>? DataCollectionResults { get; set; }

    [JsonPropertyName("evaluation_criteria_results")]
    public Dictionary<
        string,
        EvaluationCriteriaSummaryResult
    >? EvaluationCriteriaResults { get; set; }

    /// <value>Conversation tag ids assigned to this conversation.</value>
    [JsonPropertyName("tag_ids")]
    public IEnumerable<string>? TagIds { get; set; }

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
    public virtual bool Equals(ConversationSummaryResponseModel? other)
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
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(VersionId, other.VersionId)
            && ValueEquality.AreEqual(AgentName, other.AgentName)
            && ValueEquality.AreEqual(ConversationId, other.ConversationId)
            && ValueEquality.AreEqual(StartTimeUnixSecs, other.StartTimeUnixSecs)
            && ValueEquality.AreEqual(CallDurationSecs, other.CallDurationSecs)
            && ValueEquality.AreEqual(Cost, other.Cost)
            && ValueEquality.AreEqual(CostFiat, other.CostFiat)
            && ValueEquality.AreEqual(MessageCount, other.MessageCount)
            && ValueEquality.AreEqual(UserMessageCount, other.UserMessageCount)
            && ValueEquality.AreEqual(AgentMessageCount, other.AgentMessageCount)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(TerminationReason, other.TerminationReason)
            && ValueEquality.AreEqual(CallSuccessful, other.CallSuccessful)
            && ValueEquality.AreEqual(CallSuccessScore, other.CallSuccessScore)
            && ValueEquality.AreEqual(TranscriptSummary, other.TranscriptSummary)
            && ValueEquality.AreEqual(CallSummaryTitle, other.CallSummaryTitle)
            && ValueEquality.AreEqual(MainLanguage, other.MainLanguage)
            && ValueEquality.AreEqual(
                ConversationInitiationSource,
                other.ConversationInitiationSource
            )
            && ValueEquality.AreEqual(ToolNames, other.ToolNames)
            && ValueEquality.AreEqual(Direction, other.Direction)
            && ValueEquality.AreEqual(Rating, other.Rating)
            && ValueEquality.AreEqual(SentimentAnalysis, other.SentimentAnalysis)
            && ValueEquality.AreEqual(DataCollectionResults, other.DataCollectionResults)
            && ValueEquality.AreEqual(EvaluationCriteriaResults, other.EvaluationCriteriaResults)
            && ValueEquality.AreEqual(TagIds, other.TagIds)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartTimeUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallDurationSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Cost);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CostFiat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MessageCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserMessageCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentMessageCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TerminationReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallSuccessful);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallSuccessScore);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscriptSummary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallSummaryTitle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MainLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationInitiationSource);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolNames);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Direction);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Rating);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SentimentAnalysis);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DataCollectionResults);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EvaluationCriteriaResults);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TagIds);
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
