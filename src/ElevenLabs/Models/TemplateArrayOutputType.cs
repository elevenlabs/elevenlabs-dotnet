using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The kind of output: the `type` of the port's `content_schema`.</summary>
[JsonConverter(typeof(TemplateArrayOutputType.TemplateArrayOutputTypeSerializer))]
[Serializable]
public readonly record struct TemplateArrayOutputType : IStringEnum
{
    public static readonly TemplateArrayOutputType Array = new(Values.Array);

    public TemplateArrayOutputType(string value)
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
    public static TemplateArrayOutputType FromCustom(string value)
    {
        return new TemplateArrayOutputType(value);
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

    public static bool operator ==(TemplateArrayOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateArrayOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateArrayOutputType value) => value.Value;

    public static explicit operator TemplateArrayOutputType(string value) => new(value);

    internal class TemplateArrayOutputTypeSerializer : JsonConverter<TemplateArrayOutputType>
    {
        public override TemplateArrayOutputType Read(
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
            return new TemplateArrayOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateArrayOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateArrayOutputType ReadAsPropertyName(
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
            return new TemplateArrayOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateArrayOutputType value,
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
        public const string Array = "array";
    }
}
