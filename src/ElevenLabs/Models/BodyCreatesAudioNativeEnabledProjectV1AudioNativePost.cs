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
public record BodyCreatesAudioNativeEnabledProjectV1AudioNativePost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Project name.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>(Deprecated) Image URL used in the player. If not provided, default image set in the Player settings is used.</value>
    [JsonPropertyName("image")]
    public string? Image { get; set; }

    /// <value>Author used in the player and inserted at the start of the uploaded article. If not provided, the default author set in the Player settings is used.</value>
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    /// <value>Title used in the player and inserted at the top of the uploaded article. If not provided, the default title set in the Player settings is used.</value>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <value>(Deprecated) Whether to use small player or not. If not provided, default value set in the Player settings is used.</value>
    [JsonPropertyName("small")]
    public bool? Small { get; set; }

    /// <value>Text color used in the player. If not provided, default text color set in the Player settings is used.</value>
    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }

    /// <value>Background color used in the player. If not provided, default background color set in the Player settings is used.</value>
    [JsonPropertyName("background_color")]
    public string? BackgroundColor { get; set; }

    /// <value>(Deprecated) Specifies for how many minutes to persist the session across page reloads. If not provided, default sessionization set in the Player settings is used.</value>
    [JsonPropertyName("sessionization")]
    public int? Sessionization { get; set; }

    /// <value>Voice ID used to voice the content. If not provided, default voice ID set in the Player settings is used.</value>
    [JsonPropertyName("voice_id")]
    public string? VoiceId { get; set; }

    /// <value>TTS Model ID used in the player. If not provided, default model ID set in the Player settings is used.</value>
    [JsonPropertyName("model_id")]
    public string? ModelId { get; set; }

    /// <value>Either txt or HTML input file containing the article content. HTML should be formatted as follows '&amp;lt;html&amp;gt;&amp;lt;body&amp;gt;&amp;lt;div&amp;gt;&amp;lt;p&amp;gt;Your content&amp;lt;/p&amp;gt;&amp;lt;h3&amp;gt;More of your content&amp;lt;/h3&amp;gt;&amp;lt;p&amp;gt;Some more of your content&amp;lt;/p&amp;gt;&amp;lt;/div&amp;gt;&amp;lt;/body&amp;gt;&amp;lt;/html&amp;gt;'</value>
    [JsonPropertyName("file")]
    public FileParameter? File { get; set; }

    /// <value>Whether to auto convert the project to audio or not.</value>
    [JsonPropertyName("auto_convert")]
    public bool? AutoConvert { get; set; }

    /// <value>
    /// This parameter controls text normalization with four modes: 'auto', 'on', 'apply_english' and 'off'.
    ///     When set to 'auto', the system will automatically decide whether to apply text normalization
    ///     (e.g., spelling out numbers). With 'on', text normalization will always be applied, while
    ///     with 'off', it will be skipped. 'apply_english' is the same as 'on' but will assume that text is in English.
    /// </value>
    [JsonPropertyName("apply_text_normalization")]
    public BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization? ApplyTextNormalization { get; set; }

    /// <value>A list of pronunciation dictionary locators (pronunciation_dictionary_id, version_id) encoded as a list of JSON strings for pronunciation dictionaries to be applied to the text. A list of json encoded strings is required as adding projects may occur through formData as opposed to jsonBody. To specify multiple dictionaries use multiple --form lines in your curl, such as --form 'pronunciation_dictionary_locators="{\"pronunciation_dictionary_id\":\"Vmd4Zor6fplcA7WrINey\",\"version_id\":\"hRPaxjlTdR7wFMhV4w0b\"}"' --form 'pronunciation_dictionary_locators="{\"pronunciation_dictionary_id\":\"JzWtcGQMJ6bnlWwyMo7e\",\"version_id\":\"lbmwxiLu4q6txYxgdZqn\"}"'.</value>
    [JsonPropertyName("pronunciation_dictionary_locators")]
    public IEnumerable<string>? PronunciationDictionaryLocators { get; set; }

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
    public virtual bool Equals(BodyCreatesAudioNativeEnabledProjectV1AudioNativePost? other)
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
            && ValueEquality.AreEqual(Image, other.Image)
            && ValueEquality.AreEqual(Author, other.Author)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(Small, other.Small)
            && ValueEquality.AreEqual(TextColor, other.TextColor)
            && ValueEquality.AreEqual(BackgroundColor, other.BackgroundColor)
            && ValueEquality.AreEqual(Sessionization, other.Sessionization)
            && ValueEquality.AreEqual(VoiceId, other.VoiceId)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(File, other.File)
            && ValueEquality.AreEqual(AutoConvert, other.AutoConvert)
            && ValueEquality.AreEqual(ApplyTextNormalization, other.ApplyTextNormalization)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Image);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Author);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Small);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TextColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundColor);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Sessionization);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(File);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoConvert);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ApplyTextNormalization);
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
