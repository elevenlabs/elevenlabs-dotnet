using ElevenLabs;
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

namespace ElevenLabs.SpeechEngine;

[Serializable]
public record UpdateSpeechEngineRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("speech_engine")]
    public SpeechEngineConfig? SpeechEngine { get; set; }

    [JsonPropertyName("asr")]
    public AsrConversationalConfig? Asr { get; set; }

    [JsonPropertyName("tts")]
    public TtsConversationalConfigInput? Tts { get; set; }

    [JsonPropertyName("turn")]
    public BaseTurnConfig? Turn { get; set; }

    [JsonPropertyName("vad")]
    public VadConfig? Vad { get; set; }

    [JsonPropertyName("conversation")]
    public ConversationConfigInput? Conversation { get; set; }

    [JsonPropertyName("privacy")]
    public PrivacyConfigInput? Privacy { get; set; }

    [JsonPropertyName("call_limits")]
    public AgentCallLimits? CallLimits { get; set; }

    /// <value>Who may start a conversation with this speech engine</value>
    [JsonPropertyName("auth")]
    public SpeechEngineAuthConfig? Auth { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <value>Time in seconds to wait for the upstream speech engine endpoint to respond before the attempt is abandoned and retried. Must be between 2 and 15 seconds.</value>
    [JsonPropertyName("cascade_timeout_seconds")]
    public double? CascadeTimeoutSeconds { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("overrides")]
    public SpeechEngineConversationInitiationClientDataConfig? Overrides { get; set; }

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
    public virtual bool Equals(UpdateSpeechEngineRequest? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(SpeechEngine, other.SpeechEngine)
            && ValueEquality.AreEqual(Asr, other.Asr)
            && ValueEquality.AreEqual(Tts, other.Tts)
            && ValueEquality.AreEqual(Turn, other.Turn)
            && ValueEquality.AreEqual(Vad, other.Vad)
            && ValueEquality.AreEqual(Conversation, other.Conversation)
            && ValueEquality.AreEqual(Privacy, other.Privacy)
            && ValueEquality.AreEqual(CallLimits, other.CallLimits)
            && ValueEquality.AreEqual(Auth, other.Auth)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(CascadeTimeoutSeconds, other.CascadeTimeoutSeconds)
            && ValueEquality.AreEqual(Tags, other.Tags)
            && ValueEquality.AreEqual(Overrides, other.Overrides)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SpeechEngine);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Asr);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tts);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Turn);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Vad);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Conversation);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Privacy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallLimits);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Auth);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CascadeTimeoutSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Overrides);
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
