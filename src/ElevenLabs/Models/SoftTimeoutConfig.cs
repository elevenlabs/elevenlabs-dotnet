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

/// <summary>Configuration for soft timeout functionality during LLM response generation.</summary>
[Serializable]
public record SoftTimeoutConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Time in seconds before showing the predefined message while waiting for LLM response. Set to -1 to disable.</value>
    [JsonPropertyName("timeout_seconds")]
    public double? TimeoutSeconds { get; set; }

    /// <value>Message to show when the first soft timeout is reached while waiting for LLM response. Supports dynamic variables (e.g., {{system__time}}, {{custom_variable}}).</value>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <value>Extra static filler messages for subsequent soft timeouts in the same LLM generation. The first timeout uses `message`. If fewer messages are configured than `max_soft_timeouts_per_generation`, the last configured message is repeated; otherwise a built-in filler is used.</value>
    [JsonPropertyName("additional_soft_timeout_messages")]
    public IEnumerable<string>? AdditionalSoftTimeoutMessages { get; set; }

    /// <value>If enabled, the soft timeout message will be generated dynamically instead of using the static message.</value>
    [JsonPropertyName("use_llm_generated_message")]
    public bool? UseLlmGeneratedMessage { get; set; }

    /// <value>If enabled, shuffle the order of static soft timeout messages once at the start of each turn. Only applies when use_llm_generated_message is false.</value>
    [JsonPropertyName("randomize_fillers")]
    public bool? RandomizeFillers { get; set; }

    /// <value>Maximum filler messages while waiting for a single LLM response. Fires every timeout_seconds until the LLM streams content or this limit is reached.</value>
    [JsonPropertyName("max_soft_timeouts_per_generation")]
    public int? MaxSoftTimeoutsPerGeneration { get; set; }

    /// <value>Custom prompt for generating the soft timeout filler message when use_llm_generated_message is enabled. Recent conversation context is provided as a separate user message. If not set, the default prompt will be used. Supports dynamic variables (e.g., {{system__time}}, {{custom_variable}}).</value>
    [JsonPropertyName("llm_generated_message_prompt_override")]
    public string? LlmGeneratedMessagePromptOverride { get; set; }

    /// <value>When true, soft timeout fillers are suppressed until the conversation has at least one real user message. Prevents fillers during the agent's opening turn (e.g. workflow generate-immediately / tool calls before the user speaks).</value>
    [JsonPropertyName("disable_until_first_user_message")]
    public bool? DisableUntilFirstUserMessage { get; set; }

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
    public virtual bool Equals(SoftTimeoutConfig? other)
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
            && ValueEquality.AreEqual(TimeoutSeconds, other.TimeoutSeconds)
            && ValueEquality.AreEqual(Message, other.Message)
            && ValueEquality.AreEqual(
                AdditionalSoftTimeoutMessages,
                other.AdditionalSoftTimeoutMessages
            )
            && ValueEquality.AreEqual(UseLlmGeneratedMessage, other.UseLlmGeneratedMessage)
            && ValueEquality.AreEqual(RandomizeFillers, other.RandomizeFillers)
            && ValueEquality.AreEqual(
                MaxSoftTimeoutsPerGeneration,
                other.MaxSoftTimeoutsPerGeneration
            )
            && ValueEquality.AreEqual(
                LlmGeneratedMessagePromptOverride,
                other.LlmGeneratedMessagePromptOverride
            )
            && ValueEquality.AreEqual(
                DisableUntilFirstUserMessage,
                other.DisableUntilFirstUserMessage
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TimeoutSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Message);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalSoftTimeoutMessages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseLlmGeneratedMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RandomizeFillers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxSoftTimeoutsPerGeneration);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LlmGeneratedMessagePromptOverride);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableUntilFirstUserMessage);
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
