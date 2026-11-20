using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Reception;

[JsonConverter(
    typeof(ChangeResellerTierRequestBillingPeriod.ChangeResellerTierRequestBillingPeriodSerializer)
)]
[Serializable]
public readonly record struct ChangeResellerTierRequestBillingPeriod : IStringEnum
{
    public static readonly ChangeResellerTierRequestBillingPeriod MonthlyPeriod = new(
        Values.MonthlyPeriod
    );

    public static readonly ChangeResellerTierRequestBillingPeriod AnnualPeriod = new(
        Values.AnnualPeriod
    );

    public ChangeResellerTierRequestBillingPeriod(string value)
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
    public static ChangeResellerTierRequestBillingPeriod FromCustom(string value)
    {
        return new ChangeResellerTierRequestBillingPeriod(value);
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

    public static bool operator ==(ChangeResellerTierRequestBillingPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChangeResellerTierRequestBillingPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChangeResellerTierRequestBillingPeriod value) =>
        value.Value;

    public static explicit operator ChangeResellerTierRequestBillingPeriod(string value) =>
        new(value);

    internal class ChangeResellerTierRequestBillingPeriodSerializer
        : JsonConverter<ChangeResellerTierRequestBillingPeriod>
    {
        public override ChangeResellerTierRequestBillingPeriod Read(
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
            return new ChangeResellerTierRequestBillingPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChangeResellerTierRequestBillingPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ChangeResellerTierRequestBillingPeriod ReadAsPropertyName(
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
            return new ChangeResellerTierRequestBillingPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChangeResellerTierRequestBillingPeriod value,
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

        public const string AnnualPeriod = "annual_period";
    }
}
