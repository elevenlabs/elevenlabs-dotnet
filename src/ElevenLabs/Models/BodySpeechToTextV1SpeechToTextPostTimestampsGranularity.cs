using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The granularity of the timestamps in the transcription. 'word' provides word-level timestamps and 'character' provides character-level timestamps per word.</summary>
[JsonConverter(
    typeof(BodySpeechToTextV1SpeechToTextPostTimestampsGranularity.BodySpeechToTextV1SpeechToTextPostTimestampsGranularitySerializer)
)]
[Serializable]
public readonly record struct BodySpeechToTextV1SpeechToTextPostTimestampsGranularity : IStringEnum
{
    public static readonly BodySpeechToTextV1SpeechToTextPostTimestampsGranularity None = new(
        Values.None
    );

    public static readonly BodySpeechToTextV1SpeechToTextPostTimestampsGranularity Word = new(
        Values.Word
    );

    public static readonly BodySpeechToTextV1SpeechToTextPostTimestampsGranularity Character = new(
        Values.Character
    );

    public BodySpeechToTextV1SpeechToTextPostTimestampsGranularity(string value)
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
    public static BodySpeechToTextV1SpeechToTextPostTimestampsGranularity FromCustom(string value)
    {
        return new BodySpeechToTextV1SpeechToTextPostTimestampsGranularity(value);
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
        BodySpeechToTextV1SpeechToTextPostTimestampsGranularity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodySpeechToTextV1SpeechToTextPostTimestampsGranularity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodySpeechToTextV1SpeechToTextPostTimestampsGranularity value
    ) => value.Value;

    public static explicit operator BodySpeechToTextV1SpeechToTextPostTimestampsGranularity(
        string value
    ) => new(value);

    internal class BodySpeechToTextV1SpeechToTextPostTimestampsGranularitySerializer
        : JsonConverter<BodySpeechToTextV1SpeechToTextPostTimestampsGranularity>
    {
        public override BodySpeechToTextV1SpeechToTextPostTimestampsGranularity Read(
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
            return new BodySpeechToTextV1SpeechToTextPostTimestampsGranularity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostTimestampsGranularity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodySpeechToTextV1SpeechToTextPostTimestampsGranularity ReadAsPropertyName(
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
            return new BodySpeechToTextV1SpeechToTextPostTimestampsGranularity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostTimestampsGranularity value,
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
        public const string None = "none";

        public const string Word = "word";

        public const string Character = "character";
    }
}
