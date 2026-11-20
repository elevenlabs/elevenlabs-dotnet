using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AgentReasoningResponsePartClientEventType.AgentReasoningResponsePartClientEventTypeSerializer)
)]
[Serializable]
public readonly record struct AgentReasoningResponsePartClientEventType : IStringEnum
{
    public static readonly AgentReasoningResponsePartClientEventType AgentReasoningResponsePart =
        new(Values.AgentReasoningResponsePart);

    public AgentReasoningResponsePartClientEventType(string value)
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
    public static AgentReasoningResponsePartClientEventType FromCustom(string value)
    {
        return new AgentReasoningResponsePartClientEventType(value);
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
        AgentReasoningResponsePartClientEventType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentReasoningResponsePartClientEventType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AgentReasoningResponsePartClientEventType value) =>
        value.Value;

    public static explicit operator AgentReasoningResponsePartClientEventType(string value) =>
        new(value);

    internal class AgentReasoningResponsePartClientEventTypeSerializer
        : JsonConverter<AgentReasoningResponsePartClientEventType>
    {
        public override AgentReasoningResponsePartClientEventType Read(
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
            return new AgentReasoningResponsePartClientEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentReasoningResponsePartClientEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentReasoningResponsePartClientEventType ReadAsPropertyName(
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
            return new AgentReasoningResponsePartClientEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentReasoningResponsePartClientEventType value,
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
        public const string AgentReasoningResponsePart = "agent_reasoning_response_part";
    }
}
