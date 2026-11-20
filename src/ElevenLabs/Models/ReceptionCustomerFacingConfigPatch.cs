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
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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

/// <summary>Rules, procedures and transfer rules are changed through their own endpoints, not here.</summary>
[Serializable]
public record ReceptionCustomerFacingConfigPatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("additional_instructions")]
    public string? AdditionalInstructions { get; set; }

    /// <value>Personality traits for the receptionist, e.g. `['professional', 'concise']`.</value>
    [JsonPropertyName("tone_traits")]
    public IEnumerable<string>? ToneTraits { get; set; }

    /// <value>Details the agent should always try to collect from callers (presets + custom labels, e.g. ['full name', 'phone number']).</value>
    [JsonPropertyName("details_to_collect")]
    public IEnumerable<string>? DetailsToCollect { get; set; }

    /// <value>Model the receptionist runs on. Null uses the default.</value>
    [JsonPropertyName("llm")]
    public Llm? Llm { get; set; }

    /// <value>Reasoning effort for the receptionist's model, up to `medium` and only among the efforts the model supports. Null uses the model's default.</value>
    [JsonPropertyName("reasoning_effort")]
    public LlmReasoningEffort? ReasoningEffort { get; set; }

    /// <value>When true, the whole knowledge base is given to the receptionist up front instead of searched on each turn. Faster, but only for small knowledge bases; larger ones are still searched.</value>
    [JsonPropertyName("disable_rag")]
    public bool? DisableRag { get; set; }

    /// <value>Filter out far-field human speech before transcription.</value>
    [JsonPropertyName("background_voice_detection")]
    public bool? BackgroundVoiceDetection { get; set; }

    /// <value>How quickly the receptionist decides the caller has finished speaking.</value>
    [JsonPropertyName("turn_eagerness")]
    public ReceptionTurnEagerness? TurnEagerness { get; set; }

    /// <value>ElevenLabs voice ID</value>
    [JsonPropertyName("voice_id")]
    public string? VoiceId { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <value>Additional language codes the agent can communicate in</value>
    [JsonPropertyName("additional_languages")]
    public IEnumerable<string>? AdditionalLanguages { get; set; }

    /// <value>The first message the agent says when starting a conversation</value>
    [JsonPropertyName("first_message")]
    public string? FirstMessage { get; set; }

    /// <value>How the receptionist's greeting plays.</value>
    [JsonPropertyName("first_message_mode")]
    public FirstMessageMode? FirstMessageMode { get; set; }

    /// <value>Allow the end_call system tool during conversations.</value>
    [JsonPropertyName("enable_end_call_tool")]
    public bool? EnableEndCallTool { get; set; }

    /// <value>Allow the skip_turn system tool during conversations.</value>
    [JsonPropertyName("enable_skip_turn_tool")]
    public bool? EnableSkipTurnTool { get; set; }

    /// <value>Allow the play_keypad_touch_tone (DTMF) system tool during conversations. When enabled, the receptionist can play touch-tone digits on a live call to navigate automated phone menus or answer carrier prompts such as a 'press 1 to accept' call-screening step.</value>
    [JsonPropertyName("enable_play_keypad_touch_tone_tool")]
    public bool? EnablePlayKeypadTouchToneTool { get; set; }

    /// <value>Show the business's own number, rather than the caller's, as the caller ID on transferred calls.</value>
    [JsonPropertyName("hide_caller_number_on_transfers")]
    public bool? HideCallerNumberOnTransfers { get; set; }

    /// <value>Keep recording after a call is transferred and add that audio to the call recording.</value>
    [JsonPropertyName("record_after_transfers")]
    public bool? RecordAfterTransfers { get; set; }

    /// <value>When enabled, the receptionist may only look up or modify appointments and client records tied to the caller's verified phone number.</value>
    [JsonPropertyName("enable_secure_mode")]
    public bool? EnableSecureMode { get; set; }

    /// <value>When enabled, inbound calls to US numbers are screened before the receptionist answers: calls whose caller ID failed carrier (STIR/SHAKEN) verification are rejected, and unknown callers whose caller ID the carrier could not vouch for must press a key to be connected.</value>
    [JsonPropertyName("enable_spam_protection")]
    public bool? EnableSpamProtection { get; set; }

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
    public virtual bool Equals(ReceptionCustomerFacingConfigPatch? other)
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
            && ValueEquality.AreEqual(AdditionalInstructions, other.AdditionalInstructions)
            && ValueEquality.AreEqual(ToneTraits, other.ToneTraits)
            && ValueEquality.AreEqual(DetailsToCollect, other.DetailsToCollect)
            && ValueEquality.AreEqual(Llm, other.Llm)
            && ValueEquality.AreEqual(ReasoningEffort, other.ReasoningEffort)
            && ValueEquality.AreEqual(DisableRag, other.DisableRag)
            && ValueEquality.AreEqual(BackgroundVoiceDetection, other.BackgroundVoiceDetection)
            && ValueEquality.AreEqual(TurnEagerness, other.TurnEagerness)
            && ValueEquality.AreEqual(VoiceId, other.VoiceId)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(AdditionalLanguages, other.AdditionalLanguages)
            && ValueEquality.AreEqual(FirstMessage, other.FirstMessage)
            && ValueEquality.AreEqual(FirstMessageMode, other.FirstMessageMode)
            && ValueEquality.AreEqual(EnableEndCallTool, other.EnableEndCallTool)
            && ValueEquality.AreEqual(EnableSkipTurnTool, other.EnableSkipTurnTool)
            && ValueEquality.AreEqual(
                EnablePlayKeypadTouchToneTool,
                other.EnablePlayKeypadTouchToneTool
            )
            && ValueEquality.AreEqual(
                HideCallerNumberOnTransfers,
                other.HideCallerNumberOnTransfers
            )
            && ValueEquality.AreEqual(RecordAfterTransfers, other.RecordAfterTransfers)
            && ValueEquality.AreEqual(EnableSecureMode, other.EnableSecureMode)
            && ValueEquality.AreEqual(EnableSpamProtection, other.EnableSpamProtection)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalInstructions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToneTraits);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DetailsToCollect);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Llm);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReasoningEffort);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableRag);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundVoiceDetection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TurnEagerness);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AdditionalLanguages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FirstMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FirstMessageMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableEndCallTool);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableSkipTurnTool);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnablePlayKeypadTouchToneTool);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HideCallerNumberOnTransfers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecordAfterTransfers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableSecureMode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableSpamProtection);
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
