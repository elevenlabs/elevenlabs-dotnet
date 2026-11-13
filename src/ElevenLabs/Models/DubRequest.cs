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
public record DubRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>A list of file paths to audio recordings intended for voice cloning</value>
    [JsonPropertyName("file")]
    public FileParameter? File { get; set; }

    /// <value>CSV file containing transcription/translation metadata</value>
    [JsonPropertyName("csv_file")]
    public FileParameter? CsvFile { get; set; }

    /// <value>For use only with csv input</value>
    [JsonPropertyName("foreground_audio_file")]
    public FileParameter? ForegroundAudioFile { get; set; }

    /// <value>For use only with csv input</value>
    [JsonPropertyName("background_audio_file")]
    public FileParameter? BackgroundAudioFile { get; set; }

    /// <value>Name of the dubbing project.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>URL of the source video/audio file.</value>
    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; set; }

    /// <value>Source language. Expects a valid iso639-1 or iso639-3 language code.</value>
    [JsonPropertyName("source_lang")]
    public string? SourceLang { get; set; }

    /// <value>The Target language to dub the content into. Expects a valid iso639-1 or iso639-3 language code.</value>
    [JsonPropertyName("target_lang")]
    public string? TargetLang { get; set; }

    /// <value>[Experimental] An accent to apply when selecting voices from the library and to use to inform translation of the dialect to prefer.</value>
    [JsonPropertyName("target_accent")]
    public string? TargetAccent { get; set; }

    /// <value>Number of speakers to use for the dubbing. Set to 0 to automatically detect the number of speakers</value>
    [JsonPropertyName("num_speakers")]
    public int? NumSpeakers { get; set; }

    /// <value>Whether to apply watermark to the output video.</value>
    [JsonPropertyName("watermark")]
    public bool? Watermark { get; set; }

    /// <value>Start time of the source video/audio file.</value>
    [JsonPropertyName("start_time")]
    public int? StartTime { get; set; }

    /// <value>End time of the source video/audio file.</value>
    [JsonPropertyName("end_time")]
    public int? EndTime { get; set; }

    /// <value>Whether to use the highest resolution available.</value>
    [JsonPropertyName("highest_resolution")]
    public bool? HighestResolution { get; set; }

    /// <value>An advanced setting. Whether to drop background audio from the final dub. This can improve dub quality where it's known that audio shouldn't have a background track such as for speeches or monologues.</value>
    [JsonPropertyName("drop_background_audio")]
    public bool? DropBackgroundAudio { get; set; }

    /// <value>[BETA] Whether transcripts should have profanities censored with the words '[censored]'</value>
    [JsonPropertyName("use_profanity_filter")]
    public bool? UseProfanityFilter { get; set; }

    /// <value>Whether to prepare dub for edits in dubbing studio or edits as a dubbing resource.</value>
    [JsonPropertyName("dubbing_studio")]
    public bool? DubbingStudio { get; set; }

    /// <value>Instead of using a voice clone in dubbing, use a similar voice from the ElevenLabs Voice Library. Voices used from the library will contribute towards a workspace's custom voices limit, and if there aren't enough available slots the dub will fail. Using this feature requires the caller to have the 'add_voice_from_voice_library' permission on their workspace to access new voices.</value>
    [JsonPropertyName("disable_voice_cloning")]
    public bool? DisableVoiceCloning { get; set; }

    /// <value>The mode in which to run this Dubbing job. Defaults to automatic, use manual if specifically providing a CSV transcript to use. Note that manual mode is experimental and production use is strongly discouraged.</value>
    [JsonPropertyName("mode")]
    public DubRequestMode? Mode { get; set; }

    /// <value>Frames per second to use when parsing a CSV file for dubbing. If not provided, FPS will be inferred from timecodes.</value>
    [JsonPropertyName("csv_fps")]
    public double? CsvFps { get; set; }

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
    public virtual bool Equals(DubRequest? other)
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
            && ValueEquality.AreEqual(File, other.File)
            && ValueEquality.AreEqual(CsvFile, other.CsvFile)
            && ValueEquality.AreEqual(ForegroundAudioFile, other.ForegroundAudioFile)
            && ValueEquality.AreEqual(BackgroundAudioFile, other.BackgroundAudioFile)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(SourceUrl, other.SourceUrl)
            && ValueEquality.AreEqual(SourceLang, other.SourceLang)
            && ValueEquality.AreEqual(TargetLang, other.TargetLang)
            && ValueEquality.AreEqual(TargetAccent, other.TargetAccent)
            && ValueEquality.AreEqual(NumSpeakers, other.NumSpeakers)
            && ValueEquality.AreEqual(Watermark, other.Watermark)
            && ValueEquality.AreEqual(StartTime, other.StartTime)
            && ValueEquality.AreEqual(EndTime, other.EndTime)
            && ValueEquality.AreEqual(HighestResolution, other.HighestResolution)
            && ValueEquality.AreEqual(DropBackgroundAudio, other.DropBackgroundAudio)
            && ValueEquality.AreEqual(UseProfanityFilter, other.UseProfanityFilter)
            && ValueEquality.AreEqual(DubbingStudio, other.DubbingStudio)
            && ValueEquality.AreEqual(DisableVoiceCloning, other.DisableVoiceCloning)
            && ValueEquality.AreEqual(Mode, other.Mode)
            && ValueEquality.AreEqual(CsvFps, other.CsvFps)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(File);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CsvFile);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ForegroundAudioFile);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BackgroundAudioFile);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceLang);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetLang);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetAccent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NumSpeakers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Watermark);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HighestResolution);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DropBackgroundAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseProfanityFilter);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DubbingStudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DisableVoiceCloning);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Mode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CsvFps);
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
