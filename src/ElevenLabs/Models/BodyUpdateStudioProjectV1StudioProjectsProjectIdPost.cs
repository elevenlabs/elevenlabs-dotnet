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

namespace ElevenLabs.Studio;

[Serializable]
public record BodyUpdateStudioProjectV1StudioProjectsProjectIdPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The name of the Studio project, used for identification only.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The voice_id that corresponds to the default voice used for new titles.</value>
    [JsonPropertyName("default_title_voice_id")]
    public required string DefaultTitleVoiceId { get; set; }

    /// <value>The voice_id that corresponds to the default voice used for new paragraphs.</value>
    [JsonPropertyName("default_paragraph_voice_id")]
    public required string DefaultParagraphVoiceId { get; set; }

    /// <value>An optional name of the author of the Studio project, this will be added as metadata to the mp3 file on Studio project or chapter download.</value>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <value>An optional name of the author of the Studio project, this will be added as metadata to the mp3 file on Studio project or chapter download.</value>
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    /// <value>An optional ISBN number of the Studio project you want to create, this will be added as metadata to the mp3 file on Studio project or chapter download.</value>
    [JsonPropertyName("isbn_number")]
    public string? IsbnNumber { get; set; }

    /// <value>When the Studio project is downloaded, should the returned audio have postprocessing in order to make it compliant with audiobook normalized volume requirements</value>
    [JsonPropertyName("volume_normalization")]
    public bool? VolumeNormalization { get; set; }

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
    public virtual bool Equals(BodyUpdateStudioProjectV1StudioProjectsProjectIdPost? other)
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
            && ValueEquality.AreEqual(DefaultTitleVoiceId, other.DefaultTitleVoiceId)
            && ValueEquality.AreEqual(DefaultParagraphVoiceId, other.DefaultParagraphVoiceId)
            && ValueEquality.AreEqual(Title, other.Title)
            && ValueEquality.AreEqual(Author, other.Author)
            && ValueEquality.AreEqual(IsbnNumber, other.IsbnNumber)
            && ValueEquality.AreEqual(VolumeNormalization, other.VolumeNormalization)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultTitleVoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultParagraphVoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Title);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Author);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsbnNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VolumeNormalization);
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
