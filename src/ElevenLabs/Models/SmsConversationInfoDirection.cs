using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SmsConversationInfoDirection.SmsConversationInfoDirectionSerializer))]
[Serializable]
public readonly record struct SmsConversationInfoDirection : IStringEnum
{
    public static readonly SmsConversationInfoDirection Inbound = new(Values.Inbound);

    public static readonly SmsConversationInfoDirection Outbound = new(Values.Outbound);

    public SmsConversationInfoDirection(string value)
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
    public static SmsConversationInfoDirection FromCustom(string value)
    {
        return new SmsConversationInfoDirection(value);
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

    public static bool operator ==(SmsConversationInfoDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmsConversationInfoDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmsConversationInfoDirection value) => value.Value;

    public static explicit operator SmsConversationInfoDirection(string value) => new(value);

    internal class SmsConversationInfoDirectionSerializer
        : JsonConverter<SmsConversationInfoDirection>
    {
        public override SmsConversationInfoDirection Read(
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
            return new SmsConversationInfoDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmsConversationInfoDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmsConversationInfoDirection ReadAsPropertyName(
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
            return new SmsConversationInfoDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmsConversationInfoDirection value,
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
    }
}
