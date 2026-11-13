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
public record AgentPlatformSettingsResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>
    /// Settings to evaluate an agent's performance.
    /// Agents are evaluated against a set of criteria, with success being defined as meeting some combination of those criteria.
    /// </value>
    [JsonPropertyName("evaluation")]
    public EvaluationSettingsOutput? Evaluation { get; set; }

    [JsonPropertyName("widget")]
    public WidgetConfig? Widget { get; set; }

    /// <value>Data collection fields, keyed by ID. Each field is stored as an analysis item attached to the agent (see analysis_items).</value>
    [JsonPropertyName("data_collection")]
    public Dictionary<string, AnalysisProperty>? DataCollection { get; set; }

    /// <value>Scope per data collection item ID. Missing keys default to conversation scope.</value>
    [JsonPropertyName("data_collection_scopes")]
    public Dictionary<string, AnalysisScope>? DataCollectionScopes { get; set; }

    /// <value>Analysis items (evaluation criteria and data collection fields) attached to the agent by reference. They are the source of truth for the agent's analysis. Writing evaluation.criteria or data_collection inline is still supported: a new entry creates an item, and changing an entry publishes a new version of its attached item, which every agent using that item picks up. To attach or detach an existing item, use the analysis item attachments endpoint. None means the agent has no attached items yet, and its inline fields are used as they are.</value>
    [JsonPropertyName("analysis_items")]
    public AgentAnalysisItemsOutput? AnalysisItems { get; set; }

    [JsonPropertyName("overrides")]
    public ConversationInitiationClientDataConfigOutput? Overrides { get; set; }

    [JsonPropertyName("workspace_overrides")]
    public AgentWorkspaceOverridesOutput? WorkspaceOverrides { get; set; }

    /// <value>Settings for agent testing configuration.</value>
    [JsonPropertyName("testing")]
    public AgentTestingSettings? Testing { get; set; }

    /// <value>Whether the agent is archived</value>
    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    [JsonPropertyName("guardrails")]
    public GuardrailsV1Output? Guardrails { get; set; }

    /// <value>Language for all conversation analysis outputs (summaries, titles, evaluation rationales, data collection rationales). If not set, the language will be inferred from the conversation. Must be one of the supported conversation languages.</value>
    [JsonPropertyName("summary_language")]
    public string? SummaryLanguage { get; set; }

    /// <value>When enabled, a conversation transcript is automatically translated to the viewer's application language when they open the transcript page. If not set or false, transcripts are shown in their original language unless the viewer manually selects a translation.</value>
    [JsonPropertyName("auto_translate_transcript_to_app_language")]
    public bool? AutoTranslateTranscriptToAppLanguage { get; set; }

    [JsonPropertyName("auth")]
    public AuthSettings? Auth { get; set; }

    [JsonPropertyName("call_limits")]
    public AgentCallLimits? CallLimits { get; set; }

    [JsonPropertyName("queueing_config")]
    public AgentQueueingConfig? QueueingConfig { get; set; }

    [JsonPropertyName("privacy")]
    public PrivacyConfigOutput? Privacy { get; set; }

    /// <value>
    /// The trust context in which the agent operates.
    ///
    /// UNKNOWN: not yet classified (existing agents created before this feature).
    /// LOW: serves untrusted external participants (e.g. customer support, sales) —
    ///      outputs should be vetted and tool access scoped.
    /// HIGH: serves the owner (e.g. personal assistant) — full tool access is appropriate.
    /// </value>
    [JsonPropertyName("trust_context")]
    public AgentTrustContext? TrustContext { get; set; }

    [JsonPropertyName("analysis_llm")]
    public Llm? AnalysisLlm { get; set; }

    /// <value>
    /// Per-agent topic-discovery configuration. Cadence and analysis window are
    /// managed internally; this only exposes the customer-facing on/off toggle.
    /// </value>
    [JsonPropertyName("topic_discovery")]
    public TopicDiscoverySettings? TopicDiscovery { get; set; }

    [JsonPropertyName("sentiment_analysis")]
    public SentimentAnalysisSettings? SentimentAnalysis { get; set; }

    /// <value>Agent-level alerting configuration overriding workspace settings.</value>
    [JsonPropertyName("alerting")]
    public AlertingSettingsResponse? Alerting { get; set; }

    [JsonPropertyName("safety")]
    public SafetyResponseModel? Safety { get; set; }

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
    public virtual bool Equals(AgentPlatformSettingsResponseModel? other)
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
            && ValueEquality.AreEqual(Evaluation, other.Evaluation)
            && ValueEquality.AreEqual(Widget, other.Widget)
            && ValueEquality.AreEqual(DataCollection, other.DataCollection)
            && ValueEquality.AreEqual(DataCollectionScopes, other.DataCollectionScopes)
            && ValueEquality.AreEqual(AnalysisItems, other.AnalysisItems)
            && ValueEquality.AreEqual(Overrides, other.Overrides)
            && ValueEquality.AreEqual(WorkspaceOverrides, other.WorkspaceOverrides)
            && ValueEquality.AreEqual(Testing, other.Testing)
            && ValueEquality.AreEqual(Archived, other.Archived)
            && ValueEquality.AreEqual(Guardrails, other.Guardrails)
            && ValueEquality.AreEqual(SummaryLanguage, other.SummaryLanguage)
            && ValueEquality.AreEqual(
                AutoTranslateTranscriptToAppLanguage,
                other.AutoTranslateTranscriptToAppLanguage
            )
            && ValueEquality.AreEqual(Auth, other.Auth)
            && ValueEquality.AreEqual(CallLimits, other.CallLimits)
            && ValueEquality.AreEqual(QueueingConfig, other.QueueingConfig)
            && ValueEquality.AreEqual(Privacy, other.Privacy)
            && ValueEquality.AreEqual(TrustContext, other.TrustContext)
            && ValueEquality.AreEqual(AnalysisLlm, other.AnalysisLlm)
            && ValueEquality.AreEqual(TopicDiscovery, other.TopicDiscovery)
            && ValueEquality.AreEqual(SentimentAnalysis, other.SentimentAnalysis)
            && ValueEquality.AreEqual(Alerting, other.Alerting)
            && ValueEquality.AreEqual(Safety, other.Safety)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Evaluation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Widget);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DataCollection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DataCollectionScopes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AnalysisItems);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Overrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WorkspaceOverrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Testing);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Archived);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Guardrails);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SummaryLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoTranslateTranscriptToAppLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Auth);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallLimits);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QueueingConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Privacy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TrustContext);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AnalysisLlm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TopicDiscovery);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SentimentAnalysis);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Alerting);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Safety);
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
