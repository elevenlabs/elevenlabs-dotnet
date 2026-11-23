using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(McpToolApprovalResultType.McpToolApprovalResultTypeSerializer))]
[Serializable]
public readonly record struct McpToolApprovalResultType : IStringEnum
{
    public static readonly McpToolApprovalResultType McpToolApprovalResult = new(
        Values.McpToolApprovalResult
    );

    public McpToolApprovalResultType(string value)
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
    public static McpToolApprovalResultType FromCustom(string value)
    {
        return new McpToolApprovalResultType(value);
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

    public static bool operator ==(McpToolApprovalResultType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpToolApprovalResultType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpToolApprovalResultType value) => value.Value;

    public static explicit operator McpToolApprovalResultType(string value) => new(value);

    internal class McpToolApprovalResultTypeSerializer : JsonConverter<McpToolApprovalResultType>
    {
        public override McpToolApprovalResultType Read(
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
            return new McpToolApprovalResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpToolApprovalResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpToolApprovalResultType ReadAsPropertyName(
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
            return new McpToolApprovalResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpToolApprovalResultType value,
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
        public const string McpToolApprovalResult = "mcp_tool_approval_result";
    }
}
