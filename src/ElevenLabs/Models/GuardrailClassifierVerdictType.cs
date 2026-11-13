using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GuardrailClassifierVerdictType.GuardrailClassifierVerdictTypeSerializer))]
[Serializable]
public readonly record struct GuardrailClassifierVerdictType : IStringEnum
{
    public static readonly GuardrailClassifierVerdictType Classifier = new(Values.Classifier);

    public GuardrailClassifierVerdictType(string value)
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
    public static GuardrailClassifierVerdictType FromCustom(string value)
    {
        return new GuardrailClassifierVerdictType(value);
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

    public static bool operator ==(GuardrailClassifierVerdictType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardrailClassifierVerdictType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardrailClassifierVerdictType value) => value.Value;

    public static explicit operator GuardrailClassifierVerdictType(string value) => new(value);

    internal class GuardrailClassifierVerdictTypeSerializer
        : JsonConverter<GuardrailClassifierVerdictType>
    {
        public override GuardrailClassifierVerdictType Read(
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
            return new GuardrailClassifierVerdictType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardrailClassifierVerdictType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardrailClassifierVerdictType ReadAsPropertyName(
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
            return new GuardrailClassifierVerdictType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardrailClassifierVerdictType value,
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
        public const string Classifier = "classifier";
    }
}
