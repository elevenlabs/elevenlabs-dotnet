using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(RedactedTranscriptMessageType.RedactedTranscriptMessageTypeSerializer))]
[Serializable]
public readonly record struct RedactedTranscriptMessageType : IStringEnum
{
    public static readonly RedactedTranscriptMessageType RedactedTranscript = new(
        Values.RedactedTranscript
    );

    public RedactedTranscriptMessageType(string value)
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
    public static RedactedTranscriptMessageType FromCustom(string value)
    {
        return new RedactedTranscriptMessageType(value);
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

    public static bool operator ==(RedactedTranscriptMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RedactedTranscriptMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RedactedTranscriptMessageType value) => value.Value;

    public static explicit operator RedactedTranscriptMessageType(string value) => new(value);

    internal class RedactedTranscriptMessageTypeSerializer
        : JsonConverter<RedactedTranscriptMessageType>
    {
        public override RedactedTranscriptMessageType Read(
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
            return new RedactedTranscriptMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RedactedTranscriptMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RedactedTranscriptMessageType ReadAsPropertyName(
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
            return new RedactedTranscriptMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RedactedTranscriptMessageType value,
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
        public const string RedactedTranscript = "redacted_transcript";
    }
}
