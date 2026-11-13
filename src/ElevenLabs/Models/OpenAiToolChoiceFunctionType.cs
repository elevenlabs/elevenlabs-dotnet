using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OpenAiToolChoiceFunctionType.OpenAiToolChoiceFunctionTypeSerializer))]
[Serializable]
public readonly record struct OpenAiToolChoiceFunctionType : IStringEnum
{
    public static readonly OpenAiToolChoiceFunctionType Function = new(Values.Function);

    public OpenAiToolChoiceFunctionType(string value)
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
    public static OpenAiToolChoiceFunctionType FromCustom(string value)
    {
        return new OpenAiToolChoiceFunctionType(value);
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

    public static bool operator ==(OpenAiToolChoiceFunctionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OpenAiToolChoiceFunctionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OpenAiToolChoiceFunctionType value) => value.Value;

    public static explicit operator OpenAiToolChoiceFunctionType(string value) => new(value);

    internal class OpenAiToolChoiceFunctionTypeSerializer
        : JsonConverter<OpenAiToolChoiceFunctionType>
    {
        public override OpenAiToolChoiceFunctionType Read(
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
            return new OpenAiToolChoiceFunctionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OpenAiToolChoiceFunctionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OpenAiToolChoiceFunctionType ReadAsPropertyName(
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
            return new OpenAiToolChoiceFunctionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OpenAiToolChoiceFunctionType value,
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
        public const string Function = "function";
    }
}
