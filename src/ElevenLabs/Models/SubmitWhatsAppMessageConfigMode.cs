using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SubmitWhatsAppMessageConfigMode.SubmitWhatsAppMessageConfigModeSerializer))]
[Serializable]
public readonly record struct SubmitWhatsAppMessageConfigMode : IStringEnum
{
    public static readonly SubmitWhatsAppMessageConfigMode Message = new(Values.Message);

    public SubmitWhatsAppMessageConfigMode(string value)
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
    public static SubmitWhatsAppMessageConfigMode FromCustom(string value)
    {
        return new SubmitWhatsAppMessageConfigMode(value);
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

    public static bool operator ==(SubmitWhatsAppMessageConfigMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmitWhatsAppMessageConfigMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmitWhatsAppMessageConfigMode value) => value.Value;

    public static explicit operator SubmitWhatsAppMessageConfigMode(string value) => new(value);

    internal class SubmitWhatsAppMessageConfigModeSerializer
        : JsonConverter<SubmitWhatsAppMessageConfigMode>
    {
        public override SubmitWhatsAppMessageConfigMode Read(
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
            return new SubmitWhatsAppMessageConfigMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmitWhatsAppMessageConfigMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmitWhatsAppMessageConfigMode ReadAsPropertyName(
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
            return new SubmitWhatsAppMessageConfigMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmitWhatsAppMessageConfigMode value,
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
        public const string Message = "message";
    }
}
