using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TranscriptPlatformEvent.TranscriptPlatformEventSerializer))]
[Serializable]
public readonly record struct TranscriptPlatformEvent : IStringEnum
{
    public static readonly TranscriptPlatformEvent UserTurnTimeout = new(Values.UserTurnTimeout);

    public static readonly TranscriptPlatformEvent SkipTurnWaitElapsed = new(
        Values.SkipTurnWaitElapsed
    );

    public TranscriptPlatformEvent(string value)
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
    public static TranscriptPlatformEvent FromCustom(string value)
    {
        return new TranscriptPlatformEvent(value);
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

    public static bool operator ==(TranscriptPlatformEvent value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscriptPlatformEvent value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscriptPlatformEvent value) => value.Value;

    public static explicit operator TranscriptPlatformEvent(string value) => new(value);

    internal class TranscriptPlatformEventSerializer : JsonConverter<TranscriptPlatformEvent>
    {
        public override TranscriptPlatformEvent Read(
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
            return new TranscriptPlatformEvent(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscriptPlatformEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranscriptPlatformEvent ReadAsPropertyName(
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
            return new TranscriptPlatformEvent(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscriptPlatformEvent value,
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
        public const string UserTurnTimeout = "user_turn_timeout";

        public const string SkipTurnWaitElapsed = "skip_turn_wait_elapsed";
    }
}
