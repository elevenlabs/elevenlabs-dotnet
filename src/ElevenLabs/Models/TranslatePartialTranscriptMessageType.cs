using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TranslatePartialTranscriptMessageType.TranslatePartialTranscriptMessageTypeSerializer)
)]
[Serializable]
public readonly record struct TranslatePartialTranscriptMessageType : IStringEnum
{
    public static readonly TranslatePartialTranscriptMessageType PartialTranscript = new(
        Values.PartialTranscript
    );

    public TranslatePartialTranscriptMessageType(string value)
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
    public static TranslatePartialTranscriptMessageType FromCustom(string value)
    {
        return new TranslatePartialTranscriptMessageType(value);
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

    public static bool operator ==(TranslatePartialTranscriptMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslatePartialTranscriptMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslatePartialTranscriptMessageType value) =>
        value.Value;

    public static explicit operator TranslatePartialTranscriptMessageType(string value) =>
        new(value);

    internal class TranslatePartialTranscriptMessageTypeSerializer
        : JsonConverter<TranslatePartialTranscriptMessageType>
    {
        public override TranslatePartialTranscriptMessageType Read(
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
            return new TranslatePartialTranscriptMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslatePartialTranscriptMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslatePartialTranscriptMessageType ReadAsPropertyName(
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
            return new TranslatePartialTranscriptMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslatePartialTranscriptMessageType value,
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
        public const string PartialTranscript = "partial_transcript";
    }
}
