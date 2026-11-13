using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of evaluation criteria</summary>
[JsonConverter(typeof(PromptEvaluationCriteriaType.PromptEvaluationCriteriaTypeSerializer))]
[Serializable]
public readonly record struct PromptEvaluationCriteriaType : IStringEnum
{
    public static readonly PromptEvaluationCriteriaType Prompt = new(Values.Prompt);

    public PromptEvaluationCriteriaType(string value)
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
    public static PromptEvaluationCriteriaType FromCustom(string value)
    {
        return new PromptEvaluationCriteriaType(value);
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

    public static bool operator ==(PromptEvaluationCriteriaType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PromptEvaluationCriteriaType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PromptEvaluationCriteriaType value) => value.Value;

    public static explicit operator PromptEvaluationCriteriaType(string value) => new(value);

    internal class PromptEvaluationCriteriaTypeSerializer
        : JsonConverter<PromptEvaluationCriteriaType>
    {
        public override PromptEvaluationCriteriaType Read(
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
            return new PromptEvaluationCriteriaType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromptEvaluationCriteriaType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PromptEvaluationCriteriaType ReadAsPropertyName(
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
            return new PromptEvaluationCriteriaType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PromptEvaluationCriteriaType value,
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
        public const string Prompt = "prompt";
    }
}
