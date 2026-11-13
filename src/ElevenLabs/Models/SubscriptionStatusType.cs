using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SubscriptionStatusType.SubscriptionStatusTypeSerializer))]
[Serializable]
public readonly record struct SubscriptionStatusType : IStringEnum
{
    public static readonly SubscriptionStatusType Trialing = new(Values.Trialing);

    public static readonly SubscriptionStatusType Active = new(Values.Active);

    public static readonly SubscriptionStatusType Incomplete = new(Values.Incomplete);

    public static readonly SubscriptionStatusType PastDue = new(Values.PastDue);

    public static readonly SubscriptionStatusType Free = new(Values.Free);

    public static readonly SubscriptionStatusType FreeDisabled = new(Values.FreeDisabled);

    public SubscriptionStatusType(string value)
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
    public static SubscriptionStatusType FromCustom(string value)
    {
        return new SubscriptionStatusType(value);
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

    public static bool operator ==(SubscriptionStatusType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionStatusType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionStatusType value) => value.Value;

    public static explicit operator SubscriptionStatusType(string value) => new(value);

    internal class SubscriptionStatusTypeSerializer : JsonConverter<SubscriptionStatusType>
    {
        public override SubscriptionStatusType Read(
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
            return new SubscriptionStatusType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubscriptionStatusType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubscriptionStatusType ReadAsPropertyName(
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
            return new SubscriptionStatusType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubscriptionStatusType value,
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
        public const string Trialing = "trialing";

        public const string Active = "active";

        public const string Incomplete = "incomplete";

        public const string PastDue = "past_due";

        public const string Free = "free";

        public const string FreeDisabled = "free_disabled";
    }
}
