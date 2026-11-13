using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Audio encoding format for realtime translation output.</summary>
[JsonConverter(typeof(TranslationRealtimeOutputFormat.TranslationRealtimeOutputFormatSerializer))]
[Serializable]
public readonly record struct TranslationRealtimeOutputFormat : IStringEnum
{
    public static readonly TranslationRealtimeOutputFormat Mp32205032 = new(Values.Mp32205032);

    public static readonly TranslationRealtimeOutputFormat Mp34410032 = new(Values.Mp34410032);

    public static readonly TranslationRealtimeOutputFormat Mp34410064 = new(Values.Mp34410064);

    public static readonly TranslationRealtimeOutputFormat Mp34410096 = new(Values.Mp34410096);

    public static readonly TranslationRealtimeOutputFormat Mp344100128 = new(Values.Mp344100128);

    public static readonly TranslationRealtimeOutputFormat Mp344100192 = new(Values.Mp344100192);

    public static readonly TranslationRealtimeOutputFormat Pcm16000 = new(Values.Pcm16000);

    public static readonly TranslationRealtimeOutputFormat Pcm22050 = new(Values.Pcm22050);

    public static readonly TranslationRealtimeOutputFormat Pcm24000 = new(Values.Pcm24000);

    public static readonly TranslationRealtimeOutputFormat Pcm44100 = new(Values.Pcm44100);

    public static readonly TranslationRealtimeOutputFormat Ulaw8000 = new(Values.Ulaw8000);

    public TranslationRealtimeOutputFormat(string value)
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
    public static TranslationRealtimeOutputFormat FromCustom(string value)
    {
        return new TranslationRealtimeOutputFormat(value);
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

    public static bool operator ==(TranslationRealtimeOutputFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslationRealtimeOutputFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslationRealtimeOutputFormat value) => value.Value;

    public static explicit operator TranslationRealtimeOutputFormat(string value) => new(value);

    internal class TranslationRealtimeOutputFormatSerializer
        : JsonConverter<TranslationRealtimeOutputFormat>
    {
        public override TranslationRealtimeOutputFormat Read(
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
            return new TranslationRealtimeOutputFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslationRealtimeOutputFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslationRealtimeOutputFormat ReadAsPropertyName(
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
            return new TranslationRealtimeOutputFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslationRealtimeOutputFormat value,
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

        public const string Mp34410032 = "mp3_44100_32";

        public const string Mp34410064 = "mp3_44100_64";

        public const string Mp34410096 = "mp3_44100_96";

        public const string Mp344100128 = "mp3_44100_128";

        public const string Mp344100192 = "mp3_44100_192";

        public const string Pcm16000 = "pcm_16000";

        public const string Pcm22050 = "pcm_22050";

        public const string Pcm24000 = "pcm_24000";

        public const string Pcm44100 = "pcm_44100";

        public const string Ulaw8000 = "ulaw_8000";
    }
}
