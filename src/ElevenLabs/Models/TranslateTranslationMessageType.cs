using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TranslateTranslationMessageType.TranslateTranslationMessageTypeSerializer))]
[Serializable]
public readonly record struct TranslateTranslationMessageType : IStringEnum
{
    public static readonly TranslateTranslationMessageType Translation = new(Values.Translation);

    public TranslateTranslationMessageType(string value)
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
    public static TranslateTranslationMessageType FromCustom(string value)
    {
        return new TranslateTranslationMessageType(value);
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

    public static bool operator ==(TranslateTranslationMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslateTranslationMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslateTranslationMessageType value) => value.Value;

    public static explicit operator TranslateTranslationMessageType(string value) => new(value);

    internal class TranslateTranslationMessageTypeSerializer
        : JsonConverter<TranslateTranslationMessageType>
    {
        public override TranslateTranslationMessageType Read(
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
            return new TranslateTranslationMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslateTranslationMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslateTranslationMessageType ReadAsPropertyName(
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
            return new TranslateTranslationMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslateTranslationMessageType value,
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
        public const string Translation = "translation";
    }
}
