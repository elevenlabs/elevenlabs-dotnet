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

/// <summary>
/// System tools a conversational agent can be given.
///
/// Deliberately not named ConversationalBuiltInTools: BuiltInToolsInput and
/// BuiltInToolsOutput are part of the public API spec and the generated SDKs.
/// </summary>
[Serializable]
public record BuiltInToolsInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The transfer to agent tool</value>
    [JsonPropertyName("transfer_to_agent")]
    public SystemToolConfigInput? TransferToAgent { get; set; }

    /// <value>The end call tool</value>
    [JsonPropertyName("end_call")]
    public SystemToolConfigInput? EndCall { get; set; }

    /// <value>The language detection tool</value>
    [JsonPropertyName("language_detection")]
    public SystemToolConfigInput? LanguageDetection { get; set; }

    /// <value>The transfer to number tool</value>
    [JsonPropertyName("transfer_to_number")]
    public SystemToolConfigInput? TransferToNumber { get; set; }

    /// <value>The skip turn tool</value>
    [JsonPropertyName("skip_turn")]
    public SystemToolConfigInput? SkipTurn { get; set; }

    /// <value>The play DTMF tool</value>
    [JsonPropertyName("play_keypad_touch_tone")]
    public SystemToolConfigInput? PlayKeypadTouchTone { get; set; }

    /// <value>The voicemail detection tool</value>
    [JsonPropertyName("voicemail_detection")]
    public SystemToolConfigInput? VoicemailDetection { get; set; }

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
    public virtual bool Equals(BuiltInToolsInput? other)
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
            && ValueEquality.AreEqual(TransferToAgent, other.TransferToAgent)
            && ValueEquality.AreEqual(EndCall, other.EndCall)
            && ValueEquality.AreEqual(LanguageDetection, other.LanguageDetection)
            && ValueEquality.AreEqual(TransferToNumber, other.TransferToNumber)
            && ValueEquality.AreEqual(SkipTurn, other.SkipTurn)
            && ValueEquality.AreEqual(PlayKeypadTouchTone, other.PlayKeypadTouchTone)
            && ValueEquality.AreEqual(VoicemailDetection, other.VoicemailDetection)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TransferToAgent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageDetection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TransferToNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SkipTurn);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlayKeypadTouchTone);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoicemailDetection);
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
