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
public record AudioNativeProjectSettingsResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The title of the project.</value>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <value>The image of the project.</value>
    [JsonPropertyName("image")]
    public required string Image { get; set; }

    /// <value>The author of the project.</value>
    [JsonPropertyName("author")]
    public required string Author { get; set; }

    /// <value>Whether the project is small.</value>
    [JsonPropertyName("small")]
    public required bool Small { get; set; }

    /// <value>The text color of the project.</value>
    [JsonPropertyName("text_color")]
    public required string TextColor { get; set; }

    /// <value>The background color of the project.</value>
    [JsonPropertyName("background_color")]
    public required string BackgroundColor { get; set; }

    /// <value>The sessionization of the project. Specifies for how many minutes to persist the session across page reloads.</value>
    [JsonPropertyName("sessionization")]
    public required int Sessionization { get; set; }

    /// <value>The path of the audio file.</value>
    [JsonPropertyName("audio_path")]
    public string? AudioPath { get; set; }

    /// <value>The URL of the audio file.</value>
    [JsonPropertyName("audio_url")]
    public string? AudioUrl { get; set; }

    /// <value>Current state of the project</value>
    [JsonPropertyName("status")]
    public AudioNativeProjectSettingsResponseModelStatus? Status { get; set; }

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
    public virtual bool Equals(AudioNativeProjectSettingsResponseModel? other)
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
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(Image, other.Image)
            && ValueEquality.AreEqual(Author, other.Author)
            && ValueEquality.AreEqual(Small, other.Small)
            && ValueEquality.AreEqual(TextColor, other.TextColor)
            && ValueEquality.AreEqual(BackgroundColor, other.BackgroundColor)
            && ValueEquality.AreEqual(Sessionization, other.Sessionization)
            && ValueEquality.AreEqual(AudioPath, other.AudioPath)
            && ValueEquality.AreEqual(AudioUrl, other.AudioUrl)
            && ValueEquality.AreEqual(Status, other.Status)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Image);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Author);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Small);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Sessionization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AudioPath);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AudioUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
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
