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
public record TestInvocationSummaryResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the test invocation</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>The user-provided name of the test invocation, if one was set.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>The ID of the agent this test invocation belongs to</value>
    [JsonPropertyName("agent_id")]
    public string? AgentId { get; set; }

    /// <value>The ID of the branch this test invocation was run on</value>
    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>The ID of the agent version this test invocation ran against. For draft or config-override runs this is the version those uncommitted changes were applied on top of. None only for runs recorded before this field existed.</value>
    [JsonPropertyName("version_id")]
    public string? VersionId { get; set; }

    /// <value>Whether the run included uncommitted changes (a saved draft or an ad-hoc config override) layered on top of version_id.</value>
    [JsonPropertyName("ran_against_draft")]
    public bool? RanAgainstDraft { get; set; }

    /// <value>Whether the test runs in this invocation did not all execute against the same version, which happens when a subset of runs was resubmitted after the original run. When true, version_id describes the most recent resubmit rather than every run.</value>
    [JsonPropertyName("runs_diverged_from_version")]
    public bool? RunsDivergedFromVersion { get; set; }

    /// <value>Creation time of the test invocation in unix seconds</value>
    [JsonPropertyName("created_at_unix_secs")]
    public required int CreatedAtUnixSecs { get; set; }

    /// <value>Number of test runs in this invocation</value>
    [JsonPropertyName("test_run_count")]
    public required int TestRunCount { get; set; }

    /// <value>Number of test runs that passed</value>
    [JsonPropertyName("passed_count")]
    public required int PassedCount { get; set; }

    /// <value>Number of test runs that failed</value>
    [JsonPropertyName("failed_count")]
    public required int FailedCount { get; set; }

    /// <value>Number of test runs that are pending</value>
    [JsonPropertyName("pending_count")]
    public required int PendingCount { get; set; }

    /// <value>Number of test runs that were cancelled</value>
    [JsonPropertyName("cancelled_count")]
    public required int CancelledCount { get; set; }

    /// <value>Display title of the test invocation: the user-provided name when set, otherwise the folder name, single test name, or test count.</value>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <value>The access information of the test invocation</value>
    [JsonPropertyName("access_info")]
    public ResourceAccessInfo? AccessInfo { get; set; }

    /// <value>Number of times each test was repeated in this invocation</value>
    [JsonPropertyName("repeat_count")]
    public int? RepeatCount { get; set; }

    /// <value>Whether this test invocation was cancelled</value>
    [JsonPropertyName("cancelled")]
    public bool? Cancelled { get; set; }

    /// <value>Total credits billed across test runs in this invocation. None when no run has cost data.</value>
    [JsonPropertyName("credits_used")]
    public int? CreditsUsed { get; set; }

    /// <value>Total USD price across test runs in this invocation. None when no run has price data.</value>
    [JsonPropertyName("total_price")]
    public double? TotalPrice { get; set; }

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
    public virtual bool Equals(TestInvocationSummaryResponseModel? other)
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
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(VersionId, other.VersionId)
            && ValueEquality.AreEqual(RanAgainstDraft, other.RanAgainstDraft)
            && ValueEquality.AreEqual(RunsDivergedFromVersion, other.RunsDivergedFromVersion)
            && ValueEquality.AreEqual(CreatedAtUnixSecs, other.CreatedAtUnixSecs)
            && ValueEquality.AreEqual(TestRunCount, other.TestRunCount)
            && ValueEquality.AreEqual(PassedCount, other.PassedCount)
            && ValueEquality.AreEqual(FailedCount, other.FailedCount)
            && ValueEquality.AreEqual(PendingCount, other.PendingCount)
            && ValueEquality.AreEqual(CancelledCount, other.CancelledCount)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(AccessInfo, other.AccessInfo)
            && ValueEquality.AreEqual(RepeatCount, other.RepeatCount)
            && ValueEquality.AreEqual(Cancelled, other.Cancelled)
            && ValueEquality.AreEqual(CreditsUsed, other.CreditsUsed)
            && ValueEquality.AreEqual(TotalPrice, other.TotalPrice)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RanAgainstDraft);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RunsDivergedFromVersion);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnixSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TestRunCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PassedCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FailedCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PendingCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CancelledCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccessInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RepeatCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Cancelled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreditsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TotalPrice);
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
