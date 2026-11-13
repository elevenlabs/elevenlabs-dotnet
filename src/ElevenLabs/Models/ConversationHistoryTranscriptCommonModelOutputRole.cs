using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptCommonModelOutputRole.ConversationHistoryTranscriptCommonModelOutputRoleSerializer)
)]
[Serializable]
public readonly record struct ConversationHistoryTranscriptCommonModelOutputRole : IStringEnum
{
    public static readonly ConversationHistoryTranscriptCommonModelOutputRole User = new(
        Values.User
    );

    public static readonly ConversationHistoryTranscriptCommonModelOutputRole Agent = new(
        Values.Agent
    );

    public ConversationHistoryTranscriptCommonModelOutputRole(string value)
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
    public static ConversationHistoryTranscriptCommonModelOutputRole FromCustom(string value)
    {
        return new ConversationHistoryTranscriptCommonModelOutputRole(value);
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
        ConversationHistoryTranscriptCommonModelOutputRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistoryTranscriptCommonModelOutputRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationHistoryTranscriptCommonModelOutputRole value
    ) => value.Value;

    public static explicit operator ConversationHistoryTranscriptCommonModelOutputRole(
        string value
    ) => new(value);

    internal class ConversationHistoryTranscriptCommonModelOutputRoleSerializer
        : JsonConverter<ConversationHistoryTranscriptCommonModelOutputRole>
    {
        public override ConversationHistoryTranscriptCommonModelOutputRole Read(
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
            return new ConversationHistoryTranscriptCommonModelOutputRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptCommonModelOutputRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistoryTranscriptCommonModelOutputRole ReadAsPropertyName(
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
            return new ConversationHistoryTranscriptCommonModelOutputRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptCommonModelOutputRole value,
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
