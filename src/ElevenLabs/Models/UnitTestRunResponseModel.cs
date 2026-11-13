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
public record UnitTestRunResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("test_run_id")]
    public required string TestRunId { get; set; }

    [JsonPropertyName("test_info")]
    public UnitTestRunResponseModelTestInfo? TestInfo { get; set; }

    [JsonPropertyName("test_invocation_id")]
    public required string TestInvocationId { get; set; }

    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    [JsonPropertyName("version_id")]
    public string? VersionId { get; set; }

    [JsonPropertyName("ran_against_draft")]
    public bool? RanAgainstDraft { get; set; }

    [JsonPropertyName("workflow_node_id")]
    public string? WorkflowNodeId { get; set; }

    [JsonPropertyName("status")]
    public required TestRunStatus Status { get; set; }

    [JsonPropertyName("agent_responses")]
    public IEnumerable<ConversationHistoryTranscriptCommonModelOutput>? AgentResponses { get; set; }

    /// <value>Guardrails observed during this run, including blocks before an agent response.</value>
    [JsonPropertyName("triggered_guardrails")]
    public IEnumerable<TriggeredGuardrailCommonModel>? TriggeredGuardrails { get; set; }

    [JsonPropertyName("test_id")]
    public required string TestId { get; set; }

    [JsonPropertyName("test_name")]
    public string? TestName { get; set; }

    [JsonPropertyName("condition_result")]
    public TestConditionResultCommonModel? ConditionResult { get; set; }

    [JsonPropertyName("last_updated_at_unix")]
    public int? LastUpdatedAtUnix { get; set; }

    [JsonPropertyName("metadata")]
    public TestRunMetadata? Metadata { get; set; }

    [JsonPropertyName("root_folder_id")]
    public string? RootFolderId { get; set; }

    [JsonPropertyName("root_folder_name")]
    public string? RootFolderName { get; set; }

    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    /// <value>Credits billed for this test run. None for runs created before cost tracking.</value>
    [JsonPropertyName("credits_used")]
    public int? CreditsUsed { get; set; }

    /// <value>Finalized billing and provider-usage breakdown for this test run.</value>
    [JsonPropertyName("charging")]
    public ConversationChargingCommonModel? Charging { get; set; }

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
    public virtual bool Equals(UnitTestRunResponseModel? other)
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
            && ValueEquality.AreEqual(TestRunId, other.TestRunId)
            && ValueEquality.AreEqual(TestInfo, other.TestInfo)
            && ValueEquality.AreEqual(TestInvocationId, other.TestInvocationId)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(VersionId, other.VersionId)
            && ValueEquality.AreEqual(RanAgainstDraft, other.RanAgainstDraft)
            && ValueEquality.AreEqual(WorkflowNodeId, other.WorkflowNodeId)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(AgentResponses, other.AgentResponses)
            && ValueEquality.AreEqual(TriggeredGuardrails, other.TriggeredGuardrails)
            && ValueEquality.AreEqual(TestId, other.TestId)
            && ValueEquality.AreEqual(TestName, other.TestName)
            && ValueEquality.AreEqual(ConditionResult, other.ConditionResult)
            && ValueEquality.AreEqual(LastUpdatedAtUnix, other.LastUpdatedAtUnix)
            && ValueEquality.AreEqual(Metadata, other.Metadata)
            && ValueEquality.AreEqual(RootFolderId, other.RootFolderId)
            && ValueEquality.AreEqual(RootFolderName, other.RootFolderName)
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(CreditsUsed, other.CreditsUsed)
            && ValueEquality.AreEqual(Charging, other.Charging)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TestRunId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TestInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TestInvocationId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RanAgainstDraft);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WorkflowNodeId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentResponses);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TriggeredGuardrails);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TestId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TestName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConditionResult);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastUpdatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Metadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RootFolderId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RootFolderName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreditsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Charging);
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
