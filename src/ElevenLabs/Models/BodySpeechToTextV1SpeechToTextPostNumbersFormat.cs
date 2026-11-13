using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(BodySpeechToTextV1SpeechToTextPostNumbersFormat.BodySpeechToTextV1SpeechToTextPostNumbersFormatSerializer)
)]
[Serializable]
public readonly record struct BodySpeechToTextV1SpeechToTextPostNumbersFormat : IStringEnum
{
    public static readonly BodySpeechToTextV1SpeechToTextPostNumbersFormat Digits = new(
        Values.Digits
    );

    public static readonly BodySpeechToTextV1SpeechToTextPostNumbersFormat Words = new(
        Values.Words
    );

    public BodySpeechToTextV1SpeechToTextPostNumbersFormat(string value)
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
    public static BodySpeechToTextV1SpeechToTextPostNumbersFormat FromCustom(string value)
    {
        return new BodySpeechToTextV1SpeechToTextPostNumbersFormat(value);
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

    public static bool operator ==(
        BodySpeechToTextV1SpeechToTextPostNumbersFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodySpeechToTextV1SpeechToTextPostNumbersFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BodySpeechToTextV1SpeechToTextPostNumbersFormat value) =>
        value.Value;

    public static explicit operator BodySpeechToTextV1SpeechToTextPostNumbersFormat(string value) =>
        new(value);

    internal class BodySpeechToTextV1SpeechToTextPostNumbersFormatSerializer
        : JsonConverter<BodySpeechToTextV1SpeechToTextPostNumbersFormat>
    {
        public override BodySpeechToTextV1SpeechToTextPostNumbersFormat Read(
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
            return new BodySpeechToTextV1SpeechToTextPostNumbersFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostNumbersFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodySpeechToTextV1SpeechToTextPostNumbersFormat ReadAsPropertyName(
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
            return new BodySpeechToTextV1SpeechToTextPostNumbersFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostNumbersFormat value,
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
        public const string Digits = "digits";

        public const string Words = "words";
    }
}
