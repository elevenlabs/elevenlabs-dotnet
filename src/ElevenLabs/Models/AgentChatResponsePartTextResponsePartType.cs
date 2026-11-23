using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AgentChatResponsePartTextResponsePartType.AgentChatResponsePartTextResponsePartTypeSerializer)
)]
[Serializable]
public readonly record struct AgentChatResponsePartTextResponsePartType : IStringEnum
{
    public static readonly AgentChatResponsePartTextResponsePartType Start = new(Values.Start);

    public static readonly AgentChatResponsePartTextResponsePartType Delta = new(Values.Delta);

    public static readonly AgentChatResponsePartTextResponsePartType Stop = new(Values.Stop);

    public AgentChatResponsePartTextResponsePartType(string value)
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
    public static AgentChatResponsePartTextResponsePartType FromCustom(string value)
    {
        return new AgentChatResponsePartTextResponsePartType(value);
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
        AgentChatResponsePartTextResponsePartType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentChatResponsePartTextResponsePartType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AgentChatResponsePartTextResponsePartType value) =>
        value.Value;

    public static explicit operator AgentChatResponsePartTextResponsePartType(string value) =>
        new(value);

    internal class AgentChatResponsePartTextResponsePartTypeSerializer
        : JsonConverter<AgentChatResponsePartTextResponsePartType>
    {
        public override AgentChatResponsePartTextResponsePartType Read(
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
            return new AgentChatResponsePartTextResponsePartType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentChatResponsePartTextResponsePartType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentChatResponsePartTextResponsePartType ReadAsPropertyName(
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
            return new AgentChatResponsePartTextResponsePartType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentChatResponsePartTextResponsePartType value,
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
        public const string Start = "start";

        public const string Delta = "delta";

        public const string Stop = "stop";
    }
}
