using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The format of input audio. Options are 'pcm_s16le_16' or 'other' For `pcm_s16le_16`, the input audio must be 16-bit PCM at a 16kHz sample rate, single channel (mono), and little-endian byte order. Latency will be lower than with passing an encoded waveform.</summary>
[JsonConverter(
    typeof(BodySpeechToTextV1SpeechToTextPostFileFormat.BodySpeechToTextV1SpeechToTextPostFileFormatSerializer)
)]
[Serializable]
public readonly record struct BodySpeechToTextV1SpeechToTextPostFileFormat : IStringEnum
{
    public static readonly BodySpeechToTextV1SpeechToTextPostFileFormat PcmS16Le16 = new(
        Values.PcmS16Le16
    );

    public static readonly BodySpeechToTextV1SpeechToTextPostFileFormat Other = new(Values.Other);

    public BodySpeechToTextV1SpeechToTextPostFileFormat(string value)
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
    public static BodySpeechToTextV1SpeechToTextPostFileFormat FromCustom(string value)
    {
        return new BodySpeechToTextV1SpeechToTextPostFileFormat(value);
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
        BodySpeechToTextV1SpeechToTextPostFileFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodySpeechToTextV1SpeechToTextPostFileFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BodySpeechToTextV1SpeechToTextPostFileFormat value) =>
        value.Value;

    public static explicit operator BodySpeechToTextV1SpeechToTextPostFileFormat(string value) =>
        new(value);

    internal class BodySpeechToTextV1SpeechToTextPostFileFormatSerializer
        : JsonConverter<BodySpeechToTextV1SpeechToTextPostFileFormat>
    {
        public override BodySpeechToTextV1SpeechToTextPostFileFormat Read(
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
            return new BodySpeechToTextV1SpeechToTextPostFileFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostFileFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodySpeechToTextV1SpeechToTextPostFileFormat ReadAsPropertyName(
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
            return new BodySpeechToTextV1SpeechToTextPostFileFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostFileFormat value,
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
        public const string PcmS16Le16 = "pcm_s16le_16";

        public const string Other = "other";
    }
}
