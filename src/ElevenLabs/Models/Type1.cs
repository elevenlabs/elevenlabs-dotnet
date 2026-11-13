using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Type1.Type1Serializer))]
[Serializable]
public readonly record struct Type1 : IStringEnum
{
    public static readonly Type1 Llm = new(Values.Llm);

    public Type1(string value)
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
    public static Type1 FromCustom(string value)
    {
        return new Type1(value);
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

    public static bool operator ==(Type1 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Type1 value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Type1 value) => value.Value;

    public static explicit operator Type1(string value) => new(value);

    internal class Type1Serializer : JsonConverter<Type1>
    {
        public override Type1 Read(
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
            return new Type1(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Type1 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Type1 ReadAsPropertyName(
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
            return new Type1(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Type1 value,
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
        public const string Llm = "llm";
    }
}
