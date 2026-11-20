using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AgentChatResponsePartClientEventType.AgentChatResponsePartClientEventTypeSerializer)
)]
[Serializable]
public readonly record struct AgentChatResponsePartClientEventType : IStringEnum
{
    public static readonly AgentChatResponsePartClientEventType AgentChatResponsePart = new(
        Values.AgentChatResponsePart
    );

    public AgentChatResponsePartClientEventType(string value)
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
    public static AgentChatResponsePartClientEventType FromCustom(string value)
    {
        return new AgentChatResponsePartClientEventType(value);
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

    public static bool operator ==(AgentChatResponsePartClientEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentChatResponsePartClientEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentChatResponsePartClientEventType value) =>
        value.Value;

    public static explicit operator AgentChatResponsePartClientEventType(string value) =>
        new(value);

    internal class AgentChatResponsePartClientEventTypeSerializer
        : JsonConverter<AgentChatResponsePartClientEventType>
    {
        public override AgentChatResponsePartClientEventType Read(
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
            return new AgentChatResponsePartClientEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentChatResponsePartClientEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentChatResponsePartClientEventType ReadAsPropertyName(
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
            return new AgentChatResponsePartClientEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentChatResponsePartClientEventType value,
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
        public const string AgentChatResponsePart = "agent_chat_response_part";
    }
}
