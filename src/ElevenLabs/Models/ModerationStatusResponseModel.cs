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
public record ModerationStatusResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Whether the user is in probation.</value>
    [JsonPropertyName("is_in_probation")]
    public required bool IsInProbation { get; set; }

    /// <value>Whether the user's enterprise check nogo voice is enabled.</value>
    [JsonPropertyName("enterprise_check_nogo_voice")]
    public required bool EnterpriseCheckNogoVoice { get; set; }

    /// <value>Whether the user's enterprise check block nogo voice is enabled.</value>
    [JsonPropertyName("enterprise_check_block_nogo_voice")]
    public required bool EnterpriseCheckBlockNogoVoice { get; set; }

    /// <value>Whether the user's never live moderate is enabled.</value>
    [JsonPropertyName("never_live_moderate")]
    public required bool NeverLiveModerate { get; set; }

    /// <value>The number of similar voice uploads that have been blocked.</value>
    [JsonPropertyName("nogo_voice_similar_voice_upload_count")]
    public required int NogoVoiceSimilarVoiceUploadCount { get; set; }

    /// <value>Whether the user's enterprise background moderation is enabled.</value>
    [JsonPropertyName("enterprise_background_moderation_enabled")]
    public required bool EnterpriseBackgroundModerationEnabled { get; set; }

    /// <value>Whether captcha is required when creating IVCs.</value>
    [JsonPropertyName("is_ivc_captcha_required")]
    public required bool IsIvcCaptchaRequired { get; set; }

    /// <value>The safety status of the user.</value>
    [JsonPropertyName("safety_status")]
    public ModerationStatusResponseModelSafetyStatus? SafetyStatus { get; set; }

    /// <value>The warning status of the user.</value>
    [JsonPropertyName("warning_status")]
    public ModerationStatusResponseModelWarningStatus? WarningStatus { get; set; }

    /// <value>Whether the user is on the watchlist.</value>
    [JsonPropertyName("on_watchlist")]
    public required bool OnWatchlist { get; set; }

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
    public virtual bool Equals(ModerationStatusResponseModel? other)
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
            && ValueEquality.AreEqual(IsInProbation, other.IsInProbation)
            && ValueEquality.AreEqual(EnterpriseCheckNogoVoice, other.EnterpriseCheckNogoVoice)
            && ValueEquality.AreEqual(
                EnterpriseCheckBlockNogoVoice,
                other.EnterpriseCheckBlockNogoVoice
            )
            && ValueEquality.AreEqual(NeverLiveModerate, other.NeverLiveModerate)
            && ValueEquality.AreEqual(
                NogoVoiceSimilarVoiceUploadCount,
                other.NogoVoiceSimilarVoiceUploadCount
            )
            && ValueEquality.AreEqual(
                EnterpriseBackgroundModerationEnabled,
                other.EnterpriseBackgroundModerationEnabled
            )
            && ValueEquality.AreEqual(IsIvcCaptchaRequired, other.IsIvcCaptchaRequired)
            && ValueEquality.AreEqual(SafetyStatus, other.SafetyStatus)
            && ValueEquality.AreEqual(WarningStatus, other.WarningStatus)
            && ValueEquality.AreEqual(OnWatchlist, other.OnWatchlist)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsInProbation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnterpriseCheckNogoVoice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnterpriseCheckBlockNogoVoice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NeverLiveModerate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NogoVoiceSimilarVoiceUploadCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnterpriseBackgroundModerationEnabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsIvcCaptchaRequired);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SafetyStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WarningStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OnWatchlist);
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
