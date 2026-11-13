using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentResponseType.AgentResponseTypeSerializer))]
[Serializable]
public readonly record struct AgentResponseType : IStringEnum
{
    public static readonly AgentResponseType AgentResponse = new(Values.AgentResponse);

    public AgentResponseType(string value)
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
    public static AgentResponseType FromCustom(string value)
    {
        return new AgentResponseType(value);
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

    public static bool operator ==(AgentResponseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentResponseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentResponseType value) => value.Value;

    public static explicit operator AgentResponseType(string value) => new(value);

    internal class AgentResponseTypeSerializer : JsonConverter<AgentResponseType>
    {
        public override AgentResponseType Read(
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
            return new AgentResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentResponseType ReadAsPropertyName(
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
            return new AgentResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentResponseType value,
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
