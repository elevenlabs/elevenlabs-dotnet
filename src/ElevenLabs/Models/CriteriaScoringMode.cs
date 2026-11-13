using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CriteriaScoringMode.CriteriaScoringModeSerializer))]
[Serializable]
public readonly record struct CriteriaScoringMode : IStringEnum
{
    public static readonly CriteriaScoringMode Binary = new(Values.Binary);

    public static readonly CriteriaScoringMode NumericUniform = new(Values.NumericUniform);

    public CriteriaScoringMode(string value)
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
    public static CriteriaScoringMode FromCustom(string value)
    {
        return new CriteriaScoringMode(value);
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

    public static bool operator ==(CriteriaScoringMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CriteriaScoringMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CriteriaScoringMode value) => value.Value;

    public static explicit operator CriteriaScoringMode(string value) => new(value);

    internal class CriteriaScoringModeSerializer : JsonConverter<CriteriaScoringMode>
    {
        public override CriteriaScoringMode Read(
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
            return new CriteriaScoringMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CriteriaScoringMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CriteriaScoringMode ReadAsPropertyName(
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
            return new CriteriaScoringMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CriteriaScoringMode value,
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
        public const string Binary = "binary";

        public const string NumericUniform = "numeric_uniform";
    }
}
