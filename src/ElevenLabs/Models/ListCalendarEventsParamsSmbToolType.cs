using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListCalendarEventsParamsSmbToolType.ListCalendarEventsParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct ListCalendarEventsParamsSmbToolType : IStringEnum
{
    public static readonly ListCalendarEventsParamsSmbToolType ListCalendarEvents = new(
        Values.ListCalendarEvents
    );

    public ListCalendarEventsParamsSmbToolType(string value)
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
    public static ListCalendarEventsParamsSmbToolType FromCustom(string value)
    {
        return new ListCalendarEventsParamsSmbToolType(value);
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

    public static bool operator ==(ListCalendarEventsParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListCalendarEventsParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListCalendarEventsParamsSmbToolType value) =>
        value.Value;

    public static explicit operator ListCalendarEventsParamsSmbToolType(string value) => new(value);

    internal class ListCalendarEventsParamsSmbToolTypeSerializer
        : JsonConverter<ListCalendarEventsParamsSmbToolType>
    {
        public override ListCalendarEventsParamsSmbToolType Read(
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
            return new ListCalendarEventsParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListCalendarEventsParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListCalendarEventsParamsSmbToolType ReadAsPropertyName(
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
            return new ListCalendarEventsParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListCalendarEventsParamsSmbToolType value,
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
        public const string ListCalendarEvents = "list_calendar_events";
    }
}
