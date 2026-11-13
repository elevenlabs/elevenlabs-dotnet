using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The tier to change to.</summary>
[JsonConverter(
    typeof(PendingSubscriptionSwitchResponseModelNextTier.PendingSubscriptionSwitchResponseModelNextTierSerializer)
)]
[Serializable]
public readonly record struct PendingSubscriptionSwitchResponseModelNextTier : IStringEnum
{
    public static readonly PendingSubscriptionSwitchResponseModelNextTier Free = new(Values.Free);

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Starter = new(
        Values.Starter
    );

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Go = new(Values.Go);

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Creator = new(
        Values.Creator
    );

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Pro = new(Values.Pro);

    public static readonly PendingSubscriptionSwitchResponseModelNextTier GrowingBusiness = new(
        Values.GrowingBusiness
    );

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Scale20240810 = new(
        Values.Scale20240810
    );

    public static readonly PendingSubscriptionSwitchResponseModelNextTier GrantTier120250723 = new(
        Values.GrantTier120250723
    );

    public static readonly PendingSubscriptionSwitchResponseModelNextTier GrantTier220250723 = new(
        Values.GrantTier220250723
    );

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Grant = new(Values.Grant);

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Trial = new(Values.Trial);

    public static readonly PendingSubscriptionSwitchResponseModelNextTier Enterprise = new(
        Values.Enterprise
    );

    public PendingSubscriptionSwitchResponseModelNextTier(string value)
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
    public static PendingSubscriptionSwitchResponseModelNextTier FromCustom(string value)
    {
        return new PendingSubscriptionSwitchResponseModelNextTier(value);
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
        PendingSubscriptionSwitchResponseModelNextTier value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PendingSubscriptionSwitchResponseModelNextTier value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(PendingSubscriptionSwitchResponseModelNextTier value) =>
        value.Value;

    public static explicit operator PendingSubscriptionSwitchResponseModelNextTier(string value) =>
        new(value);

    internal class PendingSubscriptionSwitchResponseModelNextTierSerializer
        : JsonConverter<PendingSubscriptionSwitchResponseModelNextTier>
    {
        public override PendingSubscriptionSwitchResponseModelNextTier Read(
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
            return new PendingSubscriptionSwitchResponseModelNextTier(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PendingSubscriptionSwitchResponseModelNextTier value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PendingSubscriptionSwitchResponseModelNextTier ReadAsPropertyName(
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
            return new PendingSubscriptionSwitchResponseModelNextTier(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PendingSubscriptionSwitchResponseModelNextTier value,
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
        public const string Free = "free";

        public const string Starter = "starter";

        public const string Go = "go";

        public const string Creator = "creator";

        public const string Pro = "pro";

        public const string GrowingBusiness = "growing_business";

        public const string Scale20240810 = "scale_2024_08_10";

        public const string GrantTier120250723 = "grant_tier_1_2025_07_23";

        public const string GrantTier220250723 = "grant_tier_2_2025_07_23";

        public const string Grant = "grant";

        public const string Trial = "trial";

        public const string Enterprise = "enterprise";
    }
}
