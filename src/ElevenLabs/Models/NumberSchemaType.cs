using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(NumberSchemaType.NumberSchemaTypeSerializer))]
[Serializable]
public readonly record struct NumberSchemaType : IStringEnum
{
    public static readonly NumberSchemaType Number = new(Values.Number);

    public NumberSchemaType(string value)
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
    public static NumberSchemaType FromCustom(string value)
    {
        return new NumberSchemaType(value);
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

    public static bool operator ==(NumberSchemaType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NumberSchemaType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NumberSchemaType value) => value.Value;

    public static explicit operator NumberSchemaType(string value) => new(value);

    internal class NumberSchemaTypeSerializer : JsonConverter<NumberSchemaType>
    {
        public override NumberSchemaType Read(
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
            return new NumberSchemaType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NumberSchemaType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NumberSchemaType ReadAsPropertyName(
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
            return new NumberSchemaType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NumberSchemaType value,
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
        public const string Number = "number";
    }
}
