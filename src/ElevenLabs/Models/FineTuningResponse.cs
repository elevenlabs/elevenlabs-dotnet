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
public record FineTuningResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Whether the user is allowed to fine-tune the voice.</value>
    [JsonPropertyName("is_allowed_to_fine_tune")]
    public bool? IsAllowedToFineTune { get; set; }

    /// <value>The state of the fine-tuning process for each model.</value>
    [JsonPropertyName("state")]
    public Dictionary<string, FineTuningResponseState>? State { get; set; }

    /// <value>List of verification failures in the fine-tuning process.</value>
    [JsonPropertyName("verification_failures")]
    public IEnumerable<string>? VerificationFailures { get; set; }

    /// <value>The number of verification attempts in the fine-tuning process.</value>
    [JsonPropertyName("verification_attempts_count")]
    public int? VerificationAttemptsCount { get; set; }

    /// <value>Whether a manual verification was requested for the fine-tuning process.</value>
    [JsonPropertyName("manual_verification_requested")]
    public bool? ManualVerificationRequested { get; set; }

    /// <value>The language of the fine-tuning process.</value>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <value>The progress of the fine-tuning process.</value>
    [JsonPropertyName("progress")]
    public Dictionary<string, double>? Progress { get; set; }

    /// <value>The message of the fine-tuning process.</value>
    [JsonPropertyName("message")]
    public Dictionary<string, string>? Message { get; set; }

    /// <value>The duration of the dataset in seconds.</value>
    [JsonPropertyName("dataset_duration_seconds")]
    public double? DatasetDurationSeconds { get; set; }

    /// <value>The number of verification attempts.</value>
    [JsonPropertyName("verification_attempts")]
    public IEnumerable<VerificationAttemptResponse>? VerificationAttempts { get; set; }

    /// <value>List of slice IDs.</value>
    [JsonPropertyName("slice_ids")]
    public IEnumerable<string>? SliceIds { get; set; }

    /// <value>The manual verification of the fine-tuning process.</value>
    [JsonPropertyName("manual_verification")]
    public ManualVerificationResponse? ManualVerification { get; set; }

    /// <value>The maximum number of verification attempts.</value>
    [JsonPropertyName("max_verification_attempts")]
    public int? MaxVerificationAttempts { get; set; }

    /// <value>The next maximum verification attempts reset time in Unix milliseconds.</value>
    [JsonPropertyName("next_max_verification_attempts_reset_unix_ms")]
    public int? NextMaxVerificationAttemptsResetUnixMs { get; set; }

    [JsonPropertyName("finetuning_state")]
    public object? FinetuningState { get; set; }

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
    public virtual bool Equals(FineTuningResponse? other)
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
            && ValueEquality.AreEqual(IsAllowedToFineTune, other.IsAllowedToFineTune)
            && ValueEquality.AreEqual(State, other.State)
            && ValueEquality.AreEqual(VerificationFailures, other.VerificationFailures)
            && ValueEquality.AreEqual(VerificationAttemptsCount, other.VerificationAttemptsCount)
            && ValueEquality.AreEqual(
                ManualVerificationRequested,
                other.ManualVerificationRequested
            )
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(Progress, other.Progress)
            && ValueEquality.AreEqual(Message, other.Message)
            && ValueEquality.AreEqual(DatasetDurationSeconds, other.DatasetDurationSeconds)
            && ValueEquality.AreEqual(VerificationAttempts, other.VerificationAttempts)
            && ValueEquality.AreEqual(SliceIds, other.SliceIds)
            && ValueEquality.AreEqual(ManualVerification, other.ManualVerification)
            && ValueEquality.AreEqual(MaxVerificationAttempts, other.MaxVerificationAttempts)
            && ValueEquality.AreEqual(
                NextMaxVerificationAttemptsResetUnixMs,
                other.NextMaxVerificationAttemptsResetUnixMs
            )
            && ValueEquality.AreEqual(FinetuningState, other.FinetuningState)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsAllowedToFineTune);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(State);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VerificationFailures);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VerificationAttemptsCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ManualVerificationRequested);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Progress);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Message);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DatasetDurationSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VerificationAttempts);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SliceIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ManualVerification);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxVerificationAttempts);
            hash =
                (hash * 31) + ValueEquality.GetHashCodeOf(NextMaxVerificationAttemptsResetUnixMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FinetuningState);
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
