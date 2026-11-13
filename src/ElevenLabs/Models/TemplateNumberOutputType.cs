using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The kind of output: the `type` of the port's `content_schema`.</summary>
[JsonConverter(typeof(TemplateNumberOutputType.TemplateNumberOutputTypeSerializer))]
[Serializable]
public readonly record struct TemplateNumberOutputType : IStringEnum
{
    public static readonly TemplateNumberOutputType Number = new(Values.Number);

    public TemplateNumberOutputType(string value)
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
    public static TemplateNumberOutputType FromCustom(string value)
    {
        return new TemplateNumberOutputType(value);
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

    public static bool operator ==(TemplateNumberOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateNumberOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateNumberOutputType value) => value.Value;

    public static explicit operator TemplateNumberOutputType(string value) => new(value);

    internal class TemplateNumberOutputTypeSerializer : JsonConverter<TemplateNumberOutputType>
    {
        public override TemplateNumberOutputType Read(
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
            return new TemplateNumberOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateNumberOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateNumberOutputType ReadAsPropertyName(
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
            return new TemplateNumberOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateNumberOutputType value,
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
        public const string Number = "number";
    }
}
