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
public record Voice : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the voice.</value>
    [JsonPropertyName("voice_id")]
    public required string VoiceId { get; set; }

    /// <value>The name of the voice.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>List of samples associated with the voice.</value>
    [JsonPropertyName("samples")]
    public IEnumerable<VoiceSample>? Samples { get; set; }

    /// <value>The category of the voice.</value>
    [JsonPropertyName("category")]
    public Category? Category { get; set; }

    /// <value>Fine-tuning information for the voice.</value>
    [JsonPropertyName("fine_tuning")]
    public FineTuningResponse? FineTuning { get; set; }

    /// <value>Labels associated with the voice.</value>
    [JsonPropertyName("labels")]
    public Dictionary<string, string>? Labels { get; set; }

    /// <value>The description of the voice.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>The preview URL of the voice.</value>
    [JsonPropertyName("preview_url")]
    public string? PreviewUrl { get; set; }

    /// <value>The tiers the voice is available for.</value>
    [JsonPropertyName("available_for_tiers")]
    public IEnumerable<string>? AvailableForTiers { get; set; }

    /// <value>The settings of the voice.</value>
    [JsonPropertyName("settings")]
    public BodyTextToSpeechFullVoiceSettings? Settings { get; set; }

    /// <value>The sharing information of the voice.</value>
    [JsonPropertyName("sharing")]
    public VoiceSharingResponse? Sharing { get; set; }

    /// <value>The base model IDs for high-quality voices.</value>
    [JsonPropertyName("high_quality_base_model_ids")]
    public IEnumerable<string>? HighQualityBaseModelIds { get; set; }

    /// <value>The verified languages of the voice.</value>
    [JsonPropertyName("verified_languages")]
    public IEnumerable<VerifiedVoiceLanguageResponseModel>? VerifiedLanguages { get; set; }

    /// <value>The IDs of collections this voice belongs to.</value>
    [JsonPropertyName("collection_ids")]
    public IEnumerable<string>? CollectionIds { get; set; }

    /// <value>The safety controls of the voice.</value>
    [JsonPropertyName("safety_control")]
    public VoiceSafetyControl? SafetyControl { get; set; }

    /// <value>The voice verification of the voice.</value>
    [JsonPropertyName("voice_verification")]
    public VoiceVerificationResponse? VoiceVerification { get; set; }

    /// <value>The permission on the resource of the voice.</value>
    [JsonPropertyName("permission_on_resource")]
    public string? PermissionOnResource { get; set; }

    /// <value>Whether the voice is owned by the user.</value>
    [JsonPropertyName("is_owner")]
    public bool? IsOwner { get; set; }

    /// <value>Whether the voice is legacy.</value>
    [JsonPropertyName("is_legacy")]
    public bool? IsLegacy { get; set; }

    /// <value>Whether the voice is mixed.</value>
    [JsonPropertyName("is_mixed")]
    public bool? IsMixed { get; set; }

    /// <value>Timestamp when the voice was marked as favorite in Unix time.</value>
    [JsonPropertyName("favorited_at_unix")]
    public int? FavoritedAtUnix { get; set; }

    /// <value>The creation time of the voice in Unix time.</value>
    [JsonPropertyName("created_at_unix")]
    public int? CreatedAtUnix { get; set; }

    /// <value>Whether the voice is bookmarked by the current user. Only relevant for community (library-copied) voices.</value>
    [JsonPropertyName("is_bookmarked")]
    public bool? IsBookmarked { get; set; }

    /// <value>The recording quality of the voice as determined by the review pipeline.</value>
    [JsonPropertyName("recording_quality")]
    public VoiceRecordingQuality? RecordingQuality { get; set; }

    /// <value>The review pipeline status of the voice.</value>
    [JsonPropertyName("labelling_status")]
    public VoiceLabellingStatus? LabellingStatus { get; set; }

    /// <value>The reason for the recording quality assessment, as determined by the review pipeline.</value>
    [JsonPropertyName("recording_quality_reason")]
    public string? RecordingQualityReason { get; set; }

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
    public virtual bool Equals(Voice? other)
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
            && ValueEquality.AreEqual(VoiceId, other.VoiceId)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Samples, other.Samples)
            && ValueEquality.AreEqual(Category, other.Category)
            && ValueEquality.AreEqual(FineTuning, other.FineTuning)
            && ValueEquality.AreEqual(Labels, other.Labels)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(PreviewUrl, other.PreviewUrl)
            && ValueEquality.AreEqual(AvailableForTiers, other.AvailableForTiers)
            && ValueEquality.AreEqual(Settings, other.Settings)
            && ValueEquality.AreEqual(Sharing, other.Sharing)
            && ValueEquality.AreEqual(HighQualityBaseModelIds, other.HighQualityBaseModelIds)
            && ValueEquality.AreEqual(VerifiedLanguages, other.VerifiedLanguages)
            && ValueEquality.AreEqual(CollectionIds, other.CollectionIds)
            && ValueEquality.AreEqual(SafetyControl, other.SafetyControl)
            && ValueEquality.AreEqual(VoiceVerification, other.VoiceVerification)
            && ValueEquality.AreEqual(PermissionOnResource, other.PermissionOnResource)
            && ValueEquality.AreEqual(IsOwner, other.IsOwner)
            && ValueEquality.AreEqual(IsLegacy, other.IsLegacy)
            && ValueEquality.AreEqual(IsMixed, other.IsMixed)
            && ValueEquality.AreEqual(FavoritedAtUnix, other.FavoritedAtUnix)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(IsBookmarked, other.IsBookmarked)
            && ValueEquality.AreEqual(RecordingQuality, other.RecordingQuality)
            && ValueEquality.AreEqual(LabellingStatus, other.LabellingStatus)
            && ValueEquality.AreEqual(RecordingQualityReason, other.RecordingQualityReason)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Samples);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Category);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FineTuning);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Labels);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PreviewUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AvailableForTiers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Settings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Sharing);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HighQualityBaseModelIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VerifiedLanguages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CollectionIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SafetyControl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceVerification);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PermissionOnResource);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsOwner);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsLegacy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsMixed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FavoritedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsBookmarked);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecordingQuality);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LabellingStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecordingQualityReason);
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
