using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DubbingAudioOutputErrorMessageType.DubbingAudioOutputErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct DubbingAudioOutputErrorMessageType : IStringEnum
{
    public static readonly DubbingAudioOutputErrorMessageType AudioOutputError = new(
        Values.AudioOutputError
    );

    public DubbingAudioOutputErrorMessageType(string value)
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
    public static DubbingAudioOutputErrorMessageType FromCustom(string value)
    {
        return new DubbingAudioOutputErrorMessageType(value);
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

    public static bool operator ==(DubbingAudioOutputErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingAudioOutputErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingAudioOutputErrorMessageType value) => value.Value;

    public static explicit operator DubbingAudioOutputErrorMessageType(string value) => new(value);

    internal class DubbingAudioOutputErrorMessageTypeSerializer
        : JsonConverter<DubbingAudioOutputErrorMessageType>
    {
        public override DubbingAudioOutputErrorMessageType Read(
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
            return new DubbingAudioOutputErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingAudioOutputErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingAudioOutputErrorMessageType ReadAsPropertyName(
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
            return new DubbingAudioOutputErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingAudioOutputErrorMessageType value,
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
