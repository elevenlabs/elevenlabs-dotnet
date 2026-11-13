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
public record WorkflowOverrideAgentNodeModelInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public WorkflowOverrideAgentNodeModelInputType? Type { get; set; }

    [JsonPropertyName("position")]
    public PositionInput? Position { get; set; }

    /// <value>The ids of outgoing edges in the order they should be evaluated.</value>
    [JsonPropertyName("edge_order")]
    public IEnumerable<string>? EdgeOrder { get; set; }

    [JsonPropertyName("conversation_config")]
    public ConversationalConfigApiModelWorkflowOverrideInput? ConversationConfig { get; set; }

    /// <value>Specific goal for this subagent. It will be added to the system prompt and can be used to further refine the agent's behavior in this specific context.</value>
    [JsonPropertyName("additional_prompt")]
    public string? AdditionalPrompt { get; set; }

    /// <value>Additional knowledge base documents that the subagent has access to. These will be used in addition to the main agent's documents.</value>
    [JsonPropertyName("additional_knowledge_base")]
    public IEnumerable<KnowledgeBaseLocator>? AdditionalKnowledgeBase { get; set; }

    /// <value>IDs of additional tools that the subagent has access to. These will be used in addition to the main agent's tools.</value>
    [JsonPropertyName("additional_tool_ids")]
    public IEnumerable<string>? AdditionalToolIds { get; set; }

    /// <value>Human-readable label for the node used throughout the UI.</value>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("entry_behavior")]
    public EntryBehavior? EntryBehavior { get; set; }

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
    public virtual bool Equals(WorkflowOverrideAgentNodeModelInput? other)
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
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(Position, other.Position)
            && ValueEquality.AreEqual(EdgeOrder, other.EdgeOrder)
            && ValueEquality.AreEqual(ConversationConfig, other.ConversationConfig)
            && ValueEquality.AreEqual(AdditionalPrompt, other.AdditionalPrompt)
            && ValueEquality.AreEqual(AdditionalKnowledgeBase, other.AdditionalKnowledgeBase)
            && ValueEquality.AreEqual(AdditionalToolIds, other.AdditionalToolIds)
            && ValueEquality.AreEqual(Label, other.Label)
            && ValueEquality.AreEqual(EntryBehavior, other.EntryBehavior)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Position);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EdgeOrder);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalPrompt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalKnowledgeBase);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalToolIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Label);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EntryBehavior);
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
