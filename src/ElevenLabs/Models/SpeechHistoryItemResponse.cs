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
public record SpeechHistoryItemResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the history item.</value>
    [JsonPropertyName("history_item_id")]
    public required string HistoryItemId { get; set; }

    /// <value>The ID of the request.</value>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; set; }

    /// <value>The ID of the voice used.</value>
    [JsonPropertyName("voice_id")]
    public string? VoiceId { get; set; }

    /// <value>The ID of the model.</value>
    [JsonPropertyName("model_id")]
    public string? ModelId { get; set; }

    /// <value>The name of the voice.</value>
    [JsonPropertyName("voice_name")]
    public string? VoiceName { get; set; }

    /// <value>The category of the voice. Either 'premade', 'cloned', 'generated' or 'professional'.</value>
    [JsonPropertyName("voice_category")]
    public SpeechHistoryItemResponseVoiceCategory? VoiceCategory { get; set; }

    /// <value>The text used to generate the audio item.</value>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <value>Unix timestamp of when the item was created.</value>
    [JsonPropertyName("date_unix")]
    public required int DateUnix { get; set; }

    /// <value>The character count change from.</value>
    [JsonPropertyName("character_count_change_from")]
    public required int CharacterCountChangeFrom { get; set; }

    /// <value>The character count change to.</value>
    [JsonPropertyName("character_count_change_to")]
    public required int CharacterCountChangeTo { get; set; }

    /// <value>The content type of the generated item.</value>
    [JsonPropertyName("content_type")]
    public required string ContentType { get; set; }

    [JsonPropertyName("state")]
    public required object State { get; set; }

    /// <value>The settings of the history item.</value>
    [JsonPropertyName("settings")]
    public Dictionary<string, object?>? Settings { get; set; }

    /// <value>The ID of the share link.</value>
    [JsonPropertyName("share_link_id")]
    public string? ShareLinkId { get; set; }

    /// <value>The source of the history item. Either TTS (text to speech), STS (speech to text), AN (audio native), Projects, Dubbing, PlayAPI, PD (pronunciation dictionary) or ConvAI (Agents Platform).</value>
    [JsonPropertyName("source")]
    public SpeechHistoryItemResponseSource? Source { get; set; }

    /// <value>The alignments of the history item.</value>
    [JsonPropertyName("alignments")]
    public HistoryAlignmentsResponseModel? Alignments { get; set; }

    /// <value>The dialogue (voice and text pairs) used to generate the audio item. If this is set then the top level `text` and `voice_id` fields will be empty.</value>
    [JsonPropertyName("dialogue")]
    public IEnumerable<DialogueInputResponseModel>? Dialogue { get; set; }

    /// <value>The output format the audio was originally generated in.</value>
    [JsonPropertyName("output_format")]
    public string? OutputFormat { get; set; }

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
    public virtual bool Equals(SpeechHistoryItemResponse? other)
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
            && ValueEquality.AreEqual(HistoryItemId, other.HistoryItemId)
            && ValueEquality.AreEqual(RequestId, other.RequestId)
            && ValueEquality.AreEqual(VoiceId, other.VoiceId)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(VoiceName, other.VoiceName)
            && ValueEquality.AreEqual(VoiceCategory, other.VoiceCategory)
            && ValueEquality.AreEqual(Text, other.Text)
            && ValueEquality.AreEqual(DateUnix, other.DateUnix)
            && ValueEquality.AreEqual(CharacterCountChangeFrom, other.CharacterCountChangeFrom)
            && ValueEquality.AreEqual(CharacterCountChangeTo, other.CharacterCountChangeTo)
            && ValueEquality.AreEqual(ContentType, other.ContentType)
            && ValueEquality.AreEqual(State, other.State)
            && ValueEquality.AreEqual(Settings, other.Settings)
            && ValueEquality.AreEqual(ShareLinkId, other.ShareLinkId)
            && ValueEquality.AreEqual(Source, other.Source)
            && ValueEquality.AreEqual(Alignments, other.Alignments)
            && ValueEquality.AreEqual(Dialogue, other.Dialogue)
            && ValueEquality.AreEqual(OutputFormat, other.OutputFormat)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HistoryItemId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RequestId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceCategory);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Text);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DateUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterCountChangeFrom);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterCountChangeTo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(State);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Settings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShareLinkId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Source);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Alignments);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Dialogue);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OutputFormat);
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
