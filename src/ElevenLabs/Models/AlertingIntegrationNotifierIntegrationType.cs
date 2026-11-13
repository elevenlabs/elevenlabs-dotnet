using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Integration to deliver to. The server treats an omitted value as ``pagerduty``.</summary>
[JsonConverter(
    typeof(AlertingIntegrationNotifierIntegrationType.AlertingIntegrationNotifierIntegrationTypeSerializer)
)]
[Serializable]
public readonly record struct AlertingIntegrationNotifierIntegrationType : IStringEnum
{
    public static readonly AlertingIntegrationNotifierIntegrationType Pagerduty = new(
        Values.Pagerduty
    );

    public static readonly AlertingIntegrationNotifierIntegrationType Slack = new(Values.Slack);

    public AlertingIntegrationNotifierIntegrationType(string value)
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
    public static AlertingIntegrationNotifierIntegrationType FromCustom(string value)
    {
        return new AlertingIntegrationNotifierIntegrationType(value);
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
        AlertingIntegrationNotifierIntegrationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AlertingIntegrationNotifierIntegrationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AlertingIntegrationNotifierIntegrationType value) =>
        value.Value;

    public static explicit operator AlertingIntegrationNotifierIntegrationType(string value) =>
        new(value);

    internal class AlertingIntegrationNotifierIntegrationTypeSerializer
        : JsonConverter<AlertingIntegrationNotifierIntegrationType>
    {
        public override AlertingIntegrationNotifierIntegrationType Read(
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
            return new AlertingIntegrationNotifierIntegrationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingIntegrationNotifierIntegrationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AlertingIntegrationNotifierIntegrationType ReadAsPropertyName(
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
            return new AlertingIntegrationNotifierIntegrationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingIntegrationNotifierIntegrationType value,
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

        public const string Slack = "slack";
    }
}
