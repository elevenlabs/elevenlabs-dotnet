using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Type11.Type11Serializer))]
[Serializable]
public readonly record struct Type11 : IStringEnum
{
    public static readonly Type11 Boolean = new(Values.Boolean);

    public static readonly Type11 String = new(Values.String);

    public static readonly Type11 Integer = new(Values.Integer);

    public static readonly Type11 Number = new(Values.Number);

    public Type11(string value)
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
    public static Type11 FromCustom(string value)
    {
        return new Type11(value);
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

    public static bool operator ==(Type11 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Type11 value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Type11 value) => value.Value;

    public static explicit operator Type11(string value) => new(value);

    internal class Type11Serializer : JsonConverter<Type11>
    {
        public override Type11 Read(
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
            return new Type11(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Type11 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Type11 ReadAsPropertyName(
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
            return new Type11(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Type11 value,
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
