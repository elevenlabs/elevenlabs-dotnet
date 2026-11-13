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
public record LlmDeprecationConfigModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Number of days before the provider deprecation date when warnings start being shown.</value>
    [JsonPropertyName("warning_start_days")]
    public required int WarningStartDays { get; set; }

    /// <value>Number of days before the provider deprecation date when traffic starts being routed to the replacement model.</value>
    [JsonPropertyName("fallback_start_days")]
    public required int FallbackStartDays { get; set; }

    /// <value>Number of days before the provider deprecation date when all traffic is routed to the replacement model.</value>
    [JsonPropertyName("fallback_complete_days")]
    public required int FallbackCompleteDays { get; set; }

    /// <value>Percentage of traffic routed to the replacement model when fallback begins.</value>
    [JsonPropertyName("fallback_start_percentage")]
    public required int FallbackStartPercentage { get; set; }

    /// <value>Percentage of traffic routed to the replacement model when fallback is complete.</value>
    [JsonPropertyName("fallback_complete_percentage")]
    public required int FallbackCompletePercentage { get; set; }

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
    public virtual bool Equals(LlmDeprecationConfigModel? other)
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
            && ValueEquality.AreEqual(WarningStartDays, other.WarningStartDays)
            && ValueEquality.AreEqual(FallbackStartDays, other.FallbackStartDays)
            && ValueEquality.AreEqual(FallbackCompleteDays, other.FallbackCompleteDays)
            && ValueEquality.AreEqual(FallbackStartPercentage, other.FallbackStartPercentage)
            && ValueEquality.AreEqual(FallbackCompletePercentage, other.FallbackCompletePercentage)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WarningStartDays);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FallbackStartDays);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FallbackCompleteDays);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FallbackStartPercentage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FallbackCompletePercentage);
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
