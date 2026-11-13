using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Encoding and sample rate of output audio. PCM output is stereo; `ulaw_8000` output is mono.</summary>
[JsonConverter(typeof(DubbingLiveOutputFormat.DubbingLiveOutputFormatSerializer))]
[Serializable]
public readonly record struct DubbingLiveOutputFormat : IStringEnum
{
    public static readonly DubbingLiveOutputFormat Pcm8000 = new(Values.Pcm8000);

    public static readonly DubbingLiveOutputFormat Pcm16000 = new(Values.Pcm16000);

    public static readonly DubbingLiveOutputFormat Pcm22050 = new(Values.Pcm22050);

    public static readonly DubbingLiveOutputFormat Pcm24000 = new(Values.Pcm24000);

    public static readonly DubbingLiveOutputFormat Pcm44100 = new(Values.Pcm44100);

    public static readonly DubbingLiveOutputFormat Pcm48000 = new(Values.Pcm48000);

    public static readonly DubbingLiveOutputFormat Ulaw8000 = new(Values.Ulaw8000);

    public DubbingLiveOutputFormat(string value)
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
    public static DubbingLiveOutputFormat FromCustom(string value)
    {
        return new DubbingLiveOutputFormat(value);
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

    public static bool operator ==(DubbingLiveOutputFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingLiveOutputFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingLiveOutputFormat value) => value.Value;

    public static explicit operator DubbingLiveOutputFormat(string value) => new(value);

    internal class DubbingLiveOutputFormatSerializer : JsonConverter<DubbingLiveOutputFormat>
    {
        public override DubbingLiveOutputFormat Read(
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
            return new DubbingLiveOutputFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingLiveOutputFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingLiveOutputFormat ReadAsPropertyName(
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
            return new DubbingLiveOutputFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingLiveOutputFormat value,
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
        public const string Pcm8000 = "pcm_8000";

        public const string Pcm16000 = "pcm_16000";

        public const string Pcm22050 = "pcm_22050";

        public const string Pcm24000 = "pcm_24000";

        public const string Pcm44100 = "pcm_44100";

        public const string Pcm48000 = "pcm_48000";

        public const string Ulaw8000 = "ulaw_8000";
    }
}
