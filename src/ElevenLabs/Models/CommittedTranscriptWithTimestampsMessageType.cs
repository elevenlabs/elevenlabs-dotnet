using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CommittedTranscriptWithTimestampsMessageType.CommittedTranscriptWithTimestampsMessageTypeSerializer)
)]
[Serializable]
public readonly record struct CommittedTranscriptWithTimestampsMessageType : IStringEnum
{
    public static readonly CommittedTranscriptWithTimestampsMessageType CommittedTranscriptWithTimestamps =
        new(Values.CommittedTranscriptWithTimestamps);

    public CommittedTranscriptWithTimestampsMessageType(string value)
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
    public static CommittedTranscriptWithTimestampsMessageType FromCustom(string value)
    {
        return new CommittedTranscriptWithTimestampsMessageType(value);
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
        CommittedTranscriptWithTimestampsMessageType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CommittedTranscriptWithTimestampsMessageType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CommittedTranscriptWithTimestampsMessageType value) =>
        value.Value;

    public static explicit operator CommittedTranscriptWithTimestampsMessageType(string value) =>
        new(value);

    internal class CommittedTranscriptWithTimestampsMessageTypeSerializer
        : JsonConverter<CommittedTranscriptWithTimestampsMessageType>
    {
        public override CommittedTranscriptWithTimestampsMessageType Read(
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
            return new CommittedTranscriptWithTimestampsMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommittedTranscriptWithTimestampsMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommittedTranscriptWithTimestampsMessageType ReadAsPropertyName(
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
            return new CommittedTranscriptWithTimestampsMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommittedTranscriptWithTimestampsMessageType value,
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
        public const string CommittedTranscriptWithTimestamps =
            "committed_transcript_with_timestamps";
    }
}
