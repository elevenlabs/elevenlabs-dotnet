using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstOrOperatorNodeInputType.AstOrOperatorNodeInputTypeSerializer))]
[Serializable]
public readonly record struct AstOrOperatorNodeInputType : IStringEnum
{
    public static readonly AstOrOperatorNodeInputType OrOperator = new(Values.OrOperator);

    public AstOrOperatorNodeInputType(string value)
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
    public static AstOrOperatorNodeInputType FromCustom(string value)
    {
        return new AstOrOperatorNodeInputType(value);
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

    public static bool operator ==(AstOrOperatorNodeInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstOrOperatorNodeInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstOrOperatorNodeInputType value) => value.Value;

    public static explicit operator AstOrOperatorNodeInputType(string value) => new(value);

    internal class AstOrOperatorNodeInputTypeSerializer : JsonConverter<AstOrOperatorNodeInputType>
    {
        public override AstOrOperatorNodeInputType Read(
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
            return new AstOrOperatorNodeInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstOrOperatorNodeInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstOrOperatorNodeInputType ReadAsPropertyName(
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
            return new AstOrOperatorNodeInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstOrOperatorNodeInputType value,
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
        public const string OrOperator = "or_operator";
    }
}
