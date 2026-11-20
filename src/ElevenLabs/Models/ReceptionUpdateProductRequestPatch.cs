using ElevenLabs;
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

namespace ElevenLabs.Reception;

[Serializable]
public record ReceptionUpdateProductRequestPatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>
    /// Whether a catalog item's price and duration are known up front.
    ///
    /// - `fixed`: the catalog price and duration apply (the default).
    /// - `quote`: neither is known until the owner has seen the job. The
    ///   receptionist collects intake answers and files a quote request instead
    ///   of booking a slot or taking an order.
    /// </value>
    [JsonPropertyName("pricing_mode")]
    public PricingMode? PricingMode { get; set; }

    /// <value>Questions the agent asks before booking or ordering this item. Required for a useful `pricing_mode='quote'` item -- without them a quote request arrives with nothing to price -- but also valid on fixed-price items that need extra detail (current hair color before a dye job, allergies before a treatment).</value>
    [JsonPropertyName("intake_questions")]
    public IEnumerable<ReceptionIntakeQuestion>? IntakeQuestions { get; set; }

    /// <value>Group memberships for this item. Each entry carries the group label and the item's 0-based rank within that group.</value>
    [JsonPropertyName("groups")]
    public IEnumerable<ReceptionGroupMembership>? Groups { get; set; }

    /// <value>Display position among items with no group; `null` sorts last. Change it with the reorder endpoint.</value>
    [JsonPropertyName("ungrouped_rank")]
    public int? UngroupedRank { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>Price of the product; null for no listed price.</value>
    [JsonPropertyName("price")]
    public double? Price { get; set; }

    /// <value>False hides the product without deleting it.</value>
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

    /// <value>False keeps the product listed (callers can ask about it) but not orderable.</value>
    [JsonPropertyName("orderable")]
    public bool? Orderable { get; set; }

    /// <value>Fulfillment options customers may choose when ordering this product.</value>
    [JsonPropertyName("allowed_fulfillment_types")]
    public IEnumerable<OrderFulfillmentType>? AllowedFulfillmentTypes { get; set; }

    /// <value>Locations where this product is sold; empty list means all locations.</value>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <value>Whether this product is counted. Switching it only changes the mode: turning it on keeps whatever is already on hand, turning it off drops the counts. Use the stock endpoints to change the amounts themselves.</value>
    [JsonPropertyName("track_quantity")]
    public bool? TrackQuantity { get; set; }

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
    public virtual bool Equals(ReceptionUpdateProductRequestPatch? other)
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
            && ValueEquality.AreEqual(PricingMode, other.PricingMode)
            && ValueEquality.AreEqual(IntakeQuestions, other.IntakeQuestions)
            && ValueEquality.AreEqual(Groups, other.Groups)
            && ValueEquality.AreEqual(UngroupedRank, other.UngroupedRank)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(Price, other.Price)
            && ValueEquality.AreEqual(IsActive, other.IsActive)
            && ValueEquality.AreEqual(Orderable, other.Orderable)
            && ValueEquality.AreEqual(AllowedFulfillmentTypes, other.AllowedFulfillmentTypes)
            && ValueEquality.AreEqual(LocationIds, other.LocationIds)
            && ValueEquality.AreEqual(TrackQuantity, other.TrackQuantity)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PricingMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntakeQuestions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Groups);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UngroupedRank);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Price);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsActive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Orderable);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AllowedFulfillmentTypes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LocationIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TrackQuantity);
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
