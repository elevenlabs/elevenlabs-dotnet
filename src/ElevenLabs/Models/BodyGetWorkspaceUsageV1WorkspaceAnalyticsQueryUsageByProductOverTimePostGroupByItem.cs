using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace;

[JsonConverter(
    typeof(BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem.BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItemSerializer)
)]
[Serializable]
public readonly record struct BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem
    : IStringEnum
{
    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem ProductType =
        new(Values.ProductType);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem Model =
        new(Values.Model);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem VoiceId =
        new(Values.VoiceId);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem UserId =
        new(Values.UserId);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem FiatCurrency =
        new(Values.FiatCurrency);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem FiatChargeType =
        new(Values.FiatChargeType);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem Region =
        new(Values.Region);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem ReportingWorkspaceId =
        new(Values.ReportingWorkspaceId);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem RequestSource =
        new(Values.RequestSource);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem ResourceId =
        new(Values.ResourceId);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem SubresourceId =
        new(Values.SubresourceId);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem RequestQueueType =
        new(Values.RequestQueueType);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem VoiceMultiplier =
        new(Values.VoiceMultiplier);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem HashedXiApiKey =
        new(Values.HashedXiApiKey);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem BillingGroupId =
        new(Values.BillingGroupId);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem Surface =
        new(Values.Surface);

    public static readonly BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem Actor =
        new(Values.Actor);

    public BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem(
        string value
    )
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
    public static BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem FromCustom(
        string value
    )
    {
        return new BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem(
            value
        );
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
        BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem value
    ) => value.Value;

    public static explicit operator BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem(
        string value
    ) => new(value);

    internal class BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItemSerializer
        : JsonConverter<BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem>
    {
        public override BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem Read(
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
            return new BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem ReadAsPropertyName(
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
            return new BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePostGroupByItem value,
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
        public const string ProductType = "product_type";

        public const string Model = "model";

        public const string VoiceId = "voice_id";

        public const string UserId = "user_id";

        public const string FiatCurrency = "fiat_currency";

        public const string FiatChargeType = "fiat_charge_type";

        public const string Region = "region";

        public const string ReportingWorkspaceId = "reporting_workspace_id";

        public const string RequestSource = "request_source";

        public const string ResourceId = "resource_id";

        public const string SubresourceId = "subresource_id";

        public const string RequestQueueType = "request_queue_type";

        public const string VoiceMultiplier = "voice_multiplier";

        public const string HashedXiApiKey = "hashed_xi_api_key";

        public const string BillingGroupId = "billing_group_id";

        public const string Surface = "surface";

        public const string Actor = "actor";
    }
}
