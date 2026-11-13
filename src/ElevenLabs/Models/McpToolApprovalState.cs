using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Whether a discovered MCP tool has an approval and whether it still matches.</summary>
[JsonConverter(typeof(McpToolApprovalState.McpToolApprovalStateSerializer))]
[Serializable]
public readonly record struct McpToolApprovalState : IStringEnum
{
    public static readonly McpToolApprovalState UpToDate = new(Values.UpToDate);

    public static readonly McpToolApprovalState NeedsReview = new(Values.NeedsReview);

    public static readonly McpToolApprovalState NotApproved = new(Values.NotApproved);

    public McpToolApprovalState(string value)
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
    public static McpToolApprovalState FromCustom(string value)
    {
        return new McpToolApprovalState(value);
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

    public static bool operator ==(McpToolApprovalState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpToolApprovalState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpToolApprovalState value) => value.Value;

    public static explicit operator McpToolApprovalState(string value) => new(value);

    internal class McpToolApprovalStateSerializer : JsonConverter<McpToolApprovalState>
    {
        public override McpToolApprovalState Read(
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
            return new McpToolApprovalState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpToolApprovalState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpToolApprovalState ReadAsPropertyName(
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
            return new McpToolApprovalState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpToolApprovalState value,
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
        public const string UpToDate = "up_to_date";

        public const string NeedsReview = "needs_review";

        public const string NotApproved = "not_approved";
    }
}
