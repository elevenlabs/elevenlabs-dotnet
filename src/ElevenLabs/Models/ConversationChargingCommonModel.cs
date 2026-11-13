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
public record ConversationChargingCommonModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("dev_discount")]
    public bool? DevDiscount { get; set; }

    [JsonPropertyName("is_burst")]
    public bool? IsBurst { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }

    /// <value>LLM usage of a conversation, split by whether the generated response reached the user.</value>
    [JsonPropertyName("llm_usage")]
    public LlmCategoryUsage? LlmUsage { get; set; }

    /// <value>Total LLM price in USD. Equals the sum of the prices in `llm_usage.initiated_generation`.</value>
    [JsonPropertyName("llm_price")]
    public double? LlmPrice { get; set; }

    /// <value>Credits charged for LLM usage.</value>
    [JsonPropertyName("llm_charge")]
    public int? LlmCharge { get; set; }

    [JsonPropertyName("call_charge")]
    public int? CallCharge { get; set; }

    [JsonPropertyName("platform_charge")]
    public int? PlatformCharge { get; set; }

    /// <value>Per-category breakdown of ``platform_charge`` (the analogue of ``llm_usage``).</value>
    [JsonPropertyName("platform_usage")]
    public PlatformUsage? PlatformUsage { get; set; }

    [JsonPropertyName("platform_price")]
    public double? PlatformPrice { get; set; }

    [JsonPropertyName("free_minutes_consumed")]
    public double? FreeMinutesConsumed { get; set; }

    [JsonPropertyName("free_llm_dollars_consumed")]
    public double? FreeLlmDollarsConsumed { get; set; }

    [JsonPropertyName("tts_usage")]
    public ConversationTtsUsageModel? TtsUsage { get; set; }

    [JsonPropertyName("asr_usage")]
    public ConversationAsrUsageModel? AsrUsage { get; set; }

    [JsonPropertyName("analysis")]
    public AnalysisCharging? Analysis { get; set; }

    /// <value>Credits charged as the voice actor reward for the Voice Library voices this conversation used. It is not included in `cost`.</value>
    [JsonPropertyName("voice_surcharge_charge")]
    public int? VoiceSurchargeCharge { get; set; }

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
    public virtual bool Equals(ConversationChargingCommonModel? other)
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
            && ValueEquality.AreEqual(DevDiscount, other.DevDiscount)
            && ValueEquality.AreEqual(IsBurst, other.IsBurst)
            && ValueEquality.AreEqual(Tier, other.Tier)
            && ValueEquality.AreEqual(LlmUsage, other.LlmUsage)
            && ValueEquality.AreEqual(LlmPrice, other.LlmPrice)
            && ValueEquality.AreEqual(LlmCharge, other.LlmCharge)
            && ValueEquality.AreEqual(CallCharge, other.CallCharge)
            && ValueEquality.AreEqual(PlatformCharge, other.PlatformCharge)
            && ValueEquality.AreEqual(PlatformUsage, other.PlatformUsage)
            && ValueEquality.AreEqual(PlatformPrice, other.PlatformPrice)
            && ValueEquality.AreEqual(FreeMinutesConsumed, other.FreeMinutesConsumed)
            && ValueEquality.AreEqual(FreeLlmDollarsConsumed, other.FreeLlmDollarsConsumed)
            && ValueEquality.AreEqual(TtsUsage, other.TtsUsage)
            && ValueEquality.AreEqual(AsrUsage, other.AsrUsage)
            && ValueEquality.AreEqual(Analysis, other.Analysis)
            && ValueEquality.AreEqual(VoiceSurchargeCharge, other.VoiceSurchargeCharge)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DevDiscount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsBurst);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tier);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LlmUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LlmPrice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LlmCharge);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallCharge);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformCharge);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformPrice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FreeMinutesConsumed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FreeLlmDollarsConsumed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TtsUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AsrUsage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Analysis);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceSurchargeCharge);
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
