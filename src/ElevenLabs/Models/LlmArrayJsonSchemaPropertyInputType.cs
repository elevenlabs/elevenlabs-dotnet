using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(LlmArrayJsonSchemaPropertyInputType.LlmArrayJsonSchemaPropertyInputTypeSerializer)
)]
[Serializable]
public readonly record struct LlmArrayJsonSchemaPropertyInputType : IStringEnum
{
    public static readonly LlmArrayJsonSchemaPropertyInputType Array = new(Values.Array);

    public LlmArrayJsonSchemaPropertyInputType(string value)
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
    public static LlmArrayJsonSchemaPropertyInputType FromCustom(string value)
    {
        return new LlmArrayJsonSchemaPropertyInputType(value);
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

    public static bool operator ==(LlmArrayJsonSchemaPropertyInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LlmArrayJsonSchemaPropertyInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LlmArrayJsonSchemaPropertyInputType value) =>
        value.Value;

    public static explicit operator LlmArrayJsonSchemaPropertyInputType(string value) => new(value);

    internal class LlmArrayJsonSchemaPropertyInputTypeSerializer
        : JsonConverter<LlmArrayJsonSchemaPropertyInputType>
    {
        public override LlmArrayJsonSchemaPropertyInputType Read(
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
            return new LlmArrayJsonSchemaPropertyInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LlmArrayJsonSchemaPropertyInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LlmArrayJsonSchemaPropertyInputType ReadAsPropertyName(
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
            return new LlmArrayJsonSchemaPropertyInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LlmArrayJsonSchemaPropertyInputType value,
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
        public const string Array = "array";
    }
}
