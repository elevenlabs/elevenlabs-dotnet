using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicOutputFormat2.MusicOutputFormat2Serializer))]
[Serializable]
public readonly record struct MusicOutputFormat2 : IStringEnum
{
    public static readonly MusicOutputFormat2 Auto = new(Values.Auto);

    public MusicOutputFormat2(string value)
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
    public static MusicOutputFormat2 FromCustom(string value)
    {
        return new MusicOutputFormat2(value);
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

    public static bool operator ==(MusicOutputFormat2 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicOutputFormat2 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicOutputFormat2 value) => value.Value;

    public static explicit operator MusicOutputFormat2(string value) => new(value);

    internal class MusicOutputFormat2Serializer : JsonConverter<MusicOutputFormat2>
    {
        public override MusicOutputFormat2 Read(
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
            return new MusicOutputFormat2(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicOutputFormat2 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicOutputFormat2 ReadAsPropertyName(
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
            return new MusicOutputFormat2(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicOutputFormat2 value,
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
        public const string Auto = "auto";
    }
}
