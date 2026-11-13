using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(UsersSortBy.UsersSortBySerializer))]
[Serializable]
public readonly record struct UsersSortBy : IStringEnum
{
    public static readonly UsersSortBy LastContactUnixSecs = new(Values.LastContactUnixSecs);

    public static readonly UsersSortBy ConversationCount = new(Values.ConversationCount);

    public static readonly UsersSortBy AverageSentimentScore = new(Values.AverageSentimentScore);

    public UsersSortBy(string value)
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
    public static UsersSortBy FromCustom(string value)
    {
        return new UsersSortBy(value);
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

    public static bool operator ==(UsersSortBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UsersSortBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UsersSortBy value) => value.Value;

    public static explicit operator UsersSortBy(string value) => new(value);

    internal class UsersSortBySerializer : JsonConverter<UsersSortBy>
    {
        public override UsersSortBy Read(
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
            return new UsersSortBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UsersSortBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UsersSortBy ReadAsPropertyName(
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
            return new UsersSortBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UsersSortBy value,
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
        public const string LastContactUnixSecs = "last_contact_unix_secs";

        public const string ConversationCount = "conversation_count";

        public const string AverageSentimentScore = "average_sentiment_score";
    }
}
