// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectExternalAudioResponseModelSourceContext.JsonConverter))]
[Serializable]
public record ProjectExternalAudioResponseModelSourceContext
{
    internal ProjectExternalAudioResponseModelSourceContext(string type, object? value)
    {
        SourceType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ProjectExternalAudioResponseModelSourceContext with <see cref="ProjectExternalAudioResponseModelSourceContext.MusicExploreSong"/>.
    /// </summary>
    public ProjectExternalAudioResponseModelSourceContext(
        ProjectExternalAudioResponseModelSourceContext.MusicExploreSong value
    )
    {
        SourceType = "music_explore_song";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ProjectExternalAudioResponseModelSourceContext with <see cref="ProjectExternalAudioResponseModelSourceContext.Sfx"/>.
    /// </summary>
    public ProjectExternalAudioResponseModelSourceContext(
        ProjectExternalAudioResponseModelSourceContext.Sfx value
    )
    {
        SourceType = "sfx";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ProjectExternalAudioResponseModelSourceContext with <see cref="ProjectExternalAudioResponseModelSourceContext.Song"/>.
    /// </summary>
    public ProjectExternalAudioResponseModelSourceContext(
        ProjectExternalAudioResponseModelSourceContext.Song value
    )
    {
        SourceType = "song";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("source_type")]
    public string SourceType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="SourceType"/> is "music_explore_song"
    /// </summary>
    public bool IsMusicExploreSong => SourceType == "music_explore_song";

    /// <summary>
    /// Returns true if <see cref="SourceType"/> is "sfx"
    /// </summary>
    public bool IsSfx => SourceType == "sfx";

    /// <summary>
    /// Returns true if <see cref="SourceType"/> is "song"
    /// </summary>
    public bool IsSong => SourceType == "song";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.MusicExploreSongSourceContext"/> if <see cref="SourceType"/> is 'music_explore_song', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SourceType"/> is not 'music_explore_song'.</exception>
    public global::ElevenLabs.MusicExploreSongSourceContext AsMusicExploreSong() =>
        IsMusicExploreSong
            ? (global::ElevenLabs.MusicExploreSongSourceContext)Value!
            : throw new global::System.Exception(
                "ProjectExternalAudioResponseModelSourceContext.SourceType is not 'music_explore_song'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SfxSourceContext"/> if <see cref="SourceType"/> is 'sfx', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SourceType"/> is not 'sfx'.</exception>
    public global::ElevenLabs.SfxSourceContext AsSfx() =>
        IsSfx
            ? (global::ElevenLabs.SfxSourceContext)Value!
            : throw new global::System.Exception(
                "ProjectExternalAudioResponseModelSourceContext.SourceType is not 'sfx'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SongSourceContext"/> if <see cref="SourceType"/> is 'song', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="SourceType"/> is not 'song'.</exception>
    public global::ElevenLabs.SongSourceContext AsSong() =>
        IsSong
            ? (global::ElevenLabs.SongSourceContext)Value!
            : throw new global::System.Exception(
                "ProjectExternalAudioResponseModelSourceContext.SourceType is not 'song'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.MusicExploreSongSourceContext, T> onMusicExploreSong,
        Func<global::ElevenLabs.SfxSourceContext, T> onSfx,
        Func<global::ElevenLabs.SongSourceContext, T> onSong,
        Func<string, object?, T> onUnknown_
    )
    {
        return SourceType switch
        {
            "music_explore_song" => onMusicExploreSong(AsMusicExploreSong()),
            "sfx" => onSfx(AsSfx()),
            "song" => onSong(AsSong()),
            _ => onUnknown_(SourceType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.MusicExploreSongSourceContext> onMusicExploreSong,
        Action<global::ElevenLabs.SfxSourceContext> onSfx,
        Action<global::ElevenLabs.SongSourceContext> onSong,
        Action<string, object?> onUnknown_
    )
    {
        switch (SourceType)
        {
            case "music_explore_song":
                onMusicExploreSong(AsMusicExploreSong());
                break;
            case "sfx":
                onSfx(AsSfx());
                break;
            case "song":
                onSong(AsSong());
                break;
            default:
                onUnknown_(SourceType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.MusicExploreSongSourceContext"/> and returns true if successful.
    /// </summary>
    public bool TryAsMusicExploreSong(out global::ElevenLabs.MusicExploreSongSourceContext? value)
    {
        if (SourceType == "music_explore_song")
        {
            value = (global::ElevenLabs.MusicExploreSongSourceContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SfxSourceContext"/> and returns true if successful.
    /// </summary>
    public bool TryAsSfx(out global::ElevenLabs.SfxSourceContext? value)
    {
        if (SourceType == "sfx")
        {
            value = (global::ElevenLabs.SfxSourceContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SongSourceContext"/> and returns true if successful.
    /// </summary>
    public bool TryAsSong(out global::ElevenLabs.SongSourceContext? value)
    {
        if (SourceType == "song")
        {
            value = (global::ElevenLabs.SongSourceContext)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ProjectExternalAudioResponseModelSourceContext(
        ProjectExternalAudioResponseModelSourceContext.MusicExploreSong value
    ) => new(value);

    public static implicit operator ProjectExternalAudioResponseModelSourceContext(
        ProjectExternalAudioResponseModelSourceContext.Sfx value
    ) => new(value);

    public static implicit operator ProjectExternalAudioResponseModelSourceContext(
        ProjectExternalAudioResponseModelSourceContext.Song value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ProjectExternalAudioResponseModelSourceContext>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ProjectExternalAudioResponseModelSourceContext).IsAssignableFrom(typeToConvert);

        public override ProjectExternalAudioResponseModelSourceContext Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("source_type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'source_type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'source_type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'source_type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'source_type' is null");

            var value = discriminator switch
            {
                "music_explore_song" =>
                    json.Deserialize<global::ElevenLabs.MusicExploreSongSourceContext?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.MusicExploreSongSourceContext"
                        ),
                "sfx" => json.Deserialize<global::ElevenLabs.SfxSourceContext?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SfxSourceContext"
                    ),
                "song" => json.Deserialize<global::ElevenLabs.SongSourceContext?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SongSourceContext"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ProjectExternalAudioResponseModelSourceContext(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectExternalAudioResponseModelSourceContext value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.SourceType switch
                {
                    "music_explore_song" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sfx" => JsonSerializer.SerializeToNode(value.Value, options),
                    "song" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["source_type"] = value.SourceType;
            json.WriteTo(writer, options);
        }

        public override ProjectExternalAudioResponseModelSourceContext ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ProjectExternalAudioResponseModelSourceContext(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectExternalAudioResponseModelSourceContext value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.SourceType);
        }
    }

    /// <summary>
    /// Discriminated union type for music_explore_song
    /// </summary>
    [Serializable]
    public struct MusicExploreSong
    {
        public MusicExploreSong(global::ElevenLabs.MusicExploreSongSourceContext value)
        {
            Value = value;
        }

        internal global::ElevenLabs.MusicExploreSongSourceContext Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ProjectExternalAudioResponseModelSourceContext.MusicExploreSong(
            global::ElevenLabs.MusicExploreSongSourceContext value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sfx
    /// </summary>
    [Serializable]
    public struct Sfx
    {
        public Sfx(global::ElevenLabs.SfxSourceContext value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SfxSourceContext Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ProjectExternalAudioResponseModelSourceContext.Sfx(
            global::ElevenLabs.SfxSourceContext value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for song
    /// </summary>
    [Serializable]
    public struct Song
    {
        public Song(global::ElevenLabs.SongSourceContext value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SongSourceContext Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ProjectExternalAudioResponseModelSourceContext.Song(
            global::ElevenLabs.SongSourceContext value
        ) => new(value);
    }
}
