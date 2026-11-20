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

/// <summary>The business profile, with the current time in the business's timezone.</summary>
[Serializable]
public record ReceptionAgentInfoResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Name of the business.</value>
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; set; }

    /// <value>ISO 3166-1 alpha-2 country code where the business is based (e.g. 'US', 'PL', 'DE').</value>
    [JsonPropertyName("business_country")]
    public string? BusinessCountry { get; set; }

    /// <value>What the business does, given to the receptionist.</value>
    [JsonPropertyName("business_description")]
    public string? BusinessDescription { get; set; }

    /// <value>IANA timezone of the business.</value>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <value>Currency code for all prices (ISO 4217)</value>
    [JsonPropertyName("currency")]
    public ReceptionAgentInfoResponseCurrency? Currency { get; set; }

    [JsonPropertyName("operating_hours")]
    public WorkingHours? OperatingHours { get; set; }

    /// <value>Ambient sound played while any receptionist runs a tool (e.g. checking availability or looking up a client), filling the silence callers would otherwise hear. One sound for the whole workspace, because custom webhook and MCP tools are shared by every receptionist. Off when null.</value>
    [JsonPropertyName("tool_call_sound")]
    public ToolCallSoundType? ToolCallSound { get; set; }

    /// <value>ID of the business profile.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>When the business profile was created, as a Unix timestamp in seconds.</value>
    [JsonPropertyName("created_at_unix")]
    public required int CreatedAtUnix { get; set; }

    /// <value>When the business profile was last updated, as a Unix timestamp in seconds.</value>
    [JsonPropertyName("updated_at_unix")]
    public required int UpdatedAtUnix { get; set; }

    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("workspace_now")]
    public WorkspaceNow? WorkspaceNow { get; set; }

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
    public virtual bool Equals(ReceptionAgentInfoResponse? other)
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
            && ValueEquality.AreEqual(BusinessName, other.BusinessName)
            && ValueEquality.AreEqual(BusinessCountry, other.BusinessCountry)
            && ValueEquality.AreEqual(BusinessDescription, other.BusinessDescription)
            && ValueEquality.AreEqual(Timezone, other.Timezone)
            && ValueEquality.AreEqual(Currency, other.Currency)
            && ValueEquality.AreEqual(OperatingHours, other.OperatingHours)
            && ValueEquality.AreEqual(ToolCallSound, other.ToolCallSound)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(UpdatedAtUnix, other.UpdatedAtUnix)
            && ValueEquality.AreEqual(WorkspaceNow, other.WorkspaceNow)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BusinessName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BusinessCountry);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BusinessDescription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Timezone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Currency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OperatingHours);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallSound);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WorkspaceNow);
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
