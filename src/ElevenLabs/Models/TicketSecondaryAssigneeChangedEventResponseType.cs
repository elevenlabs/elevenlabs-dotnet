using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TicketSecondaryAssigneeChangedEventResponseType.TicketSecondaryAssigneeChangedEventResponseTypeSerializer)
)]
[Serializable]
public readonly record struct TicketSecondaryAssigneeChangedEventResponseType : IStringEnum
{
    public static readonly TicketSecondaryAssigneeChangedEventResponseType SecondaryAssigneeChanged =
        new(Values.SecondaryAssigneeChanged);

    public TicketSecondaryAssigneeChangedEventResponseType(string value)
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
    public static TicketSecondaryAssigneeChangedEventResponseType FromCustom(string value)
    {
        return new TicketSecondaryAssigneeChangedEventResponseType(value);
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
        TicketSecondaryAssigneeChangedEventResponseType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TicketSecondaryAssigneeChangedEventResponseType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TicketSecondaryAssigneeChangedEventResponseType value) =>
        value.Value;

    public static explicit operator TicketSecondaryAssigneeChangedEventResponseType(string value) =>
        new(value);

    internal class TicketSecondaryAssigneeChangedEventResponseTypeSerializer
        : JsonConverter<TicketSecondaryAssigneeChangedEventResponseType>
    {
        public override TicketSecondaryAssigneeChangedEventResponseType Read(
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
            return new TicketSecondaryAssigneeChangedEventResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketSecondaryAssigneeChangedEventResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketSecondaryAssigneeChangedEventResponseType ReadAsPropertyName(
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
            return new TicketSecondaryAssigneeChangedEventResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketSecondaryAssigneeChangedEventResponseType value,
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
        public const string SecondaryAssigneeChanged = "secondary_assignee_changed";
    }
}
