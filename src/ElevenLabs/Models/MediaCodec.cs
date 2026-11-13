using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MediaCodec.MediaCodecSerializer))]
[Serializable]
public readonly record struct MediaCodec : IStringEnum
{
    public static readonly MediaCodec G7228000 = new(Values.G7228000);

    public static readonly MediaCodec Pcmu8000 = new(Values.Pcmu8000);

    public static readonly MediaCodec Pcma8000 = new(Values.Pcma8000);

    public MediaCodec(string value)
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
    public static MediaCodec FromCustom(string value)
    {
        return new MediaCodec(value);
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

    public static bool operator ==(MediaCodec value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(MediaCodec value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MediaCodec value) => value.Value;

    public static explicit operator MediaCodec(string value) => new(value);

    internal class MediaCodecSerializer : JsonConverter<MediaCodec>
    {
        public override MediaCodec Read(
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
            return new MediaCodec(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MediaCodec value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MediaCodec ReadAsPropertyName(
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
            return new MediaCodec(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MediaCodec value,
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
        public const string G7228000 = "G722/8000";

        public const string Pcmu8000 = "PCMU/8000";

        public const string Pcma8000 = "PCMA/8000";
    }
}
