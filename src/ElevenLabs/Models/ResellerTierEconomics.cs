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
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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

/// <summary>A tier's prices and the limits shown on its tier card.</summary>
[Serializable]
public record ResellerTierEconomics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>What one month is sold for.</value>
    [JsonPropertyName("monthly_price_usd")]
    public required double MonthlyPriceUsd { get; set; }

    /// <value>What a year up front is sold for. Null for the trial.</value>
    [JsonPropertyName("annual_price_usd")]
    public double? AnnualPriceUsd { get; set; }

    /// <value>Phone minutes included each month. A web minute draws half a minute, a chat message a tenth.</value>
    [JsonPropertyName("included_minutes_per_month")]
    public required double IncludedMinutesPerMonth { get; set; }

    /// <value>Charged per minute past the included ones. Null for the trial.</value>
    [JsonPropertyName("overage_price_per_minute_usd")]
    public double? OveragePricePerMinuteUsd { get; set; }

    /// <value>Phone numbers a workspace on this tier can hold at once.</value>
    [JsonPropertyName("max_phone_numbers")]
    public required int MaxPhoneNumbers { get; set; }

    /// <value>Calls a workspace on this tier can take at the same time.</value>
    [JsonPropertyName("concurrent_calls")]
    public required int ConcurrentCalls { get; set; }

    /// <value>Business locations a workspace on this tier can have active.</value>
    [JsonPropertyName("max_active_locations")]
    public required int MaxActiveLocations { get; set; }

    /// <value>Receptionists a workspace on this tier can have active.</value>
    [JsonPropertyName("max_customer_facing_agents")]
    public required int MaxCustomerFacingAgents { get; set; }

    /// <value>Team members a workspace on this tier can have, counting pending invites.</value>
    [JsonPropertyName("max_team_members")]
    public required int MaxTeamMembers { get; set; }

    /// <value>Messages the owner can send the Assistant each day.</value>
    [JsonPropertyName("assistant_daily_messages")]
    public required int AssistantDailyMessages { get; set; }

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
    public virtual bool Equals(ResellerTierEconomics? other)
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
            && ValueEquality.AreEqual(MonthlyPriceUsd, other.MonthlyPriceUsd)
            && ValueEquality.AreEqual(AnnualPriceUsd, other.AnnualPriceUsd)
            && ValueEquality.AreEqual(IncludedMinutesPerMonth, other.IncludedMinutesPerMonth)
            && ValueEquality.AreEqual(OveragePricePerMinuteUsd, other.OveragePricePerMinuteUsd)
            && ValueEquality.AreEqual(MaxPhoneNumbers, other.MaxPhoneNumbers)
            && ValueEquality.AreEqual(ConcurrentCalls, other.ConcurrentCalls)
            && ValueEquality.AreEqual(MaxActiveLocations, other.MaxActiveLocations)
            && ValueEquality.AreEqual(MaxCustomerFacingAgents, other.MaxCustomerFacingAgents)
            && ValueEquality.AreEqual(MaxTeamMembers, other.MaxTeamMembers)
            && ValueEquality.AreEqual(AssistantDailyMessages, other.AssistantDailyMessages)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MonthlyPriceUsd);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AnnualPriceUsd);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IncludedMinutesPerMonth);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OveragePricePerMinuteUsd);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxPhoneNumbers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConcurrentCalls);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxActiveLocations);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxCustomerFacingAgents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxTeamMembers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AssistantDailyMessages);
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
