using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentConversationTicketSortBy.AgentConversationTicketSortBySerializer))]
[Serializable]
public readonly record struct AgentConversationTicketSortBy : IStringEnum
{
    public static readonly AgentConversationTicketSortBy CreatedAt = new(Values.CreatedAt);

    public static readonly AgentConversationTicketSortBy Priority = new(Values.Priority);

    public static readonly AgentConversationTicketSortBy LastReported = new(Values.LastReported);

    public AgentConversationTicketSortBy(string value)
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
    public static AgentConversationTicketSortBy FromCustom(string value)
    {
        return new AgentConversationTicketSortBy(value);
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

    public static bool operator ==(AgentConversationTicketSortBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentConversationTicketSortBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentConversationTicketSortBy value) => value.Value;

    public static explicit operator AgentConversationTicketSortBy(string value) => new(value);

    internal class AgentConversationTicketSortBySerializer
        : JsonConverter<AgentConversationTicketSortBy>
    {
        public override AgentConversationTicketSortBy Read(
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
            return new AgentConversationTicketSortBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentConversationTicketSortBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentConversationTicketSortBy ReadAsPropertyName(
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
            return new AgentConversationTicketSortBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentConversationTicketSortBy value,
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
        public const string CreatedAt = "created_at";

        public const string Priority = "priority";

        public const string LastReported = "last_reported";
    }
}
