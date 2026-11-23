using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType.McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationTypeSerializer)
)]
[Serializable]
public readonly record struct McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType
    : IStringEnum
{
    public static readonly McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType McpServer =
        new(Values.McpServer);

    public static readonly McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType McpIntegration =
        new(Values.McpIntegration);

    public McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType(string value)
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
    public static McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType FromCustom(
        string value
    )
    {
        return new McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType(value);
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

    public static bool operator ==(
        McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType value
    ) => value.Value;

    public static explicit operator McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType(
        string value
    ) => new(value);

    internal class McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationTypeSerializer
        : JsonConverter<McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType>
    {
        public override McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType Read(
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
            return new McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType ReadAsPropertyName(
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
            return new McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpConnectionStatusMcpConnectionStatusIntegrationsItemIntegrationType value,
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
        public const string McpServer = "mcp_server";

        public const string McpIntegration = "mcp_integration";
    }
}
