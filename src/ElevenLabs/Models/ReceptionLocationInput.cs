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

/// <summary>A single business location stored inline in agent info.</summary>
[Serializable]
public record ReceptionLocationInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("operating_hours")]
    public WorkingHours? OperatingHours { get; set; }

    [JsonPropertyName("customer_facing_name")]
    public string? CustomerFacingName { get; set; }

    /// <value>Maximum number of appointments that may overlap at this location at a single instant. Only enforced while the booking page setting concurrent_limit_enabled is on.</value>
    [JsonPropertyName("max_concurrent_appointments")]
    public int? MaxConcurrentAppointments { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Unix timestamp when this location was deactivated. None when active.</value>
    [JsonPropertyName("deactivated_at_unix")]
    public int? DeactivatedAtUnix { get; set; }

    /// <value>Why this location was deactivated. None when active.</value>
    [JsonPropertyName("deactivation_reason")]
    public ReceptionLocationDeactivationReason? DeactivationReason { get; set; }

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
    public virtual bool Equals(ReceptionLocationInput? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Address, other.Address)
            && ValueEquality.AreEqual(Notes, other.Notes)
            && ValueEquality.AreEqual(OperatingHours, other.OperatingHours)
            && ValueEquality.AreEqual(CustomerFacingName, other.CustomerFacingName)
            && ValueEquality.AreEqual(MaxConcurrentAppointments, other.MaxConcurrentAppointments)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(DeactivatedAtUnix, other.DeactivatedAtUnix)
            && ValueEquality.AreEqual(DeactivationReason, other.DeactivationReason)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Address);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Notes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OperatingHours);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomerFacingName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxConcurrentAppointments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeactivatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeactivationReason);
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
