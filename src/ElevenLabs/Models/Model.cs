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
public record Model : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The unique identifier of the model.</value>
    [JsonPropertyName("model_id")]
    public required string ModelId { get; set; }

    /// <value>The name of the model.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>Whether the model can be finetuned.</value>
    [JsonPropertyName("can_be_finetuned")]
    public bool? CanBeFinetuned { get; set; }

    /// <value>Whether the model can do text-to-speech.</value>
    [JsonPropertyName("can_do_text_to_speech")]
    public bool? CanDoTextToSpeech { get; set; }

    /// <value>Whether the model can do voice conversion.</value>
    [JsonPropertyName("can_do_voice_conversion")]
    public bool? CanDoVoiceConversion { get; set; }

    /// <value>Whether the model can use style.</value>
    [JsonPropertyName("can_use_style")]
    public bool? CanUseStyle { get; set; }

    /// <value>Whether the model can use speaker boost.</value>
    [JsonPropertyName("can_use_speaker_boost")]
    public bool? CanUseSpeakerBoost { get; set; }

    /// <value>Whether the model serves pro voices.</value>
    [JsonPropertyName("serves_pro_voices")]
    public bool? ServesProVoices { get; set; }

    /// <value>The cost factor for the model.</value>
    [JsonPropertyName("token_cost_factor")]
    public double? TokenCostFactor { get; set; }

    /// <value>The description of the model.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>Whether the model requires alpha access.</value>
    [JsonPropertyName("requires_alpha_access")]
    public bool? RequiresAlphaAccess { get; set; }

    /// <value>Deprecated. Not enforced; use `maximum_text_length_per_request` instead.</value>
    [JsonPropertyName("max_characters_request_free_user")]
    public int? MaxCharactersRequestFreeUser { get; set; }

    /// <value>Deprecated. Not enforced; use `maximum_text_length_per_request` instead.</value>
    [JsonPropertyName("max_characters_request_subscribed_user")]
    public int? MaxCharactersRequestSubscribedUser { get; set; }

    /// <value>The maximum number of input text characters accepted per request for this model. Longer requests are rejected.</value>
    [JsonPropertyName("maximum_text_length_per_request")]
    public int? MaximumTextLengthPerRequest { get; set; }

    /// <value>The languages supported by the model.</value>
    [JsonPropertyName("languages")]
    public IEnumerable<LanguageResponse>? Languages { get; set; }

    [JsonPropertyName("model_rates")]
    public ModelRatesResponseModel? ModelRates { get; set; }

    /// <value>The concurrency group for the model.</value>
    [JsonPropertyName("concurrency_group")]
    public string? ConcurrencyGroup { get; set; }

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
    public virtual bool Equals(Model? other)
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
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(CanBeFinetuned, other.CanBeFinetuned)
            && ValueEquality.AreEqual(CanDoTextToSpeech, other.CanDoTextToSpeech)
            && ValueEquality.AreEqual(CanDoVoiceConversion, other.CanDoVoiceConversion)
            && ValueEquality.AreEqual(CanUseStyle, other.CanUseStyle)
            && ValueEquality.AreEqual(CanUseSpeakerBoost, other.CanUseSpeakerBoost)
            && ValueEquality.AreEqual(ServesProVoices, other.ServesProVoices)
            && ValueEquality.AreEqual(TokenCostFactor, other.TokenCostFactor)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(RequiresAlphaAccess, other.RequiresAlphaAccess)
            && ValueEquality.AreEqual(
                MaxCharactersRequestFreeUser,
                other.MaxCharactersRequestFreeUser
            )
            && ValueEquality.AreEqual(
                MaxCharactersRequestSubscribedUser,
                other.MaxCharactersRequestSubscribedUser
            )
            && ValueEquality.AreEqual(
                MaximumTextLengthPerRequest,
                other.MaximumTextLengthPerRequest
            )
            && ValueEquality.AreEqual(Languages, other.Languages)
            && ValueEquality.AreEqual(ModelRates, other.ModelRates)
            && ValueEquality.AreEqual(ConcurrencyGroup, other.ConcurrencyGroup)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanBeFinetuned);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanDoTextToSpeech);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanDoVoiceConversion);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanUseStyle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanUseSpeakerBoost);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ServesProVoices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TokenCostFactor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequiresAlphaAccess);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxCharactersRequestFreeUser);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxCharactersRequestSubscribedUser);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaximumTextLengthPerRequest);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Languages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelRates);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConcurrencyGroup);
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
