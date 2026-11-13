using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(OptInSmsReminderParamsSmbToolType.OptInSmsReminderParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct OptInSmsReminderParamsSmbToolType : IStringEnum
{
    public static readonly OptInSmsReminderParamsSmbToolType OptInSmsReminder = new(
        Values.OptInSmsReminder
    );

    public OptInSmsReminderParamsSmbToolType(string value)
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
    public static OptInSmsReminderParamsSmbToolType FromCustom(string value)
    {
        return new OptInSmsReminderParamsSmbToolType(value);
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

    public static bool operator ==(OptInSmsReminderParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OptInSmsReminderParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OptInSmsReminderParamsSmbToolType value) => value.Value;

    public static explicit operator OptInSmsReminderParamsSmbToolType(string value) => new(value);

    internal class OptInSmsReminderParamsSmbToolTypeSerializer
        : JsonConverter<OptInSmsReminderParamsSmbToolType>
    {
        public override OptInSmsReminderParamsSmbToolType Read(
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
            return new OptInSmsReminderParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OptInSmsReminderParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OptInSmsReminderParamsSmbToolType ReadAsPropertyName(
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
            return new OptInSmsReminderParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OptInSmsReminderParamsSmbToolType value,
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
        public const string OptInSmsReminder = "opt_in_sms_reminder";
    }
}
