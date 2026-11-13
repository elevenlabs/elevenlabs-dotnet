using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Type13.Type13Serializer))]
[Serializable]
public readonly record struct Type13 : IStringEnum
{
    public static readonly Type13 Boolean = new(Values.Boolean);

    public static readonly Type13 String = new(Values.String);

    public static readonly Type13 Integer = new(Values.Integer);

    public static readonly Type13 Number = new(Values.Number);

    public Type13(string value)
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
    public static Type13 FromCustom(string value)
    {
        return new Type13(value);
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

    public static bool operator ==(Type13 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Type13 value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Type13 value) => value.Value;

    public static explicit operator Type13(string value) => new(value);

    internal class Type13Serializer : JsonConverter<Type13>
    {
        public override Type13 Read(
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
            return new Type13(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Type13 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Type13 ReadAsPropertyName(
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
            return new Type13(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Type13 value,
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
        public const string Boolean = "boolean";

        public const string String = "string";

        public const string Integer = "integer";

        public const string Number = "number";
    }
}
