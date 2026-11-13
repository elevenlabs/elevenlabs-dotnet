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
public record ConversationHistoryTranscriptResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("role")]
    public required ConversationHistoryTranscriptResponseModelRole Role { get; set; }

    [JsonPropertyName("agent_metadata")]
    public AgentMetadata? AgentMetadata { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("multivoice_message")]
    public ConversationHistoryMultivoiceMessageModel? MultivoiceMessage { get; set; }

    [JsonPropertyName("tool_calls")]
    public IEnumerable<ConversationHistoryTranscriptToolCallCommonModelOutput>? ToolCalls { get; set; }

    [JsonPropertyName("tool_results")]
    public IEnumerable<ConversationHistoryTranscriptResponseModelToolResultsItem>? ToolResults { get; set; }

    [JsonPropertyName("feedback")]
    public UserFeedback? Feedback { get; set; }

    [JsonPropertyName("llm_override")]
    public string? LlmOverride { get; set; }

    [JsonPropertyName("producing_llm")]
    public string? ProducingLlm { get; set; }

    [JsonPropertyName("time_in_call_secs")]
    public required int TimeInCallSecs { get; set; }

    [JsonPropertyName("conversation_turn_metrics")]
    public ConversationTurnMetrics? ConversationTurnMetrics { get; set; }

    [JsonPropertyName("rag_retrieval_info")]
    public RagRetrievalInfo? RagRetrievalInfo { get; set; }

    [JsonPropertyName("llm_usage")]
    public LlmUsageOutput? LlmUsage { get; set; }

    [JsonPropertyName("interrupted")]
    public bool? Interrupted { get; set; }

    [JsonPropertyName("ignored_as_backchannel")]
    public bool? IgnoredAsBackchannel { get; set; }

    [JsonPropertyName("platform_event")]
    public TranscriptPlatformEvent? PlatformEvent { get; set; }

    [JsonPropertyName("original_message")]
    public string? OriginalMessage { get; set; }

    [JsonPropertyName("reasoning")]
    public IEnumerable<ConversationReasoningModel>? Reasoning { get; set; }

    [JsonPropertyName("source_medium")]
    public ChatSourceMedium? SourceMedium { get; set; }

    [JsonPropertyName("source_event_id")]
    public int? SourceEventId { get; set; }

    [JsonPropertyName("used_static_kb_document_ids")]
    public IEnumerable<string>? UsedStaticKbDocumentIds { get; set; }

    [JsonPropertyName("user_identifier")]
    public string? UserIdentifier { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("created_at_unix_ms")]
    public int? CreatedAtUnixMs { get; set; }

    [JsonPropertyName("triggered_guardrails")]
    public IEnumerable<TriggeredGuardrailCommonModel>? TriggeredGuardrails { get; set; }

    /// <value>Deprecated: the first attachment on this turn. Use `file_inputs` to see every attachment.</value>
    [JsonPropertyName("file_input")]
    public ConversationHistoryTranscriptFileInputResponseModel? FileInput { get; set; }

    /// <value>All files attached to this turn, in the order the user attached them.</value>
    [JsonPropertyName("file_inputs")]
    public IEnumerable<ConversationHistoryTranscriptFileInputResponseModel>? FileInputs { get; set; }

    [JsonPropertyName("contextual_update_info")]
    public ContextualUpdateInfo? ContextualUpdateInfo { get; set; }

    [JsonPropertyName("reasoned")]
    public bool? Reasoned { get; set; }

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
    public virtual bool Equals(ConversationHistoryTranscriptResponseModel? other)
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
            && ValueEquality.AreEqual(Role, other.Role)
            && ValueEquality.AreEqual(AgentMetadata, other.AgentMetadata)
            && ValueEquality.AreEqual(Message, other.Message)
            && ValueEquality.AreEqual(MultivoiceMessage, other.MultivoiceMessage)
            && ValueEquality.AreEqual(ToolCalls, other.ToolCalls)
            && ValueEquality.AreEqual(ToolResults, other.ToolResults)
            && ValueEquality.AreEqual(Feedback, other.Feedback)
            && ValueEquality.AreEqual(LlmOverride, other.LlmOverride)
            && ValueEquality.AreEqual(ProducingLlm, other.ProducingLlm)
            && ValueEquality.AreEqual(TimeInCallSecs, other.TimeInCallSecs)
            && ValueEquality.AreEqual(ConversationTurnMetrics, other.ConversationTurnMetrics)
            && ValueEquality.AreEqual(RagRetrievalInfo, other.RagRetrievalInfo)
            && ValueEquality.AreEqual(LlmUsage, other.LlmUsage)
            && ValueEquality.AreEqual(Interrupted, other.Interrupted)
            && ValueEquality.AreEqual(IgnoredAsBackchannel, other.IgnoredAsBackchannel)
            && ValueEquality.AreEqual(PlatformEvent, other.PlatformEvent)
            && ValueEquality.AreEqual(OriginalMessage, other.OriginalMessage)
            && ValueEquality.AreEqual(Reasoning, other.Reasoning)
            && ValueEquality.AreEqual(SourceMedium, other.SourceMedium)
            && ValueEquality.AreEqual(SourceEventId, other.SourceEventId)
            && ValueEquality.AreEqual(UsedStaticKbDocumentIds, other.UsedStaticKbDocumentIds)
            && ValueEquality.AreEqual(UserIdentifier, other.UserIdentifier)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(CreatedAtUnixMs, other.CreatedAtUnixMs)
            && ValueEquality.AreEqual(TriggeredGuardrails, other.TriggeredGuardrails)
            && ValueEquality.AreEqual(FileInput, other.FileInput)
            && ValueEquality.AreEqual(FileInputs, other.FileInputs)
            && ValueEquality.AreEqual(ContextualUpdateInfo, other.ContextualUpdateInfo)
            && ValueEquality.AreEqual(Reasoned, other.Reasoned)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Role);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentMetadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Message);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MultivoiceMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCalls);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolResults);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Feedback);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LlmOverride);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProducingLlm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TimeInCallSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationTurnMetrics);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RagRetrievalInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LlmUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Interrupted);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IgnoredAsBackchannel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformEvent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OriginalMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Reasoning);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceMedium);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceEventId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UsedStaticKbDocumentIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserIdentifier);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnixMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TriggeredGuardrails);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileInput);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileInputs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContextualUpdateInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Reasoned);
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
