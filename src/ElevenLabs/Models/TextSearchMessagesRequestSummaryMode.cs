using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.Conversations;

/// <summary>Whether to include transcript summaries in the response.</summary>
[JsonConverter(
    typeof(TextSearchMessagesRequestSummaryMode.TextSearchMessagesRequestSummaryModeSerializer)
)]
[Serializable]
public readonly record struct TextSearchMessagesRequestSummaryMode : IStringEnum
{
    public static readonly TextSearchMessagesRequestSummaryMode Exclude = new(Values.Exclude);

    public static readonly TextSearchMessagesRequestSummaryMode Include = new(Values.Include);

    public TextSearchMessagesRequestSummaryMode(string value)
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
    public static TextSearchMessagesRequestSummaryMode FromCustom(string value)
    {
        return new TextSearchMessagesRequestSummaryMode(value);
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

    public static bool operator ==(TextSearchMessagesRequestSummaryMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TextSearchMessagesRequestSummaryMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TextSearchMessagesRequestSummaryMode value) =>
        value.Value;

    public static explicit operator TextSearchMessagesRequestSummaryMode(string value) =>
        new(value);

    internal class TextSearchMessagesRequestSummaryModeSerializer
        : JsonConverter<TextSearchMessagesRequestSummaryMode>
    {
        public override TextSearchMessagesRequestSummaryMode Read(
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
            return new TextSearchMessagesRequestSummaryMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextSearchMessagesRequestSummaryMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextSearchMessagesRequestSummaryMode ReadAsPropertyName(
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
            return new TextSearchMessagesRequestSummaryMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextSearchMessagesRequestSummaryMode value,
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
        public const string Exclude = "exclude";

        public const string Include = "include";
    }
}
