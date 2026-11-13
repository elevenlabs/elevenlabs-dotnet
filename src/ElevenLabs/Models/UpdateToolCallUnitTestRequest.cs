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
public record UpdateToolCallUnitTestRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Metadata of a conversation this test was created from (if applicable).</value>
    [JsonPropertyName("from_conversation_metadata")]
    public TestFromConversationMetadataInput? FromConversationMetadata { get; set; }

    /// <value>Dynamic variables to replace in the agent config during testing</value>
    [JsonPropertyName("dynamic_variables")]
    public Dictionary<string, object?>? DynamicVariables { get; set; }

    [JsonPropertyName("chat_history")]
    public IEnumerable<ConversationHistoryTranscriptCommonModelInput>? ChatHistory { get; set; }

    /// <value>Simulate the test as if the conversation originated from this channel.</value>
    [JsonPropertyName("conversation_initiation_source")]
    public ConversationInitiationSource1? ConversationInitiationSource { get; set; }

    /// <value>The environment to resolve environment-specific variable values against when running this test (URL, headers, auth connections). If not provided, defaults to 'production'. For simulation tests, simulation_environment takes precedence when set.</value>
    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    [JsonPropertyName("type")]
    public UpdateToolCallUnitTestRequestType? Type { get; set; }

    /// <value>How to evaluate the agent's tool call (if any). If empty, the tool call is not evaluated.</value>
    [JsonPropertyName("tool_call_parameters")]
    public UnitTestToolCallEvaluationModelInput? ToolCallParameters { get; set; }

    /// <value>If set to True this test will pass if any tool call returned by the LLM matches the criteria. Otherwise it will fail if more than one tool is returned by the agent.</value>
    [JsonPropertyName("check_any_tool_matches")]
    public bool? CheckAnyToolMatches { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The ID of the parent folder. If not provided, the test will be moved to the root level.</value>
    [JsonPropertyName("parent_folder_id")]
    public string? ParentFolderId { get; set; }

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
    public virtual bool Equals(UpdateToolCallUnitTestRequest? other)
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
            && ValueEquality.AreEqual(FromConversationMetadata, other.FromConversationMetadata)
            && ValueEquality.AreEqual(DynamicVariables, other.DynamicVariables)
            && ValueEquality.AreEqual(ChatHistory, other.ChatHistory)
            && ValueEquality.AreEqual(
                ConversationInitiationSource,
                other.ConversationInitiationSource
            )
            && ValueEquality.AreEqual(Environment, other.Environment)
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(ToolCallParameters, other.ToolCallParameters)
            && ValueEquality.AreEqual(CheckAnyToolMatches, other.CheckAnyToolMatches)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(ParentFolderId, other.ParentFolderId)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FromConversationMetadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DynamicVariables);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChatHistory);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationInitiationSource);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Environment);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolCallParameters);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CheckAnyToolMatches);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ParentFolderId);
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
