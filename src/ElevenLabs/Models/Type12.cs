using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Type12.Type12Serializer))]
[Serializable]
public readonly record struct Type12 : IStringEnum
{
    public static readonly Type12 Boolean = new(Values.Boolean);

    public static readonly Type12 String = new(Values.String);

    public static readonly Type12 Integer = new(Values.Integer);

    public static readonly Type12 Number = new(Values.Number);

    public Type12(string value)
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
    public static Type12 FromCustom(string value)
    {
        return new Type12(value);
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

    public static bool operator ==(Type12 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Type12 value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Type12 value) => value.Value;

    public static explicit operator Type12(string value) => new(value);

    internal class Type12Serializer : JsonConverter<Type12>
    {
        public override Type12 Read(
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
            return new Type12(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Type12 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Type12 ReadAsPropertyName(
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
            return new Type12(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Type12 value,
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
