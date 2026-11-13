using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LockReason.LockReasonSerializer))]
[Serializable]
public readonly record struct LockReason : IStringEnum
{
    public static readonly LockReason TrialEnded = new(Values.TrialEnded);

    public static readonly LockReason SubscriptionDowngrade = new(Values.SubscriptionDowngrade);

    public static readonly LockReason ExposedPublicly = new(Values.ExposedPublicly);

    public static readonly LockReason SelfDisabled = new(Values.SelfDisabled);

    public LockReason(string value)
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
    public static LockReason FromCustom(string value)
    {
        return new LockReason(value);
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

    public static bool operator ==(LockReason value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(LockReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LockReason value) => value.Value;

    public static explicit operator LockReason(string value) => new(value);

    internal class LockReasonSerializer : JsonConverter<LockReason>
    {
        public override LockReason Read(
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
            return new LockReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LockReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LockReason ReadAsPropertyName(
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
            return new LockReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LockReason value,
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
        public const string TrialEnded = "trial_ended";

        public const string SubscriptionDowngrade = "subscription_downgrade";

        public const string ExposedPublicly = "exposed_publicly";

        public const string SelfDisabled = "self_disabled";
    }
}
