using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentConversationTicketSource.AgentConversationTicketSourceSerializer))]
[Serializable]
public readonly record struct AgentConversationTicketSource : IStringEnum
{
    public static readonly AgentConversationTicketSource Qa = new(Values.Qa);

    public static readonly AgentConversationTicketSource Agent = new(Values.Agent);

    public static readonly AgentConversationTicketSource Manual = new(Values.Manual);

    public AgentConversationTicketSource(string value)
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
    public static AgentConversationTicketSource FromCustom(string value)
    {
        return new AgentConversationTicketSource(value);
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

    public static bool operator ==(AgentConversationTicketSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentConversationTicketSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentConversationTicketSource value) => value.Value;

    public static explicit operator AgentConversationTicketSource(string value) => new(value);

    internal class AgentConversationTicketSourceSerializer
        : JsonConverter<AgentConversationTicketSource>
    {
        public override AgentConversationTicketSource Read(
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
            return new AgentConversationTicketSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentConversationTicketSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentConversationTicketSource ReadAsPropertyName(
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
            return new AgentConversationTicketSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentConversationTicketSource value,
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
        public const string Qa = "qa";

        public const string Agent = "agent";

        public const string Manual = "manual";
    }
}
