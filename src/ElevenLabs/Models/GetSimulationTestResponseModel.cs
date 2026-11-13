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
public record GetSimulationTestResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The access information for the requesting user on this test.</value>
    [JsonPropertyName("access_info")]
    public ResourceAccessInfo? AccessInfo { get; set; }

    /// <value>Metadata of a conversation this test was created from (if applicable).</value>
    [JsonPropertyName("from_conversation_metadata")]
    public TestFromConversationMetadataOutput? FromConversationMetadata { get; set; }

    /// <value>Dynamic variables to replace in the agent config during testing</value>
    [JsonPropertyName("dynamic_variables")]
    public Dictionary<string, object?>? DynamicVariables { get; set; }

    [JsonPropertyName("chat_history")]
    public IEnumerable<ConversationHistoryTranscriptCommonModelOutput>? ChatHistory { get; set; }

    /// <value>Simulate the test as if the conversation originated from this channel.</value>
    [JsonPropertyName("conversation_initiation_source")]
    public ConversationInitiationSource1? ConversationInitiationSource { get; set; }

    /// <value>The environment to resolve environment-specific variable values against when running this test (URL, headers, auth connections). If not provided, defaults to 'production'. For simulation tests, simulation_environment takes precedence when set.</value>
    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    [JsonPropertyName("type")]
    public GetSimulationTestResponseModelType? Type { get; set; }

    /// <value>Deprecated legacy single success criterion. Use success_conditions instead. At least one of success_condition or success_conditions is required.</value>
    [JsonPropertyName("success_condition")]
    public string? SuccessCondition { get; set; }

    /// <value>List of prompts that evaluate whether the simulation was successful. If provided, all criteria are evaluated and merged into a final result. Capped at the maximum number of evaluation criteria.</value>
    [JsonPropertyName("success_conditions")]
    public IEnumerable<string>? SuccessConditions { get; set; }

    /// <value>Description of the simulation scenario and user persona for simulation tests.</value>
    [JsonPropertyName("simulation_scenario")]
    public string? SimulationScenario { get; set; }

    /// <value>Maximum number of conversation turns for simulation tests.</value>
    [JsonPropertyName("simulation_max_turns")]
    public int? SimulationMaxTurns { get; set; }

    /// <value>The environment to use when running this simulation test. If not provided, defaults to 'production'.</value>
    [JsonPropertyName("simulation_environment")]
    public string? SimulationEnvironment { get; set; }

    /// <value>Simulation/preview-side config: tools are identified by IDs, resolved to names at runtime.</value>
    [JsonPropertyName("tool_mock_config")]
    public SimulationToolMockBehaviorConfig? ToolMockConfig { get; set; }

    /// <value>Test-specific response mocks, keyed by tool ID. Applied ahead of the tool's shared mocks and only within this test. Only take effect for tools that are mocked (see tool_mock_config).</value>
    [JsonPropertyName("tool_mock_overrides")]
    public Dictionary<
        string,
        IEnumerable<ToolResponseMockConfigOutput>
    >? ToolMockOverrides { get; set; }

    /// <value>LLM model to use for evaluating simulation results.</value>
    [JsonPropertyName("evaluation_model")]
    public Llm? EvaluationModel { get; set; }

    /// <value>LLM model for the simulated user.</value>
    [JsonPropertyName("simulated_user_model")]
    public Llm? SimulatedUserModel { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

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
    public virtual bool Equals(GetSimulationTestResponseModel? other)
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
            && ValueEquality.AreEqual(AccessInfo, other.AccessInfo)
            && ValueEquality.AreEqual(FromConversationMetadata, other.FromConversationMetadata)
            && ValueEquality.AreEqual(DynamicVariables, other.DynamicVariables)
            && ValueEquality.AreEqual(ChatHistory, other.ChatHistory)
            && ValueEquality.AreEqual(
                ConversationInitiationSource,
                other.ConversationInitiationSource
            )
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(SuccessCondition, other.SuccessCondition)
            && ValueEquality.AreEqual(SuccessConditions, other.SuccessConditions)
            && ValueEquality.AreEqual(SimulationScenario, other.SimulationScenario)
            && ValueEquality.AreEqual(SimulationMaxTurns, other.SimulationMaxTurns)
            && ValueEquality.AreEqual(SimulationEnvironment, other.SimulationEnvironment)
            && ValueEquality.AreEqual(ToolMockConfig, other.ToolMockConfig)
            && ValueEquality.AreEqual(ToolMockOverrides, other.ToolMockOverrides)
            && ValueEquality.AreEqual(EvaluationModel, other.EvaluationModel)
            && ValueEquality.AreEqual(SimulatedUserModel, other.SimulatedUserModel)
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(Name, other.Name)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccessInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FromConversationMetadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DynamicVariables);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChatHistory);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationInitiationSource);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SuccessCondition);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SuccessConditions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SimulationScenario);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SimulationMaxTurns);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SimulationEnvironment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolMockConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolMockOverrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EvaluationModel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SimulatedUserModel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
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
