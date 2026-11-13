using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DubbingCommittedTranscriptMessageType.DubbingCommittedTranscriptMessageTypeSerializer)
)]
[Serializable]
public readonly record struct DubbingCommittedTranscriptMessageType : IStringEnum
{
    public static readonly DubbingCommittedTranscriptMessageType CommittedTranscript = new(
        Values.CommittedTranscript
    );

    public DubbingCommittedTranscriptMessageType(string value)
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
    public static DubbingCommittedTranscriptMessageType FromCustom(string value)
    {
        return new DubbingCommittedTranscriptMessageType(value);
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

    public static bool operator ==(DubbingCommittedTranscriptMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingCommittedTranscriptMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingCommittedTranscriptMessageType value) =>
        value.Value;

    public static explicit operator DubbingCommittedTranscriptMessageType(string value) =>
        new(value);

    internal class DubbingCommittedTranscriptMessageTypeSerializer
        : JsonConverter<DubbingCommittedTranscriptMessageType>
    {
        public override DubbingCommittedTranscriptMessageType Read(
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
            return new DubbingCommittedTranscriptMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingCommittedTranscriptMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingCommittedTranscriptMessageType ReadAsPropertyName(
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
            return new DubbingCommittedTranscriptMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingCommittedTranscriptMessageType value,
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
        public const string CommittedTranscript = "committed_transcript";
    }
}
