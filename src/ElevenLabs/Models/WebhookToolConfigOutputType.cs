using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of tool</summary>
[JsonConverter(typeof(WebhookToolConfigOutputType.WebhookToolConfigOutputTypeSerializer))]
[Serializable]
public readonly record struct WebhookToolConfigOutputType : IStringEnum
{
    public static readonly WebhookToolConfigOutputType Webhook = new(Values.Webhook);

    public WebhookToolConfigOutputType(string value)
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
    public static WebhookToolConfigOutputType FromCustom(string value)
    {
        return new WebhookToolConfigOutputType(value);
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

    public static bool operator ==(WebhookToolConfigOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookToolConfigOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookToolConfigOutputType value) => value.Value;

    public static explicit operator WebhookToolConfigOutputType(string value) => new(value);

    internal class WebhookToolConfigOutputTypeSerializer
        : JsonConverter<WebhookToolConfigOutputType>
    {
        public override WebhookToolConfigOutputType Read(
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
            return new WebhookToolConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookToolConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookToolConfigOutputType ReadAsPropertyName(
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
            return new WebhookToolConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookToolConfigOutputType value,
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
    }
}
