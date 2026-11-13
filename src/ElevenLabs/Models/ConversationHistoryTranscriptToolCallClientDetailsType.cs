using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptToolCallClientDetailsType.ConversationHistoryTranscriptToolCallClientDetailsTypeSerializer)
)]
[Serializable]
public readonly record struct ConversationHistoryTranscriptToolCallClientDetailsType : IStringEnum
{
    public static readonly ConversationHistoryTranscriptToolCallClientDetailsType Client = new(
        Values.Client
    );

    public ConversationHistoryTranscriptToolCallClientDetailsType(string value)
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
    public static ConversationHistoryTranscriptToolCallClientDetailsType FromCustom(string value)
    {
        return new ConversationHistoryTranscriptToolCallClientDetailsType(value);
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
        ConversationHistoryTranscriptToolCallClientDetailsType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistoryTranscriptToolCallClientDetailsType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationHistoryTranscriptToolCallClientDetailsType value
    ) => value.Value;

    public static explicit operator ConversationHistoryTranscriptToolCallClientDetailsType(
        string value
    ) => new(value);

    internal class ConversationHistoryTranscriptToolCallClientDetailsTypeSerializer
        : JsonConverter<ConversationHistoryTranscriptToolCallClientDetailsType>
    {
        public override ConversationHistoryTranscriptToolCallClientDetailsType Read(
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
            return new ConversationHistoryTranscriptToolCallClientDetailsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallClientDetailsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistoryTranscriptToolCallClientDetailsType ReadAsPropertyName(
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
            return new ConversationHistoryTranscriptToolCallClientDetailsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptToolCallClientDetailsType value,
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
        public const string Client = "client";
    }
}
