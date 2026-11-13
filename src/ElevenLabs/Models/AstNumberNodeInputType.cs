using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstNumberNodeInputType.AstNumberNodeInputTypeSerializer))]
[Serializable]
public readonly record struct AstNumberNodeInputType : IStringEnum
{
    public static readonly AstNumberNodeInputType NumberLiteral = new(Values.NumberLiteral);

    public AstNumberNodeInputType(string value)
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
    public static AstNumberNodeInputType FromCustom(string value)
    {
        return new AstNumberNodeInputType(value);
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

    public static bool operator ==(AstNumberNodeInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstNumberNodeInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstNumberNodeInputType value) => value.Value;

    public static explicit operator AstNumberNodeInputType(string value) => new(value);

    internal class AstNumberNodeInputTypeSerializer : JsonConverter<AstNumberNodeInputType>
    {
        public override AstNumberNodeInputType Read(
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
            return new AstNumberNodeInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstNumberNodeInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstNumberNodeInputType ReadAsPropertyName(
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
            return new AstNumberNodeInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstNumberNodeInputType value,
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
        public const string NumberLiteral = "number_literal";
    }
}
