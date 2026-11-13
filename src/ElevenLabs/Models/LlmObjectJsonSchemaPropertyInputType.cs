using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(LlmObjectJsonSchemaPropertyInputType.LlmObjectJsonSchemaPropertyInputTypeSerializer)
)]
[Serializable]
public readonly record struct LlmObjectJsonSchemaPropertyInputType : IStringEnum
{
    public static readonly LlmObjectJsonSchemaPropertyInputType Object = new(Values.Object);

    public LlmObjectJsonSchemaPropertyInputType(string value)
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
    public static LlmObjectJsonSchemaPropertyInputType FromCustom(string value)
    {
        return new LlmObjectJsonSchemaPropertyInputType(value);
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

    public static bool operator ==(LlmObjectJsonSchemaPropertyInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LlmObjectJsonSchemaPropertyInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LlmObjectJsonSchemaPropertyInputType value) =>
        value.Value;

    public static explicit operator LlmObjectJsonSchemaPropertyInputType(string value) =>
        new(value);

    internal class LlmObjectJsonSchemaPropertyInputTypeSerializer
        : JsonConverter<LlmObjectJsonSchemaPropertyInputType>
    {
        public override LlmObjectJsonSchemaPropertyInputType Read(
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
            return new LlmObjectJsonSchemaPropertyInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LlmObjectJsonSchemaPropertyInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LlmObjectJsonSchemaPropertyInputType ReadAsPropertyName(
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
            return new LlmObjectJsonSchemaPropertyInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LlmObjectJsonSchemaPropertyInputType value,
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
        public const string Object = "object";
    }
}
