using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Output format of the generated audio. Formatted as codec_sample_rate_bitrate. So an mp3 with 22.05kHz sample rate at 32kbs is represented as mp3_22050_32. MP3 with 192kbps bitrate requires you to be subscribed to Creator tier or above. PCM with 44.1kHz sample rate requires you to be subscribed to Pro tier or above. Note that the μ-law format (sometimes written mu-law, often approximated as u-law) is commonly used for Twilio audio inputs.</summary>
[JsonConverter(
    typeof(StreamTextToSpeechRequestOutputFormat.StreamTextToSpeechRequestOutputFormatSerializer)
)]
[Serializable]
public readonly record struct StreamTextToSpeechRequestOutputFormat : IStringEnum
{
    public static readonly StreamTextToSpeechRequestOutputFormat Mp32205032 = new(
        Values.Mp32205032
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Mp32400048 = new(
        Values.Mp32400048
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Mp34410032 = new(
        Values.Mp34410032
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Mp34410064 = new(
        Values.Mp34410064
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Mp34410096 = new(
        Values.Mp34410096
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Mp344100128 = new(
        Values.Mp344100128
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Mp344100192 = new(
        Values.Mp344100192
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Pcm8000 = new(Values.Pcm8000);

    public static readonly StreamTextToSpeechRequestOutputFormat Pcm16000 = new(Values.Pcm16000);

    public static readonly StreamTextToSpeechRequestOutputFormat Pcm22050 = new(Values.Pcm22050);

    public static readonly StreamTextToSpeechRequestOutputFormat Pcm24000 = new(Values.Pcm24000);

    public static readonly StreamTextToSpeechRequestOutputFormat Pcm32000 = new(Values.Pcm32000);

    public static readonly StreamTextToSpeechRequestOutputFormat Pcm44100 = new(Values.Pcm44100);

    public static readonly StreamTextToSpeechRequestOutputFormat Pcm48000 = new(Values.Pcm48000);

    public static readonly StreamTextToSpeechRequestOutputFormat Ulaw8000 = new(Values.Ulaw8000);

    public static readonly StreamTextToSpeechRequestOutputFormat Alaw8000 = new(Values.Alaw8000);

    public static readonly StreamTextToSpeechRequestOutputFormat Opus4800032 = new(
        Values.Opus4800032
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Opus4800064 = new(
        Values.Opus4800064
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Opus4800096 = new(
        Values.Opus4800096
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Opus48000128 = new(
        Values.Opus48000128
    );

    public static readonly StreamTextToSpeechRequestOutputFormat Opus48000192 = new(
        Values.Opus48000192
    );

    public StreamTextToSpeechRequestOutputFormat(string value)
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
    public static StreamTextToSpeechRequestOutputFormat FromCustom(string value)
    {
        return new StreamTextToSpeechRequestOutputFormat(value);
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

    public static bool operator ==(StreamTextToSpeechRequestOutputFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StreamTextToSpeechRequestOutputFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StreamTextToSpeechRequestOutputFormat value) =>
        value.Value;

    public static explicit operator StreamTextToSpeechRequestOutputFormat(string value) =>
        new(value);

    internal class StreamTextToSpeechRequestOutputFormatSerializer
        : JsonConverter<StreamTextToSpeechRequestOutputFormat>
    {
        public override StreamTextToSpeechRequestOutputFormat Read(
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
            return new StreamTextToSpeechRequestOutputFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamTextToSpeechRequestOutputFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StreamTextToSpeechRequestOutputFormat ReadAsPropertyName(
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
            return new StreamTextToSpeechRequestOutputFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StreamTextToSpeechRequestOutputFormat value,
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
        public const string Mp32205032 = "mp3_22050_32";

        public const string Mp32400048 = "mp3_24000_48";

        public const string Mp34410032 = "mp3_44100_32";

        public const string Mp34410064 = "mp3_44100_64";

        public const string Mp34410096 = "mp3_44100_96";

        public const string Mp344100128 = "mp3_44100_128";

        public const string Mp344100192 = "mp3_44100_192";

        public const string Pcm8000 = "pcm_8000";

        public const string Pcm16000 = "pcm_16000";

        public const string Pcm22050 = "pcm_22050";

        public const string Pcm24000 = "pcm_24000";

        public const string Pcm32000 = "pcm_32000";

        public const string Pcm44100 = "pcm_44100";

        public const string Pcm48000 = "pcm_48000";

        public const string Ulaw8000 = "ulaw_8000";

        public const string Alaw8000 = "alaw_8000";

        public const string Opus4800032 = "opus_48000_32";

        public const string Opus4800064 = "opus_48000_64";

        public const string Opus4800096 = "opus_48000_96";

        public const string Opus48000128 = "opus_48000_128";

        public const string Opus48000192 = "opus_48000_192";
    }
}
