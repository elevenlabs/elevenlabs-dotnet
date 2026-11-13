using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AstConditionalOperatorNodeInputType.AstConditionalOperatorNodeInputTypeSerializer)
)]
[Serializable]
public readonly record struct AstConditionalOperatorNodeInputType : IStringEnum
{
    public static readonly AstConditionalOperatorNodeInputType ConditionalOperator = new(
        Values.ConditionalOperator
    );

    public AstConditionalOperatorNodeInputType(string value)
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
    public static AstConditionalOperatorNodeInputType FromCustom(string value)
    {
        return new AstConditionalOperatorNodeInputType(value);
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

    public static bool operator ==(AstConditionalOperatorNodeInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstConditionalOperatorNodeInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstConditionalOperatorNodeInputType value) =>
        value.Value;

    public static explicit operator AstConditionalOperatorNodeInputType(string value) => new(value);

    internal class AstConditionalOperatorNodeInputTypeSerializer
        : JsonConverter<AstConditionalOperatorNodeInputType>
    {
        public override AstConditionalOperatorNodeInputType Read(
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
            return new AstConditionalOperatorNodeInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstConditionalOperatorNodeInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstConditionalOperatorNodeInputType ReadAsPropertyName(
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
            return new AstConditionalOperatorNodeInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstConditionalOperatorNodeInputType value,
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
        public const string ConditionalOperator = "conditional_operator";
    }
}
