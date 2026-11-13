using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CustomLlmapiType.CustomLlmapiTypeSerializer))]
[Serializable]
public readonly record struct CustomLlmapiType : IStringEnum
{
    public static readonly CustomLlmapiType ChatCompletions = new(Values.ChatCompletions);

    public static readonly CustomLlmapiType Responses = new(Values.Responses);

    public static readonly CustomLlmapiType Websocket = new(Values.Websocket);

    public CustomLlmapiType(string value)
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
    public static CustomLlmapiType FromCustom(string value)
    {
        return new CustomLlmapiType(value);
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

    public static bool operator ==(CustomLlmapiType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomLlmapiType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomLlmapiType value) => value.Value;

    public static explicit operator CustomLlmapiType(string value) => new(value);

    internal class CustomLlmapiTypeSerializer : JsonConverter<CustomLlmapiType>
    {
        public override CustomLlmapiType Read(
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
            return new CustomLlmapiType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomLlmapiType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomLlmapiType ReadAsPropertyName(
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
            return new CustomLlmapiType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomLlmapiType value,
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
        public const string ChatCompletions = "chat_completions";

        public const string Responses = "responses";

        public const string Websocket = "websocket";
    }
}
