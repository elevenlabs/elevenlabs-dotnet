using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AstMultiplicationOperatorNodeOutputType.AstMultiplicationOperatorNodeOutputTypeSerializer)
)]
[Serializable]
public readonly record struct AstMultiplicationOperatorNodeOutputType : IStringEnum
{
    public static readonly AstMultiplicationOperatorNodeOutputType MulOperator = new(
        Values.MulOperator
    );

    public AstMultiplicationOperatorNodeOutputType(string value)
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
    public static AstMultiplicationOperatorNodeOutputType FromCustom(string value)
    {
        return new AstMultiplicationOperatorNodeOutputType(value);
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

    public static bool operator ==(AstMultiplicationOperatorNodeOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstMultiplicationOperatorNodeOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstMultiplicationOperatorNodeOutputType value) =>
        value.Value;

    public static explicit operator AstMultiplicationOperatorNodeOutputType(string value) =>
        new(value);

    internal class AstMultiplicationOperatorNodeOutputTypeSerializer
        : JsonConverter<AstMultiplicationOperatorNodeOutputType>
    {
        public override AstMultiplicationOperatorNodeOutputType Read(
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
            return new AstMultiplicationOperatorNodeOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstMultiplicationOperatorNodeOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstMultiplicationOperatorNodeOutputType ReadAsPropertyName(
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
            return new AstMultiplicationOperatorNodeOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstMultiplicationOperatorNodeOutputType value,
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
        public const string MulOperator = "mul_operator";
    }
}
