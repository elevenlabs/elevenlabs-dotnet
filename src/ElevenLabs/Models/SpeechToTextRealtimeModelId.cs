using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The ID of the model to use for speech-to-text transcription.</summary>
[JsonConverter(typeof(SpeechToTextRealtimeModelId.SpeechToTextRealtimeModelIdSerializer))]
[Serializable]
public readonly record struct SpeechToTextRealtimeModelId : IStringEnum
{
    public static readonly SpeechToTextRealtimeModelId ScribeV2Realtime = new(
        Values.ScribeV2Realtime
    );

    public static readonly SpeechToTextRealtimeModelId ScribeV3Live = new(Values.ScribeV3Live);

    public SpeechToTextRealtimeModelId(string value)
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
    public static SpeechToTextRealtimeModelId FromCustom(string value)
    {
        return new SpeechToTextRealtimeModelId(value);
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

    public static bool operator ==(SpeechToTextRealtimeModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeechToTextRealtimeModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeechToTextRealtimeModelId value) => value.Value;

    public static explicit operator SpeechToTextRealtimeModelId(string value) => new(value);

    internal class SpeechToTextRealtimeModelIdSerializer
        : JsonConverter<SpeechToTextRealtimeModelId>
    {
        public override SpeechToTextRealtimeModelId Read(
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
            return new SpeechToTextRealtimeModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeechToTextRealtimeModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeechToTextRealtimeModelId ReadAsPropertyName(
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
            return new SpeechToTextRealtimeModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeechToTextRealtimeModelId value,
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
        public const string ScribeV2Realtime = "scribe_v2_realtime";

        public const string ScribeV3Live = "scribe_v3_live";
    }
}
