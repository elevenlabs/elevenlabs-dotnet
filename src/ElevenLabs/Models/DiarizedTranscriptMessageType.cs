using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DiarizedTranscriptMessageType.DiarizedTranscriptMessageTypeSerializer))]
[Serializable]
public readonly record struct DiarizedTranscriptMessageType : IStringEnum
{
    public static readonly DiarizedTranscriptMessageType DiarizedTranscript = new(
        Values.DiarizedTranscript
    );

    public DiarizedTranscriptMessageType(string value)
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
    public static DiarizedTranscriptMessageType FromCustom(string value)
    {
        return new DiarizedTranscriptMessageType(value);
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

    public static bool operator ==(DiarizedTranscriptMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DiarizedTranscriptMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DiarizedTranscriptMessageType value) => value.Value;

    public static explicit operator DiarizedTranscriptMessageType(string value) => new(value);

    internal class DiarizedTranscriptMessageTypeSerializer
        : JsonConverter<DiarizedTranscriptMessageType>
    {
        public override DiarizedTranscriptMessageType Read(
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
            return new DiarizedTranscriptMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DiarizedTranscriptMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DiarizedTranscriptMessageType ReadAsPropertyName(
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
            return new DiarizedTranscriptMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DiarizedTranscriptMessageType value,
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
        public const string DiarizedTranscript = "diarized_transcript";
    }
}
