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
public record ConversationInitiationClientDataInternal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("conversation_config_override")]
    public ConversationConfigClientOverrideOutput? ConversationConfigOverride { get; set; }

    [JsonPropertyName("custom_llm_extra_body")]
    public Dictionary<string, object?>? CustomLlmExtraBody { get; set; }

    /// <value>ID of the end user participating in this conversation (for agent owner's user identification)</value>
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    /// <value>Information about the source of conversation initiation</value>
    [JsonPropertyName("source_info")]
    public ConversationInitiationSourceInfo? SourceInfo { get; set; }

    /// <value>ID of the agent branch to use for this conversation</value>
    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>Environment to use for resolving environment variables</value>
    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    /// <value>If set, start the workflow at this node id instead of the default entry</value>
    [JsonPropertyName("starting_workflow_node_id")]
    public string? StartingWorkflowNodeId { get; set; }

    /// <value>If set, only these procedures are available to the starting agent. Each ID must be attached to that agent; unknown IDs fail conversation start. An empty list disables all of that agent's procedures. Not applied after an agent transfer. Requires enable_procedure_ids_from_client.</value>
    [JsonPropertyName("procedure_ids")]
    public IEnumerable<string>? ProcedureIds { get; set; }

    /// <value>If set, these free-form procedures start when the conversation starts. Accepts at most five IDs. Each ID must be available after procedure_ids is applied. Unknown IDs and structured procedures fail conversation start. Requires enable_procedure_ids_from_client.</value>
    [JsonPropertyName("start_procedure_ids")]
    public IEnumerable<string>? StartProcedureIds { get; set; }

    [JsonPropertyName("dynamic_variables")]
    public Dictionary<string, object?>? DynamicVariables { get; set; }

    /// <value>Orchestrator-side config: tools are identified by resolved names.</value>
    [JsonPropertyName("tool_mock_config")]
    public OrchestratorToolMockBehaviorConfig? ToolMockConfig { get; set; }

    /// <value>Per-tool response mock overrides keyed by resolved tool name, applied ahead of the tool's shared mocks. Used for test-specific mocks.</value>
    [JsonPropertyName("tool_mock_overrides")]
    public Dictionary<
        string,
        IEnumerable<ToolResponseMockConfigOutput>
    >? ToolMockOverrides { get; set; }

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
    public virtual bool Equals(ConversationInitiationClientDataInternal? other)
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
            && ValueEquality.AreEqual(ConversationConfigOverride, other.ConversationConfigOverride)
            && ValueEquality.AreEqual(CustomLlmExtraBody, other.CustomLlmExtraBody)
            && ValueEquality.AreEqual(UserId, other.UserId)
            && ValueEquality.AreEqual(SourceInfo, other.SourceInfo)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(StartingWorkflowNodeId, other.StartingWorkflowNodeId)
            && ValueEquality.AreEqual(ProcedureIds, other.ProcedureIds)
            && ValueEquality.AreEqual(StartProcedureIds, other.StartProcedureIds)
            && ValueEquality.AreEqual(DynamicVariables, other.DynamicVariables)
            && ValueEquality.AreEqual(ToolMockConfig, other.ToolMockConfig)
            && ValueEquality.AreEqual(ToolMockOverrides, other.ToolMockOverrides)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationConfigOverride);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomLlmExtraBody);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartingWorkflowNodeId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProcedureIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartProcedureIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DynamicVariables);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolMockConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolMockOverrides);
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
