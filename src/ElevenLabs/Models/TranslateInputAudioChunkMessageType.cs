using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TranslateInputAudioChunkMessageType.TranslateInputAudioChunkMessageTypeSerializer)
)]
[Serializable]
public readonly record struct TranslateInputAudioChunkMessageType : IStringEnum
{
    public static readonly TranslateInputAudioChunkMessageType InputAudioChunk = new(
        Values.InputAudioChunk
    );

    public TranslateInputAudioChunkMessageType(string value)
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
    public static TranslateInputAudioChunkMessageType FromCustom(string value)
    {
        return new TranslateInputAudioChunkMessageType(value);
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

    public static bool operator ==(TranslateInputAudioChunkMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslateInputAudioChunkMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslateInputAudioChunkMessageType value) =>
        value.Value;

    public static explicit operator TranslateInputAudioChunkMessageType(string value) => new(value);

    internal class TranslateInputAudioChunkMessageTypeSerializer
        : JsonConverter<TranslateInputAudioChunkMessageType>
    {
        public override TranslateInputAudioChunkMessageType Read(
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
            return new TranslateInputAudioChunkMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslateInputAudioChunkMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslateInputAudioChunkMessageType ReadAsPropertyName(
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
            return new TranslateInputAudioChunkMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslateInputAudioChunkMessageType value,
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
        public const string InputAudioChunk = "input_audio_chunk";
    }
}
