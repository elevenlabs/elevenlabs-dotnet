using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ArrayJsonSchemaPropertyInputPropertyKind.ArrayJsonSchemaPropertyInputPropertyKindSerializer)
)]
[Serializable]
public readonly record struct ArrayJsonSchemaPropertyInputPropertyKind : IStringEnum
{
    public static readonly ArrayJsonSchemaPropertyInputPropertyKind Array = new(Values.Array);

    public static readonly ArrayJsonSchemaPropertyInputPropertyKind Object = new(Values.Object);

    public ArrayJsonSchemaPropertyInputPropertyKind(string value)
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
    public static ArrayJsonSchemaPropertyInputPropertyKind FromCustom(string value)
    {
        return new ArrayJsonSchemaPropertyInputPropertyKind(value);
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

    public static bool operator ==(
        ArrayJsonSchemaPropertyInputPropertyKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ArrayJsonSchemaPropertyInputPropertyKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ArrayJsonSchemaPropertyInputPropertyKind value) =>
        value.Value;

    public static explicit operator ArrayJsonSchemaPropertyInputPropertyKind(string value) =>
        new(value);

    internal class ArrayJsonSchemaPropertyInputPropertyKindSerializer
        : JsonConverter<ArrayJsonSchemaPropertyInputPropertyKind>
    {
        public override ArrayJsonSchemaPropertyInputPropertyKind Read(
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
            return new ArrayJsonSchemaPropertyInputPropertyKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ArrayJsonSchemaPropertyInputPropertyKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ArrayJsonSchemaPropertyInputPropertyKind ReadAsPropertyName(
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
            return new ArrayJsonSchemaPropertyInputPropertyKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ArrayJsonSchemaPropertyInputPropertyKind value,
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

        public const string Object = "object";
    }
}
