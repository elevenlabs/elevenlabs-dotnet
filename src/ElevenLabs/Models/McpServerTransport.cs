using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Supported MCP server transport types.</summary>
[JsonConverter(typeof(McpServerTransport.McpServerTransportSerializer))]
[Serializable]
public readonly record struct McpServerTransport : IStringEnum
{
    public static readonly McpServerTransport Sse = new(Values.Sse);

    public static readonly McpServerTransport StreamableHttp = new(Values.StreamableHttp);

    public McpServerTransport(string value)
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
    public static McpServerTransport FromCustom(string value)
    {
        return new McpServerTransport(value);
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

    public static bool operator ==(McpServerTransport value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpServerTransport value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpServerTransport value) => value.Value;

    public static explicit operator McpServerTransport(string value) => new(value);

    internal class McpServerTransportSerializer : JsonConverter<McpServerTransport>
    {
        public override McpServerTransport Read(
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
            return new McpServerTransport(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpServerTransport value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpServerTransport ReadAsPropertyName(
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
            return new McpServerTransport(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpServerTransport value,
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
        public const string Sse = "SSE";

        public const string StreamableHttp = "STREAMABLE_HTTP";
    }
}
