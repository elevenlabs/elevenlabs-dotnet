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
public record ToolExecutionResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the tool that was executed</value>
    [JsonPropertyName("tool_id")]
    public required string ToolId { get; set; }

    /// <value>The request/call ID associated with this tool execution</value>
    [JsonPropertyName("tool_request_id")]
    public required string ToolRequestId { get; set; }

    /// <value>The ID of the conversation where the tool was executed</value>
    [JsonPropertyName("conversation_id")]
    public required string ConversationId { get; set; }

    /// <value>The ID of the agent that ran the tool</value>
    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    /// <value>The branch ID if the agent has branches</value>
    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>Unix timestamp when the tool was executed</value>
    [JsonPropertyName("timestamp")]
    public required double Timestamp { get; set; }

    /// <value>How long the tool execution took</value>
    [JsonPropertyName("latency_secs")]
    public required double LatencySecs { get; set; }

    /// <value>Whether the tool execution failed</value>
    [JsonPropertyName("is_error")]
    public bool? IsError { get; set; }

    /// <value>LLM-extracted parameters sent to the tool (JSON string)</value>
    [JsonPropertyName("request_payload")]
    public string? RequestPayload { get; set; }

    /// <value>Response returned by the tool</value>
    [JsonPropertyName("response_payload")]
    public string? ResponsePayload { get; set; }

    /// <value>Error message if the tool execution failed</value>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    /// <value>Error category (internal, customer_config, customer_auth, external_server, external_client, client_timeout, unknown)</value>
    [JsonPropertyName("error_type")]
    public string? ErrorType { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("tool_call_details")]
    public ToolExecutionResponseModelToolCallDetails? ToolCallDetails { get; set; }

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
    public virtual bool Equals(ToolExecutionResponseModel? other)
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
            && ValueEquality.AreEqual(ToolId, other.ToolId)
            && ValueEquality.AreEqual(ToolRequestId, other.ToolRequestId)
            && ValueEquality.AreEqual(ConversationId, other.ConversationId)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(Timestamp, other.Timestamp)
            && ValueEquality.AreEqual(LatencySecs, other.LatencySecs)
            && ValueEquality.AreEqual(IsError, other.IsError)
            && ValueEquality.AreEqual(RequestPayload, other.RequestPayload)
            && ValueEquality.AreEqual(ResponsePayload, other.ResponsePayload)
            && ValueEquality.AreEqual(ErrorMessage, other.ErrorMessage)
            && ValueEquality.AreEqual(ErrorType, other.ErrorType)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(ToolCallDetails, other.ToolCallDetails)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolRequestId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Timestamp);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LatencySecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsError);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestPayload);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponsePayload);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ErrorMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ErrorType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallDetails);
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
