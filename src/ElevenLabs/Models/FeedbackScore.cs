using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Feedback score for the referenced agent response. Null clears any previously submitted feedback for the event.</summary>
[JsonConverter(typeof(FeedbackScore.FeedbackScoreSerializer))]
[Serializable]
public readonly record struct FeedbackScore : IStringEnum
{
    public static readonly FeedbackScore Like = new(Values.Like);

    public static readonly FeedbackScore Dislike = new(Values.Dislike);

    public FeedbackScore(string value)
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
    public static FeedbackScore FromCustom(string value)
    {
        return new FeedbackScore(value);
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

    public static bool operator ==(FeedbackScore value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FeedbackScore value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FeedbackScore value) => value.Value;

    public static explicit operator FeedbackScore(string value) => new(value);

    internal class FeedbackScoreSerializer : JsonConverter<FeedbackScore>
    {
        public override FeedbackScore Read(
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
            return new FeedbackScore(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FeedbackScore value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FeedbackScore ReadAsPropertyName(
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
            return new FeedbackScore(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FeedbackScore value,
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
        public const string Like = "like";

        public const string Dislike = "dislike";
    }
}
