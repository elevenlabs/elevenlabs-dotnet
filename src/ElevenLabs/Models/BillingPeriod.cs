using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(BillingPeriod.BillingPeriodSerializer))]
[Serializable]
public readonly record struct BillingPeriod : IStringEnum
{
    public static readonly BillingPeriod MonthlyPeriod = new(Values.MonthlyPeriod);

    public static readonly BillingPeriod ThreeMonthPeriod = new(Values.ThreeMonthPeriod);

    public static readonly BillingPeriod SixMonthPeriod = new(Values.SixMonthPeriod);

    public static readonly BillingPeriod AnnualPeriod = new(Values.AnnualPeriod);

    public BillingPeriod(string value)
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
    public static BillingPeriod FromCustom(string value)
    {
        return new BillingPeriod(value);
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

    public static bool operator ==(BillingPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BillingPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BillingPeriod value) => value.Value;

    public static explicit operator BillingPeriod(string value) => new(value);

    internal class BillingPeriodSerializer : JsonConverter<BillingPeriod>
    {
        public override BillingPeriod Read(
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
            return new BillingPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BillingPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BillingPeriod ReadAsPropertyName(
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
            return new BillingPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BillingPeriod value,
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
        public const string MonthlyPeriod = "monthly_period";

        public const string ThreeMonthPeriod = "3_month_period";

        public const string SixMonthPeriod = "6_month_period";

        public const string AnnualPeriod = "annual_period";
    }
}
