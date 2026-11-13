using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SafetyRule.SafetyRuleSerializer))]
[Serializable]
public readonly record struct SafetyRule : IStringEnum
{
    public static readonly SafetyRule SexualMinors = new(Values.SexualMinors);

    public static readonly SafetyRule ForgetModeration = new(Values.ForgetModeration);

    public static readonly SafetyRule Extremism = new(Values.Extremism);

    public static readonly SafetyRule ScamFraud = new(Values.ScamFraud);

    public static readonly SafetyRule Political = new(Values.Political);

    public static readonly SafetyRule SelfHarm = new(Values.SelfHarm);

    public static readonly SafetyRule IllegalDistributionMedical = new(
        Values.IllegalDistributionMedical
    );

    public static readonly SafetyRule SexualAdults = new(Values.SexualAdults);

    public static readonly SafetyRule Unknown = new(Values.Unknown);

    public SafetyRule(string value)
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
    public static SafetyRule FromCustom(string value)
    {
        return new SafetyRule(value);
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

    public static bool operator ==(SafetyRule value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(SafetyRule value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SafetyRule value) => value.Value;

    public static explicit operator SafetyRule(string value) => new(value);

    internal class SafetyRuleSerializer : JsonConverter<SafetyRule>
    {
        public override SafetyRule Read(
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
            return new SafetyRule(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SafetyRule value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SafetyRule ReadAsPropertyName(
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
            return new SafetyRule(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SafetyRule value,
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
        public const string SexualMinors = "sexual_minors";

        public const string ForgetModeration = "forget_moderation";

        public const string Extremism = "extremism";

        public const string ScamFraud = "scam_fraud";

        public const string Political = "political";

        public const string SelfHarm = "self_harm";

        public const string IllegalDistributionMedical = "illegal_distribution_medical";

        public const string SexualAdults = "sexual_adults";

        public const string Unknown = "unknown";
    }
}
