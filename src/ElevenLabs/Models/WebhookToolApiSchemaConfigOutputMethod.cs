using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The HTTP method to use for the webhook</summary>
[JsonConverter(
    typeof(WebhookToolApiSchemaConfigOutputMethod.WebhookToolApiSchemaConfigOutputMethodSerializer)
)]
[Serializable]
public readonly record struct WebhookToolApiSchemaConfigOutputMethod : IStringEnum
{
    public static readonly WebhookToolApiSchemaConfigOutputMethod Get = new(Values.Get);

    public static readonly WebhookToolApiSchemaConfigOutputMethod Post = new(Values.Post);

    public static readonly WebhookToolApiSchemaConfigOutputMethod Put = new(Values.Put);

    public static readonly WebhookToolApiSchemaConfigOutputMethod Patch = new(Values.Patch);

    public static readonly WebhookToolApiSchemaConfigOutputMethod Delete = new(Values.Delete);

    public WebhookToolApiSchemaConfigOutputMethod(string value)
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
    public static WebhookToolApiSchemaConfigOutputMethod FromCustom(string value)
    {
        return new WebhookToolApiSchemaConfigOutputMethod(value);
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

    public static bool operator ==(WebhookToolApiSchemaConfigOutputMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookToolApiSchemaConfigOutputMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookToolApiSchemaConfigOutputMethod value) =>
        value.Value;

    public static explicit operator WebhookToolApiSchemaConfigOutputMethod(string value) =>
        new(value);

    internal class WebhookToolApiSchemaConfigOutputMethodSerializer
        : JsonConverter<WebhookToolApiSchemaConfigOutputMethod>
    {
        public override WebhookToolApiSchemaConfigOutputMethod Read(
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
            return new WebhookToolApiSchemaConfigOutputMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigOutputMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookToolApiSchemaConfigOutputMethod ReadAsPropertyName(
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
            return new WebhookToolApiSchemaConfigOutputMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigOutputMethod value,
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
        public const string Get = "GET";

        public const string Post = "POST";

        public const string Put = "PUT";

        public const string Patch = "PATCH";

        public const string Delete = "DELETE";
    }
}
