using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OpenAiAudioFormat.OpenAiAudioFormatSerializer))]
[Serializable]
public readonly record struct OpenAiAudioFormat : IStringEnum
{
    public static readonly OpenAiAudioFormat AudioPcm = new(Values.AudioPcm);

    public static readonly OpenAiAudioFormat AudioPcmu = new(Values.AudioPcmu);

    public OpenAiAudioFormat(string value)
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
    public static OpenAiAudioFormat FromCustom(string value)
    {
        return new OpenAiAudioFormat(value);
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

    public static bool operator ==(OpenAiAudioFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OpenAiAudioFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OpenAiAudioFormat value) => value.Value;

    public static explicit operator OpenAiAudioFormat(string value) => new(value);

    internal class OpenAiAudioFormatSerializer : JsonConverter<OpenAiAudioFormat>
    {
        public override OpenAiAudioFormat Read(
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
            return new OpenAiAudioFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OpenAiAudioFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OpenAiAudioFormat ReadAsPropertyName(
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
            return new OpenAiAudioFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OpenAiAudioFormat value,
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
        public const string AudioPcm = "audio/pcm";

        public const string AudioPcmu = "audio/pcmu";
    }
}
