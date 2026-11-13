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
public record BaseTurnConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Maximum wait time for the user's reply before re-engaging the user</value>
    [JsonPropertyName("turn_timeout")]
    public double? TurnTimeout { get; set; }

    /// <value>How long the agent will wait for the user to start the conversation if the first message is empty. If not set, uses the regular turn_timeout.</value>
    [JsonPropertyName("initial_wait_time")]
    public double? InitialWaitTime { get; set; }

    /// <value>Maximum wait time since the user last spoke before terminating the call</value>
    [JsonPropertyName("silence_end_call_timeout")]
    public double? SilenceEndCallTimeout { get; set; }

    /// <value>Agent's eagerness to respond. Higher values make agent wait for higher turn probability.</value>
    [JsonPropertyName("turn_eagerness")]
    public TurnEagerness? TurnEagerness { get; set; }

    /// <value>Controls if the agent should be more patient when user is spelling numbers and named entities.</value>
    [JsonPropertyName("spelling_patience")]
    public SpellingPatience? SpellingPatience { get; set; }

    /// <value>When enabled, starts generating LLM responses during silence before full turn confidence is reached, reducing perceived latency. May increase LLM costs.</value>
    [JsonPropertyName("speculative_turn")]
    public bool? SpeculativeTurn { get; set; }

    /// <value>When enabled, if VAD detects no speech, attempts to re-transcribe accumulated audio at turn timeout. Disables silence discount billing while enabled for the active agent or workflow node.</value>
    [JsonPropertyName("retranscribe_on_turn_timeout")]
    public bool? RetranscribeOnTurnTimeout { get; set; }

    /// <value>Version of the turn detection model to use.</value>
    [JsonPropertyName("turn_model")]
    public TurnModel? TurnModel { get; set; }

    /// <value>List of terms that should not trigger an interruption when spoken by the user (e.g. 'gotcha', 'understood'). Uses case-insensitive exact matching.</value>
    [JsonPropertyName("interruption_ignore_terms")]
    public IEnumerable<string>? InterruptionIgnoreTerms { get; set; }

    /// <value>Language codes for which preset ignore-term categories have been activated. Stored explicitly so display is not inferred from term overlap.</value>
    [JsonPropertyName("interruption_ignore_term_languages")]
    public IEnumerable<string>? InterruptionIgnoreTermLanguages { get; set; }

    /// <value>When enabled, the curated default terms for interruption_ignore_term_languages are used in addition to interruption_ignore_terms.</value>
    [JsonPropertyName("merge_with_default_ignore_terms")]
    public bool? MergeWithDefaultIgnoreTerms { get; set; }

    /// <value>When interruptions are disabled, still transcribe what the user says so it can carry into the next turn. When off, user speech during a non-interruptible turn is ignored and won't trigger a turn.</value>
    [JsonPropertyName("transcribe_on_disabled_interruptions")]
    public bool? TranscribeOnDisabledInterruptions { get; set; }

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
    public virtual bool Equals(BaseTurnConfig? other)
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
            && ValueEquality.AreEqual(TurnTimeout, other.TurnTimeout)
            && ValueEquality.AreEqual(InitialWaitTime, other.InitialWaitTime)
            && ValueEquality.AreEqual(SilenceEndCallTimeout, other.SilenceEndCallTimeout)
            && ValueEquality.AreEqual(TurnEagerness, other.TurnEagerness)
            && ValueEquality.AreEqual(SpellingPatience, other.SpellingPatience)
            && ValueEquality.AreEqual(SpeculativeTurn, other.SpeculativeTurn)
            && ValueEquality.AreEqual(RetranscribeOnTurnTimeout, other.RetranscribeOnTurnTimeout)
            && ValueEquality.AreEqual(TurnModel, other.TurnModel)
            && ValueEquality.AreEqual(InterruptionIgnoreTerms, other.InterruptionIgnoreTerms)
            && ValueEquality.AreEqual(
                InterruptionIgnoreTermLanguages,
                other.InterruptionIgnoreTermLanguages
            )
            && ValueEquality.AreEqual(
                MergeWithDefaultIgnoreTerms,
                other.MergeWithDefaultIgnoreTerms
            )
            && ValueEquality.AreEqual(
                TranscribeOnDisabledInterruptions,
                other.TranscribeOnDisabledInterruptions
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TurnTimeout);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InitialWaitTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SilenceEndCallTimeout);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TurnEagerness);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpellingPatience);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeculativeTurn);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RetranscribeOnTurnTimeout);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TurnModel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InterruptionIgnoreTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InterruptionIgnoreTermLanguages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MergeWithDefaultIgnoreTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TranscribeOnDisabledInterruptions);
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
