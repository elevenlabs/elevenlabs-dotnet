using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ConversationSentimentAnalysisOverallLabel.ConversationSentimentAnalysisOverallLabelSerializer)
)]
[Serializable]
public readonly record struct ConversationSentimentAnalysisOverallLabel : IStringEnum
{
    public static readonly ConversationSentimentAnalysisOverallLabel Positive = new(
        Values.Positive
    );

    public static readonly ConversationSentimentAnalysisOverallLabel Neutral = new(Values.Neutral);

    public static readonly ConversationSentimentAnalysisOverallLabel Negative = new(
        Values.Negative
    );

    public ConversationSentimentAnalysisOverallLabel(string value)
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
    public static ConversationSentimentAnalysisOverallLabel FromCustom(string value)
    {
        return new ConversationSentimentAnalysisOverallLabel(value);
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

    public static bool operator ==(
        ConversationSentimentAnalysisOverallLabel value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConversationSentimentAnalysisOverallLabel value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConversationSentimentAnalysisOverallLabel value) =>
        value.Value;

    public static explicit operator ConversationSentimentAnalysisOverallLabel(string value) =>
        new(value);

    internal class ConversationSentimentAnalysisOverallLabelSerializer
        : JsonConverter<ConversationSentimentAnalysisOverallLabel>
    {
        public override ConversationSentimentAnalysisOverallLabel Read(
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
            return new ConversationSentimentAnalysisOverallLabel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationSentimentAnalysisOverallLabel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationSentimentAnalysisOverallLabel ReadAsPropertyName(
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
            return new ConversationSentimentAnalysisOverallLabel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationSentimentAnalysisOverallLabel value,
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
        public const string Positive = "positive";

        public const string Neutral = "neutral";

        public const string Negative = "negative";
    }
}
