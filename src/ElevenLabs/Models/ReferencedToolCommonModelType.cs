using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of the tool</summary>
[JsonConverter(typeof(ReferencedToolCommonModelType.ReferencedToolCommonModelTypeSerializer))]
[Serializable]
public readonly record struct ReferencedToolCommonModelType : IStringEnum
{
    public static readonly ReferencedToolCommonModelType System = new(Values.System);

    public static readonly ReferencedToolCommonModelType Webhook = new(Values.Webhook);

    public static readonly ReferencedToolCommonModelType Client = new(Values.Client);

    public static readonly ReferencedToolCommonModelType Workflow = new(Values.Workflow);

    public static readonly ReferencedToolCommonModelType ApiIntegrationWebhook = new(
        Values.ApiIntegrationWebhook
    );

    public static readonly ReferencedToolCommonModelType Mcp = new(Values.Mcp);

    public static readonly ReferencedToolCommonModelType Code = new(Values.Code);

    public ReferencedToolCommonModelType(string value)
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
    public static ReferencedToolCommonModelType FromCustom(string value)
    {
        return new ReferencedToolCommonModelType(value);
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

    public static bool operator ==(ReferencedToolCommonModelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReferencedToolCommonModelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReferencedToolCommonModelType value) => value.Value;

    public static explicit operator ReferencedToolCommonModelType(string value) => new(value);

    internal class ReferencedToolCommonModelTypeSerializer
        : JsonConverter<ReferencedToolCommonModelType>
    {
        public override ReferencedToolCommonModelType Read(
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
            return new ReferencedToolCommonModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReferencedToolCommonModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReferencedToolCommonModelType ReadAsPropertyName(
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
            return new ReferencedToolCommonModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReferencedToolCommonModelType value,
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
        public const string System = "system";

        public const string Webhook = "webhook";

        public const string Client = "client";

        public const string Workflow = "workflow";

        public const string ApiIntegrationWebhook = "api_integration_webhook";

        public const string Mcp = "mcp";

        public const string Code = "code";
    }
}
