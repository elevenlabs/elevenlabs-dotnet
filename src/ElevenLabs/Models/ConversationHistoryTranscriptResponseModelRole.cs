using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptResponseModelRole.ConversationHistoryTranscriptResponseModelRoleSerializer)
)]
[Serializable]
public readonly record struct ConversationHistoryTranscriptResponseModelRole : IStringEnum
{
    public static readonly ConversationHistoryTranscriptResponseModelRole User = new(Values.User);

    public static readonly ConversationHistoryTranscriptResponseModelRole Agent = new(Values.Agent);

    public ConversationHistoryTranscriptResponseModelRole(string value)
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
    public static ConversationHistoryTranscriptResponseModelRole FromCustom(string value)
    {
        return new ConversationHistoryTranscriptResponseModelRole(value);
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
        ConversationHistoryTranscriptResponseModelRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistoryTranscriptResponseModelRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConversationHistoryTranscriptResponseModelRole value) =>
        value.Value;

    public static explicit operator ConversationHistoryTranscriptResponseModelRole(string value) =>
        new(value);

    internal class ConversationHistoryTranscriptResponseModelRoleSerializer
        : JsonConverter<ConversationHistoryTranscriptResponseModelRole>
    {
        public override ConversationHistoryTranscriptResponseModelRole Read(
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
            return new ConversationHistoryTranscriptResponseModelRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptResponseModelRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistoryTranscriptResponseModelRole ReadAsPropertyName(
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
            return new ConversationHistoryTranscriptResponseModelRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptResponseModelRole value,
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
        public const string User = "user";

        public const string Agent = "agent";
    }
}
