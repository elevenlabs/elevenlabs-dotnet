using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ArrayJsonSchemaPropertyOutputType.ArrayJsonSchemaPropertyOutputTypeSerializer)
)]
[Serializable]
public readonly record struct ArrayJsonSchemaPropertyOutputType : IStringEnum
{
    public static readonly ArrayJsonSchemaPropertyOutputType Array = new(Values.Array);

    public ArrayJsonSchemaPropertyOutputType(string value)
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
    public static ArrayJsonSchemaPropertyOutputType FromCustom(string value)
    {
        return new ArrayJsonSchemaPropertyOutputType(value);
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

    public static bool operator ==(ArrayJsonSchemaPropertyOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ArrayJsonSchemaPropertyOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ArrayJsonSchemaPropertyOutputType value) => value.Value;

    public static explicit operator ArrayJsonSchemaPropertyOutputType(string value) => new(value);

    internal class ArrayJsonSchemaPropertyOutputTypeSerializer
        : JsonConverter<ArrayJsonSchemaPropertyOutputType>
    {
        public override ArrayJsonSchemaPropertyOutputType Read(
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
            return new ArrayJsonSchemaPropertyOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ArrayJsonSchemaPropertyOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ArrayJsonSchemaPropertyOutputType ReadAsPropertyName(
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
            return new ArrayJsonSchemaPropertyOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ArrayJsonSchemaPropertyOutputType value,
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
