using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstBooleanNodeInputType.AstBooleanNodeInputTypeSerializer))]
[Serializable]
public readonly record struct AstBooleanNodeInputType : IStringEnum
{
    public static readonly AstBooleanNodeInputType BooleanLiteral = new(Values.BooleanLiteral);

    public AstBooleanNodeInputType(string value)
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
    public static AstBooleanNodeInputType FromCustom(string value)
    {
        return new AstBooleanNodeInputType(value);
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

    public static bool operator ==(AstBooleanNodeInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstBooleanNodeInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstBooleanNodeInputType value) => value.Value;

    public static explicit operator AstBooleanNodeInputType(string value) => new(value);

    internal class AstBooleanNodeInputTypeSerializer : JsonConverter<AstBooleanNodeInputType>
    {
        public override AstBooleanNodeInputType Read(
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
            return new AstBooleanNodeInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstBooleanNodeInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstBooleanNodeInputType ReadAsPropertyName(
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
            return new AstBooleanNodeInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstBooleanNodeInputType value,
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
