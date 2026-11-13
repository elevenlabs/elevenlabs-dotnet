using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(RenderType.RenderTypeSerializer))]
[Serializable]
public readonly record struct RenderType : IStringEnum
{
    public static readonly RenderType Mp4 = new(Values.Mp4);

    public static readonly RenderType Aac = new(Values.Aac);

    public static readonly RenderType Mp3 = new(Values.Mp3);

    public static readonly RenderType Wav = new(Values.Wav);

    public static readonly RenderType Aaf = new(Values.Aaf);

    public static readonly RenderType TracksZip = new(Values.TracksZip);

    public static readonly RenderType ClipsZip = new(Values.ClipsZip);

    public static readonly RenderType Zip = new(Values.Zip);

    public RenderType(string value)
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
    public static RenderType FromCustom(string value)
    {
        return new RenderType(value);
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

    public static bool operator ==(RenderType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(RenderType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RenderType value) => value.Value;

    public static explicit operator RenderType(string value) => new(value);

    internal class RenderTypeSerializer : JsonConverter<RenderType>
    {
        public override RenderType Read(
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
            return new RenderType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RenderType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RenderType ReadAsPropertyName(
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
            return new RenderType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RenderType value,
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
        public const string Mp4 = "mp4";

        public const string Aac = "aac";

        public const string Mp3 = "mp3";

        public const string Wav = "wav";

        public const string Aaf = "aaf";

        public const string TracksZip = "tracks_zip";

        public const string ClipsZip = "clips_zip";

        public const string Zip = "zip";
    }
}
