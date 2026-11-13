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
public record TextToDialogueClientMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("inputs")]
    public IEnumerable<TextToDialogueClientMessageInputsItem>? Inputs { get; set; }

    [JsonPropertyName("flush")]
    public bool? Flush { get; set; }

    [JsonPropertyName("close_socket")]
    public bool? CloseSocket { get; set; }

    [JsonPropertyName("keep_alive")]
    public bool? KeepAlive { get; set; }

    [JsonPropertyName("xi_api_key")]
    public string? XiApiKey { get; set; }

    [JsonPropertyName("authorization")]
    public string? Authorization { get; set; }

    [JsonPropertyName("single_use_token")]
    public string? SingleUseToken { get; set; }

    /// <value>List of voice IDs to register for the connection.</value>
    [JsonPropertyName("voices")]
    public IEnumerable<string>? Voices { get; set; }

    /// <value>Voice settings for the connection.</value>
    [JsonPropertyName("voice_settings")]
    public TextToDialogueClientMessageVoiceSettings? VoiceSettings { get; set; }

    [JsonPropertyName("pronunciation_dictionary_locators")]
    public IEnumerable<TextToDialogueClientMessagePronunciationDictionaryLocatorsItem>? PronunciationDictionaryLocators { get; set; }

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
    public virtual bool Equals(TextToDialogueClientMessage? other)
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
            && ValueEquality.AreEqual(Inputs, other.Inputs)
            && ValueEquality.AreEqual(Flush, other.Flush)
            && ValueEquality.AreEqual(CloseSocket, other.CloseSocket)
            && ValueEquality.AreEqual(KeepAlive, other.KeepAlive)
            && ValueEquality.AreEqual(XiApiKey, other.XiApiKey)
            && ValueEquality.AreEqual(Authorization, other.Authorization)
            && ValueEquality.AreEqual(SingleUseToken, other.SingleUseToken)
            && ValueEquality.AreEqual(Voices, other.Voices)
            && ValueEquality.AreEqual(VoiceSettings, other.VoiceSettings)
            && ValueEquality.AreEqual(
                PronunciationDictionaryLocators,
                other.PronunciationDictionaryLocators
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Inputs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Flush);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CloseSocket);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(KeepAlive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(XiApiKey);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Authorization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SingleUseToken);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Voices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PronunciationDictionaryLocators);
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
