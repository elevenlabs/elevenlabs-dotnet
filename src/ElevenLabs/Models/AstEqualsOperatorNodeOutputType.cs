using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstEqualsOperatorNodeOutputType.AstEqualsOperatorNodeOutputTypeSerializer))]
[Serializable]
public readonly record struct AstEqualsOperatorNodeOutputType : IStringEnum
{
    public static readonly AstEqualsOperatorNodeOutputType EqOperator = new(Values.EqOperator);

    public AstEqualsOperatorNodeOutputType(string value)
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
    public static AstEqualsOperatorNodeOutputType FromCustom(string value)
    {
        return new AstEqualsOperatorNodeOutputType(value);
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

    public static bool operator ==(AstEqualsOperatorNodeOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstEqualsOperatorNodeOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstEqualsOperatorNodeOutputType value) => value.Value;

    public static explicit operator AstEqualsOperatorNodeOutputType(string value) => new(value);

    internal class AstEqualsOperatorNodeOutputTypeSerializer
        : JsonConverter<AstEqualsOperatorNodeOutputType>
    {
        public override AstEqualsOperatorNodeOutputType Read(
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
            return new AstEqualsOperatorNodeOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstEqualsOperatorNodeOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstEqualsOperatorNodeOutputType ReadAsPropertyName(
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
            return new AstEqualsOperatorNodeOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstEqualsOperatorNodeOutputType value,
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
        public const string EqOperator = "eq_operator";
    }
}
