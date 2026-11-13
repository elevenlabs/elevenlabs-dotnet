using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Commit strategy for speech segmentation. 'manual' (the default for all models) requires explicit commits, 'vad' automatically segments speech using silence detection, 'turn_prediction' additionally commits as soon as the model predicts the speaker has finished their turn (only for models that predict turns).</summary>
[JsonConverter(
    typeof(SpeechToTextRealtimeCommitStrategy.SpeechToTextRealtimeCommitStrategySerializer)
)]
[Serializable]
public readonly record struct SpeechToTextRealtimeCommitStrategy : IStringEnum
{
    public static readonly SpeechToTextRealtimeCommitStrategy Manual = new(Values.Manual);

    public static readonly SpeechToTextRealtimeCommitStrategy Vad = new(Values.Vad);

    public static readonly SpeechToTextRealtimeCommitStrategy TurnPrediction = new(
        Values.TurnPrediction
    );

    public SpeechToTextRealtimeCommitStrategy(string value)
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
    public static SpeechToTextRealtimeCommitStrategy FromCustom(string value)
    {
        return new SpeechToTextRealtimeCommitStrategy(value);
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

    public static bool operator ==(SpeechToTextRealtimeCommitStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeechToTextRealtimeCommitStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeechToTextRealtimeCommitStrategy value) => value.Value;

    public static explicit operator SpeechToTextRealtimeCommitStrategy(string value) => new(value);

    internal class SpeechToTextRealtimeCommitStrategySerializer
        : JsonConverter<SpeechToTextRealtimeCommitStrategy>
    {
        public override SpeechToTextRealtimeCommitStrategy Read(
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
            return new SpeechToTextRealtimeCommitStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeechToTextRealtimeCommitStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeechToTextRealtimeCommitStrategy ReadAsPropertyName(
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
            return new SpeechToTextRealtimeCommitStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeechToTextRealtimeCommitStrategy value,
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
        public const string Manual = "manual";

        public const string Vad = "vad";

        public const string TurnPrediction = "turn_prediction";
    }
}
