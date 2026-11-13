using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DirectPublishingReadResponseModelPayoutType.DirectPublishingReadResponseModelPayoutTypeSerializer)
)]
[Serializable]
public readonly record struct DirectPublishingReadResponseModelPayoutType : IStringEnum
{
    public static readonly DirectPublishingReadResponseModelPayoutType None = new(Values.None);

    public static readonly DirectPublishingReadResponseModelPayoutType EngagementBased = new(
        Values.EngagementBased
    );

    public static readonly DirectPublishingReadResponseModelPayoutType FixedPayout = new(
        Values.FixedPayout
    );

    public DirectPublishingReadResponseModelPayoutType(string value)
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
    public static DirectPublishingReadResponseModelPayoutType FromCustom(string value)
    {
        return new DirectPublishingReadResponseModelPayoutType(value);
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
        DirectPublishingReadResponseModelPayoutType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DirectPublishingReadResponseModelPayoutType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DirectPublishingReadResponseModelPayoutType value) =>
        value.Value;

    public static explicit operator DirectPublishingReadResponseModelPayoutType(string value) =>
        new(value);

    internal class DirectPublishingReadResponseModelPayoutTypeSerializer
        : JsonConverter<DirectPublishingReadResponseModelPayoutType>
    {
        public override DirectPublishingReadResponseModelPayoutType Read(
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
            return new DirectPublishingReadResponseModelPayoutType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelPayoutType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DirectPublishingReadResponseModelPayoutType ReadAsPropertyName(
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
            return new DirectPublishingReadResponseModelPayoutType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelPayoutType value,
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
        public const string None = "none";

        public const string EngagementBased = "engagement_based";

        public const string FixedPayout = "fixed_payout";
    }
}
