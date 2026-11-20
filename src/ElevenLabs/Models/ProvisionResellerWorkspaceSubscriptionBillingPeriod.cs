using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ProvisionResellerWorkspaceSubscriptionBillingPeriod.ProvisionResellerWorkspaceSubscriptionBillingPeriodSerializer)
)]
[Serializable]
public readonly record struct ProvisionResellerWorkspaceSubscriptionBillingPeriod : IStringEnum
{
    public static readonly ProvisionResellerWorkspaceSubscriptionBillingPeriod MonthlyPeriod = new(
        Values.MonthlyPeriod
    );

    public static readonly ProvisionResellerWorkspaceSubscriptionBillingPeriod AnnualPeriod = new(
        Values.AnnualPeriod
    );

    public ProvisionResellerWorkspaceSubscriptionBillingPeriod(string value)
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
    public static ProvisionResellerWorkspaceSubscriptionBillingPeriod FromCustom(string value)
    {
        return new ProvisionResellerWorkspaceSubscriptionBillingPeriod(value);
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
        ProvisionResellerWorkspaceSubscriptionBillingPeriod value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ProvisionResellerWorkspaceSubscriptionBillingPeriod value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ProvisionResellerWorkspaceSubscriptionBillingPeriod value
    ) => value.Value;

    public static explicit operator ProvisionResellerWorkspaceSubscriptionBillingPeriod(
        string value
    ) => new(value);

    internal class ProvisionResellerWorkspaceSubscriptionBillingPeriodSerializer
        : JsonConverter<ProvisionResellerWorkspaceSubscriptionBillingPeriod>
    {
        public override ProvisionResellerWorkspaceSubscriptionBillingPeriod Read(
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
            return new ProvisionResellerWorkspaceSubscriptionBillingPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProvisionResellerWorkspaceSubscriptionBillingPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProvisionResellerWorkspaceSubscriptionBillingPeriod ReadAsPropertyName(
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
            return new ProvisionResellerWorkspaceSubscriptionBillingPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProvisionResellerWorkspaceSubscriptionBillingPeriod value,
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
