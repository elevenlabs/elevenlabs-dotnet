using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationUserTranscriptType.ConversationUserTranscriptTypeSerializer))]
[Serializable]
public readonly record struct ConversationUserTranscriptType : IStringEnum
{
    public static readonly ConversationUserTranscriptType UserTranscript = new(
        Values.UserTranscript
    );

    public ConversationUserTranscriptType(string value)
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
    public static ConversationUserTranscriptType FromCustom(string value)
    {
        return new ConversationUserTranscriptType(value);
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

    public static bool operator ==(ConversationUserTranscriptType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationUserTranscriptType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationUserTranscriptType value) => value.Value;

    public static explicit operator ConversationUserTranscriptType(string value) => new(value);

    internal class ConversationUserTranscriptTypeSerializer
        : JsonConverter<ConversationUserTranscriptType>
    {
        public override ConversationUserTranscriptType Read(
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
            return new ConversationUserTranscriptType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationUserTranscriptType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationUserTranscriptType ReadAsPropertyName(
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
            return new ConversationUserTranscriptType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationUserTranscriptType value,
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
        public const string UserTranscript = "user_transcript";
    }
}
