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
public record PromptAgentApiModelOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The prompt for the agent</value>
    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    [JsonPropertyName("llm")]
    public Llm? Llm { get; set; }

    /// <value>Reasoning effort of the model. Only available for some models.</value>
    [JsonPropertyName("reasoning_effort")]
    public LlmReasoningEffort? ReasoningEffort { get; set; }

    /// <value>
    /// Request-time processing tier for a model.
    ///
    /// STANDARD: default price and throughput.
    /// FAST: pays a per-token price premium for higher throughput / lower latency.
    ///     See OpenAI's fast mode: https://openai.com/api-fast-mode/
    /// </value>
    [JsonPropertyName("service_tier")]
    public LlmServiceTier? ServiceTier { get; set; }

    /// <value>Max number of tokens used for thinking. Use 0 to turn off if supported by the model.</value>
    [JsonPropertyName("thinking_budget")]
    public int? ThinkingBudget { get; set; }

    /// <value>Enable model reasoning summaries. When disabled, we do not request summaries from provider if possible for faster TTFB. Not ZRM compatible.</value>
    [JsonPropertyName("enable_reasoning_summary")]
    public bool? EnableReasoningSummary { get; set; }

    /// <value>The temperature for the LLM. Defaults to 0. Set to null to omit the parameter from the LLM request entirely (useful for custom LLMs that reject the temperature field).</value>
    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }

    /// <value>If greater than 0, maximum number of tokens the LLM can predict</value>
    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; }

    /// <value>A list of IDs of tools used by the agent</value>
    [JsonPropertyName("tool_ids")]
    public IEnumerable<string>? ToolIds { get; set; }

    /// <value>Only applies as a conversation override, allowed whenever tool_ids may be overridden. When true, the overridden tool_ids is the full list of tools allowed in the conversation, including tools on workflow nodes. Ignored when set on the agent.</value>
    [JsonPropertyName("tool_ids_strict")]
    public bool? ToolIdsStrict { get; set; }

    /// <value>
    /// System tools a conversational agent can be given.
    ///
    /// Deliberately not named ConversationalBuiltInTools: BuiltInToolsInput and
    /// BuiltInToolsOutput are part of the public API spec and the generated SDKs.
    /// </value>
    [JsonPropertyName("built_in_tools")]
    public BuiltInToolsOutput? BuiltInTools { get; set; }

    /// <value>Enable parallel tool calling. When enabled, the agent can execute multiple tools in parallel within a single turn. Not supported by all models.</value>
    [JsonPropertyName("enable_parallel_tool_calls")]
    public bool? EnableParallelToolCalls { get; set; }

    /// <value>A list of MCP server ids to be used by the agent</value>
    [JsonPropertyName("mcp_server_ids")]
    public IEnumerable<string>? McpServerIds { get; set; }

    /// <value>A list of Native MCP server ids to be used by the agent</value>
    [JsonPropertyName("native_mcp_server_ids")]
    public IEnumerable<string>? NativeMcpServerIds { get; set; }

    /// <value>A list of knowledge bases to be used by the agent</value>
    [JsonPropertyName("knowledge_base")]
    public IEnumerable<KnowledgeBaseLocator>? KnowledgeBase { get; set; }

    /// <value>Definition for a custom LLM if LLM field is set to 'CUSTOM_LLM'</value>
    [JsonPropertyName("custom_llm")]
    public CustomLlm? CustomLlm { get; set; }

    /// <value>Whether to remove the default personality lines from the system prompt</value>
    [JsonPropertyName("ignore_default_personality")]
    public bool? IgnoreDefaultPersonality { get; set; }

    [JsonPropertyName("rag")]
    public RagConfigOutput? Rag { get; set; }

    /// <value>Timezone for displaying current time in system prompt. If set, the current time will be included in the system prompt using this timezone. Must be a valid timezone name (e.g., 'America/New_York', 'Europe/London', 'UTC'). Recommended for accurate time-aware responses; without this, the agent has no knowledge of the current date/time unless you provide it via dynamic variables or tools, which can lead to incorrect or hallucinated time references.</value>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <value>Configuration for backup LLM cascading. Can be disabled, use system defaults, or specify custom order.</value>
    [JsonPropertyName("backup_llm_config")]
    public PromptAgentApiModelOutputBackupLlmConfig? BackupLlmConfig { get; set; }

    /// <value>Time in seconds before cascading to backup LLM. Must be between 2 and 15 seconds.</value>
    [JsonPropertyName("cascade_timeout_seconds")]
    public double? CascadeTimeoutSeconds { get; set; }

    /// <value>A list of tools that the agent can use over the course of the conversation, use tool_ids instead</value>
    [JsonPropertyName("tools")]
    public IEnumerable<PromptAgentApiModelOutputToolsItem>? Tools { get; set; }

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
    public virtual bool Equals(PromptAgentApiModelOutput? other)
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
            && ValueEquality.AreEqual(Prompt, other.Prompt)
            && ValueEquality.AreEqual(Llm, other.Llm)
            && ValueEquality.AreEqual(ReasoningEffort, other.ReasoningEffort)
            && ValueEquality.AreEqual(ServiceTier, other.ServiceTier)
            && ValueEquality.AreEqual(ThinkingBudget, other.ThinkingBudget)
            && ValueEquality.AreEqual(EnableReasoningSummary, other.EnableReasoningSummary)
            && ValueEquality.AreEqual(Temperature, other.Temperature)
            && ValueEquality.AreEqual(MaxTokens, other.MaxTokens)
            && ValueEquality.AreEqual(ToolIds, other.ToolIds)
            && ValueEquality.AreEqual(ToolIdsStrict, other.ToolIdsStrict)
            && ValueEquality.AreEqual(BuiltInTools, other.BuiltInTools)
            && ValueEquality.AreEqual(EnableParallelToolCalls, other.EnableParallelToolCalls)
            && ValueEquality.AreEqual(McpServerIds, other.McpServerIds)
            && ValueEquality.AreEqual(NativeMcpServerIds, other.NativeMcpServerIds)
            && ValueEquality.AreEqual(KnowledgeBase, other.KnowledgeBase)
            && ValueEquality.AreEqual(CustomLlm, other.CustomLlm)
            && ValueEquality.AreEqual(IgnoreDefaultPersonality, other.IgnoreDefaultPersonality)
            && ValueEquality.AreEqual(Rag, other.Rag)
            && ValueEquality.AreEqual(Timezone, other.Timezone)
            && ValueEquality.AreEqual(BackupLlmConfig, other.BackupLlmConfig)
            && ValueEquality.AreEqual(CascadeTimeoutSeconds, other.CascadeTimeoutSeconds)
            && ValueEquality.AreEqual(Tools, other.Tools)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Prompt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Llm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReasoningEffort);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ServiceTier);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ThinkingBudget);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableReasoningSummary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Temperature);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxTokens);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolIdsStrict);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BuiltInTools);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableParallelToolCalls);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(McpServerIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NativeMcpServerIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(KnowledgeBase);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomLlm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IgnoreDefaultPersonality);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Rag);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Timezone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackupLlmConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CascadeTimeoutSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tools);
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
