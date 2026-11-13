using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Content type for the request body. Only applies to POST/PUT/PATCH requests.</summary>
[JsonConverter(
    typeof(WebhookToolApiSchemaConfigOutputContentType.WebhookToolApiSchemaConfigOutputContentTypeSerializer)
)]
[Serializable]
public readonly record struct WebhookToolApiSchemaConfigOutputContentType : IStringEnum
{
    public static readonly WebhookToolApiSchemaConfigOutputContentType ApplicationJson = new(
        Values.ApplicationJson
    );

    public static readonly WebhookToolApiSchemaConfigOutputContentType ApplicationXWwwFormUrlencoded =
        new(Values.ApplicationXWwwFormUrlencoded);

    public WebhookToolApiSchemaConfigOutputContentType(string value)
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
    public static WebhookToolApiSchemaConfigOutputContentType FromCustom(string value)
    {
        return new WebhookToolApiSchemaConfigOutputContentType(value);
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
        WebhookToolApiSchemaConfigOutputContentType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WebhookToolApiSchemaConfigOutputContentType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(WebhookToolApiSchemaConfigOutputContentType value) =>
        value.Value;

    public static explicit operator WebhookToolApiSchemaConfigOutputContentType(string value) =>
        new(value);

    internal class WebhookToolApiSchemaConfigOutputContentTypeSerializer
        : JsonConverter<WebhookToolApiSchemaConfigOutputContentType>
    {
        public override WebhookToolApiSchemaConfigOutputContentType Read(
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
            return new WebhookToolApiSchemaConfigOutputContentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigOutputContentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookToolApiSchemaConfigOutputContentType ReadAsPropertyName(
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
            return new WebhookToolApiSchemaConfigOutputContentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookToolApiSchemaConfigOutputContentType value,
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
