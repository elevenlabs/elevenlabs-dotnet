using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(NonStreamingOutputFormats.NonStreamingOutputFormatsSerializer))]
[Serializable]
public readonly record struct NonStreamingOutputFormats : IStringEnum
{
    public static readonly NonStreamingOutputFormats Wav8000 = new(Values.Wav8000);

    public static readonly NonStreamingOutputFormats Wav16000 = new(Values.Wav16000);

    public static readonly NonStreamingOutputFormats Wav22050 = new(Values.Wav22050);

    public static readonly NonStreamingOutputFormats Wav24000 = new(Values.Wav24000);

    public static readonly NonStreamingOutputFormats Wav32000 = new(Values.Wav32000);

    public static readonly NonStreamingOutputFormats Wav44100 = new(Values.Wav44100);

    public static readonly NonStreamingOutputFormats Wav48000 = new(Values.Wav48000);

    public NonStreamingOutputFormats(string value)
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
    public static NonStreamingOutputFormats FromCustom(string value)
    {
        return new NonStreamingOutputFormats(value);
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

    public static bool operator ==(NonStreamingOutputFormats value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NonStreamingOutputFormats value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NonStreamingOutputFormats value) => value.Value;

    public static explicit operator NonStreamingOutputFormats(string value) => new(value);

    internal class NonStreamingOutputFormatsSerializer : JsonConverter<NonStreamingOutputFormats>
    {
        public override NonStreamingOutputFormats Read(
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
            return new NonStreamingOutputFormats(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NonStreamingOutputFormats value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NonStreamingOutputFormats ReadAsPropertyName(
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
            return new NonStreamingOutputFormats(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NonStreamingOutputFormats value,
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
        public const string Wav8000 = "wav_8000";

        public const string Wav16000 = "wav_16000";

        public const string Wav22050 = "wav_22050";

        public const string Wav24000 = "wav_24000";

        public const string Wav32000 = "wav_32000";

        public const string Wav44100 = "wav_44100";

        public const string Wav48000 = "wav_48000";
    }
}
