using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TranslateAuthErrorMessageType.TranslateAuthErrorMessageTypeSerializer))]
[Serializable]
public readonly record struct TranslateAuthErrorMessageType : IStringEnum
{
    public static readonly TranslateAuthErrorMessageType AuthError = new(Values.AuthError);

    public TranslateAuthErrorMessageType(string value)
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
    public static TranslateAuthErrorMessageType FromCustom(string value)
    {
        return new TranslateAuthErrorMessageType(value);
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

    public static bool operator ==(TranslateAuthErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslateAuthErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslateAuthErrorMessageType value) => value.Value;

    public static explicit operator TranslateAuthErrorMessageType(string value) => new(value);

    internal class TranslateAuthErrorMessageTypeSerializer
        : JsonConverter<TranslateAuthErrorMessageType>
    {
        public override TranslateAuthErrorMessageType Read(
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
            return new TranslateAuthErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslateAuthErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslateAuthErrorMessageType ReadAsPropertyName(
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
            return new TranslateAuthErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslateAuthErrorMessageType value,
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
        public const string AuthError = "auth_error";
    }
}
