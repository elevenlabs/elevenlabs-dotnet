using ElevenLabs;
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

namespace ElevenLabs.Agents;

[Serializable]
public record SubmitCampaignRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The campaign's name.</value>
    [JsonPropertyName("call_name")]
    public required string CallName { get; set; }

    /// <value>The agent that places the calls.</value>
    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    /// <value>Who to call. Each recipient becomes a lead of the campaign.</value>
    [JsonPropertyName("recipients")]
    public IEnumerable<SubmitCampaignRecipient> Recipients { get; set; } =
        new List<SubmitCampaignRecipient>();

    /// <value>When to start calling; omit to start now. Calls still wait for the next calling window.</value>
    [JsonPropertyName("scheduled_time_unix")]
    public int? ScheduledTimeUnix { get; set; }

    /// <value>IANA timezone to read the calling windows in, overriding the policy's.</value>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <value>The agent branch to call with.</value>
    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>The environment to resolve the agent's environment variables in.</value>
    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    /// <value>The most calls to place at once.</value>
    [JsonPropertyName("target_concurrency_limit")]
    public int? TargetConcurrencyLimit { get; set; }

    /// <value>Makes the request safe to retry: a repeat with the same key returns the campaign it created.</value>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <value>Policy to snapshot onto the campaign. When set, it wins over the workspace default and any per-agent override; when omitted, the workspace configuration must exist and supplies the policy.</value>
    [JsonPropertyName("policy")]
    public PolicyConfigInput? Policy { get; set; }

    /// <value>`simple` runs one attempt per recipient with always-on calling windows and nothing collected, and cannot be combined with `policy`. `advanced` uses `policy` or the workspace configuration, and is the default for phone campaigns.</value>
    [JsonPropertyName("variant")]
    public CampaignVariant? Variant { get; set; }

    [JsonPropertyName("channel_config")]
    public required SubmitCampaignRequestChannelConfig ChannelConfig { get; set; }

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
    public virtual bool Equals(SubmitCampaignRequest? other)
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
            && ValueEquality.AreEqual(CallName, other.CallName)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(Recipients, other.Recipients)
            && ValueEquality.AreEqual(ScheduledTimeUnix, other.ScheduledTimeUnix)
            && ValueEquality.AreEqual(Timezone, other.Timezone)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(TargetConcurrencyLimit, other.TargetConcurrencyLimit)
            && ValueEquality.AreEqual(IdempotencyKey, other.IdempotencyKey)
            && ValueEquality.AreEqual(Policy, other.Policy)
            && ValueEquality.AreEqual(Variant, other.Variant)
            && ValueEquality.AreEqual(ChannelConfig, other.ChannelConfig)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Recipients);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScheduledTimeUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Timezone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IdempotencyKey);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Policy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Variant);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChannelConfig);
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
