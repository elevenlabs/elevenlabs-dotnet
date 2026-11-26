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
using ElevenLabs.CustomerSupport;
using ElevenLabs.CustomerSupport.Requesters;
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

/// <summary>A receptionist.</summary>
[Serializable]
public record ReceptionCustomerFacingAgentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the ElevenLabs agent behind this receptionist.</value>
    [JsonPropertyName("agent_id")]
    public string? AgentId { get; set; }

    [JsonPropertyName("config")]
    public ReceptionCustomerFacingConfigOutput? Config { get; set; }

    /// <value>Unix timestamp when this receptionist was deactivated. None when active.</value>
    [JsonPropertyName("deactivated_at_unix")]
    public int? DeactivatedAtUnix { get; set; }

    /// <value>Why this receptionist was deactivated. None when active.</value>
    [JsonPropertyName("deactivation_reason")]
    public ReceptionCustomerFacingAgentDeactivationReason? DeactivationReason { get; set; }

    /// <value>Display name of the receptionist.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>False when the receptionist's underlying agent was deleted; it cannot take calls until it is set up again.</value>
    [JsonPropertyName("agent_exists")]
    public bool? AgentExists { get; set; }

    /// <value>Whether this receptionist can configure and use transfer rules.</value>
    [JsonPropertyName("is_transfer_allowed")]
    public bool? IsTransferAllowed { get; set; }

    /// <value>How the website widget looks. Null when the agent is missing. Unset labels follow the receptionist's language.</value>
    [JsonPropertyName("widget")]
    public ReceptionWidgetAppearance? Widget { get; set; }

    /// <value>Whether the receptionist is active. Inactive receptionists take no live calls.</value>
    [JsonAccess(JsonAccessType.ReadOnly)]
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
    public virtual bool Equals(ReceptionCustomerFacingAgentResponse? other)
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
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(Config, other.Config)
            && ValueEquality.AreEqual(DeactivatedAtUnix, other.DeactivatedAtUnix)
            && ValueEquality.AreEqual(DeactivationReason, other.DeactivationReason)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(AgentExists, other.AgentExists)
            && ValueEquality.AreEqual(IsTransferAllowed, other.IsTransferAllowed)
            && ValueEquality.AreEqual(Widget, other.Widget)
            && ValueEquality.AreEqual(IsActive, other.IsActive)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Config);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeactivatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeactivationReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentExists);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsTransferAllowed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Widget);
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
