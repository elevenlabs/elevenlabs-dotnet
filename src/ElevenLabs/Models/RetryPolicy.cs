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
public record RetryPolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>How long to wait before a short retry.</value>
    [JsonPropertyName("retry_delay_seconds")]
    public int? RetryDelaySeconds { get; set; }

    /// <value>Retries a calling window allows after a failed call. Once used up, the next retry waits for the following window, which starts afresh.</value>
    [JsonPropertyName("max_short_retries")]
    public int? MaxShortRetries { get; set; }

    /// <value>The most calls a lead gets, counting the first.</value>
    [JsonPropertyName("max_total_calls")]
    public int? MaxTotalCalls { get; set; }

    /// <value>The most callbacks to honor for one number.</value>
    [JsonPropertyName("max_callbacks")]
    public int? MaxCallbacks { get; set; }

    /// <value>The most times a lead follows a request to call another number.</value>
    [JsonPropertyName("max_redirects")]
    public int? MaxRedirects { get; set; }

    [JsonPropertyName("interval_placement")]
    public IntervalPlacement? IntervalPlacement { get; set; }

    /// <value>How far `rotate` placement moves each call. Only used by `rotate`.</value>
    [JsonPropertyName("rotate_step_seconds")]
    public int? RotateStepSeconds { get; set; }

    /// <value>Calls to one number that may fail in a row before the lead moves on to its next listed number, or ends when there is none. An answered call, or a redirect to a new number, restarts the count. Unset leaves only `max_total_calls`.</value>
    [JsonPropertyName("max_consecutive_failures_per_number")]
    public int? MaxConsecutiveFailuresPerNumber { get; set; }

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
    public virtual bool Equals(RetryPolicy? other)
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
            && ValueEquality.AreEqual(RetryDelaySeconds, other.RetryDelaySeconds)
            && ValueEquality.AreEqual(MaxShortRetries, other.MaxShortRetries)
            && ValueEquality.AreEqual(MaxTotalCalls, other.MaxTotalCalls)
            && ValueEquality.AreEqual(MaxCallbacks, other.MaxCallbacks)
            && ValueEquality.AreEqual(MaxRedirects, other.MaxRedirects)
            && ValueEquality.AreEqual(IntervalPlacement, other.IntervalPlacement)
            && ValueEquality.AreEqual(RotateStepSeconds, other.RotateStepSeconds)
            && ValueEquality.AreEqual(
                MaxConsecutiveFailuresPerNumber,
                other.MaxConsecutiveFailuresPerNumber
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RetryDelaySeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxShortRetries);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxTotalCalls);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxCallbacks);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxRedirects);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntervalPlacement);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RotateStepSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxConsecutiveFailuresPerNumber);
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
