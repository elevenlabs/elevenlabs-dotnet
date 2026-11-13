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
public record AgentTopicResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("topic_id")]
    public required string TopicId { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("conversation_count")]
    public required int ConversationCount { get; set; }

    [JsonPropertyName("parent_topic_id")]
    public string? ParentTopicId { get; set; }

    [JsonPropertyName("x_2d")]
    public double? X2D { get; set; }

    [JsonPropertyName("y_2d")]
    public double? Y2D { get; set; }

    [JsonPropertyName("metrics")]
    public TopicMetricsAggregate? Metrics { get; set; }

    /// <value>Success rate across the topic's evaluation criteria, weighted by scored conversations. Returned regardless of include_evaluation_criteria.</value>
    [JsonPropertyName("success_rate")]
    public double? SuccessRate { get; set; }

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
    public virtual bool Equals(AgentTopicResponseModel? other)
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
            && ValueEquality.AreEqual(TopicId, other.TopicId)
            && ValueEquality.AreEqual(Label, other.Label)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(ConversationCount, other.ConversationCount)
            && ValueEquality.AreEqual(ParentTopicId, other.ParentTopicId)
            && ValueEquality.AreEqual(X2D, other.X2D)
            && ValueEquality.AreEqual(Y2D, other.Y2D)
            && ValueEquality.AreEqual(Metrics, other.Metrics)
            && ValueEquality.AreEqual(SuccessRate, other.SuccessRate)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TopicId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Label);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ParentTopicId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(X2D);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Y2D);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Metrics);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SuccessRate);
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
