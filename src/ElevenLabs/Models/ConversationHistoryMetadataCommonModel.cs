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
public record ConversationHistoryMetadataCommonModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("start_time_unix_secs")]
    public required int StartTimeUnixSecs { get; set; }

    [JsonPropertyName("accepted_time_unix_secs")]
    public int? AcceptedTimeUnixSecs { get; set; }

    [JsonPropertyName("call_duration_secs")]
    public required int CallDurationSecs { get; set; }

    /// <value>Seconds the caller was held in the concurrency wait queue. Excluded from call_duration_secs and from billed time. None when the conversation was never queued.</value>
    [JsonPropertyName("queue_wait_secs")]
    public double? QueueWaitSecs { get; set; }

    [JsonPropertyName("cost")]
    public int? Cost { get; set; }

    [JsonPropertyName("deletion_settings")]
    public ConversationDeletionSettings? DeletionSettings { get; set; }

    [JsonPropertyName("feedback")]
    public ConversationHistoryFeedbackCommonModel? Feedback { get; set; }

    [JsonPropertyName("authorization_method")]
    public AuthorizationMethod? AuthorizationMethod { get; set; }

    [JsonPropertyName("charging")]
    public ConversationChargingCommonModel? Charging { get; set; }

    [JsonPropertyName("phone_call")]
    public ConversationHistoryMetadataCommonModelPhoneCall? PhoneCall { get; set; }

    [JsonPropertyName("batch_call")]
    public ConversationHistoryBatchCallModel? BatchCall { get; set; }

    [JsonPropertyName("termination_reason")]
    public string? TerminationReason { get; set; }

    [JsonPropertyName("error")]
    public ConversationHistoryErrorCommonModel? Error { get; set; }

    [JsonPropertyName("warnings")]
    public IEnumerable<string>? Warnings { get; set; }

    [JsonPropertyName("main_language")]
    public string? MainLanguage { get; set; }

    [JsonPropertyName("rag_usage")]
    public ConversationHistoryRagUsageCommonModel? RagUsage { get; set; }

    [JsonPropertyName("text_only")]
    public bool? TextOnly { get; set; }

    [JsonPropertyName("features_usage")]
    public FeaturesUsageCommonModel? FeaturesUsage { get; set; }

    [JsonPropertyName("eleven_assistant")]
    public ConversationHistoryElevenAssistantCommonModel? ElevenAssistant { get; set; }

    [JsonPropertyName("initiator_id")]
    public string? InitiatorId { get; set; }

    /// <value>Enum representing the possible sources for conversation initiation.</value>
    [JsonPropertyName("conversation_initiation_source")]
    public ConversationInitiationSource1? ConversationInitiationSource { get; set; }

    [JsonPropertyName("conversation_initiation_source_version")]
    public string? ConversationInitiationSourceVersion { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("async_metadata")]
    public AsyncConversationMetadata? AsyncMetadata { get; set; }

    [JsonPropertyName("whatsapp")]
    public WhatsAppConversationInfo? Whatsapp { get; set; }

    [JsonPropertyName("sms")]
    public SmsConversationInfo? Sms { get; set; }

    [JsonPropertyName("agent_created_from")]
    public AgentDefinitionSource? AgentCreatedFrom { get; set; }

    [JsonPropertyName("agent_last_updated_from")]
    public AgentDefinitionSource? AgentLastUpdatedFrom { get; set; }

    [JsonPropertyName("voice_rewards")]
    public IEnumerable<ConversationVoiceRewardModel>? VoiceRewards { get; set; }

    /// <value>Total fiat cost of the conversation in USD, i.e. the sum of the LLM price and the non-LLM platform price (the fiat analogue of ``cost``). ``None`` when neither is set (e.g. conversations that predate fiat cost tracking).</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("cost_fiat")]
    public double? CostFiat { get; set; }

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
    public virtual bool Equals(ConversationHistoryMetadataCommonModel? other)
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
            && ValueEquality.AreEqual(StartTimeUnixSecs, other.StartTimeUnixSecs)
            && ValueEquality.AreEqual(AcceptedTimeUnixSecs, other.AcceptedTimeUnixSecs)
            && ValueEquality.AreEqual(CallDurationSecs, other.CallDurationSecs)
            && ValueEquality.AreEqual(QueueWaitSecs, other.QueueWaitSecs)
            && ValueEquality.AreEqual(Cost, other.Cost)
            && ValueEquality.AreEqual(DeletionSettings, other.DeletionSettings)
            && ValueEquality.AreEqual(Feedback, other.Feedback)
            && ValueEquality.AreEqual(AuthorizationMethod, other.AuthorizationMethod)
            && ValueEquality.AreEqual(Charging, other.Charging)
            && ValueEquality.AreEqual(PhoneCall, other.PhoneCall)
            && ValueEquality.AreEqual(BatchCall, other.BatchCall)
            && ValueEquality.AreEqual(TerminationReason, other.TerminationReason)
            && ValueEquality.AreEqual(Error, other.Error)
            && ValueEquality.AreEqual(Warnings, other.Warnings)
            && ValueEquality.AreEqual(MainLanguage, other.MainLanguage)
            && ValueEquality.AreEqual(RagUsage, other.RagUsage)
            && ValueEquality.AreEqual(TextOnly, other.TextOnly)
            && ValueEquality.AreEqual(FeaturesUsage, other.FeaturesUsage)
            && ValueEquality.AreEqual(ElevenAssistant, other.ElevenAssistant)
            && ValueEquality.AreEqual(InitiatorId, other.InitiatorId)
            && ValueEquality.AreEqual(
                ConversationInitiationSource,
                other.ConversationInitiationSource
            )
            && ValueEquality.AreEqual(
                ConversationInitiationSourceVersion,
                other.ConversationInitiationSourceVersion
            )
            && ValueEquality.AreEqual(Timezone, other.Timezone)
            && ValueEquality.AreEqual(AsyncMetadata, other.AsyncMetadata)
            && ValueEquality.AreEqual(Whatsapp, other.Whatsapp)
            && ValueEquality.AreEqual(Sms, other.Sms)
            && ValueEquality.AreEqual(AgentCreatedFrom, other.AgentCreatedFrom)
            && ValueEquality.AreEqual(AgentLastUpdatedFrom, other.AgentLastUpdatedFrom)
            && ValueEquality.AreEqual(VoiceRewards, other.VoiceRewards)
            && ValueEquality.AreEqual(CostFiat, other.CostFiat)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartTimeUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AcceptedTimeUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallDurationSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QueueWaitSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Cost);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeletionSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Feedback);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthorizationMethod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Charging);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BatchCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TerminationReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Error);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Warnings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MainLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RagUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextOnly);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FeaturesUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ElevenAssistant);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InitiatorId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationInitiationSource);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationInitiationSourceVersion);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Timezone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AsyncMetadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Whatsapp);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Sms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentCreatedFrom);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentLastUpdatedFrom);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceRewards);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CostFiat);
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
