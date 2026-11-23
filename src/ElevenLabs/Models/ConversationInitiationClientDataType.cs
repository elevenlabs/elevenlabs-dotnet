using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationInitiationClientDataType.ConversationInitiationClientDataTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationClientDataType : IStringEnum
{
    public static readonly ConversationInitiationClientDataType ConversationInitiationClientData =
        new(Values.ConversationInitiationClientData);

    public ConversationInitiationClientDataType(string value)
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
    public static ConversationInitiationClientDataType FromCustom(string value)
    {
        return new ConversationInitiationClientDataType(value);
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

    public static bool operator ==(ConversationInitiationClientDataType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationInitiationClientDataType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationInitiationClientDataType value) =>
        value.Value;

    public static explicit operator ConversationInitiationClientDataType(string value) =>
        new(value);

    internal class ConversationInitiationClientDataTypeSerializer
        : JsonConverter<ConversationInitiationClientDataType>
    {
        public override ConversationInitiationClientDataType Read(
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
            return new ConversationInitiationClientDataType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationClientDataType ReadAsPropertyName(
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
            return new ConversationInitiationClientDataType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationClientDataType value,
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
        public const string ConversationInitiationClientData =
            "conversation_initiation_client_data";
    }
}
