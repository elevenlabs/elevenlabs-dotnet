using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AlertingPagerDutyNotifierType.AlertingPagerDutyNotifierTypeSerializer))]
[Serializable]
public readonly record struct AlertingPagerDutyNotifierType : IStringEnum
{
    public static readonly AlertingPagerDutyNotifierType Integration = new(Values.Integration);

    public AlertingPagerDutyNotifierType(string value)
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
    public static AlertingPagerDutyNotifierType FromCustom(string value)
    {
        return new AlertingPagerDutyNotifierType(value);
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

    public static bool operator ==(AlertingPagerDutyNotifierType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AlertingPagerDutyNotifierType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AlertingPagerDutyNotifierType value) => value.Value;

    public static explicit operator AlertingPagerDutyNotifierType(string value) => new(value);

    internal class AlertingPagerDutyNotifierTypeSerializer
        : JsonConverter<AlertingPagerDutyNotifierType>
    {
        public override AlertingPagerDutyNotifierType Read(
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
            return new AlertingPagerDutyNotifierType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingPagerDutyNotifierType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AlertingPagerDutyNotifierType ReadAsPropertyName(
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
            return new AlertingPagerDutyNotifierType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingPagerDutyNotifierType value,
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
        public const string Integration = "integration";
    }
}
