using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UserFeedbackScore.UserFeedbackScoreSerializer))]
[Serializable]
public readonly record struct UserFeedbackScore : IStringEnum
{
    public static readonly UserFeedbackScore Like = new(Values.Like);

    public static readonly UserFeedbackScore Dislike = new(Values.Dislike);

    public UserFeedbackScore(string value)
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
    public static UserFeedbackScore FromCustom(string value)
    {
        return new UserFeedbackScore(value);
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

    public static bool operator ==(UserFeedbackScore value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserFeedbackScore value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserFeedbackScore value) => value.Value;

    public static explicit operator UserFeedbackScore(string value) => new(value);

    internal class UserFeedbackScoreSerializer : JsonConverter<UserFeedbackScore>
    {
        public override UserFeedbackScore Read(
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
            return new UserFeedbackScore(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserFeedbackScore value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserFeedbackScore ReadAsPropertyName(
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
            return new UserFeedbackScore(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserFeedbackScore value,
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
