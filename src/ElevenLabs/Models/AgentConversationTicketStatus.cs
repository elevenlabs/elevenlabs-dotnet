using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentConversationTicketStatus.AgentConversationTicketStatusSerializer))]
[Serializable]
public readonly record struct AgentConversationTicketStatus : IStringEnum
{
    public static readonly AgentConversationTicketStatus Open = new(Values.Open);

    public static readonly AgentConversationTicketStatus InProgress = new(Values.InProgress);

    public static readonly AgentConversationTicketStatus Resolved = new(Values.Resolved);

    public static readonly AgentConversationTicketStatus Cancelled = new(Values.Cancelled);

    public static readonly AgentConversationTicketStatus Merged = new(Values.Merged);

    public AgentConversationTicketStatus(string value)
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
    public static AgentConversationTicketStatus FromCustom(string value)
    {
        return new AgentConversationTicketStatus(value);
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

    public static bool operator ==(AgentConversationTicketStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentConversationTicketStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentConversationTicketStatus value) => value.Value;

    public static explicit operator AgentConversationTicketStatus(string value) => new(value);

    internal class AgentConversationTicketStatusSerializer
        : JsonConverter<AgentConversationTicketStatus>
    {
        public override AgentConversationTicketStatus Read(
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
            return new AgentConversationTicketStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentConversationTicketStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentConversationTicketStatus ReadAsPropertyName(
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
            return new AgentConversationTicketStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentConversationTicketStatus value,
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
        public const string Open = "open";

        public const string InProgress = "in_progress";

        public const string Resolved = "resolved";

        public const string Cancelled = "cancelled";

        public const string Merged = "merged";
    }
}
