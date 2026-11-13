using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MetronomeUsageColumnFilterColumn.MetronomeUsageColumnFilterColumnSerializer))]
[Serializable]
public readonly record struct MetronomeUsageColumnFilterColumn : IStringEnum
{
    public static readonly MetronomeUsageColumnFilterColumn Model = new(Values.Model);

    public static readonly MetronomeUsageColumnFilterColumn RequestSource = new(
        Values.RequestSource
    );

    public static readonly MetronomeUsageColumnFilterColumn FiatChargeType = new(
        Values.FiatChargeType
    );

    public static readonly MetronomeUsageColumnFilterColumn FiatCurrency = new(Values.FiatCurrency);

    public static readonly MetronomeUsageColumnFilterColumn UserId = new(Values.UserId);

    public static readonly MetronomeUsageColumnFilterColumn HashedXiApiKey = new(
        Values.HashedXiApiKey
    );

    public static readonly MetronomeUsageColumnFilterColumn Region = new(Values.Region);

    public static readonly MetronomeUsageColumnFilterColumn ReportingWorkspaceId = new(
        Values.ReportingWorkspaceId
    );

    public static readonly MetronomeUsageColumnFilterColumn BillingGroupId = new(
        Values.BillingGroupId
    );

    public static readonly MetronomeUsageColumnFilterColumn ProductType = new(Values.ProductType);

    public static readonly MetronomeUsageColumnFilterColumn Surface = new(Values.Surface);

    public static readonly MetronomeUsageColumnFilterColumn Actor = new(Values.Actor);

    public MetronomeUsageColumnFilterColumn(string value)
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
    public static MetronomeUsageColumnFilterColumn FromCustom(string value)
    {
        return new MetronomeUsageColumnFilterColumn(value);
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

    public static bool operator ==(MetronomeUsageColumnFilterColumn value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MetronomeUsageColumnFilterColumn value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MetronomeUsageColumnFilterColumn value) => value.Value;

    public static explicit operator MetronomeUsageColumnFilterColumn(string value) => new(value);

    internal class MetronomeUsageColumnFilterColumnSerializer
        : JsonConverter<MetronomeUsageColumnFilterColumn>
    {
        public override MetronomeUsageColumnFilterColumn Read(
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
            return new MetronomeUsageColumnFilterColumn(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MetronomeUsageColumnFilterColumn value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MetronomeUsageColumnFilterColumn ReadAsPropertyName(
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
            return new MetronomeUsageColumnFilterColumn(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MetronomeUsageColumnFilterColumn value,
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
        public const string Model = "model";

        public const string RequestSource = "request_source";

        public const string FiatChargeType = "fiat_charge_type";

        public const string FiatCurrency = "fiat_currency";

        public const string UserId = "user_id";

        public const string HashedXiApiKey = "hashed_xi_api_key";

        public const string Region = "region";

        public const string ReportingWorkspaceId = "reporting_workspace_id";

        public const string BillingGroupId = "billing_group_id";

        public const string ProductType = "product_type";

        public const string Surface = "surface";

        public const string Actor = "actor";
    }
}
