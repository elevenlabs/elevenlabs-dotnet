using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AstNotEqualsOperatorNodeOutputType.AstNotEqualsOperatorNodeOutputTypeSerializer)
)]
[Serializable]
public readonly record struct AstNotEqualsOperatorNodeOutputType : IStringEnum
{
    public static readonly AstNotEqualsOperatorNodeOutputType NeqOperator = new(Values.NeqOperator);

    public AstNotEqualsOperatorNodeOutputType(string value)
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
    public static AstNotEqualsOperatorNodeOutputType FromCustom(string value)
    {
        return new AstNotEqualsOperatorNodeOutputType(value);
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

    public static bool operator ==(AstNotEqualsOperatorNodeOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstNotEqualsOperatorNodeOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstNotEqualsOperatorNodeOutputType value) => value.Value;

    public static explicit operator AstNotEqualsOperatorNodeOutputType(string value) => new(value);

    internal class AstNotEqualsOperatorNodeOutputTypeSerializer
        : JsonConverter<AstNotEqualsOperatorNodeOutputType>
    {
        public override AstNotEqualsOperatorNodeOutputType Read(
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
            return new AstNotEqualsOperatorNodeOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstNotEqualsOperatorNodeOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstNotEqualsOperatorNodeOutputType ReadAsPropertyName(
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
            return new AstNotEqualsOperatorNodeOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstNotEqualsOperatorNodeOutputType value,
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
        public const string NeqOperator = "neq_operator";
    }
}
