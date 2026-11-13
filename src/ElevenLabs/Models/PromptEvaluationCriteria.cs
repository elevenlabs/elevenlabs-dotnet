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

/// <summary>An evaluation using the transcript and a prompt for a yes/no achieved answer</summary>
[Serializable]
public record PromptEvaluationCriteria : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The unique identifier for the evaluation criteria</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The type of evaluation criteria</value>
    [JsonPropertyName("type")]
    public PromptEvaluationCriteriaType? Type { get; set; }

    /// <value>The prompt that the agent should use to evaluate the conversation</value>
    [JsonPropertyName("conversation_goal_prompt")]
    public required string ConversationGoalPrompt { get; set; }

    /// <value>When evaluating the prompt, should the agent's knowledge base be used.</value>
    [JsonPropertyName("use_knowledge_base")]
    public bool? UseKnowledgeBase { get; set; }

    [JsonPropertyName("scope")]
    public AnalysisScope? Scope { get; set; }

    /// <value>LLM model to use for this evaluation criteria. If not set, uses agent's analysis_llm default.</value>
    [JsonPropertyName("llm")]
    public Llm? Llm { get; set; }

    [JsonPropertyName("scoring_mode")]
    public CriteriaScoringMode? ScoringMode { get; set; }

    /// <value>Maximum value of the numeric score scale (minimum is always 0). Only used when scoring_mode is 'numeric_uniform'.</value>
    [JsonPropertyName("max_score")]
    public int? MaxScore { get; set; }

    /// <value>Optional free-text instructions describing how to assign values on the numeric scale. Only used when scoring_mode is 'numeric_uniform'.</value>
    [JsonPropertyName("score_instructions")]
    public string? ScoreInstructions { get; set; }

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
    public virtual bool Equals(PromptEvaluationCriteria? other)
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
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(ConversationGoalPrompt, other.ConversationGoalPrompt)
            && ValueEquality.AreEqual(UseKnowledgeBase, other.UseKnowledgeBase)
            && ValueEquality.AreEqual(Scope, other.Scope)
            && ValueEquality.AreEqual(Llm, other.Llm)
            && ValueEquality.AreEqual(ScoringMode, other.ScoringMode)
            && ValueEquality.AreEqual(MaxScore, other.MaxScore)
            && ValueEquality.AreEqual(ScoreInstructions, other.ScoreInstructions)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationGoalPrompt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseKnowledgeBase);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Scope);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Llm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScoringMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxScore);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScoreInstructions);
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
