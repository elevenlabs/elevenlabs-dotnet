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
public record SentimentAggregate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("scored_conversation_count")]
    public required int ScoredConversationCount { get; set; }

    [JsonPropertyName("positive_count")]
    public required int PositiveCount { get; set; }

    [JsonPropertyName("neutral_count")]
    public required int NeutralCount { get; set; }

    [JsonPropertyName("negative_count")]
    public required int NegativeCount { get; set; }

    [JsonPropertyName("average_sentiment_score")]
    public double? AverageSentimentScore { get; set; }

    [JsonPropertyName("average_frustration_score")]
    public double? AverageFrustrationScore { get; set; }

    [JsonPropertyName("recent_scored_conversation_count")]
    public required int RecentScoredConversationCount { get; set; }

    [JsonPropertyName("recent_positive_count")]
    public required int RecentPositiveCount { get; set; }

    [JsonPropertyName("recent_neutral_count")]
    public required int RecentNeutralCount { get; set; }

    [JsonPropertyName("recent_negative_count")]
    public required int RecentNegativeCount { get; set; }

    [JsonPropertyName("recent_average_sentiment_score")]
    public double? RecentAverageSentimentScore { get; set; }

    [JsonPropertyName("recent_average_frustration_score")]
    public double? RecentAverageFrustrationScore { get; set; }

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
    public virtual bool Equals(SentimentAggregate? other)
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
            && ValueEquality.AreEqual(ScoredConversationCount, other.ScoredConversationCount)
            && ValueEquality.AreEqual(PositiveCount, other.PositiveCount)
            && ValueEquality.AreEqual(NeutralCount, other.NeutralCount)
            && ValueEquality.AreEqual(NegativeCount, other.NegativeCount)
            && ValueEquality.AreEqual(AverageSentimentScore, other.AverageSentimentScore)
            && ValueEquality.AreEqual(AverageFrustrationScore, other.AverageFrustrationScore)
            && ValueEquality.AreEqual(
                RecentScoredConversationCount,
                other.RecentScoredConversationCount
            )
            && ValueEquality.AreEqual(RecentPositiveCount, other.RecentPositiveCount)
            && ValueEquality.AreEqual(RecentNeutralCount, other.RecentNeutralCount)
            && ValueEquality.AreEqual(RecentNegativeCount, other.RecentNegativeCount)
            && ValueEquality.AreEqual(
                RecentAverageSentimentScore,
                other.RecentAverageSentimentScore
            )
            && ValueEquality.AreEqual(
                RecentAverageFrustrationScore,
                other.RecentAverageFrustrationScore
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScoredConversationCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PositiveCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NeutralCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NegativeCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AverageSentimentScore);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AverageFrustrationScore);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecentScoredConversationCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecentPositiveCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecentNeutralCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecentNegativeCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecentAverageSentimentScore);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecentAverageFrustrationScore);
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
