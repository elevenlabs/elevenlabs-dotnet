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
public record SubscriptionExtrasResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The concurrency of the user.</value>
    [JsonPropertyName("concurrency")]
    public required int Concurrency { get; set; }

    /// <value>The Convai concurrency of the user.</value>
    [JsonPropertyName("convai_concurrency")]
    public required int ConvaiConcurrency { get; set; }

    /// <value>The Music concurrency of the user on enterprise plan.</value>
    [JsonPropertyName("enterprise_music_concurrency")]
    public int? EnterpriseMusicConcurrency { get; set; }

    /// <value>Custom total finetunes limit for the user.</value>
    [JsonPropertyName("music_finetunes_total_limit")]
    public int? MusicFinetunesTotalLimit { get; set; }

    /// <value>Custom monthly finetunes limit for the user.</value>
    [JsonPropertyName("music_finetunes_monthly_limit")]
    public int? MusicFinetunesMonthlyLimit { get; set; }

    /// <value>Custom finetunes concurrency limit for the user.</value>
    [JsonPropertyName("music_finetunes_concurrency_limit")]
    public int? MusicFinetunesConcurrencyLimit { get; set; }

    /// <value>The Convai characters per minute of the user. This field is deprecated and will always return None.</value>
    [JsonPropertyName("convai_chars_per_minute")]
    public int? ConvaiCharsPerMinute { get; set; }

    /// <value>The Convai ASR characters per minute of the user. This field is deprecated and will always return None.</value>
    [JsonPropertyName("convai_asr_chars_per_minute")]
    public int? ConvaiAsrCharsPerMinute { get; set; }

    /// <value>Whether the user's logging is disabled.</value>
    [JsonPropertyName("force_logging_disabled")]
    public required bool ForceLoggingDisabled { get; set; }

    /// <value>Whether the user can request manual pro voice verification.</value>
    [JsonPropertyName("can_request_manual_pro_voice_verification")]
    public required bool CanRequestManualProVoiceVerification { get; set; }

    /// <value>Whether the user can bypass the voice captcha.</value>
    [JsonPropertyName("can_bypass_voice_captcha")]
    public required bool CanBypassVoiceCaptcha { get; set; }

    [JsonPropertyName("moderation")]
    public required ModerationStatusResponseModel Moderation { get; set; }

    /// <value>The unused characters rolled over from the previous period.</value>
    [JsonPropertyName("unused_characters_rolled_over_from_previous_period")]
    public int? UnusedCharactersRolledOverFromPreviousPeriod { get; set; }

    /// <value>The overused characters rolled over from the previous period.</value>
    [JsonPropertyName("overused_characters_rolled_over_from_previous_period")]
    public int? OverusedCharactersRolledOverFromPreviousPeriod { get; set; }

    /// <value>Data on how the subscription is being used.</value>
    [JsonPropertyName("usage")]
    public SubscriptionUsageResponseModel? Usage { get; set; }

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
    public virtual bool Equals(SubscriptionExtrasResponseModel? other)
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
            && ValueEquality.AreEqual(Concurrency, other.Concurrency)
            && ValueEquality.AreEqual(ConvaiConcurrency, other.ConvaiConcurrency)
            && ValueEquality.AreEqual(EnterpriseMusicConcurrency, other.EnterpriseMusicConcurrency)
            && ValueEquality.AreEqual(MusicFinetunesTotalLimit, other.MusicFinetunesTotalLimit)
            && ValueEquality.AreEqual(MusicFinetunesMonthlyLimit, other.MusicFinetunesMonthlyLimit)
            && ValueEquality.AreEqual(
                MusicFinetunesConcurrencyLimit,
                other.MusicFinetunesConcurrencyLimit
            )
            && ValueEquality.AreEqual(ConvaiCharsPerMinute, other.ConvaiCharsPerMinute)
            && ValueEquality.AreEqual(ConvaiAsrCharsPerMinute, other.ConvaiAsrCharsPerMinute)
            && ValueEquality.AreEqual(ForceLoggingDisabled, other.ForceLoggingDisabled)
            && ValueEquality.AreEqual(
                CanRequestManualProVoiceVerification,
                other.CanRequestManualProVoiceVerification
            )
            && ValueEquality.AreEqual(CanBypassVoiceCaptcha, other.CanBypassVoiceCaptcha)
            && ValueEquality.AreEqual(Moderation, other.Moderation)
            && ValueEquality.AreEqual(
                UnusedCharactersRolledOverFromPreviousPeriod,
                other.UnusedCharactersRolledOverFromPreviousPeriod
            )
            && ValueEquality.AreEqual(
                OverusedCharactersRolledOverFromPreviousPeriod,
                other.OverusedCharactersRolledOverFromPreviousPeriod
            )
            && ValueEquality.AreEqual(Usage, other.Usage)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Concurrency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConvaiConcurrency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnterpriseMusicConcurrency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MusicFinetunesTotalLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MusicFinetunesMonthlyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MusicFinetunesConcurrencyLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConvaiCharsPerMinute);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConvaiAsrCharsPerMinute);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ForceLoggingDisabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanRequestManualProVoiceVerification);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanBypassVoiceCaptcha);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Moderation);
            hash =
                (hash * 31)
                + ValueEquality.GetHashCodeOf(UnusedCharactersRolledOverFromPreviousPeriod);
            hash =
                (hash * 31)
                + ValueEquality.GetHashCodeOf(OverusedCharactersRolledOverFromPreviousPeriod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Usage);
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
