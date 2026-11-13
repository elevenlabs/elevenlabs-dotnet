using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WhatsAppTemplateParameterFormat.WhatsAppTemplateParameterFormatSerializer))]
[Serializable]
public readonly record struct WhatsAppTemplateParameterFormat : IStringEnum
{
    public static readonly WhatsAppTemplateParameterFormat Positional = new(Values.Positional);

    public static readonly WhatsAppTemplateParameterFormat Named = new(Values.Named);

    public WhatsAppTemplateParameterFormat(string value)
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
    public static WhatsAppTemplateParameterFormat FromCustom(string value)
    {
        return new WhatsAppTemplateParameterFormat(value);
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

    public static bool operator ==(WhatsAppTemplateParameterFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WhatsAppTemplateParameterFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WhatsAppTemplateParameterFormat value) => value.Value;

    public static explicit operator WhatsAppTemplateParameterFormat(string value) => new(value);

    internal class WhatsAppTemplateParameterFormatSerializer
        : JsonConverter<WhatsAppTemplateParameterFormat>
    {
        public override WhatsAppTemplateParameterFormat Read(
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
            return new WhatsAppTemplateParameterFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WhatsAppTemplateParameterFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WhatsAppTemplateParameterFormat ReadAsPropertyName(
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
            return new WhatsAppTemplateParameterFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WhatsAppTemplateParameterFormat value,
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
        public const string Positional = "POSITIONAL";

        public const string Named = "NAMED";
    }
}
