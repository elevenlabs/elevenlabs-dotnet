using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AlertingPagerDutyNotifierResponseIntegrationType.AlertingPagerDutyNotifierResponseIntegrationTypeSerializer)
)]
[Serializable]
public readonly record struct AlertingPagerDutyNotifierResponseIntegrationType : IStringEnum
{
    public static readonly AlertingPagerDutyNotifierResponseIntegrationType Pagerduty = new(
        Values.Pagerduty
    );

    public AlertingPagerDutyNotifierResponseIntegrationType(string value)
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
    public static AlertingPagerDutyNotifierResponseIntegrationType FromCustom(string value)
    {
        return new AlertingPagerDutyNotifierResponseIntegrationType(value);
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
        AlertingPagerDutyNotifierResponseIntegrationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AlertingPagerDutyNotifierResponseIntegrationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AlertingPagerDutyNotifierResponseIntegrationType value
    ) => value.Value;

    public static explicit operator AlertingPagerDutyNotifierResponseIntegrationType(
        string value
    ) => new(value);

    internal class AlertingPagerDutyNotifierResponseIntegrationTypeSerializer
        : JsonConverter<AlertingPagerDutyNotifierResponseIntegrationType>
    {
        public override AlertingPagerDutyNotifierResponseIntegrationType Read(
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
            return new AlertingPagerDutyNotifierResponseIntegrationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingPagerDutyNotifierResponseIntegrationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AlertingPagerDutyNotifierResponseIntegrationType ReadAsPropertyName(
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
            return new AlertingPagerDutyNotifierResponseIntegrationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingPagerDutyNotifierResponseIntegrationType value,
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
