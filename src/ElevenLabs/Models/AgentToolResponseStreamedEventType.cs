using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AgentToolResponseStreamedEventType.AgentToolResponseStreamedEventTypeSerializer)
)]
[Serializable]
public readonly record struct AgentToolResponseStreamedEventType : IStringEnum
{
    public static readonly AgentToolResponseStreamedEventType AgentToolResponse = new(
        Values.AgentToolResponse
    );

    public AgentToolResponseStreamedEventType(string value)
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
    public static AgentToolResponseStreamedEventType FromCustom(string value)
    {
        return new AgentToolResponseStreamedEventType(value);
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

    public static bool operator ==(AgentToolResponseStreamedEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentToolResponseStreamedEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentToolResponseStreamedEventType value) => value.Value;

    public static explicit operator AgentToolResponseStreamedEventType(string value) => new(value);

    internal class AgentToolResponseStreamedEventTypeSerializer
        : JsonConverter<AgentToolResponseStreamedEventType>
    {
        public override AgentToolResponseStreamedEventType Read(
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
            return new AgentToolResponseStreamedEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentToolResponseStreamedEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentToolResponseStreamedEventType ReadAsPropertyName(
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
            return new AgentToolResponseStreamedEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentToolResponseStreamedEventType value,
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
        public const string AgentToolResponse = "agent_tool_response";
    }
}
