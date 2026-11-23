using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationPingType.ConversationPingTypeSerializer))]
[Serializable]
public readonly record struct ConversationPingType : IStringEnum
{
    public static readonly ConversationPingType Ping = new(Values.Ping);

    public ConversationPingType(string value)
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
    public static ConversationPingType FromCustom(string value)
    {
        return new ConversationPingType(value);
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

    public static bool operator ==(ConversationPingType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationPingType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationPingType value) => value.Value;

    public static explicit operator ConversationPingType(string value) => new(value);

    internal class ConversationPingTypeSerializer : JsonConverter<ConversationPingType>
    {
        public override ConversationPingType Read(
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
            return new ConversationPingType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationPingType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationPingType ReadAsPropertyName(
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
            return new ConversationPingType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationPingType value,
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
        public const string Ping = "ping";
    }
}
