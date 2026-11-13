using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.Conversations;

[JsonConverter(typeof(MessageSearchSortBy.MessageSearchSortBySerializer))]
[Serializable]
public readonly record struct MessageSearchSortBy : IStringEnum
{
    public static readonly MessageSearchSortBy SearchScore = new(Values.SearchScore);

    public static readonly MessageSearchSortBy CreatedAt = new(Values.CreatedAt);

    public MessageSearchSortBy(string value)
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
    public static MessageSearchSortBy FromCustom(string value)
    {
        return new MessageSearchSortBy(value);
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

    public static bool operator ==(MessageSearchSortBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MessageSearchSortBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MessageSearchSortBy value) => value.Value;

    public static explicit operator MessageSearchSortBy(string value) => new(value);

    internal class MessageSearchSortBySerializer : JsonConverter<MessageSearchSortBy>
    {
        public override MessageSearchSortBy Read(
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
            return new MessageSearchSortBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MessageSearchSortBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MessageSearchSortBy ReadAsPropertyName(
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
            return new MessageSearchSortBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MessageSearchSortBy value,
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
        public const string SearchScore = "search_score";

        public const string CreatedAt = "created_at";
    }
}
