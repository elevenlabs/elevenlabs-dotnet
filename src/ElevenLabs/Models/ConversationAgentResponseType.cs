using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationAgentResponseType.ConversationAgentResponseTypeSerializer))]
[Serializable]
public readonly record struct ConversationAgentResponseType : IStringEnum
{
    public static readonly ConversationAgentResponseType AgentResponse = new(Values.AgentResponse);

    public ConversationAgentResponseType(string value)
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
    public static ConversationAgentResponseType FromCustom(string value)
    {
        return new ConversationAgentResponseType(value);
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

    public static bool operator ==(ConversationAgentResponseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationAgentResponseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationAgentResponseType value) => value.Value;

    public static explicit operator ConversationAgentResponseType(string value) => new(value);

    internal class ConversationAgentResponseTypeSerializer
        : JsonConverter<ConversationAgentResponseType>
    {
        public override ConversationAgentResponseType Read(
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
            return new ConversationAgentResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationAgentResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationAgentResponseType ReadAsPropertyName(
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
            return new ConversationAgentResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationAgentResponseType value,
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
        public const string AgentResponse = "agent_response";
    }
}
