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
public record LlmDeprecationInfoModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("llm")]
    public required Llm Llm { get; set; }

    /// <value>Whether this model is currently deprecated. True if the model is immediately deprecated or within the warning period.</value>
    [JsonPropertyName("is_deprecated")]
    public required bool IsDeprecated { get; set; }

    /// <value>Whether this model is currently in the warning period before deprecation.</value>
    [JsonPropertyName("is_in_warning_period")]
    public bool? IsInWarningPeriod { get; set; }

    /// <value>Whether traffic is currently being progressively routed to the replacement model.</value>
    [JsonPropertyName("is_in_fallback_period")]
    public bool? IsInFallbackPeriod { get; set; }

    /// <value>Current percentage of traffic being routed to the replacement model (0-100).</value>
    [JsonPropertyName("fallback_percentage")]
    public int? FallbackPercentage { get; set; }

    /// <value>The date when the model provider will deprecate this model. Null for immediately deprecated models.</value>
    [JsonPropertyName("provider_deprecation_date")]
    public DateTime? ProviderDeprecationDate { get; set; }

    /// <value>The model that replaces this deprecated model. Traffic will be automatically routed to this model.</value>
    [JsonPropertyName("replacement_model")]
    public Llm? ReplacementModel { get; set; }

    /// <value>Custom deprecation timing configuration for this model. Null if using the default configuration.</value>
    [JsonPropertyName("deprecation_config")]
    public LlmDeprecationConfigModel? DeprecationConfig { get; set; }

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
    public virtual bool Equals(LlmDeprecationInfoModel? other)
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
            && ValueEquality.AreEqual(IsDeprecated, other.IsDeprecated)
            && ValueEquality.AreEqual(IsInWarningPeriod, other.IsInWarningPeriod)
            && ValueEquality.AreEqual(IsInFallbackPeriod, other.IsInFallbackPeriod)
            && ValueEquality.AreEqual(FallbackPercentage, other.FallbackPercentage)
            && ValueEquality.AreEqual(ProviderDeprecationDate, other.ProviderDeprecationDate)
            && ValueEquality.AreEqual(ReplacementModel, other.ReplacementModel)
            && ValueEquality.AreEqual(DeprecationConfig, other.DeprecationConfig)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Llm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsDeprecated);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsInWarningPeriod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsInFallbackPeriod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FallbackPercentage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProviderDeprecationDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReplacementModel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeprecationConfig);
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
