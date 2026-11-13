using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ArraySchemaType.ArraySchemaTypeSerializer))]
[Serializable]
public readonly record struct ArraySchemaType : IStringEnum
{
    public static readonly ArraySchemaType Array = new(Values.Array);

    public ArraySchemaType(string value)
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
    public static ArraySchemaType FromCustom(string value)
    {
        return new ArraySchemaType(value);
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

    public static bool operator ==(ArraySchemaType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ArraySchemaType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ArraySchemaType value) => value.Value;

    public static explicit operator ArraySchemaType(string value) => new(value);

    internal class ArraySchemaTypeSerializer : JsonConverter<ArraySchemaType>
    {
        public override ArraySchemaType Read(
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
            return new ArraySchemaType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ArraySchemaType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ArraySchemaType ReadAsPropertyName(
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
            return new ArraySchemaType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ArraySchemaType value,
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
