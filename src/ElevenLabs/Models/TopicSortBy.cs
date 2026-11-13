using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.Conversations;

[JsonConverter(typeof(TopicSortBy.TopicSortBySerializer))]
[Serializable]
public readonly record struct TopicSortBy : IStringEnum
{
    public static readonly TopicSortBy Conversations = new(Values.Conversations);

    public static readonly TopicSortBy Sentiment = new(Values.Sentiment);

    public static readonly TopicSortBy SuccessRate = new(Values.SuccessRate);

    public static readonly TopicSortBy Frustration = new(Values.Frustration);

    public TopicSortBy(string value)
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
    public static TopicSortBy FromCustom(string value)
    {
        return new TopicSortBy(value);
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

    public static bool operator ==(TopicSortBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TopicSortBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TopicSortBy value) => value.Value;

    public static explicit operator TopicSortBy(string value) => new(value);

    internal class TopicSortBySerializer : JsonConverter<TopicSortBy>
    {
        public override TopicSortBy Read(
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
            return new TopicSortBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TopicSortBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TopicSortBy ReadAsPropertyName(
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
            return new TopicSortBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TopicSortBy value,
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
        public const string Conversations = "conversations";

        public const string Sentiment = "sentiment";

        public const string SuccessRate = "success_rate";

        public const string Frustration = "frustration";
    }
}
