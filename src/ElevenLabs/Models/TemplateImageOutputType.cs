using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The kind of output: the `type` of the port's `content_schema`.</summary>
[JsonConverter(typeof(TemplateImageOutputType.TemplateImageOutputTypeSerializer))]
[Serializable]
public readonly record struct TemplateImageOutputType : IStringEnum
{
    public static readonly TemplateImageOutputType Image = new(Values.Image);

    public TemplateImageOutputType(string value)
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
    public static TemplateImageOutputType FromCustom(string value)
    {
        return new TemplateImageOutputType(value);
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

    public static bool operator ==(TemplateImageOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateImageOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateImageOutputType value) => value.Value;

    public static explicit operator TemplateImageOutputType(string value) => new(value);

    internal class TemplateImageOutputTypeSerializer : JsonConverter<TemplateImageOutputType>
    {
        public override TemplateImageOutputType Read(
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
            return new TemplateImageOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateImageOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateImageOutputType ReadAsPropertyName(
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
            return new TemplateImageOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateImageOutputType value,
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
        public const string Image = "image";
    }
}
