using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ResponseUnitTestModelType.ResponseUnitTestModelTypeSerializer))]
[Serializable]
public readonly record struct ResponseUnitTestModelType : IStringEnum
{
    public static readonly ResponseUnitTestModelType Llm = new(Values.Llm);

    public ResponseUnitTestModelType(string value)
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
    public static ResponseUnitTestModelType FromCustom(string value)
    {
        return new ResponseUnitTestModelType(value);
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

    public static bool operator ==(ResponseUnitTestModelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResponseUnitTestModelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResponseUnitTestModelType value) => value.Value;

    public static explicit operator ResponseUnitTestModelType(string value) => new(value);

    internal class ResponseUnitTestModelTypeSerializer : JsonConverter<ResponseUnitTestModelType>
    {
        public override ResponseUnitTestModelType Read(
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
            return new ResponseUnitTestModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResponseUnitTestModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResponseUnitTestModelType ReadAsPropertyName(
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
            return new ResponseUnitTestModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResponseUnitTestModelType value,
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
