using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentResponseClientEventType.AgentResponseClientEventTypeSerializer))]
[Serializable]
public readonly record struct AgentResponseClientEventType : IStringEnum
{
    public static readonly AgentResponseClientEventType AgentResponse = new(Values.AgentResponse);

    public AgentResponseClientEventType(string value)
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
    public static AgentResponseClientEventType FromCustom(string value)
    {
        return new AgentResponseClientEventType(value);
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

    public static bool operator ==(AgentResponseClientEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentResponseClientEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentResponseClientEventType value) => value.Value;

    public static explicit operator AgentResponseClientEventType(string value) => new(value);

    internal class AgentResponseClientEventTypeSerializer
        : JsonConverter<AgentResponseClientEventType>
    {
        public override AgentResponseClientEventType Read(
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
            return new AgentResponseClientEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentResponseClientEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentResponseClientEventType ReadAsPropertyName(
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
            return new AgentResponseClientEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentResponseClientEventType value,
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
