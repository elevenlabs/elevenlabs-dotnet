using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Encoding and sample rate of each input audio chunk.</summary>
[JsonConverter(typeof(DubbingLiveInputFormat.DubbingLiveInputFormatSerializer))]
[Serializable]
public readonly record struct DubbingLiveInputFormat : IStringEnum
{
    public static readonly DubbingLiveInputFormat Pcm8000 = new(Values.Pcm8000);

    public static readonly DubbingLiveInputFormat Pcm16000 = new(Values.Pcm16000);

    public static readonly DubbingLiveInputFormat Pcm22050 = new(Values.Pcm22050);

    public static readonly DubbingLiveInputFormat Pcm24000 = new(Values.Pcm24000);

    public static readonly DubbingLiveInputFormat Pcm44100 = new(Values.Pcm44100);

    public static readonly DubbingLiveInputFormat Pcm48000 = new(Values.Pcm48000);

    public static readonly DubbingLiveInputFormat Ulaw8000 = new(Values.Ulaw8000);

    public DubbingLiveInputFormat(string value)
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
    public static DubbingLiveInputFormat FromCustom(string value)
    {
        return new DubbingLiveInputFormat(value);
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

    public static bool operator ==(DubbingLiveInputFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingLiveInputFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingLiveInputFormat value) => value.Value;

    public static explicit operator DubbingLiveInputFormat(string value) => new(value);

    internal class DubbingLiveInputFormatSerializer : JsonConverter<DubbingLiveInputFormat>
    {
        public override DubbingLiveInputFormat Read(
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
            return new DubbingLiveInputFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingLiveInputFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingLiveInputFormat ReadAsPropertyName(
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
            return new DubbingLiveInputFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingLiveInputFormat value,
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
