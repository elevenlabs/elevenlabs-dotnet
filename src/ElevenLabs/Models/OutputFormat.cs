using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OutputFormat.OutputFormatSerializer))]
[Serializable]
public readonly record struct OutputFormat : IStringEnum
{
    public static readonly OutputFormat Mp32205032 = new(Values.Mp32205032);

    public static readonly OutputFormat Mp34410032 = new(Values.Mp34410032);

    public static readonly OutputFormat Mp34410064 = new(Values.Mp34410064);

    public static readonly OutputFormat Mp34410096 = new(Values.Mp34410096);

    public static readonly OutputFormat Mp344100128 = new(Values.Mp344100128);

    public static readonly OutputFormat Mp344100192 = new(Values.Mp344100192);

    public static readonly OutputFormat Pcm16000 = new(Values.Pcm16000);

    public static readonly OutputFormat Pcm22050 = new(Values.Pcm22050);

    public static readonly OutputFormat Pcm24000 = new(Values.Pcm24000);

    public static readonly OutputFormat Pcm44100 = new(Values.Pcm44100);

    public static readonly OutputFormat Ulaw8000 = new(Values.Ulaw8000);

    public OutputFormat(string value)
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
    public static OutputFormat FromCustom(string value)
    {
        return new OutputFormat(value);
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

    public static bool operator ==(OutputFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OutputFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OutputFormat value) => value.Value;

    public static explicit operator OutputFormat(string value) => new(value);

    internal class OutputFormatSerializer : JsonConverter<OutputFormat>
    {
        public override OutputFormat Read(
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
            return new OutputFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OutputFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OutputFormat ReadAsPropertyName(
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
            return new OutputFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OutputFormat value,
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
