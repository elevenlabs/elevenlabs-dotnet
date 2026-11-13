using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Match any guardrail triggered by the generated turn.</summary>
[JsonConverter(
    typeof(UnitTestGuardrailTriggerEvaluationModelType.UnitTestGuardrailTriggerEvaluationModelTypeSerializer)
)]
[Serializable]
public readonly record struct UnitTestGuardrailTriggerEvaluationModelType : IStringEnum
{
    public static readonly UnitTestGuardrailTriggerEvaluationModelType Any = new(Values.Any);

    public UnitTestGuardrailTriggerEvaluationModelType(string value)
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
    public static UnitTestGuardrailTriggerEvaluationModelType FromCustom(string value)
    {
        return new UnitTestGuardrailTriggerEvaluationModelType(value);
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
        UnitTestGuardrailTriggerEvaluationModelType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UnitTestGuardrailTriggerEvaluationModelType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UnitTestGuardrailTriggerEvaluationModelType value) =>
        value.Value;

    public static explicit operator UnitTestGuardrailTriggerEvaluationModelType(string value) =>
        new(value);

    internal class UnitTestGuardrailTriggerEvaluationModelTypeSerializer
        : JsonConverter<UnitTestGuardrailTriggerEvaluationModelType>
    {
        public override UnitTestGuardrailTriggerEvaluationModelType Read(
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
            return new UnitTestGuardrailTriggerEvaluationModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnitTestGuardrailTriggerEvaluationModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UnitTestGuardrailTriggerEvaluationModelType ReadAsPropertyName(
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
            return new UnitTestGuardrailTriggerEvaluationModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UnitTestGuardrailTriggerEvaluationModelType value,
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
        public const string Any = "any";
    }
}
