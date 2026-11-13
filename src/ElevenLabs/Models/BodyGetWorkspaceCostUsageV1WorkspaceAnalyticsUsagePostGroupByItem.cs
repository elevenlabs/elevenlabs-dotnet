using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace;

[JsonConverter(
    typeof(BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem.BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItemSerializer)
)]
[Serializable]
public readonly record struct BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem
    : IStringEnum
{
    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem Model =
        new(Values.Model);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem RequestSource =
        new(Values.RequestSource);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem FiatChargeType =
        new(Values.FiatChargeType);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem FiatCurrency =
        new(Values.FiatCurrency);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem UserId =
        new(Values.UserId);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem HashedXiApiKey =
        new(Values.HashedXiApiKey);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem Region =
        new(Values.Region);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem ReportingWorkspaceId =
        new(Values.ReportingWorkspaceId);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem BillingGroupId =
        new(Values.BillingGroupId);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem ProductType =
        new(Values.ProductType);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem Surface =
        new(Values.Surface);

    public static readonly BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem Actor =
        new(Values.Actor);

    public BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem(string value)
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
    public static BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem FromCustom(
        string value
    )
    {
        return new BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem(value);
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
        BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem value
    ) => value.Value;

    public static explicit operator BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem(
        string value
    ) => new(value);

    internal class BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItemSerializer
        : JsonConverter<BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem>
    {
        public override BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem Read(
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
            return new BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem ReadAsPropertyName(
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
            return new BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePostGroupByItem value,
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
