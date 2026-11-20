using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Reception;

[JsonConverter(
    typeof(AssignResellerTierRequestBillingPeriod.AssignResellerTierRequestBillingPeriodSerializer)
)]
[Serializable]
public readonly record struct AssignResellerTierRequestBillingPeriod : IStringEnum
{
    public static readonly AssignResellerTierRequestBillingPeriod MonthlyPeriod = new(
        Values.MonthlyPeriod
    );

    public static readonly AssignResellerTierRequestBillingPeriod AnnualPeriod = new(
        Values.AnnualPeriod
    );

    public AssignResellerTierRequestBillingPeriod(string value)
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
    public static AssignResellerTierRequestBillingPeriod FromCustom(string value)
    {
        return new AssignResellerTierRequestBillingPeriod(value);
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

    public static bool operator ==(AssignResellerTierRequestBillingPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AssignResellerTierRequestBillingPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AssignResellerTierRequestBillingPeriod value) =>
        value.Value;

    public static explicit operator AssignResellerTierRequestBillingPeriod(string value) =>
        new(value);

    internal class AssignResellerTierRequestBillingPeriodSerializer
        : JsonConverter<AssignResellerTierRequestBillingPeriod>
    {
        public override AssignResellerTierRequestBillingPeriod Read(
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
            return new AssignResellerTierRequestBillingPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AssignResellerTierRequestBillingPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AssignResellerTierRequestBillingPeriod ReadAsPropertyName(
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
            return new AssignResellerTierRequestBillingPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AssignResellerTierRequestBillingPeriod value,
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
