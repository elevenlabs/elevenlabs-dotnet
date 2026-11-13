using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationHistoryTranscriptCommonModelInputRole.ConversationHistoryTranscriptCommonModelInputRoleSerializer)
)]
[Serializable]
public readonly record struct ConversationHistoryTranscriptCommonModelInputRole : IStringEnum
{
    public static readonly ConversationHistoryTranscriptCommonModelInputRole User = new(
        Values.User
    );

    public static readonly ConversationHistoryTranscriptCommonModelInputRole Agent = new(
        Values.Agent
    );

    public ConversationHistoryTranscriptCommonModelInputRole(string value)
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
    public static ConversationHistoryTranscriptCommonModelInputRole FromCustom(string value)
    {
        return new ConversationHistoryTranscriptCommonModelInputRole(value);
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
        ConversationHistoryTranscriptCommonModelInputRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationHistoryTranscriptCommonModelInputRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ConversationHistoryTranscriptCommonModelInputRole value
    ) => value.Value;

    public static explicit operator ConversationHistoryTranscriptCommonModelInputRole(
        string value
    ) => new(value);

    internal class ConversationHistoryTranscriptCommonModelInputRoleSerializer
        : JsonConverter<ConversationHistoryTranscriptCommonModelInputRole>
    {
        public override ConversationHistoryTranscriptCommonModelInputRole Read(
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
            return new ConversationHistoryTranscriptCommonModelInputRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptCommonModelInputRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationHistoryTranscriptCommonModelInputRole ReadAsPropertyName(
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
            return new ConversationHistoryTranscriptCommonModelInputRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryTranscriptCommonModelInputRole value,
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
