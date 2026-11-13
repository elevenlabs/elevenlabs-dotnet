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
public record GetConversationResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("agent_name")]
    public string? AgentName { get; set; }

    [JsonPropertyName("conversation_product")]
    public string? ConversationProduct { get; set; }

    [JsonPropertyName("status")]
    public required GetConversationResponseModelStatus Status { get; set; }

    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>The ID of the agent version used for this conversation</value>
    [JsonPropertyName("version_id")]
    public string? VersionId { get; set; }

    [JsonPropertyName("metadata")]
    public required ConversationHistoryMetadataCommonModel Metadata { get; set; }

    [JsonPropertyName("analysis")]
    public ConversationHistoryAnalysisCommonModel? Analysis { get; set; }

    /// <value>Number of user transcript turns with text; tool-only turns are not counted. `null` for older conversations before this field whose transcript was deleted.</value>
    [JsonPropertyName("user_message_count")]
    public int? UserMessageCount { get; set; }

    /// <value>Number of agent transcript turns with text; tool-only turns are not counted. `null` for older conversations before this field whose transcript was deleted.</value>
    [JsonPropertyName("agent_message_count")]
    public int? AgentMessageCount { get; set; }

    [JsonPropertyName("visited_agents")]
    public IEnumerable<VisitedAgentRef>? VisitedAgents { get; set; }

    [JsonPropertyName("conversation_initiation_client_data")]
    public ConversationInitiationClientDataRequestOutput? ConversationInitiationClientData { get; set; }

    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    [JsonPropertyName("conversation_id")]
    public required string ConversationId { get; set; }

    [JsonPropertyName("has_audio")]
    public required bool HasAudio { get; set; }

    [JsonPropertyName("has_user_audio")]
    public required bool HasUserAudio { get; set; }

    [JsonPropertyName("has_response_audio")]
    public required bool HasResponseAudio { get; set; }

    [JsonPropertyName("has_auxiliary_audio")]
    public required bool HasAuxiliaryAudio { get; set; }

    [JsonPropertyName("transcript")]
    public IEnumerable<ConversationHistoryTranscriptResponseModel> Transcript { get; set; } =
        new List<ConversationHistoryTranscriptResponseModel>();

    /// <value>Conversation tag ids assigned to this conversation.</value>
    [JsonPropertyName("tag_ids")]
    public IEnumerable<string>? TagIds { get; set; }

    /// <value>OpenTelemetry trace payload when the request uses format=opentelemetry; otherwise omitted.</value>
    [JsonPropertyName("otlp_traces")]
    public Dictionary<string, object?>? OtlpTraces { get; set; }

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
    public virtual bool Equals(GetConversationResponseModel? other)
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
            && ValueEquality.AreEqual(AgentName, other.AgentName)
            && ValueEquality.AreEqual(ConversationProduct, other.ConversationProduct)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(UserId, other.UserId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(VersionId, other.VersionId)
            && ValueEquality.AreEqual(Metadata, other.Metadata)
            && ValueEquality.AreEqual(Analysis, other.Analysis)
            && ValueEquality.AreEqual(UserMessageCount, other.UserMessageCount)
            && ValueEquality.AreEqual(AgentMessageCount, other.AgentMessageCount)
            && ValueEquality.AreEqual(VisitedAgents, other.VisitedAgents)
            && ValueEquality.AreEqual(
                ConversationInitiationClientData,
                other.ConversationInitiationClientData
            )
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(ConversationId, other.ConversationId)
            && ValueEquality.AreEqual(HasAudio, other.HasAudio)
            && ValueEquality.AreEqual(HasUserAudio, other.HasUserAudio)
            && ValueEquality.AreEqual(HasResponseAudio, other.HasResponseAudio)
            && ValueEquality.AreEqual(HasAuxiliaryAudio, other.HasAuxiliaryAudio)
            && ValueEquality.AreEqual(Transcript, other.Transcript)
            && ValueEquality.AreEqual(TagIds, other.TagIds)
            && ValueEquality.AreEqual(OtlpTraces, other.OtlpTraces)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationProduct);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Metadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Analysis);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserMessageCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentMessageCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VisitedAgents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationInitiationClientData);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasUserAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasResponseAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasAuxiliaryAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Transcript);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TagIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OtlpTraces);
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
