using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SystemEvaluationId.SystemEvaluationIdSerializer))]
[Serializable]
public readonly record struct SystemEvaluationId : IStringEnum
{
    public static readonly SystemEvaluationId SystemEvalCriteriaSentiment = new(
        Values.SystemEvalCriteriaSentiment
    );

    public static readonly SystemEvaluationId SystemEvalCriteriaFrustration = new(
        Values.SystemEvalCriteriaFrustration
    );

    public SystemEvaluationId(string value)
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
    public static SystemEvaluationId FromCustom(string value)
    {
        return new SystemEvaluationId(value);
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

    public static bool operator ==(SystemEvaluationId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SystemEvaluationId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SystemEvaluationId value) => value.Value;

    public static explicit operator SystemEvaluationId(string value) => new(value);

    internal class SystemEvaluationIdSerializer : JsonConverter<SystemEvaluationId>
    {
        public override SystemEvaluationId Read(
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
            return new SystemEvaluationId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SystemEvaluationId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SystemEvaluationId ReadAsPropertyName(
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
            return new SystemEvaluationId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SystemEvaluationId value,
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
        public const string SystemEvalCriteriaSentiment = "__system_eval_criteria_sentiment";

        public const string SystemEvalCriteriaFrustration = "__system_eval_criteria_frustration";
    }
}
