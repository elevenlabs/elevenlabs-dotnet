using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstDivisionOperatorNodeInputType.AstDivisionOperatorNodeInputTypeSerializer))]
[Serializable]
public readonly record struct AstDivisionOperatorNodeInputType : IStringEnum
{
    public static readonly AstDivisionOperatorNodeInputType DivOperator = new(Values.DivOperator);

    public AstDivisionOperatorNodeInputType(string value)
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
    public static AstDivisionOperatorNodeInputType FromCustom(string value)
    {
        return new AstDivisionOperatorNodeInputType(value);
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

    public static bool operator ==(AstDivisionOperatorNodeInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstDivisionOperatorNodeInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstDivisionOperatorNodeInputType value) => value.Value;

    public static explicit operator AstDivisionOperatorNodeInputType(string value) => new(value);

    internal class AstDivisionOperatorNodeInputTypeSerializer
        : JsonConverter<AstDivisionOperatorNodeInputType>
    {
        public override AstDivisionOperatorNodeInputType Read(
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
            return new AstDivisionOperatorNodeInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstDivisionOperatorNodeInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstDivisionOperatorNodeInputType ReadAsPropertyName(
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
            return new AstDivisionOperatorNodeInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstDivisionOperatorNodeInputType value,
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
