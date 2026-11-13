using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(IntegrationType.IntegrationTypeSerializer))]
[Serializable]
public readonly record struct IntegrationType : IStringEnum
{
    public static readonly IntegrationType McpServer = new(Values.McpServer);

    public static readonly IntegrationType McpIntegration = new(Values.McpIntegration);

    public IntegrationType(string value)
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
    public static IntegrationType FromCustom(string value)
    {
        return new IntegrationType(value);
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

    public static bool operator ==(IntegrationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IntegrationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IntegrationType value) => value.Value;

    public static explicit operator IntegrationType(string value) => new(value);

    internal class IntegrationTypeSerializer : JsonConverter<IntegrationType>
    {
        public override IntegrationType Read(
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
            return new IntegrationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IntegrationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IntegrationType ReadAsPropertyName(
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
            return new IntegrationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IntegrationType value,
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
