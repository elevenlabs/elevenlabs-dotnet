using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(McpToolCallType.McpToolCallTypeSerializer))]
[Serializable]
public readonly record struct McpToolCallType : IStringEnum
{
    public static readonly McpToolCallType McpToolCall = new(Values.McpToolCall);

    public McpToolCallType(string value)
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
    public static McpToolCallType FromCustom(string value)
    {
        return new McpToolCallType(value);
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

    public static bool operator ==(McpToolCallType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpToolCallType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpToolCallType value) => value.Value;

    public static explicit operator McpToolCallType(string value) => new(value);

    internal class McpToolCallTypeSerializer : JsonConverter<McpToolCallType>
    {
        public override McpToolCallType Read(
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
            return new McpToolCallType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpToolCallType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpToolCallType ReadAsPropertyName(
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
            return new McpToolCallType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpToolCallType value,
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
        public const string McpToolCall = "mcp_tool_call";
    }
}
