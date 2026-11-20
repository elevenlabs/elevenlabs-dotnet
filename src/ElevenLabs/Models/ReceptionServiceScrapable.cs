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

/// <summary>
/// Scrape-reachable subset of a service (classic, rental or group).
///
/// The extraction pipeline uses one LLM prompt per kind (so the model sees
/// kind-specific guidance), but every code path produces this single shape:
/// onboarding, imports and the unified ``smb_services`` collection all
/// discriminate by the ``kind`` field.
/// </summary>
[Serializable]
public record ReceptionServiceScrapable : IJsonOnDeserialized
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

    /// <value>Group memberships for this item. Each entry carries the group label and the item's 0-based rank within that group.</value>
    [JsonPropertyName("groups")]
    public IEnumerable<ReceptionGroupMembership>? Groups { get; set; }

    /// <value>Display position among items with no group; `null` sorts last. Change it with the reorder endpoint.</value>
    [JsonPropertyName("ungrouped_rank")]
    public int? UngroupedRank { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>Bookable options for this service. Always non-empty; `variants[0]` is the default option shown when callers don't pick a specific variant. Each entry has its own duration and (optional) price, and uniqueness is keyed by duration.</value>
    [JsonPropertyName("variants")]
    public IEnumerable<ReceptionServiceVariant>? Variants { get; set; }

    /// <value>
    /// What a service books.
    ///
    /// - `classic`: a staff-delivered service (haircut, consultation, massage, ...).
    /// - `rental`: an asset reservation (court, room, equipment).
    /// - `group`: seats in a multi-participant session (class, workshop, tour).
    /// </value>
    [JsonPropertyName("kind")]
    public ReceptionServiceKind? Kind { get; set; }

    /// <value>Turnover/cleanup time reserved after each booking. Applies to every service kind; default 0 means no buffer.</value>
    [JsonPropertyName("buffer_minutes")]
    public int? BufferMinutes { get; set; }

    /// <value>Where a classic service is delivered.</value>
    [JsonPropertyName("service_location")]
    public ServiceLocationType? ServiceLocation { get; set; }

    /// <value>Optional extras that can be added to a booking of this service.</value>
    [JsonPropertyName("add_ons")]
    public IEnumerable<ReceptionAddOn>? AddOns { get; set; }

    /// <value>Capacity for `kind='group'`: how many seats a single session can sell across all registrations. Must be null for classic and rental services (those are always exclusive to one client per booking).</value>
    [JsonPropertyName("max_participants")]
    public int? MaxParticipants { get; set; }

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
    public virtual bool Equals(ReceptionServiceScrapable? other)
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
            && ValueEquality.AreEqual(Groups, other.Groups)
            && ValueEquality.AreEqual(UngroupedRank, other.UngroupedRank)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(Variants, other.Variants)
            && ValueEquality.AreEqual(Kind, other.Kind)
            && ValueEquality.AreEqual(BufferMinutes, other.BufferMinutes)
            && ValueEquality.AreEqual(ServiceLocation, other.ServiceLocation)
            && ValueEquality.AreEqual(AddOns, other.AddOns)
            && ValueEquality.AreEqual(MaxParticipants, other.MaxParticipants)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PricingMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Groups);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UngroupedRank);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Variants);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Kind);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BufferMinutes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ServiceLocation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AddOns);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxParticipants);
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
