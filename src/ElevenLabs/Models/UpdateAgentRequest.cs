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

[Serializable]
public record UpdateAgentRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("conversation_config")]
    public ConversationalConfig? ConversationConfig { get; set; }

    [JsonPropertyName("platform_settings")]
    public AgentPlatformSettingsRequestModel? PlatformSettings { get; set; }

    [JsonPropertyName("workflow")]
    public AgentWorkflowRequestModel? Workflow { get; set; }

    /// <value>A name to make the agent easier to find</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>Tags to help classify and filter the agent</value>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <value>Description for this version when publishing changes (only applicable for versioned agents)</value>
    [JsonPropertyName("version_description")]
    public string? VersionDescription { get; set; }

    /// <value>Procedure versions to publish, keyed by procedure_id. When provided, this map replaces the procedures from the current draft or branch tip. When omitted or null, unpublished procedure edits are used if present; otherwise, the branch tip's procedures are retained. Pass an empty object to remove all procedures.</value>
    [JsonPropertyName("procedures")]
    public Dictionary<string, ProcedureVersionRef>? Procedures { get; set; }

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
    public virtual bool Equals(UpdateAgentRequest? other)
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
            && ValueEquality.AreEqual(ConversationConfig, other.ConversationConfig)
            && ValueEquality.AreEqual(PlatformSettings, other.PlatformSettings)
            && ValueEquality.AreEqual(Workflow, other.Workflow)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Tags, other.Tags)
            && ValueEquality.AreEqual(VersionDescription, other.VersionDescription)
            && ValueEquality.AreEqual(Procedures, other.Procedures)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Workflow);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VersionDescription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Procedures);
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
