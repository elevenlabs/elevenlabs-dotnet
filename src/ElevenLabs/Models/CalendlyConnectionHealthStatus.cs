using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CalendlyConnectionHealthStatus.CalendlyConnectionHealthStatusSerializer))]
[Serializable]
public readonly record struct CalendlyConnectionHealthStatus : IStringEnum
{
    public static readonly CalendlyConnectionHealthStatus Healthy = new(Values.Healthy);

    public static readonly CalendlyConnectionHealthStatus NeedsReauth = new(Values.NeedsReauth);

    public CalendlyConnectionHealthStatus(string value)
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
    public static CalendlyConnectionHealthStatus FromCustom(string value)
    {
        return new CalendlyConnectionHealthStatus(value);
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

    public static bool operator ==(CalendlyConnectionHealthStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CalendlyConnectionHealthStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CalendlyConnectionHealthStatus value) => value.Value;

    public static explicit operator CalendlyConnectionHealthStatus(string value) => new(value);

    internal class CalendlyConnectionHealthStatusSerializer
        : JsonConverter<CalendlyConnectionHealthStatus>
    {
        public override CalendlyConnectionHealthStatus Read(
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
            return new CalendlyConnectionHealthStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CalendlyConnectionHealthStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CalendlyConnectionHealthStatus ReadAsPropertyName(
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
            return new CalendlyConnectionHealthStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CalendlyConnectionHealthStatus value,
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
        public const string Healthy = "healthy";

        public const string NeedsReauth = "needs_reauth";
    }
}
