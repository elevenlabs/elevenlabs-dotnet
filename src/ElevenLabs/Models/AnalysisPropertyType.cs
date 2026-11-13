using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AnalysisPropertyType.AnalysisPropertyTypeSerializer))]
[Serializable]
public readonly record struct AnalysisPropertyType : IStringEnum
{
    public static readonly AnalysisPropertyType Boolean = new(Values.Boolean);

    public static readonly AnalysisPropertyType String = new(Values.String);

    public static readonly AnalysisPropertyType Integer = new(Values.Integer);

    public static readonly AnalysisPropertyType Number = new(Values.Number);

    public AnalysisPropertyType(string value)
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
    public static AnalysisPropertyType FromCustom(string value)
    {
        return new AnalysisPropertyType(value);
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

    public static bool operator ==(AnalysisPropertyType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AnalysisPropertyType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AnalysisPropertyType value) => value.Value;

    public static explicit operator AnalysisPropertyType(string value) => new(value);

    internal class AnalysisPropertyTypeSerializer : JsonConverter<AnalysisPropertyType>
    {
        public override AnalysisPropertyType Read(
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
            return new AnalysisPropertyType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AnalysisPropertyType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AnalysisPropertyType ReadAsPropertyName(
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
            return new AnalysisPropertyType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AnalysisPropertyType value,
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
        public const string Boolean = "boolean";

        public const string String = "string";

        public const string Integer = "integer";

        public const string Number = "number";
    }
}
