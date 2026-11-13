using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SpeechToSpeechStreamRequestFileFormat.SpeechToSpeechStreamRequestFileFormatSerializer)
)]
[Serializable]
public readonly record struct SpeechToSpeechStreamRequestFileFormat : IStringEnum
{
    public static readonly SpeechToSpeechStreamRequestFileFormat PcmS16Le16 = new(
        Values.PcmS16Le16
    );

    public static readonly SpeechToSpeechStreamRequestFileFormat Other = new(Values.Other);

    public SpeechToSpeechStreamRequestFileFormat(string value)
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
    public static SpeechToSpeechStreamRequestFileFormat FromCustom(string value)
    {
        return new SpeechToSpeechStreamRequestFileFormat(value);
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

    public static bool operator ==(SpeechToSpeechStreamRequestFileFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeechToSpeechStreamRequestFileFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeechToSpeechStreamRequestFileFormat value) =>
        value.Value;

    public static explicit operator SpeechToSpeechStreamRequestFileFormat(string value) =>
        new(value);

    internal class SpeechToSpeechStreamRequestFileFormatSerializer
        : JsonConverter<SpeechToSpeechStreamRequestFileFormat>
    {
        public override SpeechToSpeechStreamRequestFileFormat Read(
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
            return new SpeechToSpeechStreamRequestFileFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeechToSpeechStreamRequestFileFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeechToSpeechStreamRequestFileFormat ReadAsPropertyName(
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
            return new SpeechToSpeechStreamRequestFileFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeechToSpeechStreamRequestFileFormat value,
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
