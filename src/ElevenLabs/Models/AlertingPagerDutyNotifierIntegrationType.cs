using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AlertingPagerDutyNotifierIntegrationType.AlertingPagerDutyNotifierIntegrationTypeSerializer)
)]
[Serializable]
public readonly record struct AlertingPagerDutyNotifierIntegrationType : IStringEnum
{
    public static readonly AlertingPagerDutyNotifierIntegrationType Pagerduty = new(
        Values.Pagerduty
    );

    public AlertingPagerDutyNotifierIntegrationType(string value)
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
    public static AlertingPagerDutyNotifierIntegrationType FromCustom(string value)
    {
        return new AlertingPagerDutyNotifierIntegrationType(value);
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
        AlertingPagerDutyNotifierIntegrationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AlertingPagerDutyNotifierIntegrationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AlertingPagerDutyNotifierIntegrationType value) =>
        value.Value;

    public static explicit operator AlertingPagerDutyNotifierIntegrationType(string value) =>
        new(value);

    internal class AlertingPagerDutyNotifierIntegrationTypeSerializer
        : JsonConverter<AlertingPagerDutyNotifierIntegrationType>
    {
        public override AlertingPagerDutyNotifierIntegrationType Read(
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
            return new AlertingPagerDutyNotifierIntegrationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingPagerDutyNotifierIntegrationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AlertingPagerDutyNotifierIntegrationType ReadAsPropertyName(
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
            return new AlertingPagerDutyNotifierIntegrationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingPagerDutyNotifierIntegrationType value,
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
        public const string Pagerduty = "pagerduty";
    }
}
