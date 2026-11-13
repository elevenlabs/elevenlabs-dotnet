using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MetricType.MetricTypeSerializer))]
[Serializable]
public readonly record struct MetricType : IStringEnum
{
    public static readonly MetricType Credits = new(Values.Credits);

    public static readonly MetricType TtsCharacters = new(Values.TtsCharacters);

    public static readonly MetricType MinutesUsed = new(Values.MinutesUsed);

    public static readonly MetricType RequestCount = new(Values.RequestCount);

    public static readonly MetricType TtfbAvg = new(Values.TtfbAvg);

    public static readonly MetricType TtfbP95 = new(Values.TtfbP95);

    public static readonly MetricType FiatUnitsSpent = new(Values.FiatUnitsSpent);

    public static readonly MetricType Concurrency = new(Values.Concurrency);

    public static readonly MetricType ConcurrencyAverage = new(Values.ConcurrencyAverage);

    public MetricType(string value)
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
    public static MetricType FromCustom(string value)
    {
        return new MetricType(value);
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

    public static bool operator ==(MetricType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(MetricType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MetricType value) => value.Value;

    public static explicit operator MetricType(string value) => new(value);

    internal class MetricTypeSerializer : JsonConverter<MetricType>
    {
        public override MetricType Read(
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
            return new MetricType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MetricType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MetricType ReadAsPropertyName(
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
            return new MetricType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MetricType value,
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
        public const string Credits = "credits";

        public const string TtsCharacters = "tts_characters";

        public const string MinutesUsed = "minutes_used";

        public const string RequestCount = "request_count";

        public const string TtfbAvg = "ttfb_avg";

        public const string TtfbP95 = "ttfb_p95";

        public const string FiatUnitsSpent = "fiat_units_spent";

        public const string Concurrency = "concurrency";

        public const string ConcurrencyAverage = "concurrency_average";
    }
}
