using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(McpConnectionStatusType.McpConnectionStatusTypeSerializer))]
[Serializable]
public readonly record struct McpConnectionStatusType : IStringEnum
{
    public static readonly McpConnectionStatusType McpConnectionStatus = new(
        Values.McpConnectionStatus
    );

    public McpConnectionStatusType(string value)
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
    public static McpConnectionStatusType FromCustom(string value)
    {
        return new McpConnectionStatusType(value);
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

    public static bool operator ==(McpConnectionStatusType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpConnectionStatusType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpConnectionStatusType value) => value.Value;

    public static explicit operator McpConnectionStatusType(string value) => new(value);

    internal class McpConnectionStatusTypeSerializer : JsonConverter<McpConnectionStatusType>
    {
        public override McpConnectionStatusType Read(
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
            return new McpConnectionStatusType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpConnectionStatusType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpConnectionStatusType ReadAsPropertyName(
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
            return new McpConnectionStatusType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpConnectionStatusType value,
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
        public const string McpConnectionStatus = "mcp_connection_status";
    }
}
