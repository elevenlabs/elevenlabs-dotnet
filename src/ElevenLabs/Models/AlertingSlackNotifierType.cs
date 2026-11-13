using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AlertingSlackNotifierType.AlertingSlackNotifierTypeSerializer))]
[Serializable]
public readonly record struct AlertingSlackNotifierType : IStringEnum
{
    public static readonly AlertingSlackNotifierType Integration = new(Values.Integration);

    public AlertingSlackNotifierType(string value)
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
    public static AlertingSlackNotifierType FromCustom(string value)
    {
        return new AlertingSlackNotifierType(value);
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

    public static bool operator ==(AlertingSlackNotifierType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AlertingSlackNotifierType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AlertingSlackNotifierType value) => value.Value;

    public static explicit operator AlertingSlackNotifierType(string value) => new(value);

    internal class AlertingSlackNotifierTypeSerializer : JsonConverter<AlertingSlackNotifierType>
    {
        public override AlertingSlackNotifierType Read(
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
            return new AlertingSlackNotifierType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AlertingSlackNotifierType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AlertingSlackNotifierType ReadAsPropertyName(
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
            return new AlertingSlackNotifierType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AlertingSlackNotifierType value,
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
