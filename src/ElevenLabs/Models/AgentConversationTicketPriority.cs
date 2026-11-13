using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentConversationTicketPriority.AgentConversationTicketPrioritySerializer))]
[Serializable]
public readonly record struct AgentConversationTicketPriority : IStringEnum
{
    public static readonly AgentConversationTicketPriority Low = new(Values.Low);

    public static readonly AgentConversationTicketPriority Medium = new(Values.Medium);

    public static readonly AgentConversationTicketPriority High = new(Values.High);

    public static readonly AgentConversationTicketPriority Urgent = new(Values.Urgent);

    public AgentConversationTicketPriority(string value)
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
    public static AgentConversationTicketPriority FromCustom(string value)
    {
        return new AgentConversationTicketPriority(value);
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

    public static bool operator ==(AgentConversationTicketPriority value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentConversationTicketPriority value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentConversationTicketPriority value) => value.Value;

    public static explicit operator AgentConversationTicketPriority(string value) => new(value);

    internal class AgentConversationTicketPrioritySerializer
        : JsonConverter<AgentConversationTicketPriority>
    {
        public override AgentConversationTicketPriority Read(
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
            return new AgentConversationTicketPriority(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentConversationTicketPriority value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentConversationTicketPriority ReadAsPropertyName(
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
            return new AgentConversationTicketPriority(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentConversationTicketPriority value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";

        public const string Urgent = "urgent";
    }
}
