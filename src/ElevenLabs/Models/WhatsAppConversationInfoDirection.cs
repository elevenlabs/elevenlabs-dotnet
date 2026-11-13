using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WhatsAppConversationInfoDirection.WhatsAppConversationInfoDirectionSerializer)
)]
[Serializable]
public readonly record struct WhatsAppConversationInfoDirection : IStringEnum
{
    public static readonly WhatsAppConversationInfoDirection Inbound = new(Values.Inbound);

    public static readonly WhatsAppConversationInfoDirection Outbound = new(Values.Outbound);

    public static readonly WhatsAppConversationInfoDirection Unknown = new(Values.Unknown);

    public WhatsAppConversationInfoDirection(string value)
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
    public static WhatsAppConversationInfoDirection FromCustom(string value)
    {
        return new WhatsAppConversationInfoDirection(value);
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

    public static bool operator ==(WhatsAppConversationInfoDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WhatsAppConversationInfoDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WhatsAppConversationInfoDirection value) => value.Value;

    public static explicit operator WhatsAppConversationInfoDirection(string value) => new(value);

    internal class WhatsAppConversationInfoDirectionSerializer
        : JsonConverter<WhatsAppConversationInfoDirection>
    {
        public override WhatsAppConversationInfoDirection Read(
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
            return new WhatsAppConversationInfoDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WhatsAppConversationInfoDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WhatsAppConversationInfoDirection ReadAsPropertyName(
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
            return new WhatsAppConversationInfoDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WhatsAppConversationInfoDirection value,
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
        public const string Inbound = "inbound";

        public const string Outbound = "outbound";

        public const string Unknown = "unknown";
    }
}
