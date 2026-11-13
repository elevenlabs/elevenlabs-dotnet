using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(ToolTypeFilter.ToolTypeFilterSerializer))]
[Serializable]
public readonly record struct ToolTypeFilter : IStringEnum
{
    public static readonly ToolTypeFilter Webhook = new(Values.Webhook);

    public static readonly ToolTypeFilter Client = new(Values.Client);

    public static readonly ToolTypeFilter ApiIntegrationWebhook = new(Values.ApiIntegrationWebhook);

    public ToolTypeFilter(string value)
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
    public static ToolTypeFilter FromCustom(string value)
    {
        return new ToolTypeFilter(value);
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

    public static bool operator ==(ToolTypeFilter value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolTypeFilter value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolTypeFilter value) => value.Value;

    public static explicit operator ToolTypeFilter(string value) => new(value);

    internal class ToolTypeFilterSerializer : JsonConverter<ToolTypeFilter>
    {
        public override ToolTypeFilter Read(
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
            return new ToolTypeFilter(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolTypeFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolTypeFilter ReadAsPropertyName(
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
            return new ToolTypeFilter(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolTypeFilter value,
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
        public const string Webhook = "webhook";

        public const string Client = "client";

        public const string ApiIntegrationWebhook = "api_integration_webhook";
    }
}
