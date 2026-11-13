using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(AstGreaterThanOperatorNodeInputType.AstGreaterThanOperatorNodeInputTypeSerializer)
)]
[Serializable]
public readonly record struct AstGreaterThanOperatorNodeInputType : IStringEnum
{
    public static readonly AstGreaterThanOperatorNodeInputType GtOperator = new(Values.GtOperator);

    public AstGreaterThanOperatorNodeInputType(string value)
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
    public static AstGreaterThanOperatorNodeInputType FromCustom(string value)
    {
        return new AstGreaterThanOperatorNodeInputType(value);
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

    public static bool operator ==(AstGreaterThanOperatorNodeInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstGreaterThanOperatorNodeInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstGreaterThanOperatorNodeInputType value) =>
        value.Value;

    public static explicit operator AstGreaterThanOperatorNodeInputType(string value) => new(value);

    internal class AstGreaterThanOperatorNodeInputTypeSerializer
        : JsonConverter<AstGreaterThanOperatorNodeInputType>
    {
        public override AstGreaterThanOperatorNodeInputType Read(
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
            return new AstGreaterThanOperatorNodeInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstGreaterThanOperatorNodeInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstGreaterThanOperatorNodeInputType ReadAsPropertyName(
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
            return new AstGreaterThanOperatorNodeInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstGreaterThanOperatorNodeInputType value,
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
        public const string GtOperator = "gt_operator";
    }
}
