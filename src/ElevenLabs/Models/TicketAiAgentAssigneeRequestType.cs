using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TicketAiAgentAssigneeRequestType.TicketAiAgentAssigneeRequestTypeSerializer))]
[Serializable]
public readonly record struct TicketAiAgentAssigneeRequestType : IStringEnum
{
    public static readonly TicketAiAgentAssigneeRequestType AiAgent = new(Values.AiAgent);

    public TicketAiAgentAssigneeRequestType(string value)
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
    public static TicketAiAgentAssigneeRequestType FromCustom(string value)
    {
        return new TicketAiAgentAssigneeRequestType(value);
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

    public static bool operator ==(TicketAiAgentAssigneeRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketAiAgentAssigneeRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketAiAgentAssigneeRequestType value) => value.Value;

    public static explicit operator TicketAiAgentAssigneeRequestType(string value) => new(value);

    internal class TicketAiAgentAssigneeRequestTypeSerializer
        : JsonConverter<TicketAiAgentAssigneeRequestType>
    {
        public override TicketAiAgentAssigneeRequestType Read(
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
            return new TicketAiAgentAssigneeRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketAiAgentAssigneeRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketAiAgentAssigneeRequestType ReadAsPropertyName(
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
            return new TicketAiAgentAssigneeRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketAiAgentAssigneeRequestType value,
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
        public const string AiAgent = "ai_agent";
    }
}
