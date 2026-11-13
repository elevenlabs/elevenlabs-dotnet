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
public record CallView : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("intent_id")]
    public required string IntentId { get; set; }

    [JsonPropertyName("lead_id")]
    public required string LeadId { get; set; }

    [JsonPropertyName("intent_type")]
    public required CampaignConversationType IntentType { get; set; }

    /// <value>`1` for the first call and `+1` per retry of it; unset for callbacks, redirects and their retries.</value>
    [JsonPropertyName("cold_attempt")]
    public int? ColdAttempt { get; set; }

    [JsonPropertyName("status")]
    public required CallStatus Status { get; set; }

    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; set; }

    /// <value>When the call is due to be placed.</value>
    [JsonPropertyName("scheduled_time_unix")]
    public required int ScheduledTimeUnix { get; set; }

    [JsonPropertyName("conversation_id")]
    public string? ConversationId { get; set; }

    /// <value>The call's final dialing status, set once it ends.</value>
    [JsonPropertyName("outcome")]
    public BatchCallRecipientStatus? Outcome { get; set; }

    /// <value>How the call ended.</value>
    [JsonPropertyName("call_result")]
    public CallResult? CallResult { get; set; }

    /// <value>When the call ended.</value>
    [JsonPropertyName("outcome_at_unix")]
    public int? OutcomeAtUnix { get; set; }

    /// <value>What the campaign did after the call, such as queue a retry or a callback, or finish the lead.</value>
    [JsonPropertyName("decision_disposition")]
    public DecisionDisposition? DecisionDisposition { get; set; }

    /// <value>Data collection results this call copied into the lead's dynamic variables for later calls, with secrets redacted.</value>
    [JsonPropertyName("collected_dynamic_variables")]
    public Dictionary<string, object?>? CollectedDynamicVariables { get; set; }

    /// <value>The message's delivery; set on message campaigns.</value>
    [JsonPropertyName("delivery")]
    public LeadDeliveryView? Delivery { get; set; }

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
    public virtual bool Equals(CallView? other)
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
            && ValueEquality.AreEqual(IntentId, other.IntentId)
            && ValueEquality.AreEqual(LeadId, other.LeadId)
            && ValueEquality.AreEqual(IntentType, other.IntentType)
            && ValueEquality.AreEqual(ColdAttempt, other.ColdAttempt)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(PhoneNumber, other.PhoneNumber)
            && ValueEquality.AreEqual(ScheduledTimeUnix, other.ScheduledTimeUnix)
            && ValueEquality.AreEqual(ConversationId, other.ConversationId)
            && ValueEquality.AreEqual(Outcome, other.Outcome)
            && ValueEquality.AreEqual(CallResult, other.CallResult)
            && ValueEquality.AreEqual(OutcomeAtUnix, other.OutcomeAtUnix)
            && ValueEquality.AreEqual(DecisionDisposition, other.DecisionDisposition)
            && ValueEquality.AreEqual(CollectedDynamicVariables, other.CollectedDynamicVariables)
            && ValueEquality.AreEqual(Delivery, other.Delivery)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LeadId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ColdAttempt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScheduledTimeUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Outcome);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallResult);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OutcomeAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DecisionDisposition);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CollectedDynamicVariables);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Delivery);
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
