using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The HTTP method to use for the webhook</summary>
[JsonConverter(
    typeof(WebhookToolApiSchemaConfigInputMethod.WebhookToolApiSchemaConfigInputMethodSerializer)
)]
[Serializable]
public readonly record struct WebhookToolApiSchemaConfigInputMethod : IStringEnum
{
    public static readonly WebhookToolApiSchemaConfigInputMethod Get = new(Values.Get);

    public static readonly WebhookToolApiSchemaConfigInputMethod Post = new(Values.Post);

    public static readonly WebhookToolApiSchemaConfigInputMethod Put = new(Values.Put);

    public static readonly WebhookToolApiSchemaConfigInputMethod Patch = new(Values.Patch);

    public static readonly WebhookToolApiSchemaConfigInputMethod Delete = new(Values.Delete);

    public WebhookToolApiSchemaConfigInputMethod(string value)
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
    public static WebhookToolApiSchemaConfigInputMethod FromCustom(string value)
    {
        return new WebhookToolApiSchemaConfigInputMethod(value);
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

    public static bool operator ==(WebhookToolApiSchemaConfigInputMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookToolApiSchemaConfigInputMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookToolApiSchemaConfigInputMethod value) =>
        value.Value;

    public static explicit operator WebhookToolApiSchemaConfigInputMethod(string value) =>
        new(value);

    internal class WebhookToolApiSchemaConfigInputMethodSerializer
        : JsonConverter<WebhookToolApiSchemaConfigInputMethod>
    {
        public override WebhookToolApiSchemaConfigInputMethod Read(
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
            return new WebhookToolApiSchemaConfigInputMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigInputMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookToolApiSchemaConfigInputMethod ReadAsPropertyName(
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
            return new WebhookToolApiSchemaConfigInputMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigInputMethod value,
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
