using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AlertingIntegrationNotifierResponseType.AlertingIntegrationNotifierResponseTypeSerializer)
)]
[Serializable]
public readonly record struct AlertingIntegrationNotifierResponseType : IStringEnum
{
    public static readonly AlertingIntegrationNotifierResponseType Integration = new(
        Values.Integration
    );

    public AlertingIntegrationNotifierResponseType(string value)
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
    public static AlertingIntegrationNotifierResponseType FromCustom(string value)
    {
        return new AlertingIntegrationNotifierResponseType(value);
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

    public static bool operator ==(AlertingIntegrationNotifierResponseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AlertingIntegrationNotifierResponseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AlertingIntegrationNotifierResponseType value) =>
        value.Value;

    public static explicit operator AlertingIntegrationNotifierResponseType(string value) =>
        new(value);

    internal class AlertingIntegrationNotifierResponseTypeSerializer
        : JsonConverter<AlertingIntegrationNotifierResponseType>
    {
        public override AlertingIntegrationNotifierResponseType Read(
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
            return new AlertingIntegrationNotifierResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingIntegrationNotifierResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AlertingIntegrationNotifierResponseType ReadAsPropertyName(
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
            return new AlertingIntegrationNotifierResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingIntegrationNotifierResponseType value,
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
