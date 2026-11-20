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

/// <summary>Represents a physical resource that can be booked (rooms, equipment, vehicles).</summary>
[Serializable]
public record ReceptionAssetResource : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    /// <value>Whether the asset can be booked. Inactive assets keep their booking history.</value>
    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

    /// <value>Custom availability hours for this asset. Null means follow the assigned location's operating_hours (requires location_id).</value>
    [JsonPropertyName("available_hours")]
    public WorkingHours? AvailableHours { get; set; }

    /// <value>URL of a photo of the asset.</value>
    [JsonPropertyName("photo_url")]
    public string? PhotoUrl { get; set; }

    /// <value>Location this asset belongs to; empty means available at all locations.</value>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    [JsonPropertyName("customer_facing_name")]
    public string? CustomerFacingName { get; set; }

    /// <value>The asset's ID.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Unix timestamp (seconds since epoch)</value>
    [JsonPropertyName("created_at_unix")]
    public int? CreatedAtUnix { get; set; }

    /// <value>Unix timestamp (seconds since epoch)</value>
    [JsonPropertyName("updated_at_unix")]
    public int? UpdatedAtUnix { get; set; }

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
    public virtual bool Equals(ReceptionAssetResource? other)
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
            && ValueEquality.AreEqual(Groups, other.Groups)
            && ValueEquality.AreEqual(UngroupedRank, other.UngroupedRank)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(IsActive, other.IsActive)
            && ValueEquality.AreEqual(AvailableHours, other.AvailableHours)
            && ValueEquality.AreEqual(PhotoUrl, other.PhotoUrl)
            && ValueEquality.AreEqual(LocationId, other.LocationId)
            && ValueEquality.AreEqual(CustomerFacingName, other.CustomerFacingName)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(UpdatedAtUnix, other.UpdatedAtUnix)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Groups);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UngroupedRank);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsActive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AvailableHours);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhotoUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LocationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomerFacingName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnix);
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
