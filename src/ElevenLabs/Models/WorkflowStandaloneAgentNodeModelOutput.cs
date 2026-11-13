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
public record WorkflowStandaloneAgentNodeModelOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public required WorkflowStandaloneAgentNodeModelOutputType Type { get; set; }

    [JsonPropertyName("position")]
    public required PositionOutput Position { get; set; }

    /// <value>The ids of outgoing edges in the order they should be evaluated.</value>
    [JsonPropertyName("edge_order")]
    public IEnumerable<string> EdgeOrder { get; set; } = new List<string>();

    /// <value>The ID of the agent to transfer the conversation to. None means transfer within the current agent.</value>
    [JsonPropertyName("agent_id")]
    public string? AgentId { get; set; }

    /// <value>Optional branch ID for the target agent. None follows the target agent's traffic deployment, or uses its main branch when node_id is set.</value>
    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>Optional target node ID in the destination agent's workflow. When set, the transfer starts at this node instead of the default entry node.</value>
    [JsonPropertyName("node_id")]
    public string? NodeId { get; set; }

    /// <value>Artificial delay in milliseconds applied before transferring the conversation.</value>
    [JsonPropertyName("delay_ms")]
    public required int DelayMs { get; set; }

    /// <value>Optional message sent to the user before the transfer is initiated.</value>
    [JsonPropertyName("transfer_message")]
    public string? TransferMessage { get; set; }

    /// <value>Whether to enable the transferred agent to send its configured first message after the transfer.</value>
    [JsonPropertyName("enable_transferred_agent_first_message")]
    public required bool EnableTransferredAgentFirstMessage { get; set; }

    /// <value>Defines whether TTS client overrides should be carried over to the transferred agent.</value>
    [JsonPropertyName("preserve_client_tts_overrides")]
    public required bool PreserveClientTtsOverrides { get; set; }

    /// <value>Defines whether the base voice, TTS model and voice settings should be carried over to the transferred agent.</value>
    [JsonPropertyName("preserve_voice_settings")]
    public required bool PreserveVoiceSettings { get; set; }

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
    public virtual bool Equals(WorkflowStandaloneAgentNodeModelOutput? other)
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
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(NodeId, other.NodeId)
            && ValueEquality.AreEqual(DelayMs, other.DelayMs)
            && ValueEquality.AreEqual(TransferMessage, other.TransferMessage)
            && ValueEquality.AreEqual(
                EnableTransferredAgentFirstMessage,
                other.EnableTransferredAgentFirstMessage
            )
            && ValueEquality.AreEqual(PreserveClientTtsOverrides, other.PreserveClientTtsOverrides)
            && ValueEquality.AreEqual(PreserveVoiceSettings, other.PreserveVoiceSettings)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NodeId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DelayMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TransferMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableTransferredAgentFirstMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreserveClientTtsOverrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreserveVoiceSettings);
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
