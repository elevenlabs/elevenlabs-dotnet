using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The time interval over which to aggregate the usage data.</summary>
[JsonConverter(typeof(UsageAggregationInterval.UsageAggregationIntervalSerializer))]
[Serializable]
public readonly record struct UsageAggregationInterval : IStringEnum
{
    public static readonly UsageAggregationInterval Hour = new(Values.Hour);

    public static readonly UsageAggregationInterval Day = new(Values.Day);

    public static readonly UsageAggregationInterval Week = new(Values.Week);

    public static readonly UsageAggregationInterval Month = new(Values.Month);

    public static readonly UsageAggregationInterval Cumulative = new(Values.Cumulative);

    public UsageAggregationInterval(string value)
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
    public static UsageAggregationInterval FromCustom(string value)
    {
        return new UsageAggregationInterval(value);
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

    public static bool operator ==(UsageAggregationInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UsageAggregationInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UsageAggregationInterval value) => value.Value;

    public static explicit operator UsageAggregationInterval(string value) => new(value);

    internal class UsageAggregationIntervalSerializer : JsonConverter<UsageAggregationInterval>
    {
        public override UsageAggregationInterval Read(
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
            return new UsageAggregationInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UsageAggregationInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UsageAggregationInterval ReadAsPropertyName(
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
            return new UsageAggregationInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UsageAggregationInterval value,
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
        public const string Hour = "hour";

        public const string Day = "day";

        public const string Week = "week";

        public const string Month = "month";

        public const string Cumulative = "cumulative";
    }
}
