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
public record AgentVersionParents : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("in_branch_parent_id")]
    public string? InBranchParentId { get; set; }

    [JsonPropertyName("out_of_branch_parent_id")]
    public string? OutOfBranchParentId { get; set; }

    [JsonPropertyName("merged_into_branch_id")]
    public string? MergedIntoBranchId { get; set; }

    [JsonPropertyName("merged_from_branch_id")]
    public string? MergedFromBranchId { get; set; }

    [JsonPropertyName("merged_from_version_id")]
    public string? MergedFromVersionId { get; set; }

    [JsonPropertyName("rebased_from_version_id")]
    public string? RebasedFromVersionId { get; set; }

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
    public virtual bool Equals(AgentVersionParents? other)
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
            && ValueEquality.AreEqual(InBranchParentId, other.InBranchParentId)
            && ValueEquality.AreEqual(OutOfBranchParentId, other.OutOfBranchParentId)
            && ValueEquality.AreEqual(MergedIntoBranchId, other.MergedIntoBranchId)
            && ValueEquality.AreEqual(MergedFromBranchId, other.MergedFromBranchId)
            && ValueEquality.AreEqual(MergedFromVersionId, other.MergedFromVersionId)
            && ValueEquality.AreEqual(RebasedFromVersionId, other.RebasedFromVersionId)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InBranchParentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OutOfBranchParentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MergedIntoBranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MergedFromBranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MergedFromVersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RebasedFromVersionId);
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
