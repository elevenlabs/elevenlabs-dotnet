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
public record ReceptionCreateServiceRequest : IJsonOnDeserialized
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

    /// <value>Not used to limit bookings; set `max_participants` on group services instead.</value>
    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    /// <value>Whether the service is offered; inactive services can't be booked.</value>
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

    /// <value>Whether any staff member can deliver the service. When false, only the staff in `staff_ids` can. Ignored for rentals.</value>
    [JsonPropertyName("any_staff_member")]
    public bool? AnyStaffMember { get; set; }

    /// <value>Staff assigned to this service; must be empty for kind='rental'.</value>
    [JsonPropertyName("staff_ids")]
    public IEnumerable<string>? StaffIds { get; set; }

    /// <value>Assets, such as rooms or equipment, this service can be booked on.</value>
    [JsonPropertyName("asset_ids")]
    public IEnumerable<string>? AssetIds { get; set; }

    /// <value>How far into the future customer-facing channels (public booking page, voice agent) may book this service. Applies to every kind.</value>
    [JsonPropertyName("advance_booking_minutes")]
    public int? AdvanceBookingMinutes { get; set; }

    /// <value>Locations where this service is offered; empty list means all locations.</value>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <value>Whether the service is listed on the public booking page.</value>
    [JsonPropertyName("display_on_booking_page")]
    public bool? DisplayOnBookingPage { get; set; }

    /// <value>Travel time in minutes added before/after appointments for customer-location services. Blocks the staff member's calendar but is not visible to the customer. Ignored when `service_location='business'`.</value>
    [JsonPropertyName("travel_minutes")]
    public int? TravelMinutes { get; set; }

    /// <value>Add travel time before the appointment (outbound trip).</value>
    [JsonPropertyName("travel_before")]
    public bool? TravelBefore { get; set; }

    /// <value>Add travel time after the appointment (return trip).</value>
    [JsonPropertyName("travel_after")]
    public bool? TravelAfter { get; set; }

    /// <value>Time-bound discounts applicable to this service or specific variants.</value>
    [JsonPropertyName("promotions")]
    public IEnumerable<ReceptionServicePromotion>? Promotions { get; set; }

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
    public virtual bool Equals(ReceptionCreateServiceRequest? other)
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
            && ValueEquality.AreEqual(Variants, other.Variants)
            && ValueEquality.AreEqual(Kind, other.Kind)
            && ValueEquality.AreEqual(BufferMinutes, other.BufferMinutes)
            && ValueEquality.AreEqual(ServiceLocation, other.ServiceLocation)
            && ValueEquality.AreEqual(AddOns, other.AddOns)
            && ValueEquality.AreEqual(MaxParticipants, other.MaxParticipants)
            && ValueEquality.AreEqual(Capacity, other.Capacity)
            && ValueEquality.AreEqual(IsActive, other.IsActive)
            && ValueEquality.AreEqual(AnyStaffMember, other.AnyStaffMember)
            && ValueEquality.AreEqual(StaffIds, other.StaffIds)
            && ValueEquality.AreEqual(AssetIds, other.AssetIds)
            && ValueEquality.AreEqual(AdvanceBookingMinutes, other.AdvanceBookingMinutes)
            && ValueEquality.AreEqual(LocationIds, other.LocationIds)
            && ValueEquality.AreEqual(DisplayOnBookingPage, other.DisplayOnBookingPage)
            && ValueEquality.AreEqual(TravelMinutes, other.TravelMinutes)
            && ValueEquality.AreEqual(TravelBefore, other.TravelBefore)
            && ValueEquality.AreEqual(TravelAfter, other.TravelAfter)
            && ValueEquality.AreEqual(Promotions, other.Promotions)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Variants);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Kind);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BufferMinutes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ServiceLocation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AddOns);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxParticipants);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Capacity);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsActive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AnyStaffMember);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StaffIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AssetIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdvanceBookingMinutes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LocationIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisplayOnBookingPage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TravelMinutes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TravelBefore);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TravelAfter);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Promotions);
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
