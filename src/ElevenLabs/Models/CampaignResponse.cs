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
public record CampaignResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("campaign_id")]
    public required string CampaignId { get; set; }

    /// <value>The campaign's name.</value>
    [JsonPropertyName("call_name")]
    public required string CallName { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("channel_config")]
    public required CampaignResponseChannelConfig ChannelConfig { get; set; }

    [JsonPropertyName("status")]
    public required CampaignStatus Status { get; set; }

    /// <value>The policy the campaign took when it was created, laid out like a submitted `policy`.</value>
    [JsonPropertyName("policy")]
    public required CampaignPolicySnapshot Policy { get; set; }

    [JsonPropertyName("variant")]
    public required CampaignVariant Variant { get; set; }

    /// <value>Whether the campaign was created in the app or through the API.</value>
    [JsonPropertyName("source")]
    public CampaignSource? Source { get; set; }

    [JsonPropertyName("created_at_unix")]
    public required int CreatedAtUnix { get; set; }

    /// <value>When the campaign starts calling; unset to start once created.</value>
    [JsonPropertyName("scheduled_time_unix")]
    public int? ScheduledTimeUnix { get; set; }

    [JsonPropertyName("updated_at_unix")]
    public required int UpdatedAtUnix { get; set; }

    /// <value>The agent branch the campaign calls with.</value>
    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>The environment the agent's environment variables resolve in.</value>
    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    /// <value>The most calls the campaign places at once.</value>
    [JsonPropertyName("target_concurrency_limit")]
    public int? TargetConcurrencyLimit { get; set; }

    [JsonPropertyName("channel")]
    public required OutboundChannel Channel { get; set; }

    [JsonPropertyName("mode")]
    public required OutboundMode Mode { get; set; }

    [JsonPropertyName("counts")]
    public required CampaignSummaryCounts Counts { get; set; }

    [JsonPropertyName("agent_name")]
    public required string AgentName { get; set; }

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
    public virtual bool Equals(CampaignResponse? other)
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
            && ValueEquality.AreEqual(CampaignId, other.CampaignId)
            && ValueEquality.AreEqual(CallName, other.CallName)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(ChannelConfig, other.ChannelConfig)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(Policy, other.Policy)
            && ValueEquality.AreEqual(Variant, other.Variant)
            && ValueEquality.AreEqual(Source, other.Source)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(ScheduledTimeUnix, other.ScheduledTimeUnix)
            && ValueEquality.AreEqual(UpdatedAtUnix, other.UpdatedAtUnix)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(TargetConcurrencyLimit, other.TargetConcurrencyLimit)
            && ValueEquality.AreEqual(Channel, other.Channel)
            && ValueEquality.AreEqual(Mode, other.Mode)
            && ValueEquality.AreEqual(Counts, other.Counts)
            && ValueEquality.AreEqual(AgentName, other.AgentName)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CampaignId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChannelConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Policy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Variant);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Source);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScheduledTimeUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Channel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Mode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Counts);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentName);
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
