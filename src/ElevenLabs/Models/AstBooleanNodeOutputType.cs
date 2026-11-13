using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstBooleanNodeOutputType.AstBooleanNodeOutputTypeSerializer))]
[Serializable]
public readonly record struct AstBooleanNodeOutputType : IStringEnum
{
    public static readonly AstBooleanNodeOutputType BooleanLiteral = new(Values.BooleanLiteral);

    public AstBooleanNodeOutputType(string value)
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
    public static AstBooleanNodeOutputType FromCustom(string value)
    {
        return new AstBooleanNodeOutputType(value);
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

    public static bool operator ==(AstBooleanNodeOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstBooleanNodeOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstBooleanNodeOutputType value) => value.Value;

    public static explicit operator AstBooleanNodeOutputType(string value) => new(value);

    internal class AstBooleanNodeOutputTypeSerializer : JsonConverter<AstBooleanNodeOutputType>
    {
        public override AstBooleanNodeOutputType Read(
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
            return new AstBooleanNodeOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstBooleanNodeOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstBooleanNodeOutputType ReadAsPropertyName(
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
            return new AstBooleanNodeOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstBooleanNodeOutputType value,
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
        public const string BooleanLiteral = "boolean_literal";
    }
}
