using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TranslateAudioOutputErrorMessageType.TranslateAudioOutputErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct TranslateAudioOutputErrorMessageType : IStringEnum
{
    public static readonly TranslateAudioOutputErrorMessageType AudioOutputError = new(
        Values.AudioOutputError
    );

    public TranslateAudioOutputErrorMessageType(string value)
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
    public static TranslateAudioOutputErrorMessageType FromCustom(string value)
    {
        return new TranslateAudioOutputErrorMessageType(value);
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

    public static bool operator ==(TranslateAudioOutputErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslateAudioOutputErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslateAudioOutputErrorMessageType value) =>
        value.Value;

    public static explicit operator TranslateAudioOutputErrorMessageType(string value) =>
        new(value);

    internal class TranslateAudioOutputErrorMessageTypeSerializer
        : JsonConverter<TranslateAudioOutputErrorMessageType>
    {
        public override TranslateAudioOutputErrorMessageType Read(
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
            return new TranslateAudioOutputErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslateAudioOutputErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslateAudioOutputErrorMessageType ReadAsPropertyName(
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
            return new TranslateAudioOutputErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslateAudioOutputErrorMessageType value,
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
        public const string AudioOutputError = "audio_output_error";
    }
}
