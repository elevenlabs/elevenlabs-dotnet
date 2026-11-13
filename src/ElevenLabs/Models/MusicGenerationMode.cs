using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicGenerationMode.MusicGenerationModeSerializer))]
[Serializable]
public readonly record struct MusicGenerationMode : IStringEnum
{
    public static readonly MusicGenerationMode Track = new(Values.Track);

    public static readonly MusicGenerationMode Loop = new(Values.Loop);

    public static readonly MusicGenerationMode Ambience = new(Values.Ambience);

    public static readonly MusicGenerationMode VideoToMusic = new(Values.VideoToMusic);

    public MusicGenerationMode(string value)
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
    public static MusicGenerationMode FromCustom(string value)
    {
        return new MusicGenerationMode(value);
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

    public static bool operator ==(MusicGenerationMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicGenerationMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicGenerationMode value) => value.Value;

    public static explicit operator MusicGenerationMode(string value) => new(value);

    internal class MusicGenerationModeSerializer : JsonConverter<MusicGenerationMode>
    {
        public override MusicGenerationMode Read(
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
            return new MusicGenerationMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicGenerationMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicGenerationMode ReadAsPropertyName(
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
            return new MusicGenerationMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicGenerationMode value,
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
        public const string Track = "track";

        public const string Loop = "loop";

        public const string Ambience = "ambience";

        public const string VideoToMusic = "video_to_music";
    }
}
