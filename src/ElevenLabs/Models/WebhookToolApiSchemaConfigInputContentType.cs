using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Content type for the request body. Only applies to POST/PUT/PATCH requests.</summary>
[JsonConverter(
    typeof(WebhookToolApiSchemaConfigInputContentType.WebhookToolApiSchemaConfigInputContentTypeSerializer)
)]
[Serializable]
public readonly record struct WebhookToolApiSchemaConfigInputContentType : IStringEnum
{
    public static readonly WebhookToolApiSchemaConfigInputContentType ApplicationJson = new(
        Values.ApplicationJson
    );

    public static readonly WebhookToolApiSchemaConfigInputContentType ApplicationXWwwFormUrlencoded =
        new(Values.ApplicationXWwwFormUrlencoded);

    public WebhookToolApiSchemaConfigInputContentType(string value)
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
    public static WebhookToolApiSchemaConfigInputContentType FromCustom(string value)
    {
        return new WebhookToolApiSchemaConfigInputContentType(value);
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
        WebhookToolApiSchemaConfigInputContentType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WebhookToolApiSchemaConfigInputContentType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(WebhookToolApiSchemaConfigInputContentType value) =>
        value.Value;

    public static explicit operator WebhookToolApiSchemaConfigInputContentType(string value) =>
        new(value);

    internal class WebhookToolApiSchemaConfigInputContentTypeSerializer
        : JsonConverter<WebhookToolApiSchemaConfigInputContentType>
    {
        public override WebhookToolApiSchemaConfigInputContentType Read(
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
            return new WebhookToolApiSchemaConfigInputContentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigInputContentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookToolApiSchemaConfigInputContentType ReadAsPropertyName(
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
            return new WebhookToolApiSchemaConfigInputContentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigInputContentType value,
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
        public const string ApplicationJson = "application/json";

        public const string ApplicationXWwwFormUrlencoded = "application/x-www-form-urlencoded";
    }
}
