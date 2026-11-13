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
public record BodyVideoToMusicV1MusicVideoToMusicPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>
    /// One or more video files sent via FormData array (multipart/form-data). They will be combined into one codec in order.
    ///             A maximum of 10 videos is allowed, where the total size of the combined video is limited to 200MB.
    ///             In total, the video can be up to 600 seconds long. Note that combining multiple videos may increase the request duration significantly. If possible, combine the videos beforehand.
    /// </value>
    [JsonPropertyName("videos")]
    public IEnumerable<FileParameter> Videos { get; set; } = new List<FileParameter>();

    /// <value>Optional text description of the music you want. A maximum of 4100 characters is allowed.</value>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <value>Optional list of style tags (e.g. ['upbeat', 'cinematic']). A maximum of 10 tags is allowed.</value>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("model_id")]
    public MusicModelId? ModelId { get; set; }

    /// <value>When true, incorporate SFX cues from the video.</value>
    [JsonPropertyName("add_sfx")]
    public bool? AddSfx { get; set; }

    /// <value>When true, return a ZIP with separate music and SFX audio tracks instead of a single mixed file. Use this for more flexibility to layer the tracks.</value>
    [JsonPropertyName("separate_tracks")]
    public bool? SeparateTracks { get; set; }

    /// <value>When true, analyze the video's audio track and use its genres, BPM, instrumentation, mood, and arc as reference characteristics for music generation.</value>
    [JsonPropertyName("use_audio_as_reference")]
    public bool? UseAudioAsReference { get; set; }

    /// <value>Whether to sign the generated song with C2PA. Applicable only for mp3 files.</value>
    [JsonPropertyName("sign_with_c2pa")]
    public bool? SignWithC2Pa { get; set; }

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
    public virtual bool Equals(BodyVideoToMusicV1MusicVideoToMusicPost? other)
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
            && ValueEquality.AreEqual(Videos, other.Videos)
            && ValueEquality.AreEqual(Description, other.Description)
            && ValueEquality.AreEqual(Tags, other.Tags)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(AddSfx, other.AddSfx)
            && ValueEquality.AreEqual(SeparateTracks, other.SeparateTracks)
            && ValueEquality.AreEqual(UseAudioAsReference, other.UseAudioAsReference)
            && ValueEquality.AreEqual(SignWithC2Pa, other.SignWithC2Pa)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Videos);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Description);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AddSfx);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SeparateTracks);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseAudioAsReference);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SignWithC2Pa);
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
