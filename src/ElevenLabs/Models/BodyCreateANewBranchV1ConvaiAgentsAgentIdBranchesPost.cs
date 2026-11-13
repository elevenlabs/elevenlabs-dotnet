using ElevenLabs;
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

namespace ElevenLabs.Agents;

[Serializable]
public record BodyCreateANewBranchV1ConvaiAgentsAgentIdBranchesPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the version to branch from</value>
    [JsonPropertyName("parent_version_id")]
    public required string ParentVersionId { get; set; }

    /// <value>Name of the branch. It is unique within the agent.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>Description for the branch</value>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <value>Changes to apply to conversation config</value>
    [JsonPropertyName("conversation_config")]
    public Dictionary<string, object?>? ConversationConfig { get; set; }

    /// <value>Changes to apply to platform settings</value>
    [JsonPropertyName("platform_settings")]
    public Dictionary<string, object?>? PlatformSettings { get; set; }

    /// <value>Updated workflow definition</value>
    [JsonPropertyName("workflow")]
    public AgentWorkflowRequestModel? Workflow { get; set; }

    /// <value>When true, the new branch uses the caller's draft procedure set instead of the branch tip. Requires parent_version_id to be the branch tip.</value>
    [JsonPropertyName("include_draft")]
    public bool? IncludeDraft { get; set; }

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
    public virtual bool Equals(BodyCreateANewBranchV1ConvaiAgentsAgentIdBranchesPost? other)
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
            && ValueEquality.AreEqual(ParentVersionId, other.ParentVersionId)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(ConversationConfig, other.ConversationConfig)
            && ValueEquality.AreEqual(PlatformSettings, other.PlatformSettings)
            && ValueEquality.AreEqual(Workflow, other.Workflow)
            && ValueEquality.AreEqual(IncludeDraft, other.IncludeDraft)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ParentVersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Workflow);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IncludeDraft);
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
