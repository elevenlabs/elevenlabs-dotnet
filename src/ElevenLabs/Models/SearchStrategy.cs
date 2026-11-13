using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SearchStrategy.SearchStrategySerializer))]
[Serializable]
public readonly record struct SearchStrategy : IStringEnum
{
    public static readonly SearchStrategy Cat = new(Values.Cat);

    public static readonly SearchStrategy Keyword = new(Values.Keyword);

    public static readonly SearchStrategy Semantic = new(Values.Semantic);

    public static readonly SearchStrategy Ls = new(Values.Ls);

    public SearchStrategy(string value)
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
    public static SearchStrategy FromCustom(string value)
    {
        return new SearchStrategy(value);
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

    public static bool operator ==(SearchStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SearchStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SearchStrategy value) => value.Value;

    public static explicit operator SearchStrategy(string value) => new(value);

    internal class SearchStrategySerializer : JsonConverter<SearchStrategy>
    {
        public override SearchStrategy Read(
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
            return new SearchStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SearchStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SearchStrategy ReadAsPropertyName(
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
            return new SearchStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SearchStrategy value,
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
        public const string Cat = "cat";

        public const string Keyword = "keyword";

        public const string Semantic = "semantic";

        public const string Ls = "ls";
    }
}
