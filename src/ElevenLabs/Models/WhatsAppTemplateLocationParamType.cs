using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WhatsAppTemplateLocationParamType.WhatsAppTemplateLocationParamTypeSerializer)
)]
[Serializable]
public readonly record struct WhatsAppTemplateLocationParamType : IStringEnum
{
    public static readonly WhatsAppTemplateLocationParamType Location = new(Values.Location);

    public WhatsAppTemplateLocationParamType(string value)
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
    public static WhatsAppTemplateLocationParamType FromCustom(string value)
    {
        return new WhatsAppTemplateLocationParamType(value);
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

    public static bool operator ==(WhatsAppTemplateLocationParamType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WhatsAppTemplateLocationParamType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WhatsAppTemplateLocationParamType value) => value.Value;

    public static explicit operator WhatsAppTemplateLocationParamType(string value) => new(value);

    internal class WhatsAppTemplateLocationParamTypeSerializer
        : JsonConverter<WhatsAppTemplateLocationParamType>
    {
        public override WhatsAppTemplateLocationParamType Read(
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
            return new WhatsAppTemplateLocationParamType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WhatsAppTemplateLocationParamType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WhatsAppTemplateLocationParamType ReadAsPropertyName(
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
            return new WhatsAppTemplateLocationParamType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WhatsAppTemplateLocationParamType value,
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
        public const string Location = "location";
    }
}
