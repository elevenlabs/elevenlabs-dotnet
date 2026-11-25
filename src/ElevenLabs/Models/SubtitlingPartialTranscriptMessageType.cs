using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SubtitlingPartialTranscriptMessageType.SubtitlingPartialTranscriptMessageTypeSerializer)
)]
[Serializable]
public readonly record struct SubtitlingPartialTranscriptMessageType : IStringEnum
{
    public static readonly SubtitlingPartialTranscriptMessageType PartialTranscript = new(
        Values.PartialTranscript
    );

    public SubtitlingPartialTranscriptMessageType(string value)
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
    public static SubtitlingPartialTranscriptMessageType FromCustom(string value)
    {
        return new SubtitlingPartialTranscriptMessageType(value);
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

    public static bool operator ==(SubtitlingPartialTranscriptMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingPartialTranscriptMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingPartialTranscriptMessageType value) =>
        value.Value;

    public static explicit operator SubtitlingPartialTranscriptMessageType(string value) =>
        new(value);

    internal class SubtitlingPartialTranscriptMessageTypeSerializer
        : JsonConverter<SubtitlingPartialTranscriptMessageType>
    {
        public override SubtitlingPartialTranscriptMessageType Read(
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
            return new SubtitlingPartialTranscriptMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingPartialTranscriptMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingPartialTranscriptMessageType ReadAsPropertyName(
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
            return new SubtitlingPartialTranscriptMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingPartialTranscriptMessageType value,
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
