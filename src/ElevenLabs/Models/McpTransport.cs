using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(McpTransport.McpTransportSerializer))]
[Serializable]
public readonly record struct McpTransport : IStringEnum
{
    public static readonly McpTransport Sse = new(Values.Sse);

    public static readonly McpTransport StreamableHttp = new(Values.StreamableHttp);

    public McpTransport(string value)
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
    public static McpTransport FromCustom(string value)
    {
        return new McpTransport(value);
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

    public static bool operator ==(McpTransport value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(McpTransport value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(McpTransport value) => value.Value;

    public static explicit operator McpTransport(string value) => new(value);

    internal class McpTransportSerializer : JsonConverter<McpTransport>
    {
        public override McpTransport Read(
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
            return new McpTransport(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpTransport value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpTransport ReadAsPropertyName(
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
            return new McpTransport(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpTransport value,
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
