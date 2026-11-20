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

/// <summary>A phone number held by the workspace.</summary>
[Serializable]
public record ReceptionPhoneAssignment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Phone number in E.164 format.</value>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <value>True when the phone is bring-your-own: registered by the workspace using their own telephony provider (Twilio credentials or SIP trunk). BYO phones are never part of the shared pool, do not count against the plan's phone number limit, and are deleted (rather than returned to the pool) on release.</value>
    [JsonPropertyName("is_byo")]
    public bool? IsByo { get; set; }

    /// <value>How calls to the number reach ElevenLabs: through Twilio or a SIP trunk.</value>
    [JsonPropertyName("provider")]
    public ReceptionPhoneProvider? Provider { get; set; }

    /// <value>US/Canada NANP area code (NPA) as an integer.</value>
    [JsonPropertyName("nanp_area_code")]
    public int? NanpAreaCode { get; set; }

    /// <value>The receptionist that answers this number. Null when the workspace holds the number but no receptionist answers it yet.</value>
    [JsonPropertyName("customer_facing_agent_id")]
    public string? CustomerFacingAgentId { get; set; }

    /// <value>Unix timestamp when this number was deactivated; it is released 14 days later. Null when active.</value>
    [JsonPropertyName("deactivated_at_unix")]
    public int? DeactivatedAtUnix { get; set; }

    /// <value>Why this number was deactivated. Null when active.</value>
    [JsonPropertyName("deactivation_reason")]
    public ReceptionPhoneAssignmentDeactivationReason? DeactivationReason { get; set; }

    /// <value>Null for numbers that need no paperwork. `held` while the workspace's own application is under review, `approved` once it passed and the number is fully usable.</value>
    [JsonPropertyName("regulatory_status")]
    public ReceptionPhoneRegulatoryStatus? RegulatoryStatus { get; set; }

    /// <value>The regulated number type this number was issued as. Null for numbers that need no paperwork.</value>
    [JsonPropertyName("regulatory_number_type")]
    public ApplicationNumberType? RegulatoryNumberType { get; set; }

    /// <value>ISO country the regulated number was issued in. Null for numbers that need no paperwork.</value>
    [JsonPropertyName("regulatory_country")]
    public string? RegulatoryCountry { get; set; }

    /// <value>The phone number assignment's ID.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Unix timestamp (seconds since epoch)</value>
    [JsonPropertyName("created_at_unix")]
    public int? CreatedAtUnix { get; set; }

    /// <value>Unix timestamp (seconds since epoch)</value>
    [JsonPropertyName("updated_at_unix")]
    public int? UpdatedAtUnix { get; set; }

    /// <value>Whether the number is active; false during the 14 days before a deactivated number is released.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

    /// <value>Whether inbound calls from the public may reach the receptionist.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("accepts_public_calls")]
    public bool? AcceptsPublicCalls { get; set; }

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
    public virtual bool Equals(ReceptionPhoneAssignment? other)
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
            && ValueEquality.AreEqual(PhoneNumber, other.PhoneNumber)
            && ValueEquality.AreEqual(IsByo, other.IsByo)
            && ValueEquality.AreEqual(Provider, other.Provider)
            && ValueEquality.AreEqual(NanpAreaCode, other.NanpAreaCode)
            && ValueEquality.AreEqual(CustomerFacingAgentId, other.CustomerFacingAgentId)
            && ValueEquality.AreEqual(DeactivatedAtUnix, other.DeactivatedAtUnix)
            && ValueEquality.AreEqual(DeactivationReason, other.DeactivationReason)
            && ValueEquality.AreEqual(RegulatoryStatus, other.RegulatoryStatus)
            && ValueEquality.AreEqual(RegulatoryNumberType, other.RegulatoryNumberType)
            && ValueEquality.AreEqual(RegulatoryCountry, other.RegulatoryCountry)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(UpdatedAtUnix, other.UpdatedAtUnix)
            && ValueEquality.AreEqual(IsActive, other.IsActive)
            && ValueEquality.AreEqual(AcceptsPublicCalls, other.AcceptsPublicCalls)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsByo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Provider);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NanpAreaCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomerFacingAgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeactivatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeactivationReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RegulatoryStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RegulatoryNumberType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RegulatoryCountry);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsActive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AcceptsPublicCalls);
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
