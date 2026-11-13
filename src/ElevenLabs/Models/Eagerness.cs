using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Eagerness.EagernessSerializer))]
[Serializable]
public readonly record struct Eagerness : IStringEnum
{
    public static readonly Eagerness Low = new(Values.Low);

    public static readonly Eagerness Medium = new(Values.Medium);

    public static readonly Eagerness High = new(Values.High);

    public Eagerness(string value)
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
    public static Eagerness FromCustom(string value)
    {
        return new Eagerness(value);
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

    public static bool operator ==(Eagerness value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Eagerness value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Eagerness value) => value.Value;

    public static explicit operator Eagerness(string value) => new(value);

    internal class EagernessSerializer : JsonConverter<Eagerness>
    {
        public override Eagerness Read(
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
            return new Eagerness(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Eagerness value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Eagerness ReadAsPropertyName(
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
            return new Eagerness(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Eagerness value,
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
