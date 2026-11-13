using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The kind of output: the `type` of the port's `content_schema`.</summary>
[JsonConverter(typeof(TemplateIntegerOutputType.TemplateIntegerOutputTypeSerializer))]
[Serializable]
public readonly record struct TemplateIntegerOutputType : IStringEnum
{
    public static readonly TemplateIntegerOutputType Integer = new(Values.Integer);

    public TemplateIntegerOutputType(string value)
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
    public static TemplateIntegerOutputType FromCustom(string value)
    {
        return new TemplateIntegerOutputType(value);
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

    public static bool operator ==(TemplateIntegerOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateIntegerOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateIntegerOutputType value) => value.Value;

    public static explicit operator TemplateIntegerOutputType(string value) => new(value);

    internal class TemplateIntegerOutputTypeSerializer : JsonConverter<TemplateIntegerOutputType>
    {
        public override TemplateIntegerOutputType Read(
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
            return new TemplateIntegerOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateIntegerOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateIntegerOutputType ReadAsPropertyName(
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
            return new TemplateIntegerOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateIntegerOutputType value,
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
        public const string Integer = "integer";
    }
}
