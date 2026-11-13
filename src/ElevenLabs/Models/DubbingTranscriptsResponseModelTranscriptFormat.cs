using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DubbingTranscriptsResponseModelTranscriptFormat.DubbingTranscriptsResponseModelTranscriptFormatSerializer)
)]
[Serializable]
public readonly record struct DubbingTranscriptsResponseModelTranscriptFormat : IStringEnum
{
    public static readonly DubbingTranscriptsResponseModelTranscriptFormat Srt = new(Values.Srt);

    public static readonly DubbingTranscriptsResponseModelTranscriptFormat Webvtt = new(
        Values.Webvtt
    );

    public static readonly DubbingTranscriptsResponseModelTranscriptFormat Json = new(Values.Json);

    public DubbingTranscriptsResponseModelTranscriptFormat(string value)
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
    public static DubbingTranscriptsResponseModelTranscriptFormat FromCustom(string value)
    {
        return new DubbingTranscriptsResponseModelTranscriptFormat(value);
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
        DubbingTranscriptsResponseModelTranscriptFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DubbingTranscriptsResponseModelTranscriptFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DubbingTranscriptsResponseModelTranscriptFormat value) =>
        value.Value;

    public static explicit operator DubbingTranscriptsResponseModelTranscriptFormat(string value) =>
        new(value);

    internal class DubbingTranscriptsResponseModelTranscriptFormatSerializer
        : JsonConverter<DubbingTranscriptsResponseModelTranscriptFormat>
    {
        public override DubbingTranscriptsResponseModelTranscriptFormat Read(
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
            return new DubbingTranscriptsResponseModelTranscriptFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingTranscriptsResponseModelTranscriptFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingTranscriptsResponseModelTranscriptFormat ReadAsPropertyName(
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
            return new DubbingTranscriptsResponseModelTranscriptFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingTranscriptsResponseModelTranscriptFormat value,
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
        public const string Srt = "srt";

        public const string Webvtt = "webvtt";

        public const string Json = "json";
    }
}
