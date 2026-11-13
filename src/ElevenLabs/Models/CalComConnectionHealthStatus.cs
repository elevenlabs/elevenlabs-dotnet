using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CalComConnectionHealthStatus.CalComConnectionHealthStatusSerializer))]
[Serializable]
public readonly record struct CalComConnectionHealthStatus : IStringEnum
{
    public static readonly CalComConnectionHealthStatus Healthy = new(Values.Healthy);

    public static readonly CalComConnectionHealthStatus NeedsReauth = new(Values.NeedsReauth);

    public CalComConnectionHealthStatus(string value)
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
    public static CalComConnectionHealthStatus FromCustom(string value)
    {
        return new CalComConnectionHealthStatus(value);
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

    public static bool operator ==(CalComConnectionHealthStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CalComConnectionHealthStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CalComConnectionHealthStatus value) => value.Value;

    public static explicit operator CalComConnectionHealthStatus(string value) => new(value);

    internal class CalComConnectionHealthStatusSerializer
        : JsonConverter<CalComConnectionHealthStatus>
    {
        public override CalComConnectionHealthStatus Read(
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
            return new CalComConnectionHealthStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CalComConnectionHealthStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CalComConnectionHealthStatus ReadAsPropertyName(
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
            return new CalComConnectionHealthStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CalComConnectionHealthStatus value,
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
