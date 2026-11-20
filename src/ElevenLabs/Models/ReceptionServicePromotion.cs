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

/// <summary>A time-bound promotion on a service/variant or on add-ons.</summary>
[Serializable]
public record ReceptionServicePromotion : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Stable ID of this promotion.</value>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>What a promotion discounts: the service price or add-on prices.</value>
    [JsonPropertyName("target")]
    public PromotionTarget? Target { get; set; }

    /// <value>When set (target=service), the promotion applies only to this variant.</value>
    [JsonPropertyName("variant_id")]
    public string? VariantId { get; set; }

    /// <value>When set (target=add_on), the promotion applies only to this add-on.</value>
    [JsonPropertyName("add_on_id")]
    public string? AddOnId { get; set; }

    /// <value>The final price when this promotion is applied to a matching line item.</value>
    [JsonPropertyName("promotional_price")]
    public required double PromotionalPrice { get; set; }

    /// <value>Days when the promotion is active (0=Monday, 6=Sunday); empty means every day.</value>
    [JsonPropertyName("days_of_week")]
    public IEnumerable<int>? DaysOfWeek { get; set; }

    /// <value>First day the promotion applies, inclusive.</value>
    [JsonPropertyName("start_date")]
    public required DateOnly StartDate { get; set; }

    /// <value>Last day the promotion applies, inclusive; on or after `start_date`.</value>
    [JsonPropertyName("end_date")]
    public required DateOnly EndDate { get; set; }

    /// <value>Whether the promotion applies; inactive promotions are ignored.</value>
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

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
    public virtual bool Equals(ReceptionServicePromotion? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Target, other.Target)
            && ValueEquality.AreEqual(VariantId, other.VariantId)
            && ValueEquality.AreEqual(AddOnId, other.AddOnId)
            && ValueEquality.AreEqual(PromotionalPrice, other.PromotionalPrice)
            && ValueEquality.AreEqual(DaysOfWeek, other.DaysOfWeek)
            && ValueEquality.AreEqual(StartDate, other.StartDate)
            && ValueEquality.AreEqual(EndDate, other.EndDate)
            && ValueEquality.AreEqual(IsActive, other.IsActive)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Target);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VariantId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AddOnId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PromotionalPrice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DaysOfWeek);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsActive);
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
