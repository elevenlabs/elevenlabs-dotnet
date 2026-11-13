using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TranslateInputErrorMessageType.TranslateInputErrorMessageTypeSerializer))]
[Serializable]
public readonly record struct TranslateInputErrorMessageType : IStringEnum
{
    public static readonly TranslateInputErrorMessageType InputError = new(Values.InputError);

    public TranslateInputErrorMessageType(string value)
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
    public static TranslateInputErrorMessageType FromCustom(string value)
    {
        return new TranslateInputErrorMessageType(value);
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

    public static bool operator ==(TranslateInputErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslateInputErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslateInputErrorMessageType value) => value.Value;

    public static explicit operator TranslateInputErrorMessageType(string value) => new(value);

    internal class TranslateInputErrorMessageTypeSerializer
        : JsonConverter<TranslateInputErrorMessageType>
    {
        public override TranslateInputErrorMessageType Read(
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
            return new TranslateInputErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslateInputErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslateInputErrorMessageType ReadAsPropertyName(
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
            return new TranslateInputErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslateInputErrorMessageType value,
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
        public const string InputError = "input_error";
    }
}
