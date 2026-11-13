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
public record ReviewResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("review_status")]
    public required ReviewResponseModelReviewStatus ReviewStatus { get; set; }

    [JsonPropertyName("reviewed_at_unix")]
    public required int ReviewedAtUnix { get; set; }

    [JsonPropertyName("reviewed_by")]
    public string? ReviewedBy { get; set; }

    [JsonPropertyName("reject_reasons")]
    public IEnumerable<ReviewResponseModelRejectReasonsItem>? RejectReasons { get; set; }

    [JsonPropertyName("scores_breakdown")]
    public Dictionary<string, int>? ScoresBreakdown { get; set; }

    [JsonPropertyName("rejected_details")]
    public string? RejectedDetails { get; set; }

    [JsonPropertyName("explanation")]
    public string? Explanation { get; set; }

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
    public virtual bool Equals(ReviewResponseModel? other)
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
            && ValueEquality.AreEqual(ReviewStatus, other.ReviewStatus)
            && ValueEquality.AreEqual(ReviewedAtUnix, other.ReviewedAtUnix)
            && ValueEquality.AreEqual(ReviewedBy, other.ReviewedBy)
            && ValueEquality.AreEqual(RejectReasons, other.RejectReasons)
            && ValueEquality.AreEqual(ScoresBreakdown, other.ScoresBreakdown)
            && ValueEquality.AreEqual(RejectedDetails, other.RejectedDetails)
            && ValueEquality.AreEqual(Explanation, other.Explanation)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReviewStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReviewedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReviewedBy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RejectReasons);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScoresBreakdown);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RejectedDetails);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Explanation);
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
