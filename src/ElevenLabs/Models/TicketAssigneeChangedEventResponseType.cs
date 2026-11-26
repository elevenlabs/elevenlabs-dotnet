using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TicketAssigneeChangedEventResponseType.TicketAssigneeChangedEventResponseTypeSerializer)
)]
[Serializable]
public readonly record struct TicketAssigneeChangedEventResponseType : IStringEnum
{
    public static readonly TicketAssigneeChangedEventResponseType AssigneeChanged = new(
        Values.AssigneeChanged
    );

    public TicketAssigneeChangedEventResponseType(string value)
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
    public static TicketAssigneeChangedEventResponseType FromCustom(string value)
    {
        return new TicketAssigneeChangedEventResponseType(value);
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

    public static bool operator ==(TicketAssigneeChangedEventResponseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketAssigneeChangedEventResponseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketAssigneeChangedEventResponseType value) =>
        value.Value;

    public static explicit operator TicketAssigneeChangedEventResponseType(string value) =>
        new(value);

    internal class TicketAssigneeChangedEventResponseTypeSerializer
        : JsonConverter<TicketAssigneeChangedEventResponseType>
    {
        public override TicketAssigneeChangedEventResponseType Read(
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
            return new TicketAssigneeChangedEventResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketAssigneeChangedEventResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketAssigneeChangedEventResponseType ReadAsPropertyName(
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
            return new TicketAssigneeChangedEventResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketAssigneeChangedEventResponseType value,
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
        public const string AssigneeChanged = "assignee_changed";
    }
}
