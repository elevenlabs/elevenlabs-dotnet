using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

/// <summary>Whether to include transcript summaries in the response.</summary>
[JsonConverter(
    typeof(ListConversationsRequestSummaryMode.ListConversationsRequestSummaryModeSerializer)
)]
[Serializable]
public readonly record struct ListConversationsRequestSummaryMode : IStringEnum
{
    public static readonly ListConversationsRequestSummaryMode Exclude = new(Values.Exclude);

    public static readonly ListConversationsRequestSummaryMode Include = new(Values.Include);

    public ListConversationsRequestSummaryMode(string value)
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
    public static ListConversationsRequestSummaryMode FromCustom(string value)
    {
        return new ListConversationsRequestSummaryMode(value);
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

    public static bool operator ==(ListConversationsRequestSummaryMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListConversationsRequestSummaryMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListConversationsRequestSummaryMode value) =>
        value.Value;

    public static explicit operator ListConversationsRequestSummaryMode(string value) => new(value);

    internal class ListConversationsRequestSummaryModeSerializer
        : JsonConverter<ListConversationsRequestSummaryMode>
    {
        public override ListConversationsRequestSummaryMode Read(
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
            return new ListConversationsRequestSummaryMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListConversationsRequestSummaryMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListConversationsRequestSummaryMode ReadAsPropertyName(
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
            return new ListConversationsRequestSummaryMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListConversationsRequestSummaryMode value,
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
