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
public record BatchCallResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("phone_number_id")]
    public string? PhoneNumberId { get; set; }

    [JsonPropertyName("phone_provider")]
    public TelephonyProvider? PhoneProvider { get; set; }

    [JsonPropertyName("whatsapp_params")]
    public BatchCallWhatsAppParams? WhatsappParams { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    [JsonPropertyName("created_at_unix")]
    public required int CreatedAtUnix { get; set; }

    [JsonPropertyName("scheduled_time_unix")]
    public required int ScheduledTimeUnix { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("total_calls_dispatched")]
    public required int TotalCallsDispatched { get; set; }

    [JsonPropertyName("total_calls_scheduled")]
    public required int TotalCallsScheduled { get; set; }

    [JsonPropertyName("total_calls_finished")]
    public required int TotalCallsFinished { get; set; }

    [JsonPropertyName("last_updated_at_unix")]
    public required int LastUpdatedAtUnix { get; set; }

    [JsonPropertyName("status")]
    public required BatchCallStatus Status { get; set; }

    [JsonPropertyName("retry_count")]
    public required int RetryCount { get; set; }

    [JsonPropertyName("telephony_call_config")]
    public required TelephonyCallConfigOutput TelephonyCallConfig { get; set; }

    /// <value>Maximum number of simultaneous calls for this batch. When set, dispatch is governed by this limit rather than workspace/agent capacity percentages.</value>
    [JsonPropertyName("target_concurrency_limit")]
    public int? TargetConcurrencyLimit { get; set; }

    [JsonPropertyName("agent_name")]
    public required string AgentName { get; set; }

    [JsonPropertyName("branch_name")]
    public string? BranchName { get; set; }

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
    public virtual bool Equals(BatchCallResponse? other)
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
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(PhoneNumberId, other.PhoneNumberId)
            && ValueEquality.AreEqual(PhoneProvider, other.PhoneProvider)
            && ValueEquality.AreEqual(WhatsappParams, other.WhatsappParams)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(ScheduledTimeUnix, other.ScheduledTimeUnix)
            && ValueEquality.AreEqual(Timezone, other.Timezone)
            && ValueEquality.AreEqual(TotalCallsDispatched, other.TotalCallsDispatched)
            && ValueEquality.AreEqual(TotalCallsScheduled, other.TotalCallsScheduled)
            && ValueEquality.AreEqual(TotalCallsFinished, other.TotalCallsFinished)
            && ValueEquality.AreEqual(LastUpdatedAtUnix, other.LastUpdatedAtUnix)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(RetryCount, other.RetryCount)
            && ValueEquality.AreEqual(TelephonyCallConfig, other.TelephonyCallConfig)
            && ValueEquality.AreEqual(TargetConcurrencyLimit, other.TargetConcurrencyLimit)
            && ValueEquality.AreEqual(AgentName, other.AgentName)
            && ValueEquality.AreEqual(BranchName, other.BranchName)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumberId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneProvider);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WhatsappParams);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScheduledTimeUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Timezone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TotalCallsDispatched);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TotalCallsScheduled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TotalCallsFinished);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastUpdatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RetryCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TelephonyCallConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchName);
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
