using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Threshold2.Threshold2Serializer))]
[Serializable]
public readonly record struct Threshold2 : IStringEnum
{
    public static readonly Threshold2 Low = new(Values.Low);

    public static readonly Threshold2 Medium = new(Values.Medium);

    public static readonly Threshold2 High = new(Values.High);

    public Threshold2(string value)
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
    public static Threshold2 FromCustom(string value)
    {
        return new Threshold2(value);
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

    public static bool operator ==(Threshold2 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Threshold2 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Threshold2 value) => value.Value;

    public static explicit operator Threshold2(string value) => new(value);

    internal class Threshold2Serializer : JsonConverter<Threshold2>
    {
        public override Threshold2 Read(
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
            return new Threshold2(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Threshold2 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Threshold2 ReadAsPropertyName(
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
            return new Threshold2(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Threshold2 value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";
    }
}
