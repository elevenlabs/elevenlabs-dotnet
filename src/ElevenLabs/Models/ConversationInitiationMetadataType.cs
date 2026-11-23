using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationInitiationMetadataType.ConversationInitiationMetadataTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationInitiationMetadataType : IStringEnum
{
    public static readonly ConversationInitiationMetadataType ConversationInitiationMetadata = new(
        Values.ConversationInitiationMetadata
    );

    public ConversationInitiationMetadataType(string value)
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
    public static ConversationInitiationMetadataType FromCustom(string value)
    {
        return new ConversationInitiationMetadataType(value);
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

    public static bool operator ==(ConversationInitiationMetadataType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationInitiationMetadataType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationInitiationMetadataType value) => value.Value;

    public static explicit operator ConversationInitiationMetadataType(string value) => new(value);

    internal class ConversationInitiationMetadataTypeSerializer
        : JsonConverter<ConversationInitiationMetadataType>
    {
        public override ConversationInitiationMetadataType Read(
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
            return new ConversationInitiationMetadataType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationInitiationMetadataType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationInitiationMetadataType ReadAsPropertyName(
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
            return new ConversationInitiationMetadataType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationInitiationMetadataType value,
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
        public const string ConversationInitiationMetadata = "conversation_initiation_metadata";
    }
}
