using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CommittedTranscriptEntitiesMessageType.CommittedTranscriptEntitiesMessageTypeSerializer)
)]
[Serializable]
public readonly record struct CommittedTranscriptEntitiesMessageType : IStringEnum
{
    public static readonly CommittedTranscriptEntitiesMessageType CommittedTranscriptEntities = new(
        Values.CommittedTranscriptEntities
    );

    public CommittedTranscriptEntitiesMessageType(string value)
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
    public static CommittedTranscriptEntitiesMessageType FromCustom(string value)
    {
        return new CommittedTranscriptEntitiesMessageType(value);
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

    public static bool operator ==(CommittedTranscriptEntitiesMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommittedTranscriptEntitiesMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommittedTranscriptEntitiesMessageType value) =>
        value.Value;

    public static explicit operator CommittedTranscriptEntitiesMessageType(string value) =>
        new(value);

    internal class CommittedTranscriptEntitiesMessageTypeSerializer
        : JsonConverter<CommittedTranscriptEntitiesMessageType>
    {
        public override CommittedTranscriptEntitiesMessageType Read(
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
            return new CommittedTranscriptEntitiesMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommittedTranscriptEntitiesMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommittedTranscriptEntitiesMessageType ReadAsPropertyName(
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
            return new CommittedTranscriptEntitiesMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommittedTranscriptEntitiesMessageType value,
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
        public const string CommittedTranscriptEntities = "committed_transcript_entities";
    }
}
