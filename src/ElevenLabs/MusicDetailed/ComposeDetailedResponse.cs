using System.Text.Json.Nodes;

namespace ElevenLabs.Music;

/// <summary>
/// A composed song from <see cref="MusicDetailed.ComposeDetailedAsync"/>: the metadata the API returns
/// with it, the audio file, and its name.
/// </summary>
/// <remarks>Hand-written (see <c>.fernignore</c>), mirroring <c>MultipartResponse</c> in the Python and TypeScript SDKs.</remarks>
public sealed class ComposeDetailedResponse
{
    internal ComposeDetailedResponse(JsonObject json, byte[] audio, string filename, string? songId)
    {
        Json = json;
        Audio = audio;
        Filename = filename;
        SongId = songId;
    }

    /// <summary>
    /// The JSON metadata part as the API sent it (snake_case keys): <c>composition_plan</c>,
    /// <c>song_metadata</c> (title, description, genres, languages, is_explicit),
    /// <c>words_timestamps</c> (null unless <c>WithTimestamps</c> is set) and, with
    /// <c>WithWaveformVisual</c>, <c>waveform_visual</c>.
    /// </summary>
    public JsonObject Json { get; }

    /// <summary>The audio file's bytes, in the requested output format.</summary>
    public byte[] Audio { get; }

    /// <summary>The file name the API suggests for the audio, or <c>generated_music.mp3</c>.</summary>
    public string Filename { get; }

    /// <summary>The <c>song-id</c> response header, sent when <c>StoreForInpainting</c> is set.</summary>
    public string? SongId { get; }
}
