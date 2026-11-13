using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateCalendarEventParamsSmbToolType.UpdateCalendarEventParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateCalendarEventParamsSmbToolType : IStringEnum
{
    public static readonly UpdateCalendarEventParamsSmbToolType UpdateCalendarEvent = new(
        Values.UpdateCalendarEvent
    );

    public UpdateCalendarEventParamsSmbToolType(string value)
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
    public static UpdateCalendarEventParamsSmbToolType FromCustom(string value)
    {
        return new UpdateCalendarEventParamsSmbToolType(value);
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

    public static bool operator ==(UpdateCalendarEventParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateCalendarEventParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateCalendarEventParamsSmbToolType value) =>
        value.Value;

    public static explicit operator UpdateCalendarEventParamsSmbToolType(string value) =>
        new(value);

    internal class UpdateCalendarEventParamsSmbToolTypeSerializer
        : JsonConverter<UpdateCalendarEventParamsSmbToolType>
    {
        public override UpdateCalendarEventParamsSmbToolType Read(
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
            return new UpdateCalendarEventParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateCalendarEventParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateCalendarEventParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateCalendarEventParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateCalendarEventParamsSmbToolType value,
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
        public const string UpdateCalendarEvent = "update_calendar_event";
    }
}
