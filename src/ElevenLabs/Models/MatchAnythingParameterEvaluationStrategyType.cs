using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(MatchAnythingParameterEvaluationStrategyType.MatchAnythingParameterEvaluationStrategyTypeSerializer)
)]
[Serializable]
public readonly record struct MatchAnythingParameterEvaluationStrategyType : IStringEnum
{
    public static readonly MatchAnythingParameterEvaluationStrategyType Anything = new(
        Values.Anything
    );

    public MatchAnythingParameterEvaluationStrategyType(string value)
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
    public static MatchAnythingParameterEvaluationStrategyType FromCustom(string value)
    {
        return new MatchAnythingParameterEvaluationStrategyType(value);
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
        MatchAnythingParameterEvaluationStrategyType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        MatchAnythingParameterEvaluationStrategyType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(MatchAnythingParameterEvaluationStrategyType value) =>
        value.Value;

    public static explicit operator MatchAnythingParameterEvaluationStrategyType(string value) =>
        new(value);

    internal class MatchAnythingParameterEvaluationStrategyTypeSerializer
        : JsonConverter<MatchAnythingParameterEvaluationStrategyType>
    {
        public override MatchAnythingParameterEvaluationStrategyType Read(
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
            return new MatchAnythingParameterEvaluationStrategyType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MatchAnythingParameterEvaluationStrategyType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MatchAnythingParameterEvaluationStrategyType ReadAsPropertyName(
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
            return new MatchAnythingParameterEvaluationStrategyType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MatchAnythingParameterEvaluationStrategyType value,
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
        public const string Anything = "anything";
    }
}
