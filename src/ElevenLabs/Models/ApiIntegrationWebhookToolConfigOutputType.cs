using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ApiIntegrationWebhookToolConfigOutputType.ApiIntegrationWebhookToolConfigOutputTypeSerializer)
)]
[Serializable]
public readonly record struct ApiIntegrationWebhookToolConfigOutputType : IStringEnum
{
    public static readonly ApiIntegrationWebhookToolConfigOutputType ApiIntegrationWebhook = new(
        Values.ApiIntegrationWebhook
    );

    public ApiIntegrationWebhookToolConfigOutputType(string value)
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
    public static ApiIntegrationWebhookToolConfigOutputType FromCustom(string value)
    {
        return new ApiIntegrationWebhookToolConfigOutputType(value);
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
        ApiIntegrationWebhookToolConfigOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ApiIntegrationWebhookToolConfigOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ApiIntegrationWebhookToolConfigOutputType value) =>
        value.Value;

    public static explicit operator ApiIntegrationWebhookToolConfigOutputType(string value) =>
        new(value);

    internal class ApiIntegrationWebhookToolConfigOutputTypeSerializer
        : JsonConverter<ApiIntegrationWebhookToolConfigOutputType>
    {
        public override ApiIntegrationWebhookToolConfigOutputType Read(
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
            return new ApiIntegrationWebhookToolConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ApiIntegrationWebhookToolConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ApiIntegrationWebhookToolConfigOutputType ReadAsPropertyName(
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
            return new ApiIntegrationWebhookToolConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ApiIntegrationWebhookToolConfigOutputType value,
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
        public const string ApiIntegrationWebhook = "api_integration_webhook";
    }
}
