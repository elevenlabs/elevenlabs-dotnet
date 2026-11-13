using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AstDivisionOperatorNodeOutputType.AstDivisionOperatorNodeOutputTypeSerializer)
)]
[Serializable]
public readonly record struct AstDivisionOperatorNodeOutputType : IStringEnum
{
    public static readonly AstDivisionOperatorNodeOutputType DivOperator = new(Values.DivOperator);

    public AstDivisionOperatorNodeOutputType(string value)
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
    public static AstDivisionOperatorNodeOutputType FromCustom(string value)
    {
        return new AstDivisionOperatorNodeOutputType(value);
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

    public static bool operator ==(AstDivisionOperatorNodeOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstDivisionOperatorNodeOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstDivisionOperatorNodeOutputType value) => value.Value;

    public static explicit operator AstDivisionOperatorNodeOutputType(string value) => new(value);

    internal class AstDivisionOperatorNodeOutputTypeSerializer
        : JsonConverter<AstDivisionOperatorNodeOutputType>
    {
        public override AstDivisionOperatorNodeOutputType Read(
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
            return new AstDivisionOperatorNodeOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstDivisionOperatorNodeOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstDivisionOperatorNodeOutputType ReadAsPropertyName(
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
            return new AstDivisionOperatorNodeOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstDivisionOperatorNodeOutputType value,
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
        public const string DivOperator = "div_operator";
    }
}
