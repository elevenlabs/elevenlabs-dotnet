using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SubtitlingInputAudioChunkMessageType.SubtitlingInputAudioChunkMessageTypeSerializer)
)]
[Serializable]
public readonly record struct SubtitlingInputAudioChunkMessageType : IStringEnum
{
    public static readonly SubtitlingInputAudioChunkMessageType InputAudioChunk = new(
        Values.InputAudioChunk
    );

    public SubtitlingInputAudioChunkMessageType(string value)
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
    public static SubtitlingInputAudioChunkMessageType FromCustom(string value)
    {
        return new SubtitlingInputAudioChunkMessageType(value);
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

    public static bool operator ==(SubtitlingInputAudioChunkMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingInputAudioChunkMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingInputAudioChunkMessageType value) =>
        value.Value;

    public static explicit operator SubtitlingInputAudioChunkMessageType(string value) =>
        new(value);

    internal class SubtitlingInputAudioChunkMessageTypeSerializer
        : JsonConverter<SubtitlingInputAudioChunkMessageType>
    {
        public override SubtitlingInputAudioChunkMessageType Read(
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
            return new SubtitlingInputAudioChunkMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingInputAudioChunkMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingInputAudioChunkMessageType ReadAsPropertyName(
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
            return new SubtitlingInputAudioChunkMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingInputAudioChunkMessageType value,
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
