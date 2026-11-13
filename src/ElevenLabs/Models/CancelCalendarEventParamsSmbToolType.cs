using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CancelCalendarEventParamsSmbToolType.CancelCalendarEventParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct CancelCalendarEventParamsSmbToolType : IStringEnum
{
    public static readonly CancelCalendarEventParamsSmbToolType CancelCalendarEvent = new(
        Values.CancelCalendarEvent
    );

    public CancelCalendarEventParamsSmbToolType(string value)
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
    public static CancelCalendarEventParamsSmbToolType FromCustom(string value)
    {
        return new CancelCalendarEventParamsSmbToolType(value);
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

    public static bool operator ==(CancelCalendarEventParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CancelCalendarEventParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CancelCalendarEventParamsSmbToolType value) =>
        value.Value;

    public static explicit operator CancelCalendarEventParamsSmbToolType(string value) =>
        new(value);

    internal class CancelCalendarEventParamsSmbToolTypeSerializer
        : JsonConverter<CancelCalendarEventParamsSmbToolType>
    {
        public override CancelCalendarEventParamsSmbToolType Read(
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
            return new CancelCalendarEventParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelCalendarEventParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelCalendarEventParamsSmbToolType ReadAsPropertyName(
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
            return new CancelCalendarEventParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelCalendarEventParamsSmbToolType value,
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
        public const string CancelCalendarEvent = "cancel_calendar_event";
    }
}
