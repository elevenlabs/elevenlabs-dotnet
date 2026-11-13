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

/// <summary>Single custom guardrail configuration</summary>
[Serializable]
public record CustomGuardrailConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("is_enabled")]
    public bool? IsEnabled { get; set; }

    /// <value>User-facing name for this guardrail</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>Instruction describing what to block, e.g. 'don't talk about politics'</value>
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }

    [JsonPropertyName("execution_mode")]
    public GuardrailExecutionMode? ExecutionMode { get; set; }

    /// <value>LLM model to use for custom guardrail evaluation</value>
    [JsonPropertyName("model")]
    public CustomGuardrailConfigModel? Model { get; set; }

    /// <value>How much recent history the guardrail sees before the reply it evaluates, counted in user messages (the agent replies between them are included too). The guardrail always gets a single &lt;conversation_history&gt; transcript ending in the evaluated reply, marked 'AGENT [current reply]:'. 0 (default) adds no prior history (just that line); 1 adds the latest user message onward.</value>
    [JsonPropertyName("history_message_count")]
    public int? HistoryMessageCount { get; set; }

    [JsonPropertyName("trigger_action")]
    public CustomGuardrailConfigTriggerAction? TriggerAction { get; set; }

    /// <value>Evaluate once against the complete non-TTS response instead of cumulative partials. Requires blocking mode.</value>
    [JsonPropertyName("evaluate_full_response_only")]
    public bool? EvaluateFullResponseOnly { get; set; }

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
    public virtual bool Equals(CustomGuardrailConfig? other)
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
            && ValueEquality.AreEqual(IsEnabled, other.IsEnabled)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Prompt, other.Prompt)
            && ValueEquality.AreEqual(ExecutionMode, other.ExecutionMode)
            && ValueEquality.AreEqual(Model, other.Model)
            && ValueEquality.AreEqual(HistoryMessageCount, other.HistoryMessageCount)
            && ValueEquality.AreEqual(TriggerAction, other.TriggerAction)
            && ValueEquality.AreEqual(EvaluateFullResponseOnly, other.EvaluateFullResponseOnly)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Prompt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExecutionMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Model);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HistoryMessageCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TriggerAction);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EvaluateFullResponseOnly);
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
