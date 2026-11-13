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
public record LlmInfoModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("llm")]
    public required Llm Llm { get; set; }

    /// <value>Whether this is a pinned checkpoint version of a model rather than a top-level alias.</value>
    [JsonPropertyName("is_checkpoint")]
    public required bool IsCheckpoint { get; set; }

    /// <value>Maximum number of output tokens the model can generate.</value>
    [JsonPropertyName("max_tokens_limit")]
    public required int MaxTokensLimit { get; set; }

    /// <value>Maximum number of input context tokens the model supports.</value>
    [JsonPropertyName("max_context_limit")]
    public required int MaxContextLimit { get; set; }

    /// <value>Whether the model supports image file inputs during conversations.</value>
    [JsonPropertyName("supports_image_input")]
    public required bool SupportsImageInput { get; set; }

    /// <value>Whether the model supports document (PDF) file inputs during conversations.</value>
    [JsonPropertyName("supports_document_input")]
    public required bool SupportsDocumentInput { get; set; }

    /// <value>Whether the model supports calling multiple tools in parallel.</value>
    [JsonPropertyName("supports_parallel_tool_calls")]
    public required bool SupportsParallelToolCalls { get; set; }

    /// <value>Available reasoning effort levels for this model. Null if the model does not support configurable reasoning.</value>
    [JsonPropertyName("available_reasoning_efforts")]
    public IEnumerable<LlmReasoningEffort>? AvailableReasoningEfforts { get; set; }

    /// <value>Available service tiers for this model. Always includes at least the standard tier.</value>
    [JsonPropertyName("available_service_tiers")]
    public IEnumerable<LlmServiceTier> AvailableServiceTiers { get; set; } =
        new List<LlmServiceTier>();

    /// <value>Deprecation information if this model is deprecated or scheduled for deprecation. Null if the model is not affected.</value>
    [JsonPropertyName("deprecation_info")]
    public LlmDeprecationInfoModel? DeprecationInfo { get; set; }

    /// <value>Regional processing surcharge details if this model has additional costs in the current deployment region. Null if no surcharge applies.</value>
    [JsonPropertyName("regional_processing_surcharge")]
    public RegionalProcessingSurchargeInfo? RegionalProcessingSurcharge { get; set; }

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
    public virtual bool Equals(LlmInfoModel? other)
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
            && ValueEquality.AreEqual(Llm, other.Llm)
            && ValueEquality.AreEqual(IsCheckpoint, other.IsCheckpoint)
            && ValueEquality.AreEqual(MaxTokensLimit, other.MaxTokensLimit)
            && ValueEquality.AreEqual(MaxContextLimit, other.MaxContextLimit)
            && ValueEquality.AreEqual(SupportsImageInput, other.SupportsImageInput)
            && ValueEquality.AreEqual(SupportsDocumentInput, other.SupportsDocumentInput)
            && ValueEquality.AreEqual(SupportsParallelToolCalls, other.SupportsParallelToolCalls)
            && ValueEquality.AreEqual(AvailableReasoningEfforts, other.AvailableReasoningEfforts)
            && ValueEquality.AreEqual(AvailableServiceTiers, other.AvailableServiceTiers)
            && ValueEquality.AreEqual(DeprecationInfo, other.DeprecationInfo)
            && ValueEquality.AreEqual(
                RegionalProcessingSurcharge,
                other.RegionalProcessingSurcharge
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Llm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsCheckpoint);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxTokensLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxContextLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportsImageInput);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportsDocumentInput);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SupportsParallelToolCalls);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AvailableReasoningEfforts);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AvailableServiceTiers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeprecationInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RegionalProcessingSurcharge);
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
