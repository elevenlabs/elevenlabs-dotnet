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
public record ReceptionCreateHolidayRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Display name of the closure or time off.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>Represents a calendar date as individual numeric components.</value>
    [JsonPropertyName("start_date")]
    public required DateModel StartDate { get; set; }

    /// <value>Represents a calendar date as individual numeric components.</value>
    [JsonPropertyName("end_date")]
    public required DateModel EndDate { get; set; }

    /// <value>Whether the entry closes the target for the whole range or replaces its working hours.</value>
    [JsonPropertyName("holiday_type")]
    public HolidayType? HolidayType { get; set; }

    /// <value>Replacement working hours when holiday_type is 'override'.</value>
    [JsonPropertyName("override_hours")]
    public IEnumerable<TimeRangeModel>? OverrideHours { get; set; }

    /// <value>What a time-off entry blocks: a staff member, an asset, or a location.</value>
    [JsonPropertyName("time_off_type")]
    public required TimeOffType1 TimeOffType { get; set; }

    /// <value>The staff member or asset ID; required when time_off_type is 'staff' or 'asset'.</value>
    [JsonPropertyName("resource_id")]
    public string? ResourceId { get; set; }

    /// <value>For LOCATION type: the location this closure applies to.</value>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <value>Optional note on why the closure or time off happens, up to 500 characters.</value>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

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
    public virtual bool Equals(ReceptionCreateHolidayRequest? other)
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
            && ValueEquality.AreEqual(StartDate, other.StartDate)
            && ValueEquality.AreEqual(EndDate, other.EndDate)
            && ValueEquality.AreEqual(HolidayType, other.HolidayType)
            && ValueEquality.AreEqual(OverrideHours, other.OverrideHours)
            && ValueEquality.AreEqual(TimeOffType, other.TimeOffType)
            && ValueEquality.AreEqual(ResourceId, other.ResourceId)
            && ValueEquality.AreEqual(LocationId, other.LocationId)
            && ValueEquality.AreEqual(Reason, other.Reason)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HolidayType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OverrideHours);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TimeOffType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResourceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LocationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Reason);
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
