using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AppointmentReminderMode.AppointmentReminderModeSerializer))]
[Serializable]
public readonly record struct AppointmentReminderMode : IStringEnum
{
    public static readonly AppointmentReminderMode Reminder = new(Values.Reminder);

    public static readonly AppointmentReminderMode Confirmation = new(Values.Confirmation);

    public AppointmentReminderMode(string value)
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
    public static AppointmentReminderMode FromCustom(string value)
    {
        return new AppointmentReminderMode(value);
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

    public static bool operator ==(AppointmentReminderMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AppointmentReminderMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AppointmentReminderMode value) => value.Value;

    public static explicit operator AppointmentReminderMode(string value) => new(value);

    internal class AppointmentReminderModeSerializer : JsonConverter<AppointmentReminderMode>
    {
        public override AppointmentReminderMode Read(
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
            return new AppointmentReminderMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AppointmentReminderMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AppointmentReminderMode ReadAsPropertyName(
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
            return new AppointmentReminderMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AppointmentReminderMode value,
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
        public const string Reminder = "reminder";

        public const string Confirmation = "confirmation";
    }
}
