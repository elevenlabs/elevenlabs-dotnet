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
public record SubscriptionUsageResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The rollover credits quota.</value>
    [JsonPropertyName("rollover_credits_quota")]
    public required int RolloverCreditsQuota { get; set; }

    /// <value>The subscription cycle credits quota.</value>
    [JsonPropertyName("subscription_cycle_credits_quota")]
    public required int SubscriptionCycleCreditsQuota { get; set; }

    /// <value>The manually gifted credits quota.</value>
    [JsonPropertyName("manually_gifted_credits_quota")]
    public required int ManuallyGiftedCreditsQuota { get; set; }

    /// <value>The payg credits quota.</value>
    [JsonPropertyName("payg_credits_quota")]
    public int? PaygCreditsQuota { get; set; }

    /// <value>The rollover credits used.</value>
    [JsonPropertyName("rollover_credits_used")]
    public required int RolloverCreditsUsed { get; set; }

    /// <value>The subscription cycle credits used.</value>
    [JsonPropertyName("subscription_cycle_credits_used")]
    public required int SubscriptionCycleCreditsUsed { get; set; }

    /// <value>The manually gifted credits used.</value>
    [JsonPropertyName("manually_gifted_credits_used")]
    public required int ManuallyGiftedCreditsUsed { get; set; }

    /// <value>The payg credits used.</value>
    [JsonPropertyName("payg_credits_used")]
    public int? PaygCreditsUsed { get; set; }

    /// <value>The paid usage based credits used.</value>
    [JsonPropertyName("paid_usage_based_credits_used")]
    public required int PaidUsageBasedCreditsUsed { get; set; }

    /// <value>The actual reported credits.</value>
    [JsonPropertyName("actual_reported_credits")]
    public required int ActualReportedCredits { get; set; }

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
    public virtual bool Equals(SubscriptionUsageResponseModel? other)
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
            && ValueEquality.AreEqual(RolloverCreditsQuota, other.RolloverCreditsQuota)
            && ValueEquality.AreEqual(
                SubscriptionCycleCreditsQuota,
                other.SubscriptionCycleCreditsQuota
            )
            && ValueEquality.AreEqual(ManuallyGiftedCreditsQuota, other.ManuallyGiftedCreditsQuota)
            && ValueEquality.AreEqual(PaygCreditsQuota, other.PaygCreditsQuota)
            && ValueEquality.AreEqual(RolloverCreditsUsed, other.RolloverCreditsUsed)
            && ValueEquality.AreEqual(
                SubscriptionCycleCreditsUsed,
                other.SubscriptionCycleCreditsUsed
            )
            && ValueEquality.AreEqual(ManuallyGiftedCreditsUsed, other.ManuallyGiftedCreditsUsed)
            && ValueEquality.AreEqual(PaygCreditsUsed, other.PaygCreditsUsed)
            && ValueEquality.AreEqual(PaidUsageBasedCreditsUsed, other.PaidUsageBasedCreditsUsed)
            && ValueEquality.AreEqual(ActualReportedCredits, other.ActualReportedCredits)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RolloverCreditsQuota);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SubscriptionCycleCreditsQuota);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ManuallyGiftedCreditsQuota);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PaygCreditsQuota);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RolloverCreditsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SubscriptionCycleCreditsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ManuallyGiftedCreditsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PaygCreditsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PaidUsageBasedCreditsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ActualReportedCredits);
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
