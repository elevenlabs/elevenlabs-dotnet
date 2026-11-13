using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(MusicExploreSongSourceContextSourceType.MusicExploreSongSourceContextSourceTypeSerializer)
)]
[Serializable]
public readonly record struct MusicExploreSongSourceContextSourceType : IStringEnum
{
    public static readonly MusicExploreSongSourceContextSourceType MusicExploreSong = new(
        Values.MusicExploreSong
    );

    public MusicExploreSongSourceContextSourceType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static MusicExploreSongSourceContextSourceType FromCustom(string value)
    {
        return new MusicExploreSongSourceContextSourceType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(MusicExploreSongSourceContextSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicExploreSongSourceContextSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicExploreSongSourceContextSourceType value) =>
        value.Value;

    public static explicit operator MusicExploreSongSourceContextSourceType(string value) =>
        new(value);

    internal class MusicExploreSongSourceContextSourceTypeSerializer
        : JsonConverter<MusicExploreSongSourceContextSourceType>
    {
        public override MusicExploreSongSourceContextSourceType Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new MusicExploreSongSourceContextSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicExploreSongSourceContextSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicExploreSongSourceContextSourceType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new MusicExploreSongSourceContextSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicExploreSongSourceContextSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string MusicExploreSong = "music_explore_song";
    }
}
