using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TicketEventHumanAgentAuthorResponseType.TicketEventHumanAgentAuthorResponseTypeSerializer)
)]
[Serializable]
public readonly record struct TicketEventHumanAgentAuthorResponseType : IStringEnum
{
    public static readonly TicketEventHumanAgentAuthorResponseType HumanAgent = new(
        Values.HumanAgent
    );

    public TicketEventHumanAgentAuthorResponseType(string value)
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
    public static TicketEventHumanAgentAuthorResponseType FromCustom(string value)
    {
        return new TicketEventHumanAgentAuthorResponseType(value);
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

    public static bool operator ==(TicketEventHumanAgentAuthorResponseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketEventHumanAgentAuthorResponseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketEventHumanAgentAuthorResponseType value) =>
        value.Value;

    public static explicit operator TicketEventHumanAgentAuthorResponseType(string value) =>
        new(value);

    internal class TicketEventHumanAgentAuthorResponseTypeSerializer
        : JsonConverter<TicketEventHumanAgentAuthorResponseType>
    {
        public override TicketEventHumanAgentAuthorResponseType Read(
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
            return new TicketEventHumanAgentAuthorResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketEventHumanAgentAuthorResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketEventHumanAgentAuthorResponseType ReadAsPropertyName(
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
            return new TicketEventHumanAgentAuthorResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketEventHumanAgentAuthorResponseType value,
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
        public const string HumanAgent = "human_agent";
    }
}
