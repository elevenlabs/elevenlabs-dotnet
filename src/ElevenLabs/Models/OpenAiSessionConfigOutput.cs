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
using OneOf;

namespace ElevenLabs;

[Serializable]
public record OpenAiSessionConfigOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public OpenAiSessionConfigOutputType? Type { get; set; }

    [JsonPropertyName("model")]
    public RealtimeModel? Model { get; set; }

    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    [JsonPropertyName("output_modalities")]
    public IEnumerable<string>? OutputModalities { get; set; }

    [JsonPropertyName("audio")]
    public OpenAiAudioConfigOutput? Audio { get; set; }

    [JsonPropertyName("tools")]
    public IEnumerable<OpenAiSessionConfigOutputToolsItem>? Tools { get; set; }

    [JsonPropertyName("tool_choice")]
    public OneOf<string, OpenAiToolChoiceFunction>? ToolChoice { get; set; }

    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }

    [JsonPropertyName("max_response_output_tokens")]
    public OneOf<int, MaxResponseOutputTokens22>? MaxResponseOutputTokens { get; set; }

    /// <value>Maximum wall-clock duration of the session in seconds. The session is closed with code 1000 once it is exceeded.</value>
    [JsonPropertyName("max_duration_seconds")]
    public int? MaxDurationSeconds { get; set; }

    [JsonPropertyName("tracing")]
    public OneOf<
        OpenAiSessionConfigOutputTracing1,
        OpenAiTracingConfiguration
    >? Tracing { get; set; }

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
    public virtual bool Equals(OpenAiSessionConfigOutput? other)
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
            && ValueEquality.AreEqual(Type, other.Type)
            && ValueEquality.AreEqual(Model, other.Model)
            && ValueEquality.AreEqual(Instructions, other.Instructions)
            && ValueEquality.AreEqual(OutputModalities, other.OutputModalities)
            && ValueEquality.AreEqual(Audio, other.Audio)
            && ValueEquality.AreEqual(Tools, other.Tools)
            && ValueEquality.AreEqual(ToolChoice, other.ToolChoice)
            && ValueEquality.AreEqual(Temperature, other.Temperature)
            && ValueEquality.AreEqual(MaxResponseOutputTokens, other.MaxResponseOutputTokens)
            && ValueEquality.AreEqual(MaxDurationSeconds, other.MaxDurationSeconds)
            && ValueEquality.AreEqual(Tracing, other.Tracing)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Model);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Instructions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OutputModalities);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Audio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tools);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolChoice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Temperature);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxResponseOutputTokens);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxDurationSeconds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tracing);
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
