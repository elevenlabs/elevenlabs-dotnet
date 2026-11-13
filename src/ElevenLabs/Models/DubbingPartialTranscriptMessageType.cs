using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DubbingPartialTranscriptMessageType.DubbingPartialTranscriptMessageTypeSerializer)
)]
[Serializable]
public readonly record struct DubbingPartialTranscriptMessageType : IStringEnum
{
    public static readonly DubbingPartialTranscriptMessageType PartialTranscript = new(
        Values.PartialTranscript
    );

    public DubbingPartialTranscriptMessageType(string value)
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
    public static DubbingPartialTranscriptMessageType FromCustom(string value)
    {
        return new DubbingPartialTranscriptMessageType(value);
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

    public static bool operator ==(DubbingPartialTranscriptMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingPartialTranscriptMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingPartialTranscriptMessageType value) =>
        value.Value;

    public static explicit operator DubbingPartialTranscriptMessageType(string value) => new(value);

    internal class DubbingPartialTranscriptMessageTypeSerializer
        : JsonConverter<DubbingPartialTranscriptMessageType>
    {
        public override DubbingPartialTranscriptMessageType Read(
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
            return new DubbingPartialTranscriptMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingPartialTranscriptMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingPartialTranscriptMessageType ReadAsPropertyName(
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
            return new DubbingPartialTranscriptMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingPartialTranscriptMessageType value,
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
