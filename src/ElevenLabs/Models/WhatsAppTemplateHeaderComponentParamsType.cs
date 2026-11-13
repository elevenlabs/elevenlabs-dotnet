using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WhatsAppTemplateHeaderComponentParamsType.WhatsAppTemplateHeaderComponentParamsTypeSerializer)
)]
[Serializable]
public readonly record struct WhatsAppTemplateHeaderComponentParamsType : IStringEnum
{
    public static readonly WhatsAppTemplateHeaderComponentParamsType Header = new(Values.Header);

    public WhatsAppTemplateHeaderComponentParamsType(string value)
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
    public static WhatsAppTemplateHeaderComponentParamsType FromCustom(string value)
    {
        return new WhatsAppTemplateHeaderComponentParamsType(value);
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

    public static bool operator ==(
        WhatsAppTemplateHeaderComponentParamsType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WhatsAppTemplateHeaderComponentParamsType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(WhatsAppTemplateHeaderComponentParamsType value) =>
        value.Value;

    public static explicit operator WhatsAppTemplateHeaderComponentParamsType(string value) =>
        new(value);

    internal class WhatsAppTemplateHeaderComponentParamsTypeSerializer
        : JsonConverter<WhatsAppTemplateHeaderComponentParamsType>
    {
        public override WhatsAppTemplateHeaderComponentParamsType Read(
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
            return new WhatsAppTemplateHeaderComponentParamsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WhatsAppTemplateHeaderComponentParamsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WhatsAppTemplateHeaderComponentParamsType ReadAsPropertyName(
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
            return new WhatsAppTemplateHeaderComponentParamsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WhatsAppTemplateHeaderComponentParamsType value,
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
        public const string Header = "header";
    }
}
